using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace AprajitaRetailMonitor.SeviceWorker.EF

{
    public class InsertData
    {
        #region EF6

        /// <summary>
        /// using EF 6
        /// </summary>
        /// <param name="voygerBill"></param>
        public static void InsertBillData( AprajitaRetailsDB.DataTypes.VoygerBill voygerBill )
        {
            LogEvent.WriteEvent( "insert bill data" );
            AprajitaRetailsDB.DataBase.Voyager.VoyBill bill = voygerBill.bill;
            List<AprajitaRetailsDB.DataBase.Voyager.LineItem> lineItemList = voygerBill.lineItems;
            List<AprajitaRetailsDB.DataBase.Voyager.VPaymentMode> paymentList = voygerBill.payModes;
            //ConnectLinqDataBase();
            AprajitaRetailsDB.DataBase.Voyager.VoyagerDB voyDatabase;
            using (voyDatabase=new AprajitaRetailsDB.DataBase.Voyager.VoyagerDB())
            {
                var v = from vyb in voyDatabase.VoyBills
                        where vyb.BillNumber==bill.BillNumber&&vyb.BillTime==bill.BillTime
                        select new { vyb.ID };

                if (v.Count()>0)
                {
                    Console.WriteLine( "Invoice all ready Present in file" );
                    LogEvent.WriteEvent( "Invoice all ready Present in file" );
                    return;
                }
                voyDatabase.VoyBills.Add( bill );//.InsertOnSubmit( bill );
                voyDatabase.SaveChanges();//.SubmitChanges();
                foreach (AprajitaRetailsDB.DataBase.Voyager.LineItem item in lineItemList)
                {
                    item.VoyBillId=bill.ID;
                    voyDatabase.LineItems.Add( item );//.InsertOnSubmit( item );
                }
                LogEvent.WriteEvent( "Inserted LinesItem" );
                foreach (AprajitaRetailsDB.DataBase.Voyager.VPaymentMode item in paymentList)
                {
                    item.VoyBillId=bill.ID;
                    voyDatabase.VPaymentModes.Add( item );
                }
                LogEvent.WriteEvent( "Inserted payments" );
                AprajitaRetailsDB.DataBase.Voyager.InsertDataLog dataLog = new AprajitaRetailsDB.DataBase.Voyager.InsertDataLog()
                {
                    BillNumber=bill.BillNumber,
                    Remark="First Step",
                    VoyBillId=bill.ID,
                };
                LogEvent.WriteEvent( "Inserted Datalog" );
                voyDatabase.InsertDataLogs.Add( dataLog );
                voyDatabase.SaveChanges();//.SubmitChanges();
                LogEvent.WriteEvent( "VoyBill is added with BillId: "+bill.ID+"and BillNo: "+bill.BillNumber );
            }
        }

        #endregion EF6
    }
}