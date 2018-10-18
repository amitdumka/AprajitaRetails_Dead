using System;

//This Project is final.
// There will hardly change. Currently Closed.
// Version 2:Distributed Model
namespace CyberN.ExcelReader
{
    /// <summary>
    ///
    /// </summary>
    public class DataConvertor
    {
        public static DateTime DateFromExcelFormat( string ExcelCellValue )
        {
            if (ExcelCellValue.Length >= 0)
                return DateTime.Now;
            return DateTime.FromOADate(Convert.ToDouble(ExcelCellValue));
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="ExcelCellValue"></param>
        /// <returns></returns>
        public static string DateFromExcelFormatString( string ExcelCellValue )
        {
            DateTime dt = DateTime.FromOADate(Convert.ToDouble(ExcelCellValue));
            //DateTime dt = DateTime.Parse (ExcelCellValue);
            return dt.ToShortDateString();
        }
    }
}