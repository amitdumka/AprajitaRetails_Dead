using AprajitaRetailsDataBase.LinqDataBase;
using CyberN.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace AprajitaRetailMonitor.SeviceWorker
{
    public class InsertData
    {
        #region LinqSql

        
        public void InsertBillData( VoygerBillWithLinq voygerBill )
        {
            VoyBill bill = voygerBill.bill;
            List<LineItems> lineItemList = voygerBill.lineItems;
            List<VPaymentMode> paymentList = voygerBill.payModes;
            //ConnectLinqDataBase();
            using (LinqDatabase voyDatabase = new LinqDatabase())
            {
                var v = from vyb in voyDatabase.db.VoyBill
                        where vyb.BillNumber == bill.BillNumber && vyb.BillTime == bill.BillTime
                        select new { vyb.ID };

                if (v.Count() > 0)
                {
                    Console.WriteLine("Invoice all ready Present in file");
                    LogEvent.WriteEvent("Invoice all ready Present in file");
                    return;
                }
                voyDatabase.db.VoyBill.InsertOnSubmit(bill);
                voyDatabase.db.SubmitChanges();
                foreach (LineItems item in lineItemList)
                {
                    item.VoyBillId = bill.ID;
                    voyDatabase.db.LineItems.InsertOnSubmit(item);
                }
                LogEvent.WriteEvent("Inserted LinesItem");
                foreach (VPaymentMode item in paymentList)
                {
                    item.VoyBillId = bill.ID;
                    voyDatabase.db.VPaymentMode.InsertOnSubmit(item);
                }
                LogEvent.WriteEvent("Inserted payments");
                InsertDataLog dataLog = new InsertDataLog()
                {
                    BillNumber = bill.BillNumber,
                    Remark = "First Step",
                    VoyBillId = bill.ID,
                };
                LogEvent.WriteEvent("Inserted Datalog");
                voyDatabase.db.InsertDataLogs.InsertOnSubmit(dataLog);
                voyDatabase.db.SubmitChanges();
                LogEvent.WriteEvent("VoyBill is added with BillId: " + bill.ID + "and BillNo: " + bill.BillNumber);

            }


        }

        #endregion LinqSql
    }
}