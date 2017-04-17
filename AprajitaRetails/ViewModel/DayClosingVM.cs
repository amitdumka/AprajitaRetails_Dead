using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AprajitaRetails.Data;

namespace AprajitaRetails.ViewModel
{
    class DayClosingVM
    {
        DayClosingDB DB;
        public DayClosingVM()
        {
            DB = new DayClosingDB ();
        }
        public int SaveData(DayClosing dayClosing)
        {
            return DB.InsertData (dayClosing);

        }

    }

    class DayClosingDB : DataOps<DayClosing>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="days"></param>
        /// <returns></returns>
        public override int InsertData(DayClosing days)
        {
            SqlCommand cmd = new SqlCommand (InsertSqlQuery, Db.DBCon);
            cmd.Parameters.AddWithValue ("@OnDate", days.OnDate);
            cmd.Parameters.AddWithValue ("@TotalAmount", days.TotalAmount);
            cmd.Parameters.AddWithValue ("@Coin5", days.Coin5);
            cmd.Parameters.AddWithValue ("@Coin2", days.Coin2);
            cmd.Parameters.AddWithValue ("@Coin10", days.Coin10);
            cmd.Parameters.AddWithValue ("@Coin1", days.Coin1);
            cmd.Parameters.AddWithValue ("@C500", days.C500);
            cmd.Parameters.AddWithValue ("@C50", days.C50);
            cmd.Parameters.AddWithValue ("@C5", days.C5);
            cmd.Parameters.AddWithValue ("@C2000", days.C2000);
            cmd.Parameters.AddWithValue ("@C20", days.C20);
            cmd.Parameters.AddWithValue ("@C1000", days.C1000);
            cmd.Parameters.AddWithValue ("@C100", days.C100);
            cmd.Parameters.AddWithValue ("@C10", days.C10);
            return cmd.ExecuteNonQuery ();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public override DayClosing ResultToObject(List<DayClosing> data, int index)
        {
            return data [index];
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="rootEle"></param>
        /// <returns></returns>
        public override DayClosing ResultToObject(SortedDictionary<string, string> rootEle)
        {
            DayClosing ele = new DayClosing ()
            {
                C10 = Int32.Parse (rootEle ["C10"]),
                C100 = Int32.Parse (rootEle ["C100"]),
                C1000 = Int32.Parse (rootEle ["C1000"]),
                C20 = Int32.Parse (rootEle ["C20"]),
                C2000 = Int32.Parse (rootEle ["C2000"]),
                C5 = Int32.Parse (rootEle ["C5"]),
                C50 = Int32.Parse (rootEle ["C50"]),
                C500 = Int32.Parse (rootEle ["C500"]),
                Coin1 = Int32.Parse (rootEle ["Coin1"]),
                Coin2 = Int32.Parse (rootEle ["Coin2"]),
                Coin10 = Int32.Parse (rootEle ["Coin10"]),
                Coin5 = Int32.Parse (rootEle ["Coin5"]),
                OnDate = DateTime.Parse (rootEle ["OnDate"]),
                ID = Int32.Parse (rootEle ["ID"]),
                TotalAmount = Int32.Parse (rootEle ["TotalAmount"])
            };
            return ele;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public override List<DayClosing> ResultToObject(List<SortedDictionary<string, string>> data)
        {
            List<DayClosing> rootList = new List<DayClosing> ();
            DayClosing ele;
            foreach ( SortedDictionary<string, string> rootEle in data )
            {
                ele = new DayClosing ()
                {
                    C10 = Int32.Parse (rootEle ["C10"]),
                    C100 = Int32.Parse (rootEle ["C100"]),
                    C1000 = Int32.Parse (rootEle ["C1000"]),
                    C20 = Int32.Parse (rootEle ["C20"]),
                    C2000 = Int32.Parse (rootEle ["C2000"]),
                    C5 = Int32.Parse (rootEle ["C5"]),
                    C50 = Int32.Parse (rootEle ["C50"]),
                    C500 = Int32.Parse (rootEle ["C500"]),
                    Coin1 = Int32.Parse (rootEle ["Coin1"]),
                    Coin2 = Int32.Parse (rootEle ["Coin2"]),
                    Coin10 = Int32.Parse (rootEle ["Coin10"]),
                    Coin5 = Int32.Parse (rootEle ["Coin5"]),
                    OnDate = DateTime.Parse (rootEle ["OnDate"]),
                    ID = Int32.Parse (rootEle ["ID"]),
                    TotalAmount = Int32.Parse (rootEle ["TotalAmount"])
                };
                rootList.Add (ele);

            }
            return rootList;
        }
    }

    class DayEndDetailsDB : DataOps<DayEndDetails>
    {
        public override int InsertData(DayEndDetails obj)
        {
            throw new NotImplementedException ();
        }

        public override DayEndDetails ResultToObject(List<DayEndDetails> data, int index)
        {
            throw new NotImplementedException ();
        }

        public override DayEndDetails ResultToObject(SortedDictionary<string, string> data)
        {
            throw new NotImplementedException ();
        }

        public override List<DayEndDetails> ResultToObject(List<SortedDictionary<string, string>> data)
        {
            throw new NotImplementedException ();
        }
    }

    sealed class DayEndOps : DayEndDetailsDB
    {
        SqlConnection con;
        DayEndDetails dayEnd;
        public DayEndOps()
        {
            con = Db.DBCon;
            dayEnd = new DayEndDetails ();
        }
        
        void SaleData()
        {
                                                  
            //Total Sale, Total RMZ, Fabric, tailoring,
            //total card sale , debit card , credit card
            //total accessor sale
            //
        }
        void TailoringData()
        {
            //total tailoringg booking deliver no with amount

        }

        void ExpensesAndBank()
        {

        }

        void CashDetails()
        {

        }


    }

}
