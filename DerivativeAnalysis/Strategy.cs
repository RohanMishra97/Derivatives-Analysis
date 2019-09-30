using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DerivativeAnalysis
{
    public class Strategy
    {
        public ObservableCollection<OptionTrade> Option_Trades { get; set; }
        public ObservableCollection<FutureTrade> Future_Trades { get; set; }


        public Strategy()
        {

            this.Strategy_Id = -1;
            this.Strategy_Name = null;
            this.User_Id = -1;
            this.Symbol = null;
            this.Max_Profit = -1;
            this.Max_Loss = -1;
            this.Capt_Reqd = -1;
            this.Expiry_Date = null;
            this.Bep = null;
            this.Roi = -1;
            this.Currrent_Pl = 0;
            this.Future_Trades = new ObservableCollection<FutureTrade>();
            this.Option_Trades = new ObservableCollection<OptionTrade>();
            this.Sections = new List<Temp>()
            {
                 new Temp() { Name="Option trades", Items=this.Option_Trades},
                new Temp() { Name="Future trades", Items=this.Future_Trades}


            };
            this.Position = 0;
        }

        public Strategy(Int32 strategy_id, String strategy_name, Int32 user_id, String symbol, Decimal max_profit,
           Decimal max_loss, Decimal capital_reqd, String expiry_date, String bep, Decimal roi, Decimal curr_pl, Int32 position)
        {
            this.Strategy_Name = strategy_name;
            this.Strategy_Id = strategy_id;
            this.User_Id = user_id;
            this.Symbol = symbol;
            this.Max_Profit = max_profit;
            this.Max_Loss = max_loss;
            this.Capt_Reqd = capital_reqd;
            this.Expiry_Date = expiry_date;
            this.Bep = bep;
            this.Roi = roi;
            this.Currrent_Pl = curr_pl;
            this.Future_Trades = new ObservableCollection<FutureTrade>();
            this.Option_Trades = new ObservableCollection<OptionTrade>();
            this.Sections = new List<Temp>()
            {

                new Temp() { Name="Option Trades", Items=this.Option_Trades},
               new Temp() { Name="Future Trades", Items=this.Future_Trades}
            };
            this.Position = 0;
        }
        public List<Temp> Sections { get; set; }
        public String Strategy_Name { get; set; }
        public Int32 Strategy_Id { get; set; }
        public Int32 User_Id { get; set; }
        public String Symbol { get; set; }
        public Decimal Max_Profit { get; set; }
        public Decimal Max_Loss { get; set; }
        public Decimal Capt_Reqd { get; set; }
        public Decimal Currrent_Pl { get; set; }
        public String Bep { get; set; }
        public Decimal Roi { get; set; }
        public String Expiry_Date { get; set; }
        public Int32 Position { get; set; }
    }
}
