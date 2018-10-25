using AprajitaRetailsDB.DataBase.AprajitaRetails;
using AprajitaRetailsDB.DataTypes;
using AprajitaRetailsDB.Models.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;

namespace AprajitaRetailsViewModels.EF6
{
    public class SaleInvoiceViewModel : IDisposable
    {
        #region Declarations

        private static string StoreCode;
        private readonly bool IsManualInvoice = false;

        private AprajitaRetailsMainDB mainDB;

       // private readonly Salesman salesman;
       // private readonly SaleInvoice saleInvoice;
       // private readonly ProductItem productItem;
       // private readonly SaleItem saleItem;
       // private readonly CardPaymentDetail cardPaymentDetail;
       // private readonly PaymentDetail paymentDetail;

        private const string ManualSeries = "MI";
        private const long SeriesStart = 10000000;

        #endregion Declarations

        #region Object Operations
        /// <summary>
        /// 
        /// </summary>
        /// <param name="manualBill"></param>
        /// <param name="storeCode"></param>
        public SaleInvoiceViewModel( bool manualBill, string storeCode )
        {
            IsManualInvoice=manualBill; StoreCode=storeCode;
            mainDB=new AprajitaRetailsMainDB();
        }

        /// <summary>
        /// Dispose Database Object
        /// </summary>
        public void Dispose( )
        {
            ((IDisposable)mainDB).Dispose();
        }
        #endregion
        #region Salesmans

        // Functions
        /// <summary>
        /// Get List of Salesmam
        /// </summary>
        /// <returns>  </returns>
        public List<Salesman> GetSalesmanList( )
        {
            mainDB.Salesmen.Load();
            return mainDB.Salesmen.Local.ToList();
        }

        /// <summary>
        /// Get List of Salesman Name
        /// </summary>
        /// <returns></returns>
        public List<string> GetSalesmanNameList( )
        {
            mainDB.Salesmen.LoadAsync();

            List<string> list = new List<string>();
            List<Salesman> salesman = mainDB.Salesmen.Local.ToList();
            foreach (Salesman data in salesman)
            {
                list.Add( data.SalesmanName );
            }
            return list;
        }

        public string GetSalesmanName( int id )
        {
            if (id>0)
            {
                return mainDB.Salesmen.Local.Where( s => s.SalesmanID==id ).FirstOrDefault().SalesmanName;
            }
            else
            {
                return "NotFound";
            }
        }

        public string GetSalesmanName( string smcode )
        {
            if (smcode!=null&&smcode!="")
            {
                return mainDB.Salesmen.Local.Where( s => s.SMCode==smcode ).FirstOrDefault().SalesmanName;
            }

            return "NotFound";
        }

        public int GetSalesmanID( string salesmanname, string smcode )
        {
            if (salesmanname!=null&&salesmanname!="")
            {
                return mainDB.Salesmen.Local.Where( s => s.SalesmanName==salesmanname ).FirstOrDefault().SalesmanID;
            }

            if (smcode!=null&&smcode!="")
            {
                return mainDB.Salesmen.Local.Where( s => s.SMCode==smcode ).FirstOrDefault().SalesmanID;
            }

            return -1;
        }

        public string GetSalesmanCode( int id )
        {
            if (id>0)
            {
                return mainDB.Salesmen.Local.Where( s => s.SalesmanID==id ).FirstOrDefault().SMCode;
            }
            else
            {
                return "NotFound";
            }
        }

        public string GetSalesmanCode( string salesman )
        {
            if (salesman!=null&&salesman!="")
            {
                return mainDB.Salesmen.Local.Where( s => s.SalesmanName==salesman ).FirstOrDefault().SMCode;
            }

            return "NotFound";
        }

        #endregion Salesmans

        #region Items

        public List<string> GetBarCodesList( int Size )
        {
            return null;
            // return pDB.GetBarCodeList( x );
        }




