using AprajitaRetailsDataBase.DataTypes;
using AprajitaRetailsDataBase.LinqDataBase;
using AprajitaRetailsDataBase.SqlDataBase.Data;
using AprajitaRetailsDataBase.SqlDataBase.DataModel;
using CyberN.Utility;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AprajitaRetailsDataBase.SqlDataBase.ViewModel
{   //TODO: Make static function to getID of tables so it will less memory uses and fast
    public class DailySalesVM
    {
        private DailySaleDB DB;
        private static int LoopCount = 0;

        #region LinqSql

        private LinqDatabase linqDB;

        //private string L_InvoiceID;
        private List<VoygerBill> voyBillList;

        public List<VoygerBill> GetAllVoyBills( )
        {
            List<VoygerBill> allBills = new List<VoygerBill>();
            using (linqDB=new LinqDatabase())
            {
                var bills = from me in linqDB.db.VoyBill
                            from you in linqDB.db.InsertDataLogs
                            where you.DailySaleId.HasValue==false&&you.SaleInvoiceId.HasValue==false&&me.ID==you.VoyBillId
                            select me;
                foreach (VoyBill cBill in bills)
                {
                    var paymode = (from pp in linqDB.db.VPaymentMode
                                   where pp.VoyBillId==cBill.ID
                                   select pp).ToList();
                    var items = (from ll in linqDB.db.LineItems
                                 where ll.VoyBillId==cBill.ID
                                 select ll).ToList();

                    allBills.Add( new VoygerBill()
                    {
                        bill=cBill,
                        lineItems=items,
                        payModes=paymode
                    } );
                }

                return allBills;
            }
        }

        public VoygerBill GetVoyBillsByID( int ID )
        {
            using (linqDB=new LinqDatabase())
            {
                var cBill = from me in linqDB.db.VoyBill
                            where me.ID==ID
                            select me;

                var paymode = (from pp in linqDB.db.VPaymentMode
                               where pp.VoyBillId==ID
                               select pp).ToList();
                var items = (from ll in linqDB.db.LineItems
                             where ll.VoyBillId==ID
                             select ll).ToList();
                return new VoygerBill()
                {
                    bill=cBill.First(),
                    lineItems=items,
                    payModes=paymode
                };
            }

            //return allBills;
        }

        private void SetUnSavedVoyBill( List<VoygerBill> bill )
        {
            voyBillList=bill;
        }

        private void SetUnSavedVoyBill( )
        {
            List<VoygerBill> allBills = new List<VoygerBill>();
            using (linqDB=new LinqDatabase())
            {
                var bills = from me in linqDB.db.VoyBill
                            from you in linqDB.db.InsertDataLogs
                            where you.DailySaleId.HasValue==false&&you.SaleInvoiceId.HasValue==false&&me.ID==you.VoyBillId
                            select me;

                Console.WriteLine( "Querry Created" );

                if (bills!=null&&(bills.Count()>0))
                {
                    foreach (VoyBill cBill in bills)
                    {
                        var paymode = (from pp in linqDB.db.VPaymentMode
                                       where pp.VoyBillId==cBill.ID
                                       select pp).ToList();
                        var items = (from ll in linqDB.db.LineItems
                                     where ll.VoyBillId==cBill.ID
                                     select ll).ToList();

                        allBills.Add( new VoygerBill()
                        {
                            bill=cBill,
                            lineItems=items,
                            payModes=paymode
                        } );
                    }
                    this.voyBillList=allBills;
                }
                else
                {
                    Console.WriteLine( "bill is null or bills count is zero" );
                    this.voyBillList=null;
                    if (bills==null)
                    {
                        Console.WriteLine( "bill is null " );
                    }
                }
            }
        }

        public List<SortedDictionary<string, string>> GetPendingList( )
        {
            List<SortedDictionary<string, string>> list = new List<SortedDictionary<string, string>>();
            if (voyBillList!=null&&voyBillList.Count>0)
            {
                Console.WriteLine( "Found in PendingList:#"+voyBillList.Count );
                foreach (var itemBill in voyBillList)
                {
                    SortedDictionary<string, string> a = new SortedDictionary<string, string>
                    {
                        { "InvoiceNo", itemBill.bill.BillNumber },
                        { "InvoiceDate", itemBill.bill.BillTime.ToString() },
                        { "Amount", itemBill.bill.BillGrossAmount.ToString() },
                        { "ID", itemBill.bill.ID.ToString() }
                    };
                    list.Add( a );
                }
            }
            else
            {
                Console.WriteLine( "it  may be null" );
                if (LoopCount>3)
                {
                    LoopCount=0;
                    Console.WriteLine( "Exiting pending invoice recurretion" );
                    return null;
                }
                Console.WriteLine( "Calling PendoingInvoice Again" );
                LoopCount++;
                SetUnSavedVoyBill();
                return GetPendingList();
            }

            return list;
        }

        #endregion LinqSql

        public DailySalesVM( )
        {
            DB=new DailySaleDB();
            linqDB=new LinqDatabase();
        }

        public List<SortedDictionary<string, string>> GetSaleList( )
        {
            return DB.GetSaleList();
        }

        public List<string> GetMobileNoList( )
        {
            return DB.GetMobileNoList();
        }

        public string AddData( )
        {
            //TODO: Might be removed in version 2 onwards
            SetUnSavedVoyBill();
            return "";
            //GenerateInvoiceNo ();
        }

        public string GenerateInvoiceNo( )
        {
            throw new NotImplementedException();
        }

        public int GetCustomerID( string mobile )
        {
            CustomerDB cDM = new CustomerDB();
            return cDM.GetID( "MobileNo", mobile );
        }

        public SaleInfo GetSaleInfo( )
        {
            return DB.GetSaleInfo();
        }

        public string GetCustomerName( int id )
        {
            return DB.GetCustomerName( id );
        }

        public string GetCustomerName( string mobileNo )
        {
            return DB.GetCustomerName( mobileNo );
        }

        public bool SaveData( DailySaleDM data )
        {
            bool status = false;
            DailySale dailySale = new DailySale()
            {
                ID=-1,
                Discount=data.Discount,
                Fabric=data.Fabric,
                Amount=data.Amount,
                InvoiceNo=data.InvoiceNo,
                RMZ=data.RMZ,
                SaleDate=data.SaleDate,
                Tailoring=data.Tailoring,
                PaymentMode=data.PaymentMode,
                CustomerID=GetCustomerID( data.CustomerMobileNo )
            };
            if (DB.InsertData( dailySale )>0)
            {
                status=true;
                Logs.LogMe( "DailySale is added!" );
            }
            if (data.NewCustomer==1)
            {
                NewCustomer newCust = new NewCustomer()
                {
                    CustomerID=dailySale.CustomerID,
                    ID=-1,
                    InvoiceNo=data.InvoiceNo,
                    OnDate=data.SaleDate,
                    CustomerFullName=data.CustomerFullName
                };
                NewCustomerDB nDB = new NewCustomerDB();
                if (nDB.Insert( newCust )>0)
                {
                    status=true;
                }
                else
                {
                    if (status)
                    {
                        Logs.LogMe( "New Customer Data not able to add!" );
                    }
                }
            }
            return status;
        }

        public void InsertInvoiceDetails( DailySaleDM data )
        {
        }

        public DailySale GetInvoiceDetails( string invoiceno )
        {
            return DB.GetByColName( "InvoiceNo", invoiceno );
        }

        public DailySale GetInvoiceDetails( int id )
        {
            return DB.GetByID( id );
        }

        public void UpdateInvoiceDetails( DailySaleDM data )
        {
        }

        public void DeleteInvoiceNo( string invoiceno )
        {
        }

        /// <summary>
        /// Get all Payment Modes
        /// </summary>
        /// <returns></returns>
        public List<PaymentMode> GetPaymentTypes( )
        {
            List<PaymentMode> listItem = new List<PaymentMode>();
            Logs.LogMe( "GetPaymentTypes():Calling GetDataForm" );
            List<SortedDictionary<string, string>> result = DB.GetDataFrom( "PaymentMode" );
            foreach (SortedDictionary<string, string> item in result)
            {
                PaymentMode mode = new PaymentMode()
                {
                    ID=Int32.Parse( item["PaymentModeID"] ),
                    PayMode=item["PayMode"]
                };
                listItem.Add( mode );
            }
            return listItem;
        }
    }
}