from datetime import date
from nsepy import get_history
from nsepy.commons import *
import ast
import json
from nsepy.liveurls import quote_eq_url, quote_derivative_url, option_chain_url
from nsepy.derivatives import get_expiry_date
import requests, bs4
import glob, datetime, os, sys
import time
from datetime import datetime
import sqlalchemy
import pyodbc
import urllib
from sqlalchemy.sql import text as sa_text

symbols_stock = ['YESBANK','MARUTI','RELIANCE','BPCL','HDFC','SBIN','HDFCBANK','ICICIBANK','TATAMOTORS','BAJFINANCE','TATASTEEL','AXISBANK','TCS','TITAN','INFY','ITC','LT']
symbols_index = ['NIFTY']
sector_dict = {'YESBANK':'Banking','MARUTI':'Automobile','RELIANCE':'Energy','BPCL':'Energy','HDFC':'Financial Services','SBIN':'Banking','HDFCBANK':'Banking','ICICIBANK':'Banking','TATAMOTORS':'Automobile','BAJFINANCE':'Financial Services','TATASTEEL':'Metals','AXISBANK':'Banking','TCS':'Information Technology','TITAN':'Consumer Goods','INFY':'Information Technology','ITC':'Consumer Goods','LT':'Construction'}
month_list = [10, 11, 12]
expiries = [get_expiry_date(year=2019, month=k) for k in month_list]

eq_quote_referer = "https://www.nseindia.com/live_market/dynaContent/live_watch/get_quote/GetQuote.jsp?symbol={}&illiquid=0&smeFlag=0&itpFlag=0"
derivative_quote_referer = "https://www.nseindia.com/live_market/dynaContent/live_watch/get_quote/GetQuoteFO.jsp?underlying={}&instrument={}&expiry={}&type={}&strike={}"
option_chain_referer = "https://www.nseindia.com/live_market/dynaContent/live_watch/option_chain/optionKeys.jsp?symbolCode=-9999&symbol=NIFTY&symbol=BANKNIFTY&instrument=OPTIDX&date=-&segmentLink=17&segmentLink=17"

quoted = urllib.parse.quote_plus("DRIVER={SQL Server Native Client 11.0};SERVER=NKS\SQLEXPRESS;DATABASE=Derivative Analysis;Trusted_Connection=yes;")
engine = sqlalchemy.create_engine('mssql+pyodbc:///?odbc_connect={}'.format(quoted))

def refresh_table(df, table_name):
    df.to_sql(table_name, con = engine, if_exists = 'append', index=False)
    print ("Refreshed "+ table_name)

def get_quote(symbol, series='EQ', instrument=None, expiry=None, option_type=None, strike=None):
    """
    1. Underlying security (stock symbol or index name)
    2. instrument (FUTSTK, OPTSTK, FUTIDX, OPTIDX)
    3. expiry (ddMMMyyyy)
    4. type (CE/PE for options, - for futures
    5. strike (strike price upto two decimal places
    """

    if instrument:
        expiry_str = "%02d%s%d"%(expiry.day, months[expiry.month][0:3].upper(), expiry.year)
        #print (expiry_str)
        
        quote_derivative_url.session.headers.update({'Referer': eq_quote_referer.format(symbol)})
        strike_str = "{:.2f}".format(strike) if strike else "" 
        res = quote_derivative_url(symbol, instrument, expiry_str, option_type, strike_str)
    else:
        quote_eq_url.session.headers.update({'Referer': eq_quote_referer.format(symbol)})
        res = quote_eq_url(symbol, series)

    #print (res.url)
    d =  json.loads(res.text)['data'][0]
    #print (d)
    res = {}
    for k in d.keys():
        v = d[k]
        try:
            v_ = None
            if v.find('.') > 0:
                v_ = float(v.strip().replace(',', ''))
            else:
                v_ = int(v.strip().replace(',', ''))
        except:
            v_ = v
        if v_ == '-':
            v_ = 0
        res[k] = v_
    #print (res)
    return res

