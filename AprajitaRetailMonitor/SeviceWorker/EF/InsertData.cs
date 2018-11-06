using AprajitaRetailsDB.DataBase.Voyager;
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
            LogEvent.WriteEvent( "insert bill data _with_EF6" );
            if (voygerBill!=null)
            {
                LogEvent.WriteEvent( " voy bil is not null" );
                if (voygerBill.bill.BillType!=null)
                {
                    LogEvent.WriteEvent( "bill tye: "+voygerBill.bill.BillType );
                }
            }
            VoyBill bill = voygerBill.bill;

            List<LineItem> lineItemList = voygerBill.lineItems;
            List<VPaymentMode> paymentList = voygerBill.payModes;

            VoyagerDB voyDatabase;

            using (voyDatabase=new VoyagerDB())
            {
                LogEvent.WriteEvent( "Voyager DB is connected" );
                var v = from vyb in voyDatabase.VoyBills
                        where vyb.BillNumber==bill.BillNumber&&vyb.BillTime==bill.BillTime
                        select new { vyb.ID };

                if (v.Count()>0)
                {
                    LogEvent.WriteEvent( "Invoice all ready Present in file" );
                    return;
                }

                voyDatabase.VoyBills.Add( bill );
                if (voyDatabase.SaveChanges()>0)
                {
                    LogEvent.WriteEvent( "Bill is saved!!!" );
                }
                else
                {
                    LogEvent.WriteEvent( "bill is not Saved" );
                }
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

                voyDatabase.SaveChanges();
                LogEvent.WriteEvent( "VoyBill is added with BillId: "+bill.ID+"and BillNo: "+bill.BillNumber );
            }
        }

        #endregion EF6
    }
}