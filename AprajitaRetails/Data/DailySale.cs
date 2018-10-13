using System;

namespace AprajitaRetails.Data
{
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
            this.SP = sp;
        }

        public InvoiceNo( string sp, long tp )
        {
            this.SP = sp;
            this.TP = tp;
        }

        public override string ToString( )
        {
            return FP + SP + TP;
        }

        public static string GetInvoiceNo( int old, int newno )
        {  //C33 IN 500001
            InvoiceNo inv = new InvoiceNo
            {
                TP = newno
            };
            return inv.ToString();
        }

        public static string GetInvoiceNo( int nos )
        {  //C33 IN 500001
            InvoiceNo inv = new InvoiceNo
            {
                TP = nos
            };
            return inv.ToString();
        }

        public static InvoiceNo GetNewInvoviceNo( int oldinv )
        {
            InvoiceNo inv = new InvoiceNo
            {
                TP = oldinv + 1
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
            string s = inv.Substring(5).Trim();
            long nums = -1;
            if (s != null && s.Length > 0)
            {
                try
                {
                    nums = long.Parse(s);
                }
                catch (Exception)
                {
                    nums = -2;
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
                TP = newno,
                SP = sp
            };
            return inv.ToString();
        }

        public static string GetInvoiceNo( int nos, string sp )
        {  //C33 IN 500001
            InvoiceNo inv = new InvoiceNo
            {
                TP = nos,
                SP = sp
            };
            return inv.ToString();
        }

        public static InvoiceNo GetNewInvoviceNo( int oldinv, string sp )
        {
            InvoiceNo inv = new InvoiceNo
            {
                TP = oldinv + 1,
                SP = sp
            };
            return inv;
        }
    }

    public class SaleInfo
    {
        public string TodaySale { get; set; }
        public string MonthlySale { get; set; }
        public string YearlySale { get; set; }
    }

    public class DailySale
    {
        public int ID { set; get; }
        public DateTime SaleDate { set; get; }
        public int CustomerID { set; get; }
        public string InvoiceNo { set; get; }
        public double Amount { set; get; }
        public double Discount { set; get; }
        public int RMZ { set; get; }
        public int Fabric { set; get; }
        public int Tailoring { set; get; }
        public int PaymentMode { set; get; }
    }

    internal class Discounts
    {
        public int ID { set; get; }
        public string DiscountCode { set; get; }
    }

    internal class DiscountCodeGenerator
    {
        public int ID { set; get; }
        public string DiscountCode { set; get; }
        public DateTime GenDate { set; get; }
        //TODO: Implement with full secure
    }
}