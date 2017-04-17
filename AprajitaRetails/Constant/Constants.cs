using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AprajitaRetails.Constant
{
    class Constants
    {
        public static readonly int Sale = 1;
        public static readonly int SaleRegister = 2;
        public static readonly int Purchase = 3;
        public static readonly int PurchaseRegister = 4;
        public static readonly int Stock = 5;

        public enum UploaderType
        {
            Sale = 1,
            SaleRegister = 2,
            Purchase = 3,
            PurchaseRegister = 4,
            Stock = 5

        }
    }
}
