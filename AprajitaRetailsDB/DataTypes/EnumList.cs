using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Drawing.Printing;
using static AprajitaRetailsDB.DataTypes.EnumList;

namespace AprajitaRetailsDB.DataTypes
{
    //TODO: Create in Shared Code 
   public  class EnumList
    {
        public enum SaleInvoiceTypes
        {
            Regular=1, Manual=2,SalesReturn=3,Tailoring=4,Others=5
        }
        public enum SalePayMode { Cash = 1, Card = 2, Mix = 3 }
        public enum TaxType { Vat = 0, Gst = 1, SGST = 2, CGST = 3, IGST = 4 }
    }
    public class UtilOps
    {
       // public static string PrinterName = new PrintDocument().PrinterSettings.PrinterName;

        public static int TaxMode( TaxType taxType )
        {
            switch (taxType)
            {
                case TaxType.IGST:
                    return 4;

                case TaxType.Gst:
                    return 1;

                case TaxType.CGST:
                    return 3;

                case TaxType.SGST:
                    return 2;

                case TaxType.Vat:
                    return 0;

                default:
                    return -999;
            }
        }

        public static TaxType TaxMode( int taxType )
        {
            switch (taxType)
            {
                case 4:
                    return TaxType.IGST;

                case 1:
                    return TaxType.Gst;

                case 3:
                    return TaxType.CGST;

                case 2:
                    return TaxType.SGST;

                case 0:
                    return TaxType.Vat;

                default:
                    return TaxType.Gst;
            }
        }

        /// <summary>
        /// Get Sale Payment Mode
        /// </summary>
        /// <param name="mode"></param>
        /// <returns>return Mode in interger , on error returns 1(Cash)</returns>
        public static int GetSalePayMode( SalePayMode mode )
        {
            if (mode==SalePayMode.Card)
                return 2;
            if (mode==SalePayMode.Cash)
                return 1;
            if (mode==SalePayMode.Mix)
                return 3;
            return 1;
        }

        /// <summary>
        /// SalePayMode
        /// </summary>
        /// <param name="mode"></param>
        /// <returns> Return Sale Payment mode, default or on error return cash</returns>
        public static SalePayMode GetSalePayMode( int mode )
        {
            if (mode==1)
                return SalePayMode.Cash;
            if (mode==2)
                return SalePayMode.Card;
            if (mode==3)
                return SalePayMode.Mix;
            return SalePayMode.Cash;
        }
    }
    public class CardType
    {
        public static readonly int Visa = 1;
        public static readonly int MasterCard = 2;
        public static readonly int Mastro = 3;
        public static readonly int Amex = 4;
        public static readonly int Dinners = 5;
        public static readonly int Rupay = 6;
    }
}
