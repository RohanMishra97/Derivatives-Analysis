using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DerivativeAnalysis
{
    public class FutureTrade
    {
        Int32 strategy_id;
        Int32 fut_trade_id;
        String future_id;
        String buying_date;
        Int32 num_lots { get; set; }
        Int64 margin_avail { get; set; }
        String symbol { get; set; }
        String trade_type { get; set; }
        Decimal exercise_price { get; set; }

        public Int32 Fut_trade_id { get { return fut_trade_id; } set { fut_trade_id = value; } }
        public Int32 Strategy_id
        { get { return strategy_id; } set { strategy_id = value; } }
        public String Future_id
        { get { return future_id; } set { future_id = value; } }
        public String Buying_date
        { get { return buying_date; } set { buying_date = value; } }
        public Int32 Num_lots
        { get { return num_lots; } set { num_lots = value; } }
        public Int64 Margin_avail
        { get { return margin_avail; } set { margin_avail = value; } }
        public String Symbol
        { get { return symbol; } set { symbol = value; } }
        public String Trade_type
        { get { return trade_type; } set { trade_type = value; } }
        public Decimal Exercise_price
        { get { return exercise_price; } set { exercise_price = value; } }
        public FutureTrade()
        {
            this.future_id = null;
            this.buying_date = null;
            this.num_lots = -1;
            this.margin_avail = -1;
            this.strategy_id = -1;
            this.symbol = null;
            this.trade_type = null;
            this.exercise_price = -1;
        }
        public FutureTrade(String future_id, Int32 num_lots, Int64 margin_avail, Int32 strategy_id, String symbol,
            String trade_type, Decimal exercise_price, Int32 ltp)
        {
            this.future_id = future_id;
            this.buying_date = DateTime.Now.ToString("dd/M/yyyy"); 
            this.num_lots = num_lots;
            this.margin_avail = (Int64)0.1 * ltp;
            this.strategy_id = -1;
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
