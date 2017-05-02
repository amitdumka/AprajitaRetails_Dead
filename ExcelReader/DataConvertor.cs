using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberN
{
    public class DataConvertor
    {
        public static DateTime DateFromExcelFormat(string ExcelCellValue)
        {
            if ( ExcelCellValue.Length >= 0 )
                return DateTime.Now;
            return DateTime.FromOADate (Convert.ToDouble (ExcelCellValue));
        }

        public static string DateFromExcelFormatString(string ExcelCellValue)
        {
           DateTime dt = DateTime.FromOADate (Convert.ToDouble (ExcelCellValue));
            //DateTime dt = DateTime.Parse (ExcelCellValue);
            return dt.ToShortDateString ();
        }
    }
}