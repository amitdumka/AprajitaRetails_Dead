using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
using AprajitaRetailsDB.DataBase.AprajitaRetails.HRM;

namespace AprajitaRetailsDB.DataBase.AprajitaRetails
{
    public class ExtraTables
    {
        //TODO: list of table is here 
        //implement it
    }

    [Table( "FootFall" )]
    public class FootFall
    {
        [Key]
        [DatabaseGenerated( DatabaseGeneratedOption.Identity )]
        public int FootFallID { set; get; }

        public DateTime OnDate { set; get; }

        public int Total { set; get; }
        public int T9_10 { set; get; }
        public int T10_11 { set; get; }
        public int T11_12 { set; get; }
        public int T12_1 { set; get; }
        public int T1_2 { set; get; }
        public int T2_3 { set; get; }
        public int T3_4 { set; get; }
        public int T4_5 { set; get; }
        public int T5_6 { set; get; }
        public int T6_7 { set; get; }
        public int T7_8 { set; get; }
        public int T8_9 { set; get; }
        [StringLength( 20 )]
        public string StoreCode { get; set; }
    }
    [Table("CashDetail")]
    public class CashDetail{
        [Key]
        [DatabaseGenerated( DatabaseGeneratedOption.Identity )]
        public int CashDetailID { set; get; }
        public int TotalAmount { set; get; }
        public int C2000 { set; get; }
        public int C1000 { set; get; }
        public int C500 { set; get; }
        public int C100 { set; get; }
        public int C50 { set; get; }
        public int C20 { set; get; }
        public int C10 { set; get; }
        public int C5 { set; get; }
        public int Coin10 { set; get; }
        public int Coin5 { set; get; }
        public int Coin2 { set; get; }
        public int Coin1 { set; get; }
        [StringLength( 20 )]
        public string StoreCode { get; set; }
    }
    public class DayEndDetails
    {
        public int DayEndDetailsID { set; get; }
        public int DayClosingID { set; get; }
        public DateTime OnDate { set; get; }

        public double TotalSale { set; get; }

        public double CreditCardSale { get; set; }
        public double DebitCardSale { get; set; }

        public double TotalRMZSale { set; get; }
        public double TotalFabricSale { set; get; }
        public double TotalRMZNo { set; get; }
        public double TotalFabricNo { set; get; }

        public double TailoringSale { get; set; }
        public int TotalTailorDeliveryNo { get; set; }
        public double TotalTailoringBookingAmount { set; get; }
        public int TotalTailoringBookingNo { set; get; }

        public double TotalBankDeposit { set; get; }
        public double TotalBankPayment { set; get; }
        public double TotalCashPayment { set; get; }

        public double TotalExpenses { set; get; }

        public double TotalAccessicorySale { get; set; }
        public int TotalAccessicoryNo { get; set; }
    }
    public class DiscountCodeGenerator
    {
        public int ID { set; get; }
        public string DiscountCode { set; get; }
        public DateTime GenDate { set; get; }
        //TODO: Implement with full secure
    }

    public class Discount
    {
        public int DiscountID { set; get; }
        public string DiscountCode { set; get; }
    }
    internal class Dues
    {//TODO:HRM or payroll
        public int ID { get; set; }
        public int EmpID { get; set; }
        public string EMPCode { get; set; }
        public double DuesAmount { get; set; }
    }
    internal class DuesPayment
    {
        public int ID { get; set; }
        public int EmpID { get; set; }
        public string EmpCode { get; set; }
        public int AdvanceID { get; set; }
        public double Amount { get; set; }
        public int ReciptNo { get; set; }
        public DateTime DateOfRecipt { get; set; }
    }
    /// <summary>
    /// ExpensesForm Level
    /// </summary>
    internal class ExpensesLevel
    {
        public static readonly int General = 1;
        public static readonly int Low = 2;
        public static readonly int Medium = 3;
        public static readonly int High = 4;
        public static readonly int VeryHigh = 5;
        public static readonly int Other = 6;

        public static int ExpensesLevelID( string level )
        {
            int id = 1;
            switch (level)
            {
                case "Other":
                    id=6;
                    break;

                case "VeryHigh":
                    id=5;
                    break;

                case "High":
                    id=4;
                    break;

                case "General":
                    id=1;
                    break;

                case "Low":
                    id=2;
                    break;

                case "Medium":
                    id=3;
                    break;

                default:
                    id=1;
                    break;
            }

            return id;
        }

