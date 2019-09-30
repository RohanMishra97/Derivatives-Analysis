import sys
import time
import sqlalchemy
import pyodbc
import urllib
from sqlalchemy.sql import text as sa_text
import quantsbin.derivativepricing as qbdp
import json
import time
from datetime import datetime
import numpy as np
import matplotlib.pyplot as plt
import seaborn
import pandas as pd

quoted = urllib.parse.quote_plus("DRIVER={SQL Server Native Client 11.0};SERVER=NKS\SQLEXPRESS;DATABASE=Derivative Analysis;Trusted_Connection=yes;")
engine = sqlalchemy.create_engine('mssql+pyodbc:///?odbc_connect={}'.format(quoted))
connection = engine.connect()

strategy_id = int(sys.argv[1])

df = pd.read_sql_query("SELECT * FROM Strategy WHERE strategy_id = "+str(strategy_id), connection)
fut_trades = pd.read_sql_query("SELECT * FROM FutureTrade WHERE strategy_id = "+ str(strategy_id), connection)
opt_trades = pd.read_sql_query("SELECT * FROM OptionTrade WHERE strategy_id = "+ str(strategy_id), connection)

trades = []
symbol = "HELLO"
opt_trades = pd.read_sql_query("SELECT * FROM OptionTrade WHERE strategy_id = "+ str(strategy_id), connection)
for curr, row in fut_trades.iterrows():
    obj = {}
    obj['future_id'] = row['future_id']
    obj['buying_date'] = row['buying_date']
    obj['num_lots'] = row['num_lots']
    obj['trade_type'] = row['trade_type']
    obj['price'] = row['exercise_price']
    obj['margin'] = row['margin_avail']
    obj['op_type'] = 'FUT'
    trades.append(obj)

opt_trades = pd.read_sql_query("SELECT * FROM OptionTrade WHERE strategy_id = "+ str(strategy_id), connection)
for curr, row in opt_trades.iterrows():
    obj = {}
    obj['option_id'] = row['option_id']
    obj['buying_date'] = row['buying_date']
    obj['num_lots'] = row['num_lots']
    obj['trade_type'] = row['trade_type']
    symbol = row['option_id'].split("_")[0]
    expiry_date = row['option_id'].split("_")[1]
    obj['price'] = int(row['option_id'].split("_")[2])
    obj['premium'] = row['premium']
    obj['op_type'] = row['option_id'].split("_")[3]
    trades.append(obj)
#print(trades)
#print(symbol, expiry_date)

company = pd.read_sql_query("SELECT * FROM Company WHERE symbol = '"+ symbol +"'", connection)

lot_size = company['lot_size'].values[0]
spot_price = company['value'].values[0]
#expiry_date = "2019-10-31"
expiry_dt = datetime.strptime(expiry_date,"%Y-%m-%d")

scale = 100.0/spot_price
epsilon = 30

#Scaling
spot_price = spot_price * scale
for trade in trades:
    if trade['op_type'] != 'FUT':
        trade['premium'] = trade['premium'] * scale
    trade['price'] = trade['price'] * scale
s_p = [obj['price'] for obj in trades]
min_sp = min(s_p)
max_sp = max(s_p)
l = min_sp - 3*epsilon
#l = max(min_sp - 3*epsilon,0)
r = max_sp + 3*epsilon

#print (spot_price)
#print (trades)
#print (min_sp, max_sp)
#print (l,r)

def get_capital_reqd(trades):
    res = 0.0
    for trade in trades:
        if trade['op_type'] == 'FUT':
            #print ("Future Margin : ", trade['margin']*trade['num_lots']*lot_size)
            res = res + trade['margin']*trade['num_lots']*lot_size
        else:
            if trade['trade_type'] == 'long':
                #print ("Long Premium : ", trade['premium']*trade['num_lots']*lot_size)
                res = res + trade['premium']*trade['num_lots']*lot_size
            else:
                #print ("Short Premium : -", trade['premium']*trade['num_lots']*lot_size)
                res = res - trade['premium']*trade['num_lots']*lot_size
    #print (res)
    #rescale
    return round(res,2) 
	
def get_greeks(trades):
    lots = []
    op_objects = []
    for trade in trades:
        if trade['op_type'] == 'CE':
            op_objects.append(qbdp.EqOption(option_type='Call', strike=trade['price']/scale,expiry_date=datetime.strftime(expiry_dt,"%Y%m%d"),expiry_type='European'))
            lots.append(trade['num_lots'])
        elif trade['op_type'] == 'PE':
            op_objects.append(qbdp.EqOption(option_type='Put', strike=trade['price']/scale,expiry_date=datetime.strftime(expiry_dt,"%Y%m%d"),expiry_type='European'))
            lots.append(trade['num_lots'])
        else:
            time.sleep(0.01)
            #print ("Future")
    
    custom_option = [(op_objects[i],lots[i]) for i in range(len(lots))]
    custom_stgy1 = qbdp.OptionStr1Udl(option_portfolio=custom_option)
    eq1_engine = custom_stgy1.engine(model='BSM',pricing_date=datetime.strftime(datetime.now(),"%Y%m%d"),spot0=spot_price, rf_rate=3.68, volatility=0.25)
    #print(eq1_engine.risk_parameters())
    greeks = eq1_engine.risk_parameters()
    return greeks['delta'],greeks['theta'],greeks['vega'],greeks['gamma']
	
