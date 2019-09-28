using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DerivativeAnalysis
{
    class Strategy
    {
        Boolean whether_portfolio = false;
        Boolean whether_MISC = false;
        string strategy_name;
        string strategy_id;
        public FutureTrade[] fut_trades = new FutureTrade[100];
        public OptionTrade[] opt_trades = new OptionTrade[100];
        string user_id;
        string symbol;
        float max_profit;
        float max_loss;
        float capital_reqd;
        float current_pl;
        string bep;
        float delta;
        float theta;
        float vega;
        float gamma;
        Nullable<DateTime> expiry_date;

        public FutureTrade[] get_fut_trades() { return fut_trades; }
        public void set_fut_trades(FutureTrade[] objarr) { this.fut_trades = objarr; }

        public OptionTrade[] get_opt_trades() { return opt_trades; }
        public void set_opt_trades(OptionTrade[] objarr) { this.opt_trades = objarr; }

        public string get_strategy_name() { return strategy_name; }
        public string get_strategy_id() { return strategy_id; }
        public Boolean get_whether_MISC() { return whether_MISC; }
        public void set_whether_MISC(Boolean whether_MISC) { this.whether_MISC = whether_MISC; }
        public void set_symbol(string symbol) { this.symbol = symbol; }
        public void set_strategy_name(string strategy_name) { this.strategy_name = strategy_name; }
        public void set_strategy_id(string strategy_id) { this.strategy_id = strategy_id; }
        public void set_user_id(string user_id) { this.user_id = user_id; }
        public void set_max_profit(float max_profit) { this.max_profit = max_profit; }
        public void set_max_loss(float max_loss) { this.max_loss = max_loss; }
        public void set_capital_reqd(float capital_reqd) { this.capital_reqd = capital_reqd; }
        public void set_bep(string bep) { this.bep = bep; }
        public void set_delta(float delta) { this.delta = delta; }
        public void set_theta(float theta) { this.theta = theta; }
        public void set_vega(float vega) { this.vega = vega; }
        public void set_gamma(float gamma) { this.gamma = gamma; }
        public void set_expiry_date(Nullable<DateTime> exp_date) { this.expiry_date = exp_date; }
        public Strategy()
        {

            this.strategy_name = null;
            this.strategy_id = null;
            this.user_id = null;
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

        public Strategy(string strategy_name, string strategy_id, string user_id, string symbol, float max_profit,
            float max_loss, float capital_reqd, Nullable<DateTime> expiry_date, string bep, float delta, float theta,
            float vega, float gamma, FutureTrade[] fut_trades, OptionTrade[] opt_trades, Nullable<DateTime> buydate)
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
