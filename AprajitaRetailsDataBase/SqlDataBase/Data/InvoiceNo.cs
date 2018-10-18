using System;

namespace AprajitaRetailsDataBase.SqlDataBase.Data
{
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
}