def payoff(trade):
    strike_price = trade['price']
    op_type = trade['op_type']
    if op_type != 'FUT':
        premium = trade['premium']
    tr_type = trade['trade_type']
    if op_type == 'CE':
        if tr_type == 'long':
            return {x : round(trade['num_lots']*(max(x-strike_price,0)-premium),4) for x in spot_range}
        else:
            return {x : round(trade['num_lots']*(-1.0 * (max(x-strike_price,0)-premium)),4) for x in spot_range}
    elif op_type == 'PE':
        if tr_type == 'long':
            return {x : round(trade['num_lots']*(max(strike_price-x,0)-premium),4) for x in spot_range}
        else:
            return {x : round(trade['num_lots']*(-1.0 * (max(strike_price-x,0)-premium)),4) for x in spot_range}
    else:
        if tr_type == 'long':
            return {x : round(trade['num_lots']* (x-strike_price),4) for x in spot_range}
        else:
            return {x : round(trade['num_lots']*(strike_price-x),4) for x in spot_range}
			
def payoff0(trade):
    strike_price = trade['price']
    op_type = trade['op_type']
    if op_type != 'FUT':
        premium = trade['premium']
    tr_type = trade['trade_type']
    if op_type == 'CE':
        if tr_type == 'long':
            return premium
            #return {x : round(max(x-strike_price,0)-premium,4) for x in spot_range}
        else:
            return -premium
            #return {x : round(-1.0 * (max(x-strike_price,0)-premium),4) for x in spot_range}
    elif op_type == 'PE':
        if tr_type == 'long':
            return strike_price - premium
            #return {x : round(max(strike_price-x,0)-premium,4) for x in spot_range}
        else:
            return premium - strike_price
            #return {x : round(-1.0 * (max(strike_price-x,0)-premium),4) for x in spot_range}
    else:
        if tr_type == 'long':
            return strike_price
            #return {x : round(x-strike_price,4) for x in spot_range}
        else:
            return -1.0*strike_price
            #return {x : round(strike_price-x,4) for x in spot_range}
			
spot_range = np.arange(l,r,0.01)

p_l = payoff(trades[0])
pl_0 = payoff0(trades[0])
pl_0/scale

def get_plot(p_l, l,r):
    lists = sorted(p_l.items())
    x, y = zip(*lists)
    x = [k for k in x if k >= l and k <= r]
    y = [p_l[k]/scale for k in x]
    x = [k/scale for k in x if k >= l and k <= r]
    plt.plot(x,y)
    plt.show()
    return plt
	
def get_breakeven(p_l):
    #print ("Break Even Points: ")
    pts = []
    sign = p_l[l] > 0
    for k,v in p_l.items():
        if sign == True and v < 0:
            pts.append(k)
            sign = False
            #sign = !
        if sign == False and v > 0:
            pts.append(k)
            sign = True
        if v==0:
            pts.append(k)
            #print (k)
    pts = [str(round(x/scale,2)) for x in pts]
    return ",".join(pts)
	
def get_max_pl(p_l, p_l0):
    lev = p_l0
    spots = list(p_l.keys())
    red = round(p_l[spots[-1]] - p_l[spots[-2]],2)
    #print (red)
    rev = p_l[spots[-2]]
    
    #print (led, lev, red, rev)
    rc = rev
    if red > 0:
        #print ("red>0")
        rc = np.inf
        max_p = rc
        max_l = min(p_l.values())
    elif red < 0:
        #print ("red<0")
        rc = -np.inf
        max_l = rc
        max_p = max(p_l.values())
    else:
        #print ("red=0")
        #print (rev/scale,lev/scale)
        max_p = max(rev/scale, lev/scale)
        max_l = min(rev, lev)

    #print ("Maximum Profit: ", max_p*lot_size)
    #print ("Maximum Loss: ", max_l*lot_size)
    return max_p*lot_size, max_l*lot_size

def get_curr_pl(pl):
    for k,v in pl.items():
        if k>=100.0:
            return round(v/scale,2)
	
def combine_payoffs(p_ls):
    res_pl = {}
    for x in spot_range:
        res_pl[x] = sum(k[x] for k in p_ls)
    return res_pl
	
payoffs = [payoff(trade) for trade in trades]
payoffs_0 = [payoff0(trade) for trade in trades]
plc = combine_payoffs(payoffs)
plc_0 = sum(payoffs_0)

max_p,max_l = get_max_pl(plc,plc_0)
if max_p == np.inf:
    max_p = -1
if max_l == -np.inf:
    max_l = 1
#print (max_p, max_l)

def print_payoff(pl):
	x = []
	y = []
	i=0
	for k,v in pl.items():
		if i%100 == 0:
			x.append(str(round(k/scale, 2)));
			y.append(str(round(v/scale,2)));
		i = i+1
	x = ", ".join(x);
	y = ", ".join(y);
	with open(str(strategy_id)+"_x.txt", "w") as f:
		f.write(x)
	with open(str(strategy_id)+"_y.txt",'w') as f:
		f.write(y)

bep = get_breakeven(plc)
#print (bep)

capt = get_capital_reqd(trades)
curr_pl = get_curr_pl(plc)
roi = round(curr_pl/capt * (12),2)
print_payoff(plc)
#delta,theta,vega,gamma = get_greeks(trades)
#print(delta, theta, vega, gamma)

query = '''
            UPDATE Strategy
            SET symbol = \''''+symbol+'''\'
            , expiry_date = \''''+expiry_date+'''\'
            , max_profit = '''+str(max_p)+'''
            , max_loss = '''+str(max_l)+'''
            , bep = \''''+str(bep)+'''\'
            , capital_reqd = '''+str(capt)+'''
            , curr_pl = '''+str(curr_pl)+'''
            , roi = '''+str(roi)+'''
             WHERE strategy_id = '''+str(strategy_id)
    
print (query)

connection.execute(query)
