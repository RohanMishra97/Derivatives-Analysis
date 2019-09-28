using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DerivativeAnalysis
{
    public class Futures
    {
        string future_id;
        public string Future_id
        {
            get { return future_id; }
            set { this.future_id = value; }
        }
        string symbol;
        public string Symbol
        {
            get { return symbol; }
            set { this.symbol = value; }
        }
        string expiry_date;
        public string Expiry_date
        {
            get { return expiry_date; }
            set { this.expiry_date = value; }
        }
        Decimal ltp;
        public Decimal Ltp
        {
            get { return ltp; }
            set { this.ltp = value; }
        }
        Int64 oi;
        public Int64 Oi
        {
            get { return oi; }
            set { this.oi = value; }
        }
        Int64 oi_change;
        public Int64 Oi_change
        {
            get { return oi_change; }
            set { this.oi_change = value; }
        }
        Int64 volume;
        public Int64 Volume
        {
            get { return volume; }
            set { this.volume = value; }
        }
        
        Decimal vwap;
        public Decimal Vwap
        {
            get { return vwap; }
            set { this.vwap = value; }
        }
        
        public Futures()
        {
            this.future_id = null;
            this.symbol = null;
            this.expiry_date = null;
            this.ltp = -1;
            this.oi = -1;
            this.oi_change = -1;
            this.volume = -1;
            this.vwap = -1;
        }

        public Futures(string future_id, string symbol, string expiry_date,
            Decimal ltp, Int64 oi, Int64 oi_change, Int64 volume, Decimal vwap)
        {
            this.future_id = future_id;
            this.symbol = symbol;
            this.expiry_date = expiry_date;
            this.ltp = ltp;
            this.oi = oi;
            this.oi_change = oi_change;
            this.volume = volume;
            this.vwap = vwap;
        }

        public override string ToString()
        {
            return string.Format("future_id : " + future_id + "symbol : " + symbol + "expiry_date : "
                + expiry_date + "ltp : " + ltp + "oi : " + oi + "oi_change : " + oi_change + "volume : "
                + volume + "vwap : " + vwap);
        }
    }
}
