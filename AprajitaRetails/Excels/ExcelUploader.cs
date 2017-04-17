﻿using Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AprajitaRetails
{
    public class ExcelUploader
    {
        public string FileName { get; set; }
        private ExcelToDB DB;

        public ExcelUploader()
        {
            DB = new ExcelToDB ();
        }

        private int AddColSale(Cell cell, ref SaleItemWise sr, int c)
        {
            Logs.LogMe ("cell(" + cell.ColumnIndex + ")=" + cell.Text);
            switch ( cell.ColumnIndex )
            {
                case 0:
                    sr.InvoiceNo = cell.Text;
                    c++;
                    break;
                case 1:
                    sr.InvDate = DataConvertor.DateFromExcelFormatString (cell.Text);
                    c++;
                    break;
                case 2:
                    sr.InvType = cell.Text;
                    c++;
                    break;
                case 3:
                    sr.BrandName = cell.Text;
                    c++;
                    break;
                case 4:
                    sr.ProductName = cell.Text;
                    c++;
                    break;
                case 5:
                    sr.ItemDesc = cell.Text;
                    c++;
                    break;
                case 6:
                    sr.Barcode = cell.Text;
                    c++;
                    break;
                case 7:
                    sr.StyleCode = cell.Text;
                    c++;
                    break;
                case 8:
                    sr.QTY = (int) cell.Amount;
                    c++;
                    break;
                case 9:
                    sr.MRP = cell.Amount;
                    c++;
                    break;
                case 10:
                    sr.BasicRate = cell.Amount;
                    c++;
                    break;
                case 11:
                    sr.Discount = cell.Amount;
                    c++;
                    break;
                case 12:
                    sr.Tax = cell.Amount;
                    c++;
                    break;
                case 14:
                    sr.RoundOff = cell.Amount;
                    c++;
                    break;
                case 13:
                    sr.LineTotal = cell.Amount;
                    c++;
                    break;
                case 15:
                    sr.BillAmnt = cell.Amount;
                    c++;
                    break;
                case 16:
                    sr.Saleman = cell.Text;
                    c++;
                    break;
                case 17:
                    sr.PaymentType = cell.Text;
                    c++;
                    break;
            }

            return c;
        }

        private int AddCol(Cell cell, ref SaleRegister sr, int c)
        {
            Logs.LogMe ("cell(" + cell.ColumnIndex + ")=" + cell.Text);
            switch ( cell.ColumnIndex )
            {
                case 0:
                    sr.InvoiceNo = cell.Text;
                    c++;
                    break;
                case 1:
                    sr.InvDate = DataConvertor.DateFromExcelFormatString (cell.Text);
                    c++;
                    break;
                case 2:
                    sr.InvType = cell.Text;
                    c++;
                    break;
                case 3:
                    sr.QTY = (int) cell.Amount;
                    c++;
                    break;
                case 4:
                    sr.MRP = cell.Amount;
                    c++;
                    break;
                case 6:
                    sr.BasicRate = cell.Amount;
                    c++;
                    break;
                case 5:
                    sr.Discount = cell.Amount;
                    c++;
                    break;
                case 7:
                    sr.Tax = cell.Amount;
                    c++;
                    break;
                case 8:
                    sr.RoundOff = cell.Amount;
                    c++;
                    break;
                case 9:
                    sr.BillAmnt = cell.Amount;
                    c++;
                    break;
                case 10:
                    sr.paymentType = cell.Text;
                    c++;
                    break;
                    // case 11: sr.coupon = cell.Text; c++; break; case 12: sr.couponAmt = cell.Text;
                    // c++; break; case 13: sr.LP = cell.Value; c++; break; case 14: sr.instaorder =
                    // cell.Text; c++; break; case 15: sr.Tailoring = cell.Text; c++; break;
            }

            return c;
        }

        private int I(string num)
        {
            return Int32.Parse (num.Trim ());
        }

        private int AddColPurchase(Cell cell, ref Purchase sr, int c)
        {
            Logs.LogMe ("cell(" + cell.ColumnIndex + ")=" + cell.Text);
            switch ( cell.ColumnIndex )
            {
                case 0:
                    sr.Grnno = cell.Text;
                    c++;
                    break;
                case 1:
                    sr.Grndate = DataConvertor.DateFromExcelFormat (cell.Text);
                    c++;
                    break;
                case 2:
                    sr.Invoiceno = cell.Text;
                    c++;
                    break;
                case 3:
                    sr.Invdate = DataConvertor.DateFromExcelFormat (cell.Text);
                    c++;
                    break;
                case 4:
                    sr.Suppliername = cell.Text;
                    c++;
                    break;
                case 6:
                    sr.Barcode = cell.Text;
                    c++;
                    break;
                case 5:
                    sr.Productname = cell.Text;
                    c++;
                    break;
                case 7:
                    sr.Stylecode = cell.Text;
                    c++;
                    break;
                case 8:
                    sr.Itemdesc = cell.Text;
                    c++;
                    break;
                case 9:
                    sr.Qty = cell.Amount;
                    c++;
                    break;
                case 10:
                    sr.Mrp = cell.Amount;
                    c++;
                    break;
                case 11:
                    sr.Mrpvalue = cell.Amount;
                    c++;
                    break;
                case 12:
                    sr.Cost = cell.Amount;
                    c++;
                    break;
                case 13:
                    sr.Costvalue = cell.Amount;
                    c++;
                    break;
                case 14:
                    sr.Taxamt = cell.Amount;
                    c++;
                    break;
            }

            return c;
        }

        public int ReadDataSaleRegister(string fname, int start, int end, ProgressBar pBar)
        {
            DataTable dt = new DataTable ("SalesRegister");
            int Row = 0;
            int r = 0, c = 0;
            SaleRegister sr;
            Logs.LogMe ("Started reading");
            foreach ( var worksheet in Workbook.Worksheets (fname) )
            {
                Logs.LogMe (worksheet.ToString ());

                foreach ( var row in worksheet.Rows )
                {
                    Logs.LogMe ("Row=" + row.ToString () + "RowNo=" + Row);
                    if ( Row <= end )
                    {
                        if ( Row >= start )
                        {
                            Logs.LogMe ("iRow=" + r);
                            sr = new SaleRegister ();
                            c = 0;
                            foreach ( var cell in row.Cells )
                            {
                                if ( cell != null )
                                {
                                    c = AddCol (cell, ref sr, c);
                                }
                                else
                                {
                                    Logs.LogMe ("C=" + c + "Null");
                                }
                                c++;
                            }
                            if ( DB.SaveRowData (sr) > 0 )
                            {
                                r++;
                                pBar.BeginInvoke (new Action (() =>
                                  {
                                      pBar.PerformStep ();
                                  }));
                                Logs.LogMe ("Row=" + r + " got saved");
                                //if (InvokeRequired)
                                //{
                                //    this.Invoke((MethodInvoker)delegate { pBar.PerformStep(); });
                                //}
                            }
                        }
                        Row++;
                        Logs.LogMe ("Row will be" + Row + "\tr=" + r);
                    }
                    else
                    {
                        Logs.LogMe ("End Target Matched , Breaking out now");
                        break;
                    }
                }
            }
            Logs.LogMe ("end , record=" + r);
            return r;
        }
        public int ReadPurchase(string fname, int start, int end, ProgressBar pBar)
        {
            DataTable dt = new DataTable ("SalesRegister");
            int Row = 0;
            int r = 0, c = 0;
            Purchase sr;
            Logs.LogMe ("Started Reading");
            foreach ( var worksheet in Workbook.Worksheets (fname) )
            {
                Logs.LogMe (worksheet.ToString ());

                foreach ( var row in worksheet.Rows )
                {
                    Logs.LogMe ("Row=" + row.ToString () + "RowNo=" + Row);
                    if ( Row <= end )
                    {
                        if ( Row >= start )
                        {
                            Logs.LogMe ("iRow=" + r);
                            sr = new Purchase ();
                            c = 0;
                            foreach ( var cell in row.Cells )
                            {
                                if ( cell != null )
                                {
                                    c = AddColPurchase (cell, ref sr, c);
                                }
                                else
                                {
                                    Logs.LogMe ("C=" + c + "Null");
                                }
                                c++;
                            }
                            if ( DB.SaveRowData (sr) > 0 )
                            {
                                r++;
                                pBar.BeginInvoke (new Action (() =>
                                  {
                                      pBar.PerformStep ();
                                  }));
                                Logs.LogMe ("Row=" + r + " got saved");
                                //if (InvokeRequired)
                                //{
                                //    this.Invoke((MethodInvoker)delegate { pBar.PerformStep(); });
                                //}
                            }
                        }
                        Row++;
                        Logs.LogMe ("Row will be" + Row + "\tr=" + r);
                    }
                    else
                    {
                        Logs.LogMe ("End Target Matched , Breaking out now");
                        break;
                    }
                }
            }
            Logs.LogMe ("End of line");
            return r;
        }

    }
}