def get_option_chain(symbol, instrument=None, expiry=None):
        #print (symbol, expiry)
	if expiry:
		expiry_str = "%02d%s%d"%(expiry.day, months[expiry.month][0:3].upper(), expiry.year)
	else:
		expiry_str = "-"


	#print (expiry_str)


	req_url = "https://www.nseindia.com/live_market/dynaContent/live_watch/option_chain/optionKeys.jsp?segmentLink=17&symbol="+symbol+"&instrument="+instrument+"&date="+expiry_str
	option_chain_url.session.headers.update({'Referer': option_chain_referer})
	r = requests.get(url=req_url)

	#print (r.url)


	soup = bs4.BeautifulSoup(r.text, "html.parser")
	curr_px = soup.find("span").text.strip().split(" ")[-1]
	table = soup.find("table", {"id":"octable"})
	trs = table.find_all("tr")
	lines = []
	for tr in trs:
		tds = tr.find_all("th") + tr.find_all("td")
		fields = []
		if len(tds) == 23:
			if lines:
				fields = [x.text.strip().replace(",", "").replace("-", "") for x in tds[1:-1]] + [curr_px]
				#print (fields)
			else:
				fields = [x.text.strip().replace(",", "").replace("-", "") for x in tds[1:-1]] + ['CurrPx']
		lines.append(",".join(fields))

	#print (curr_px)
	trades = []
	call_keys = ['OI','Chng in OI','Volume','IV','LTP','Net Chng','BidQty','BidPrice','AskPrice','AskQty','Strike Price','Option Type','Symbol','Underlying Value','Market Lot']
	put_keys = ['Strike Price','BidQty','BidPrice','AskPrice','AskQty','Net Chng','LTP','IV','Volume','Chng in OI','OI','Symbol','Underlying Value','Market Lot']
	for i in range(2, len(lines)-1):
		fields = lines[i].split(',')
		#print(fields)
		#print ("For strike price - "+ fields[10])
		trade = {}
		for j in range(11):
			if fields[j] == '':
				trade[call_keys[j]] = 0
			else:
				trade[call_keys[j]] = float(fields[j])
		trade['Option Type'] = 'CE'
		trade['Symbol'] = symbol
		#trade['Underlying Value'] = curr_px
		#trade['Market Lot'] = lot_dict[symbol]
		trade['Expiry Date'] = expiry
		#print (trade)
		trades.append(trade)
		trade = {}
		for j in range(10,len(fields)-1):
			if fields[j] == '':
				trade[put_keys[j-10]] = 0
			else:
				trade[put_keys[j-10]] = float(fields[j])
		trade['Option Type'] = 'PE'
		trade['Symbol'] = symbol
		#trade['Underlying Value'] = curr_px
		#trade['Market Lot'] = lot_dict[symbol]
		trade['Expiry Date'] = expiry
		trades.append(trade)
	return trades
	
def get_company_data():
	start_time = time.time()
	company_table = []
	for symbol in symbols_stock:
		c = {}
		quote = get_quote(symbol=symbol, series='EQ', instrument="FUTSTK", expiry=expiries[0])
		c['symbol'] = symbol
		c['value'] = quote['underlyingValue']
		c['lot_size'] = quote['marketLot']
		c['sector'] = sector_dict[symbol]
		company_table.append(c)

	for symbol in symbols_index:
		c = {}
		quote = get_quote(symbol=symbol, series='EQ', instrument="FUTIDX", expiry=expiries[0])
		c['symbol'] = symbol
		c['value'] = quote['underlyingValue']
		c['lot_size'] = quote['marketLot']
		c['sector'] = 'Index'
		company_table.append(c)
	df = pd.DataFrame(company_table)
	print (time.time() - start_time)
	return df
	#df.to_csv("Company Table.csv", index=False)
	#refresh_table(df, "Company")
	


