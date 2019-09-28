using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DerivativeAnalysis
{
    public class Options
    {
        string option_id;
        public string Option_id
        { get { return option_id; }
         set { this.option_id = value; }
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
        { get { return oi_change; }
            set { this.oi_change = value; }
        }
        Int64 volume;
        public Int64 Volume
        {
            get { return volume; }
            set { this.volume = value; }
        }
        string op_type;
        public string Op_type
        {   get { return op_type; }
            set { this.op_type = value; }
        }
        Decimal p_change;
        public Decimal P_change
        { get { return p_change; }
          set { this.p_change = value; }
        }
        Decimal strike_price;
        public Decimal Strike_price
        {
            get { return strike_price; }
            set { this.strike_price = value; }
        }
        Decimal iv; 
        public Decimal Iv
        {
            get { return iv; }
            set { this.iv = value; }
        }

        public Options()
        {
            this.option_id = null;
            this.symbol = null;
            this.expiry_date = null;
            this.ltp = -1;
            this.oi = -1;
            this.oi_change = -1;
            this.volume = -1;
            this.op_type = null;
            this.p_change = -1;
            this.strike_price = -1;
            this.iv = -1;
        }
        public Options(string id, string sym, string expdate, Decimal ltp, Int64 oi, Int64 oichange, Int64 vol, string op_type, Decimal p_change, Decimal strikeprice, Decimal iv)
        {
            this.option_id = id;
            this.symbol = sym;
            this.expiry_date = expdate;
            this.ltp = ltp;
            this.oi = oi;
            this.oi_change = oi_change;
            this.volume = vol;
            this.op_type = op_type;
            this.p_change = p_change;
            this.strike_price = strikeprice;
            this.iv = iv;
        }

        public override string ToString()
        {
            return string.Format("option_id {0}, symbol {1} expiry_date {2}, ltp {3}, oi {4}, oi_change {5}, volume {6},op_type {7}, p_change {8}, strike_price {9}, iv {10} \n", option_id, symbol, expiry_date, ltp, oi, oi_change, volume, op_type, p_change, strike_price, iv);
        }
    }
}
