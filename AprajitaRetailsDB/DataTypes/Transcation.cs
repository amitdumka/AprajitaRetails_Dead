using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AprajitaRetailsDB.DataTypes
{
    class Transcation
    {
    }
    /// <summary>
    /// Transcation Type
    /// </summary>
    public class TranscationType
    {
        public static readonly int Cash = 7;
        public static readonly int Cheque = 1;
        public static readonly int RTGS = 2;
        public static readonly int NEFT = 3;
        public static readonly int IMPS = 4;
        public static readonly int UPI = 5;
        public static readonly int PaymentAPP = 6;
        public static readonly int BankTransfer = 8;
        public static readonly int Others = 9;

        public static List<string> ToList( )
        {
            List<string> list = new List<string>();
            Type t = typeof( TranscationType );

            foreach (FieldInfo p in t.GetFields())
            {
                list.Add( p.Name );
            }
            return list;
        }
    }
}