        public ProductItem GetProductItemDetais( string barcode )
        {
            mainDB.ProductItems.LoadAsync();
            return mainDB.ProductItems.Local.Where( s => s.Barcode==barcode ).FirstOrDefault();
            // return pDB.GetProductItemDetais( barcode );


        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cBInvoiceNo"></param>
        /// <returns></returns>
        public int GetInvoiceNoList( ComboBox cBInvoiceNo )
        {
            List<string> itemList = GetInvoiceNoList();
            foreach (string item in itemList)
            {
                cBInvoiceNo.Items.Add( item );
            }
            return itemList.Count;
        }
        /// <summary>
        /// /
        /// </summary>
        /// <param name="cBMobileNo"></param>
        /// <returns></returns>
        public int GetCustomerMobileNoList( ComboBox cBMobileNo )
        {
            List<string> itemList = GetCustomerMobileNoList();
            foreach (string item in itemList)
            {
                cBMobileNo.Items.Add( item );
            }
            return itemList.Count;
        }

        #endregion Items

        #region Get Function

        public List<string> GetInvoiceNoList( )
        {
            mainDB.SaleInvoices.LoadAsync();
            return mainDB.SaleInvoices.Local.Select( s => s.InvoiceNo ).ToList();
        }

        private string GetLastInvoiceNo( )
        {
            mainDB.SaleInvoices.LoadAsync();
            return mainDB.SaleInvoices.Local.Where( s => s.SaleTypeID==(int)EnumList.SaleInvoiceTypes.Manual ).LastOrDefault().InvoiceNo;
        }

        #endregion Get Function

        #region Customer

        public SortedDictionary<string, string> GetCustomerInfo( string mobileNo )
        {
            if (mobileNo.Trim().Length<=0)
            {
                return null;
            }
            else
            {
                mainDB.Customers.LoadAsync();
                var cust = mainDB.Customers.Local.Where( s => s.MobileNo==mobileNo ).FirstOrDefault();
                return (new SortedDictionary<string, string>()
                {{"FirstName",cust.FirstName},{"LastName",cust.LastName},{"ID",""+cust.CustomerID},
                    {"MobileNo",cust.MobileNo }
                });
            }
        }

        public SortedDictionary<string, string> GetCustomerInfo( int custId )
        {
            if (custId>0)
            {
                mainDB.Customers.LoadAsync();
                var cust = mainDB.Customers.Local.Where( s => s.CustomerID==custId ).FirstOrDefault();
                return (new SortedDictionary<string, string>()
                {{"FirstName",cust.FirstName},{"LastName",cust.LastName},{"ID",""+cust.CustomerID},
                    {"MobileNo",cust.MobileNo }
                });
            }
            else
            {
                return null;
            }
        }

        public List<string> GetCustomerMobileNoList( )
        {
            mainDB.Customers.LoadAsync();
            return mainDB.Customers.Local.Select( s => s.MobileNo ).ToList();
        }

        #endregion Customer

        #region SavingInvoice

        /// <summary>
        ///
        /// </summary>
        /// <param name="saleInv"></param>
        /// <param name="itemTable"></param>
        /// <param name="pd"></param>
        /// <returns></returns>
        public int SaveInvoiceData( SaleInvoice saleInv, DataTable itemTable, SalePaymentDetails pd )
        {    //TODO: for payment mode need check and insert
            int vSaleId = mainDB.SaleInvoices.Local.LastOrDefault().SaleInvoiceID;
            string vInvNo = mainDB.SaleInvoices.Local.LastOrDefault().InvoiceNo;
            List<SaleItem> saleItems = new List<SaleItem>();
            foreach (DataRow dr in itemTable.Rows)
            {
                SaleItem items = new SaleItem()
                {
                    InvoiceNo=(string)dr["InvoiceNo"],
                    BarCode=(string)dr["BarCode"],
                    Qty=decimal.Parse( (string)dr["Qty"] ),
                    MRP=decimal.Parse( (string)dr["MRP"] ),
                    BasicAmount=decimal.Parse( (string)dr["BasicAmount"] ),
                    Discount=decimal.Parse( (string)dr["Discount"] ),
                    BillAmount=decimal.Parse( (string)dr["Amount"] ),
                    CGST=decimal.Parse( (string)dr["CGST"] ),
                    CGSTRate=Double.Parse( (string)dr["CGSTRate"] ),
                    IGSTRate=Double.Parse( (string)dr["IGSTRate"] ),
                    IsAdjusted=1,
                    IsManualBill=1,
                    SalesmanID=(int)dr["SalesmanID"],
                    SGST=decimal.Parse( (string)dr["SGST"] ),
                    SGSTRate=Double.Parse( (string)dr["SGSTRate"] ),
                    Tax=decimal.Parse( (string)dr["Tax"] ),
                };
                saleItems.Add( items );
            }
            // Adding Sold Items
            saleInv.SaleItems=saleItems;

            CardPaymentDetail cd = new CardPaymentDetail()
            {
                Amount=pd.CardDetails.Amount,
                AuthCode=pd.CardDetails.AuthCode,
                CardPaymentDetailsID=pd.CardDetails.ID,
                CardType=pd.CardDetails.CardType,
                InvoiceNo=pd.CardDetails.InvoiceNo,
                LastDigit=pd.CardDetails.LastDigit
            };
            PaymentDetail payDetails = new PaymentDetail()
            {
                CardAmount=pd.CardAmount,
                CashAmount=pd.CashAmount,
                InvoiceNo=pd.InvoiceNo,
                PayMode=pd.PayMode,
                PaymentDetailsID=pd.ID,
                CardPaymentDetail=cd,
            };

            saleInv.PaymentDetails.Add( payDetails );

            mainDB.SaleInvoices.Add( saleInv );
            return mainDB.SaveChanges();

            /*if (payDetails.PayMode==UtilOps.GetSalePayMode( SalePayMode.Card )||payDetails.PayMode==UtilOps.GetSalePayMode( SalePayMode.Mix ))
                    {
                        modef=true;
                        payDetails.CardDetails.InvoiceNo=invNo;
                        status2=SaveCardDetails( payDetails.CardDetails );
                        int cardDetailsId = 0;
                        status=SavePaymentDetails( payDetails, cardDetailsId );
                    }
                    else
                    {
                        //For CashPayment
                        status=SavePaymentDetails( payDetails, -1 );
                    }
             */
        }

        #endregion SavingInvoice

        public InvoiceNo GenerateInvoiceNo( )
        {
            InvoiceNo inv = new InvoiceNo( ManualSeries );
            //TODO: series Start should be changed every Finnical Year;
            //TODO: Should have option to check data and based on that generate it
            string iNo = GetLastInvoiceNo();
            if (iNo.Length>0)
            {
                if (iNo!="0")
                {
                    // Logs.LogMe( "Inv="+iNo );
                    iNo=iNo.Substring( 5 );
                    //Logs.LogMe( "Inv="+iNo );
                    long i = long.Parse( iNo );
                    //Logs.LogMe( "Inv="+i );
                    inv.TP=i+1;
                }
                else
                { inv.TP=SeriesStart+1; }
            }
            else
            {
                //TODO: check future what happens and what condtion  come here
                inv.TP=SeriesStart+1;
                //Logs.LogMe( "Future check :Inv="+inv.TP );
            }
            return inv;
        }
    }
}
