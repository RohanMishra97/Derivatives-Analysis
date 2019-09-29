using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DerivativeAnalysis
{
    class Strategy
    {
        Boolean whether_portfolio;
        public Boolean Whether_portfolio
        { get { return whether_portfolio; } set { whether_portfolio = value; } }
        Boolean whether_MISC = false;
        public Boolean Whether_MISC
        { get { return whether_MISC; } set { whether_MISC = value; } }
        String strategy_name;
        public String Strategy_name
        { get { return strategy_name; } set { strategy_name = value; } }
        Int32 strategy_id;
        public Int32 Strategy_id
        { get { return strategy_id; } set { strategy_id = value; } }
        public FutureTrade[] fut_trades = new FutureTrade[100];
        public FutureTrade[] Fut_trades { get { return fut_trades; } set { fut_trades = value; } }
        public OptionTrade[] opt_trades = new OptionTrade[100];
        public OptionTrade[] Opt_trades { get { return opt_trades; } set { opt_trades = value; } }
        Int32 user_id;
        public Int32 User_id { get { return user_id; } set { user_id = value; } }
        String symbol;
        public String Symbol { get { return symbol; } set { symbol = value; } }
        Decimal max_profit;
        public Decimal Max_profit { get { return max_profit; } set { max_profit = value; } }
        Decimal max_loss;
        public Decimal Max_loss { get { return max_loss; } set { max_loss = value; } }
        Decimal capital_reqd;
        public Decimal Capital_reqd { get { return capital_reqd; } set { capital_reqd = value; } }
        Decimal current_pl;
        public Decimal Current_pl { get { return current_pl; } set { current_pl = value; } }
        String bep;
        public String Bep { get { return bep; } set { bep = value; } }
        Decimal delta;
        public Decimal Delta { get { return delta; } set { delta = value; } }
        Decimal theta;
        public Decimal Theta { get { return theta; } set { theta = value; } }
        Decimal vega;
        public Decimal Vega { get { return vega; } set { vega = value; } }
        Decimal gamma;
        public Decimal Gamma { get { return gamma; } set { gamma = value; } }
        String expiry_date;
        public String Expiry_date { get { return expiry_date; } set { expiry_date = value; } }
        
        public Strategy()
        {

            this.strategy_name = null;
            this.strategy_id = -1;
            this.user_id = -1;
            this.symbol = null;
            this.max_profit = -1;
            this.max_loss = -1;
            this.capital_reqd = -1;
            this.expiry_date = null;
            this.bep = null;
            this.delta = -1;
            this.theta = -1;
            this.vega = -1;
            this.gamma = -1;
            this.current_pl = 0;
            this.fut_trades = null;
            this.opt_trades = null;
        }

        public Strategy(String strategy_name, Int32 strategy_id, Int32 user_id, String symbol, Decimal max_profit,
            Decimal max_loss, Decimal capital_reqd, String expiry_date, String bep, Decimal delta, Decimal theta,
            Decimal vega, Decimal gamma, FutureTrade[] fut_trades, OptionTrade[] opt_trades, String buydate)
        {
            this.strategy_name = strategy_name;
            this.strategy_id = strategy_id;
            this.user_id = user_id;
            this.symbol = symbol;
            this.max_profit = max_profit;
            this.max_loss = max_loss;
            this.capital_reqd = capital_reqd;
            this.expiry_date = expiry_date;
            this.bep = bep;
            this.delta = delta;
            this.theta = theta;
            this.vega = vega;
            this.gamma = gamma;

            foreach (FutureTrade x in fut_trades)
            {
                x.Strategy_id = strategy_id;
                x.Buying_date = buydate;
            }
            this.fut_trades = fut_trades;


            foreach (OptionTrade x in opt_trades)
            {
                x.Strategy_id = strategy_id;
                x.Buying_date = buydate;
            }


            this.opt_trades = opt_trades;
        }
        
        public override string ToString()
        {
            return string.Format("Strategy_name : " + strategy_name + "strategy_id : " + strategy_id + "user_id : " + user_id + "symbol : "
                + symbol + "max_profit : " + max_profit + "max_loss : " + max_loss + "capital_reqd : "
                + capital_reqd + "expiry_date : " + expiry_date + "bep : " + bep + "delta : "
                + delta + "theta : " + theta + "vega : " + vega + "gamma : " + gamma);
        }
    }
}
