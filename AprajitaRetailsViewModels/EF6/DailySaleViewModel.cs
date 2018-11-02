using AprajitaRetailsDB.DataBase.AprajitaRetails;
using AprajitaRetailsDB.DataBase.Voyager;
using AprajitaRetailsDB.DataTypes;
using CyberN.Utility;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace AprajitaRetailsViewModels.EF6
{
    public class DailySaleDM
    {
        //TODO: move to correct place
        public DailySale DailySale { get; set; }

        public string FullCustomerName { get; set; }
        public bool IsNewCustomer { get; set; }
        public NewCustomer NewCustomer { get; set; }
    }
    public class DSInfo
    {//TODO : move to proper place
        public int DailySaleId { get; set; }
        public decimal Amount { get; set; }
        public String InvoiceNo { get; set; }

    }
    public class CustomerInfo
    {
        public int CustomerID { get; set; }
        public String CustomerName { get; set; }
        public String MobileNo { get; set; }
    }

    public static class SaleQuery
    { //TODO: move to correct place
        public static string qYearly = "select sum(Amount),DATEPART(YY,SaleDate) as Year from DailySale "+
                                       "where DATEPART(YY, SaleDate)=@year group by DATEPART(YY, SaleDate)";

        public static string QMontly = "select 	 sum(Amount) as TAmount,DATEPART(MM,SaleDate) as Months, "+
                                       "DATEPART(YY,SaleDate) as Years from DailySale"+
                                       "where DATEPART(YY, SaleDate)=@year    and DATEPART(MM, SaleDate)=@month"+
                                       "group by DATEPART(MM, SaleDate)  , DATEPART(YY, SaleDate)";

        public static string QDaily = "select  Sum(Amount) as TAmount  from DailySale "
                                      +"where datediff(day, SaleDate,@date) = 0 ";

        public static string QueryAll = "select TAmount, MAmount, YAmount  from "+
                                        "(select Sum(Amount) as TAmount from DailySale  where datediff(day, SaleDate, @CDate) = 0  ) as DS,"+
                                        "(select Sum(Amount) as MAmount ,DatePart(MM, SaleDate) as Months, DatePart(YY, SaleDate) as Years from DailySale "+
                                        "where    DatePart(MM, SaleDate)=@CMon	  and DatePart(YY, SaleDate)=@CYear "+
                                        "Group By DatePart(MM, SaleDate) ,DatePart(YY, SaleDate) ) as MS , "+
                                        " (  select Sum(Amount) as YAmount , DatePart(YY, SaleDate) as Years from DailySale "+
                                        " where   DatePart(YY, SaleDate)=@CYear2   Group By DatePart(YY, SaleDate) ) as YS";
        private static AprajitaRetailsMainDB mainDB;

        public static decimal GetMonthlySaleData( )
        {
            using (mainDB= new AprajitaRetailsMainDB())
            {
               // var c= from DailySale cn in mainDB where  

                DateTime period = DateTime.Today.Subtract( TimeSpan.FromDays( 30 ) );
                return mainDB.DailySales.Where( s => s.SaleDate==period&&s.SaleDate==DateTime.Today ).Sum( s => s.Amount )??0;
                
            }

        }
        public static decimal GetDailySaleData( )
        {

            using (mainDB=new AprajitaRetailsMainDB())
            
            return mainDB.DailySales.Where( s => s.SaleDate==DateTime.Today ).Sum( s => s.Amount )??0;
        }
        public static decimal GetYearlySaleData( )
        {

            using (mainDB=new AprajitaRetailsMainDB())
            {
                DateTime period;
                period=DateTime.Today.Subtract( TimeSpan.FromDays( 365 ) );
                return mainDB.DailySales.Where( s => s.SaleDate==period&&s.SaleDate==DateTime.Today ).Sum( s => s.Amount )??0;


            }

        }

    }

    public class DailySaleViewModel : IDisposable
    {
        //public AprajitaRetailsHRMDB hrmDB;
        public AprajitaRetailsMainDB mainDB;

        public VoyagerDB voyDB;// Use and destroy by using Using method

        public DailySaleViewModel( )
        {
            mainDB=new AprajitaRetailsMainDB();
        }

        public void Dispose( )
        {
            ((IDisposable)mainDB).Dispose();
        }

        #region MainDB

        public string AddData( )
        {
            //TODO: Might be removed in version 2 onwards
            SetUnSavedVoyBill();
            return "";
            //GenerateInvoiceNo ();
        }

        public void DeleteInvoiceNo( string invoiceno )
        {
        }

        public string GenerateInvoiceNo( )
        {
            throw new NotImplementedException();
        }

        #region Get Data

        public int GetCustomerID( string mobile )
        {
            mainDB.Customers.Load();
            return mainDB.Customers.Local.Where( s => s.MobileNo==mobile ).FirstOrDefault().CustomerID;
        }

        public string GetCustomerName( int id )
        {
            mainDB.Customers.Load();
            return mainDB.Customers.Local.Where( s => s.CustomerID==id ).FirstOrDefault().FirstName;
        }
        public CustomerInfo GetCustomerInfo( int id )
        {
            mainDB.Customers.Load();
            return mainDB.Customers.Local.Where( s => s.CustomerID==id ).Select(s=>new CustomerInfo() {CustomerID=s.CustomerID, CustomerName=s.FirstName+" "+s.LastName, MobileNo=s.MobileNo } ).FirstOrDefault();
        }
        public string GetCustomerName( string mobileNo )
        {
            //TODO: Handle Null Exception here . if it return null
            mainDB.Customers.Load();
             
            var custName=    mainDB.Customers.Local.Where( s => s.MobileNo==mobileNo ).FirstOrDefault();
            if (custName!=null)
                return custName.FirstName+" "+custName.LastName; else return "";
        }

        public DailySale GetInvoiceDetails( string invoiceno )
        {
            mainDB.DailySales.Load();
            return mainDB.DailySales.Local.Where( s => s.InvoiceNo==invoiceno ).FirstOrDefault();
        }

        public DailySale GetInvoiceDetails( int id )
        {
            mainDB.DailySales.Load();
            return mainDB.DailySales.Local.Where( s => s.DailySaleID==id ).FirstOrDefault();
        }

        public List<string> GetMobileNoList( )
        {
            mainDB.Customers.Load();
            List<string > lists= mainDB.Customers.Local.Select( s => s.MobileNo ).ToList();
            Console.WriteLine( "MobileList No ={0}", lists.Count );
            foreach (string v in lists)
                Console.WriteLine( v );
            return lists;
        }

        /// <summary>
        /// Get all Payment Modes
        /// </summary>
        /// <returns></returns>
        public List<PaymentMode> GetPaymentTypes( )
        {
            mainDB.PaymentModes.Load();
            return mainDB.PaymentModes.Select( s => s ).ToList();
            // List<PaymentMode> listItem = new List<PaymentMode>();
            //Logs.LogMe( "GetPaymentTypes():Calling GetDataForm" );
            //List<SortedDictionary<string, string>> result = DB.GetDataFrom( "PaymentMode" );

            //foreach (SortedDictionary<string, string> item in result)
            //{
            //    PaymentMode mode = new PaymentMode()
            //    {
            //        PaymentModeID=Int32.Parse( item["PaymentModeID"] ),
            //        PayMode=item["PayMode"]
            //    };
            //    listItem.Add( mode );
            //}
            //return listItem;
        }
        public List<string> GetPaymentTypeName( )
        {
            mainDB.PaymentModes.Load();
            return mainDB.PaymentModes.Select( s => s.PayMode ).ToList();
        }
            #endregion Get Data

            public SaleInfo GetSaleInfo( )
        {
            //TODO:implement this very impt
            DateTime s = DateTime.Now;
            Logs.LogMe( "Sale Info Date: "+s.ToShortDateString() );

            string cd = ""+DateTime.Now.Month+"/"+DateTime.Now.Day+"/"+DateTime.Now.Year;
            string cy = ""+DateTime.Now.Year;
            string cm = ""+DateTime.Now.Month;

            Logs.LogMe( "Date "+cd+"="+DateTime.Now.ToLongDateString() );

            //SqlCommand cmd = new SqlCommand( SaleQuery.QueryAll, Db.DBCon );
            //cmd.Parameters.AddWithValue( "@CDate", cd );
            //cmd.Parameters.AddWithValue( "@CYear2", cy );
            //cmd.Parameters.AddWithValue( "@CMon", cm );
            //cmd.Parameters.AddWithValue( "@CYear", cy );
            //SqlDataReader reader = cmd.ExecuteReader();

            SaleInfo info = new SaleInfo();
            //if (reader!=null&&reader.HasRows)
            //{
            //    reader.Read();
            //    info.MonthlySale=""+reader["MAmount"];
            //    info.TodaySale=""+reader["TAmount"];
            //    info.YearlySale=""+reader["YAmount"];
            //    Logs.LogMe( "Sale Info: "+reader["TAmount"]+"=="+reader["MAmount"]+"=="+reader["YAmount"] );
            //}
            //reader.Close();
            return info;
        }

        public int InsertData( DailySale data )
        {
            mainDB.DailySales.Add( data );
            return mainDB.SaveChanges();
        }

        public bool SaveData( DailySaleDM data )
        {
            bool status = false;

            if (InsertData( data.DailySale )>0)
            {
                status=true;
                Logs.LogMe( "DailySale is added!" );
            }
            if (data.IsNewCustomer)
            {
                NewCustomer newCust = new NewCustomer()
                {
                    CustomerID=data.DailySale.CustomerID,
                    // ID=-1,
                    InvoiceNo=data.DailySale.InvoiceNo,
                    OnDate=data.DailySale.SaleDate,
                    CustomerFullName=data.FullCustomerName
                };
                //mainDB.NewCustomer.add( newCust );
                mainDB.SaveChanges();

                if (status)
                {
                    Logs.LogMe( "New Customer Data not able to add!" );
                }
            }
            return status;
        }

        public List<DSInfo> GetSaleList( )
        {
            string sql = " select  InvoiceNo, Amount, ID from DailySale "+
                    " where DATEDIFF(day, SaleDate,@dates)= 0 order by ID Desc ";
            mainDB.DailySales.Load();
           return mainDB.DailySales.Local.Where( s => DateTime.Compare(s.SaleDate.Date,DateTime.Today.Date )==0).Select( s => new DSInfo{ InvoiceNo= s.InvoiceNo, Amount= s.Amount??0,DailySaleId= s.DailySaleID } ).ToList();
            
        }

        public void UpdateInvoiceDetails( DailySale data )
        {
        }

        
        #endregion MainDB

        #region VoygerDB

        public List<VoygerBill> GetAllVoyBills( )
        {
            List<VoygerBill> allBills = new List<VoygerBill>();
            using (voyDB=new VoyagerDB())
            {
                var bills = from me in voyDB.VoyBills
                            from you in voyDB.InsertDataLogs
                            where you.DailySaleId.HasValue==false&&you.SaleInvoiceId.HasValue==false&&me.ID==you.VoyBillId
                            select me;
                foreach (VoyBill cBill in bills)
                {
                    var paymode = (from pp in voyDB.VPaymentModes
                                   where pp.VoyBillId==cBill.ID
                                   select pp).ToList();
                    var items = (from ll in voyDB.LineItems
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

        public VoygerBill GetVoyBillsByID( int ID )
        {
            using (voyDB=new VoyagerDB())
            {
                var cBill = from me in voyDB.VoyBills
                            where me.ID==ID
                            select me;

                var paymode = (from pp in voyDB.VPaymentModes
                               where pp.VoyBillId==ID
                               select pp).ToList();
                var items = (from ll in voyDB.LineItems
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

        private static int LoopCount = 0;
        // private VoyagerDB voyDB;

        //private string L_InvoiceID;
        private List<VoygerBill> voyBillList;

        private void SetUnSavedVoyBill( List<VoygerBill> bill )
        {
            voyBillList=bill;
        }

        private void SetUnSavedVoyBill( )
        {
            List<VoygerBill> allBills = new List<VoygerBill>();
            using (voyDB=new VoyagerDB())
            {
                var bills = from me in voyDB.VoyBills
                            from you in voyDB.InsertDataLogs
                            where you.DailySaleId.HasValue==false&&you.SaleInvoiceId.HasValue==false&&me.ID==you.VoyBillId
                            select me;

                Console.WriteLine( "Querry Created" );

                if (bills!=null&&(bills.Count()>0))
                {
                    foreach (VoyBill cBill in bills)
                    {
                        var paymode = (from pp in voyDB.VPaymentModes
                                       where pp.VoyBillId==cBill.ID
                                       select pp).ToList();
                        var items = (from ll in voyDB.LineItems
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

        #endregion VoygerDB
    }
}