﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DerivativeAnalysis
{
    class OptionTrade
    {
        string option_id;
        Nullable<DateTime> buying_date;
        int num_lots;
        decimal premium;
        string strategy_id { get; set; }
        string symbol { get; set; }
        string trade_type { get; set; }

        public string Option_id
        { get { return option_id; } set { option_id = value; } }

        public Nullable<DateTime> Buying_date
        { get { return buying_date; } set { buying_date = value; } }

        public int Num_lots
        { get { return num_lots; } set { num_lots = value; } }
        public decimal Premium
        { get { return premium; } set { premium = value; } }

        public string Strategy_id
        { get { return strategy_id; } set { strategy_id = value; } }

        public string Symbol
        { get { return symbol; } set { symbol = value; } }

        public string Trade_type
        { get { return trade_type; } set { trade_type = value; } }

        public OptionTrade()
        {
            this.option_id = null;
            this.buying_date = null;
            this.num_lots = -1;
            this.premium = -1;
            this.strategy_id = null;
            this.symbol = null;
            this.trade_type = null;
        }
        public OptionTrade(string id, Nullable<DateTime> buydate, int lots, decimal premium,
            string stratid, string sym, string tradetype)
        {
            this.option_id = id;
            this.buying_date = buydate;
            this.num_lots = lots;
            this.premium = premium;
            this.strategy_id = stratid;
            this.symbol = sym;
            this.trade_type = tradetype;
        }

        public override string ToString()
        {
            return string.Format("option_id {0}, buying_date {1}, num_lots {2}, premium {3}, strategy_id {4}, symbol {5}, trade_type {6} \n", option_id, buying_date, num_lots, premium, strategy_id, symbol, trade_type);
        }
    }
}
