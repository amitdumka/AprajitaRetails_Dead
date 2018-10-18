using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using AprajitaRetailsDataBase.SqlDataBase.Data;

namespace AprajitaRetailsDataBase.SqlDataBase.ViewModel
{
    internal class DayClosingDB : DataOps<DayClosing>
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="days"></param>
        /// <returns></returns>
        public override int InsertData( DayClosing days )
        {
            SqlCommand cmd = new SqlCommand(InsertSqlQuery, Db.DBCon);
            cmd.Parameters.AddWithValue("@OnDate", days.OnDate);
            cmd.Parameters.AddWithValue("@TotalAmount", days.TotalAmount);
            cmd.Parameters.AddWithValue("@Coin5", days.Coin5);
            cmd.Parameters.AddWithValue("@Coin2", days.Coin2);
            cmd.Parameters.AddWithValue("@Coin10", days.Coin10);
            cmd.Parameters.AddWithValue("@Coin1", days.Coin1);
            cmd.Parameters.AddWithValue("@C500", days.C500);
            cmd.Parameters.AddWithValue("@C50", days.C50);
            cmd.Parameters.AddWithValue("@C5", days.C5);

            cmd.Parameters.AddWithValue("@C200", days.C200);
            cmd.Parameters.AddWithValue("@C2000", days.C2000);
            cmd.Parameters.AddWithValue("@C20", days.C20);
            cmd.Parameters.AddWithValue("@C1000", days.C1000);
            cmd.Parameters.AddWithValue("@C100", days.C100);
            cmd.Parameters.AddWithValue("@C10", days.C10);
            return cmd.ExecuteNonQuery();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="data"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public override DayClosing ResultToObject( List<DayClosing> data, int index )
        {
            return data[index];
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="rootEle"></param>
        /// <returns></returns>
        public override DayClosing ResultToObject( SortedDictionary<string, string> rootEle )
        {
            DayClosing ele = new DayClosing()
            {
                C200 = Int32.Parse(rootEle["C200"]),

                C10 = Int32.Parse(rootEle["C10"]),
                C100 = Int32.Parse(rootEle["C100"]),
                C1000 = Int32.Parse(rootEle["C1000"]),
                C20 = Int32.Parse(rootEle["C20"]),
                C2000 = Int32.Parse(rootEle["C2000"]),
                C5 = Int32.Parse(rootEle["C5"]),
                C50 = Int32.Parse(rootEle["C50"]),
                C500 = Int32.Parse(rootEle["C500"]),
                Coin1 = Int32.Parse(rootEle["Coin1"]),
                Coin2 = Int32.Parse(rootEle["Coin2"]),
                Coin10 = Int32.Parse(rootEle["Coin10"]),
                Coin5 = Int32.Parse(rootEle["Coin5"]),
                OnDate = DateTime.Parse(rootEle["OnDate"]),
                ID = Int32.Parse(rootEle["ID"]),
                TotalAmount = Int32.Parse(rootEle["TotalAmount"])
            };
            return ele;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public override List<DayClosing> ResultToObject( List<SortedDictionary<string, string>> data )
        {
            List<DayClosing> rootList = new List<DayClosing>();
            DayClosing ele;
            foreach (SortedDictionary<string, string> rootEle in data)
            {
                ele = new DayClosing()
                {
                    C10 = Int32.Parse(rootEle["C10"]),
                    C100 = Int32.Parse(rootEle["C100"]),
                    C1000 = Int32.Parse(rootEle["C1000"]),
                    C20 = Int32.Parse(rootEle["C20"]),
                    C200 = Int32.Parse(rootEle["C200"]),

                    C2000 = Int32.Parse(rootEle["C2000"]),
                    C5 = Int32.Parse(rootEle["C5"]),
                    C50 = Int32.Parse(rootEle["C50"]),
                    C500 = Int32.Parse(rootEle["C500"]),
                    Coin1 = Int32.Parse(rootEle["Coin1"]),
                    Coin2 = Int32.Parse(rootEle["Coin2"]),
                    Coin10 = Int32.Parse(rootEle["Coin10"]),
                    Coin5 = Int32.Parse(rootEle["Coin5"]),
                    OnDate = DateTime.Parse(rootEle["OnDate"]),
                    ID = Int32.Parse(rootEle["ID"]),
                    TotalAmount = Int32.Parse(rootEle["TotalAmount"])
                };
                rootList.Add(ele);
            }
            return rootList;
        }
    }
}