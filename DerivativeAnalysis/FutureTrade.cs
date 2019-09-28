using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DerivativeAnalysis
{
    class FutureTrade
    {
        string strategy_id;


        string future_id;
        Nullable<DateTime> buying_date;
        int num_lots { get; set; }
        Int64 margin_avail { get; set; }
        string symbol { get; set; }
        string trade_type { get; set; }
        decimal exercise_price { get; set; }

        public string Strategy_id
        { get { return strategy_id; } set { strategy_id = value; } }
        public string Future_id
        { get { return future_id; } set { future_id = value; } }
        public Nullable<DateTime> Buying_date
        { get { return buying_date; } set { buying_date = value; } }
        public int Num_lots
        { get { return num_lots; } set { num_lots = value; } }
        public long Margin_avail
        { get { return margin_avail; } set { margin_avail = value; } }
        public string Symbol
        { get { return symbol; } set { symbol = value; } }
        public string Trade_type
        { get { return trade_type; } set { trade_type = value; } }
        public decimal Exercise_price
        { get { return exercise_price; } set { exercise_price = value; } }
        public FutureTrade()
        {
            this.future_id = null;
            this.buying_date = null;
            this.num_lots = -1;
            this.margin_avail = -1;
            this.strategy_id = null;
            this.symbol = null;
            this.trade_type = null;
            this.exercise_price = -1;
        }
        public FutureTrade(string future_id, Nullable<DateTime> buying_date,
            int num_lots, Int64 margin_avail, string strategy_id, string symbol,
            string trade_type, decimal exercise_price, int ltp)
        {
            this.future_id = future_id;
            this.buying_date = DateTime.UtcNow.Date;
            this.num_lots = num_lots;
            this.margin_avail = (Int64)0.1 * ltp;
            this.strategy_id = null;
            this.symbol = symbol;
            this.trade_type = trade_type;
            this.exercise_price = exercise_price;


        }

        public override string ToString()
        {
            return string.Format("future_id : " + future_id + "buying_date : " + buying_date
                + "num_lots : " + num_lots + "margin_avail : " + margin_avail + "strategy_id : "
                + strategy_id + "symbol : " + symbol + "trade_type : " + trade_type + "exercise_price : "
                + exercise_price);
        }

    }
}
