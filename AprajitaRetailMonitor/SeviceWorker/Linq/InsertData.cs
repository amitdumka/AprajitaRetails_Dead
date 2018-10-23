using AprajitaRetailsDataBase.LinqDataBase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace AprajitaRetailMonitor.SeviceWorker.Linq
{
    public class InsertData
    {
        #region LinqSql

        /// <summary>
        /// using Linq to SQL
        /// </summary>
        /// <param name="voygerBill"></param>
        public static void InsertBillData( VoygerBillWithLinq voygerBill )
        {
            LogEvent.WriteEvent( "insert bill data" );
            VoyBill bill = voygerBill.bill;
            List<LineItems> lineItemList = voygerBill.lineItems;
            List<VPaymentMode> paymentList = voygerBill.payModes;
            //ConnectLinqDataBase();
            using (AprajitaRetailsDataBase.LinqDataBase.LinqDatabase voyDatabase = new AprajitaRetailsDataBase.LinqDataBase.LinqDatabase())
            {
                var v = from vyb in voyDatabase.db.VoyBill
                        where vyb.BillNumber==bill.BillNumber&&vyb.BillTime==bill.BillTime
                        select new { vyb.ID };

                if (v.Count()>0)
                {
                    Console.WriteLine( "Invoice all ready Present in file" );
                    LogEvent.WriteEvent( "Invoice all ready Present in file" );
                    return;
                }
                voyDatabase.db.VoyBill.InsertOnSubmit( bill );
                voyDatabase.db.SubmitChanges();
                foreach (LineItems item in lineItemList)
                {
                    item.VoyBillId=bill.ID;
                    voyDatabase.db.LineItems.InsertOnSubmit( item );
                }
                LogEvent.WriteEvent( "Inserted LinesItem" );
                foreach (VPaymentMode item in paymentList)
                {
                    item.VoyBillId=bill.ID;
                    voyDatabase.db.VPaymentMode.InsertOnSubmit( item );
                }
                LogEvent.WriteEvent( "Inserted payments" );
                InsertDataLog dataLog = new InsertDataLog()
                {
                    BillNumber=bill.BillNumber,
                    Remark="First Step",
                    VoyBillId=bill.ID,
                };
                LogEvent.WriteEvent( "Inserted Datalog" );
                voyDatabase.db.InsertDataLogs.InsertOnSubmit( dataLog );
                voyDatabase.db.SubmitChanges();
                LogEvent.WriteEvent( "VoyBill is added with BillId: "+bill.ID+"and BillNo: "+bill.BillNumber );
            }
        }

        #endregion LinqSql
    }
}