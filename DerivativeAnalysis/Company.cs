using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DerivativeAnalysis
{
    class Company
    {
        string symbol { get; set; }
        decimal value { get; set; }
        Int32 lot_size { get; set; }
        string sector { get; set; }

        public Company()
        {
            this.symbol = null;
            this.value = -1;
            this.lot_size = -1;
            this.sector = null;

        }
        public Company(string symbol, decimal value, Int32 lot_size, string sector)
        {
            this.symbol = symbol;
            this.value = value;
            this.lot_size = lot_size;
            this.sector = sector;
        }

        public override string ToString()
        {
            return string.Format("symbol : " + symbol + "value : " + value + " lot_size : " + lot_size + "sector : " + sector);
        }
    }
}