def get_futures_data():
	keys = ['underlying','lastPrice','openInterest','changeinOpenInterest','numberOfContractsTraded','vwap']
	start_time = time.time()
	futures_table = []
	for sym in symbols_stock:
		print (sym)
		for exp_dt in expiries:
			trades = get_quote(symbol=sym,series='EQ', instrument="FUTSTK", expiry=exp_dt, option_type=None, strike=None)
			trades = { key: trades[key] for key in keys }
			trades['expiryDate'] = exp_dt
			futures_table.append(trades)
	for sym in symbols_index:
		print (sym)
		for exp_dt in expiries:
			#print (sym, exp_dt)
			trades = get_quote(symbol=sym,series='EQ', instrument="FUTIDX", expiry=exp_dt, option_type=None, strike=None)
			trades = { key: trades[key] for key in keys }
			trades['expiryDate'] = exp_dt
			futures_table.append(trades)

	df = pd.DataFrame(futures_table)
	def f(x):
		return x[0] + "_" + x[1] + "_fut"
	df['expiryDate'] = df['expiryDate'].apply(lambda x: x.strftime("%Y-%m-%d"))
	df['future_id'] = df[['underlying','expiryDate']].apply(f,axis=1)
	df.columns = ['symbol','ltp','oi','oi_change','volume','vwap','expiry_date','future_id']
	df = df[['future_id','symbol','expiry_date','ltp','oi','oi_change','volume','vwap']]
	print (time.time() - start_time)
	return df
    #refresh_table(df,"Futures")
    #df.to_csv('Futures Table.csv', index=False)
    #print (time.time() - start_time)
	
def get_options_data():
	start_time = time.time()
	option_table = []
	for sym in symbols_stock:
		print (sym)
		for exp_dt in expiries:
			#print (sym, exp_dt)
			trades = get_option_chain(sym,"OPTSTK",exp_dt)
			option_table = option_table + trades
			#option_table.append(trades)
	for sym in symbols_index:
		print (sym)
		for exp_dt in expiries:
			#print (sym, exp_dt)
			trades = get_option_chain(sym,"OPTIDX",exp_dt)
			option_table = option_table + trades
			#option_table.append(trades)
	df = pd.DataFrame(option_table)
	df['Expiry Date'] = df['Expiry Date'].apply(lambda x: x.strftime("%Y-%m-%d"))
	del df['BidQty']
	del df['BidPrice']
	del df['AskPrice']
	del df['AskQty']
	df.columns = ['oi','oi_change','volume','iv','ltp','p_change','strike_price','op_type','symbol','expiry_date']
	def f(x):
		return x[0] + "_" + x[1] + "_" + str(int(x[2])) + "_"+ x[3]+"_opt"
	df['option_id'] = df[['symbol','expiry_date','strike_price','op_type']].apply(f,axis=1)
	df = df[['option_id','symbol','expiry_date','ltp','oi','oi_change','volume','op_type','p_change','strike_price','iv']]
	df['volume'] = df['volume'].astype(int)
	df['oi'] = df['oi'].astype(int)
	df['oi_change'] = df['oi_change'].astype(int)
	print (time.time() - start_time)
	return df
	#df.to_csv('Options Table.csv', index=False)
	#refresh_table(df, "Options")

while(True):
	try:
		company_data = get_company_data()
		tbl_name = "Company"
		sql_query = """
		-- Delete all records
		DELETE FROM ["""+tbl_name+"""]
		DBCC CHECKIDENT (["""+tbl_name+"""], RESEED, 0)
		"""
		engine.execute(sa_text(sql_query).execution_options(autocommit=True))
		refresh_table(company_data, tbl_name)
	except e:
		print (e)
		print ("Could not get Company Data")
	try:
		futures_data = get_futures_data()
		tbl_name = "Futures"
		sql_query = """
		DELETE FROM ["""+tbl_name+"""]
		DBCC CHECKIDENT (["""+tbl_name+"""], RESEED, 0)
		"""
		engine.execute(sa_text(sql_query).execution_options(autocommit=True))
		refresh_table(futures_data, tbl_name)
	except e:
		print (e)
		print ("Could not get Futures Data")
	try:
		options_data = get_options_data()
		tbl_name = "Options"
		sql_query = """
		DELETE FROM ["""+tbl_name+"""]
		DBCC CHECKIDENT (["""+tbl_name+"""], RESEED, 0)
		"""
		engine.execute(sa_text(sql_query).execution_options(autocommit=True))
		refresh_table(options_data, tbl_name)
	except e:
		print (e)
		print ("Could not get Options Data")
	print ("Last Updated on " + datetime.strftime(datetime.now(),"%H:%M")) 
	time.sleep(30)