        public static string ExpensesLevelName( int id )
        {
            string name = "General";
            switch (id)
            {
                case 6:
                    name="Other";
                    break;

                case 5:
                    name="VeryHigh";
                    break;

                case 4:
                    name="High";
                    break;

                case 1:
                    name="General";
                    break;

                case 2:
                    name="Low";
                    break;

                case 3:
                    name="Medium";

                    break;

                default:
                    name="General";
                    break;
            }
            return name;
        }
    }

    internal class Incentive
    {
        public int ID { get; set; }
        public double IncentivePercentage { get; set; }
        public double TargetAmount { get; set; }
    }
    /// <summary>
    /// Its store Invoice Details
    /// </summary>
    public class InvoiceNo
    {
        public readonly string FP = "C33";
        public string SP = "IN";
        public long TP { get; set; }

        public InvoiceNo( )
        {
        }

        public InvoiceNo( string sp )
        {
            this.SP=sp;
        }

        public InvoiceNo( string sp, long tp )
        {
            this.SP=sp;
            this.TP=tp;
        }

        public override string ToString( )
        {
            return FP+SP+TP;
        }

        public static string GetInvoiceNo( int old, int newno )
        {  //C33 IN 500001
            InvoiceNo inv = new InvoiceNo
            {
                TP=newno
            };
            return inv.ToString();
        }

        public static string GetInvoiceNo( int nos )
        {  //C33 IN 500001
            InvoiceNo inv = new InvoiceNo
            {
                TP=nos
            };
            return inv.ToString();
        }

        public static InvoiceNo GetNewInvoviceNo( int oldinv )
        {
            InvoiceNo inv = new InvoiceNo
            {
                TP=oldinv+1
            };
            return inv;
        }

        public static InvoiceNo GetNewInvoviceNo( InvoiceNo oldinv )
        {
            oldinv.TP++;
            return (oldinv);
        }

        public static long GetInvNo( string inv )
        {
            string s = inv.Substring( 5 ).Trim();
            long nums = -1;
            if (s!=null&&s.Length>0)
            {
                try
                {
                    nums=long.Parse( s );
                }
                catch (Exception)
                {
                    nums=-2;
                    return -2;
                }
            }
            return nums;
        }

        public static long GetInvNo( InvoiceNo inv )
        {
            return inv.TP;
        }

        public static string GetInvoiceNo( int old, int newno, string sp )
        {  //C33 IN 500001
            InvoiceNo inv = new InvoiceNo
            {
                TP=newno,
                SP=sp
            };
            return inv.ToString();
        }

        public static string GetInvoiceNo( int nos, string sp )
        {  //C33 IN 500001
            InvoiceNo inv = new InvoiceNo
            {
                TP=nos,
                SP=sp
            };
            return inv.ToString();
        }

        public static InvoiceNo GetNewInvoviceNo( int oldinv, string sp )
        {
            InvoiceNo inv = new InvoiceNo
            {
                TP=oldinv+1,
                SP=sp
            };
            return inv;
        }
    }
    internal class Salary
    {
        public int ID { get; set; }
        public double BasicSalary { get; set; }
        public double ExtraSalary { get; set; }
        public Incentive IncentiveID { get; set; }
    }
    public class NewCustomer
    {
        public int ID { set; get; }
        public int CustomerID { set; get; }
        public string InvoiceNo { set; get; }
        public DateTime OnDate { set; get; }
        public string CustomerFullName { get; set; }
    }
    internal class PaySlip
    {
        public int ID { get; set; }
        public int EmpCode { get; set; }
        public EmpType EmpTyee { get; set; }
        public int NoOfWorkingDay { get; set; }
        public int Attendence { get; set; }
        public int Leaves { get; set; }
        public int NoofPaidLeave { get; set; }
        public int MedicalLeaves { get; set; }
        public int CasualLeave { get; set; }
        public Salary SalaryID { get; set; }
        public double BasicSalary { get; set; }
        public double Incentive { get; set; }
        public string StandDeducationDetails { get; set; }
        public double StandardDeducation { get; set; }
        public double NetSalary { get; set; }
        public double AspireBonus { get; set; }
        public string OtherDeducationsDetails { get; set; }
        public double OtherDeducations { get; set; }
        public double FinalPayment { get; set; }
    }

    public class SaleInfo
    {
        public string TodaySale { get; set; }
        public string MonthlySale { get; set; }
        public string YearlySale { get; set; }
    }
    internal class Stores
    {
        public int _ID { get; set; }
        public string StoreName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PinCode { get; set; }
        public string PhoneNo { get; set; }
        public string StoreManagerName { get; set; }
        public string StoreManagerPhoneNo { get; set; }
        public string GSTNO { get; set; }
        public int NoOfEmployees { get; set; }
        public DateTime OpeningDate { get; set; }
        public DateTime ClosingDate { get; set; }
        public string Status { get; set; }
    }


}

