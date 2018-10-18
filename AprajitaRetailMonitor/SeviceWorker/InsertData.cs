using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace AprajitaRetailMonitor.SeviceWorker
{
    public class InsertData
    {
        #region LinqSql

        public const string dbName = "VoygerDatabase.mdf";
        public static string pathName = System.IO.Directory.GetCurrentDirectory();

        private VoygerDatabase voyDatabase;

        public bool ConnectLinqDataBase( )
        {
            System.IO.Directory.GetCurrentDirectory();
            if (voyDatabase == null)
            {
                voyDatabase = new VoygerDatabase(pathName + "\\" + dbName);
                if (!voyDatabase.DatabaseExists())
                {
                    voyDatabase.CreateDatabase();
                }
                if (voyDatabase != null && voyDatabase.Connection.State == ConnectionState.Open)
                {
                    LogEvent.WriteEvent("Connected");
                }
                else
                {
                    return false;
                }
                if (voyDatabase == null)
                {
                    LogEvent.WriteEvent("DataBase doesnt exsits");
                }
                else
                {
                    LogEvent.WriteEvent("Database is present and running");
                }
            }
            if (voyDatabase.Connection.State == ConnectionState.Open)
            {
                LogEvent.WriteEvent("DataBase is Running");
                return true;
            }
            else
            {
                LogEvent.WriteEvent("DataBase is not Running");
                return false;
            }
        }

        public void InsertBillData( VoygerBillWithLinq voygerBill )
        {
            VoyBill bill = voygerBill.bill;
            List<LineItems> lineItemList = voygerBill.lineItems;
            List<VPaymentMode> paymentList = voygerBill.payModes;
            ConnectLinqDataBase();
            var v = from vyb in voyDatabase.VoyBill
                    where vyb.BillNumber == bill.BillNumber && vyb.BillTime == bill.BillTime
                    select new { vyb.ID };

            if (v.Count() > 0)
            {
                Console.WriteLine("Invoice all ready Present in file");
                return;
            }
            voyDatabase.VoyBill.InsertOnSubmit(bill);
            voyDatabase.SubmitChanges();
            foreach (LineItems item in lineItemList)
            {
                item.VoyBillId = bill.ID;
                voyDatabase.LineItems.InsertOnSubmit(item);
            }
            foreach (VPaymentMode item in paymentList)
            {
                item.VoyBillId = bill.ID;
                voyDatabase.VPaymentMode.InsertOnSubmit(item);
            }
            InsertDataLog dataLog = new InsertDataLog()
            {
                BillNumber = bill.BillNumber,
                Remark = "First Step",
                VoyBillId = bill.ID,
            };
            voyDatabase.InsertDataLogs.InsertOnSubmit(dataLog);
            voyDatabase.SubmitChanges();
        }

        #endregion LinqSql
    }
}