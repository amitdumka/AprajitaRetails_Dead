using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AprajitaRetails.ViewModel;
using CyberN;


namespace AprajitaRetails.Excels
{
    public class Querys
    {
        // TODO: Not be part of final realse. 
        //TODO: better verison of reporting can be done on based on this
        public static string qAll = "select* from SalesRegister";
        public static string qAllPurchase = "select * from Purchase";
        public static string qByDay = "select InvoiceDate, sum(Qty) as QTY, sum(MRP) as MRP, SUM(Discount) as Discount, Sum(TaxAmount) as Tax, Sum(BillAmount) as BillAmount from SalesRegister group by InvoiceDate";
        public static string qByDayP = "select InvoiceDate , Sum(MRP) as MRP,sum(Discount) as Dis, sum(BillAmount) as Bill,sum(TaxAmount) as Tax, Sum(MRP)*0.40-sum(Discount)-sum(TaxAmount) as Pro From SalesRegister Group by InvoiceDate";
        public static string qByMonth = "select  DATEPART(MM, InvoiceDate)as Month, sum(Qty) as QTY, sum(MRP) as MRP, SUM(Discount) as Discount, Sum(TaxAmount) as Tax, Sum(BillAmount) as BillAmount from SalesRegister group by DATEPART(MM, InvoiceDate)";
        public static string qByMonthP = "select DATEPART(MM, InvoiceDate)as Month , Sum(MRP) as MRP,sum(Discount) as Dis, sum(BillAmount) as Bill,sum(TaxAmount) as Tax, Sum(MRP)*0.40-sum(Discount)-sum(TaxAmount) as Pro From SalesRegister Group by DATEPART(MM, InvoiceDate)";
        public static string qByYear = "select  DATEPART(YEAR, InvoiceDate)as Year, sum(Qty) as QTY, sum(MRP) as MRP, SUM(Discount) as Discount, Sum(TaxAmount) as Tax, Sum(BillAmount) as BillAmount from SalesRegister group by DATEPART(YEAR, InvoiceDate)";
        public static string qByYearP = "select DATEPART(YEAR, InvoiceDate)as Year,  Sum(MRP) as MRP,sum(Discount) as Dis, sum(BillAmount) as Bill,sum(TaxAmount) as Tax, Sum(MRP)*0.40-sum(Discount)-sum(TaxAmount) as Pro From SalesRegister Group by DATEPART(Year, InvoiceDate)";
    }

    public class QuerySales
    {
        // TODO: Not be part of final realse. 
        //TODO: better verison of reporting can be done on based on this
        public static string qAll = "select* from Sales";
        public static string qByDay = "select InvoiceDate, sum(Qty) as QTY, sum(MRP) as MRP, SUM(Discount) as Discount, Sum(TaxAmount) as Tax, Sum(BillAmount) as BillAmount from Sales group by InvoiceDate";
        public static string qByDayP = "select InvoiceDate , Sum(MRP) as MRP,sum(Discount) as Dis, sum(BillAmount) as Bill,sum(TaxAmount) as Tax, Sum(MRP)*0.40-sum(Discount)-sum(TaxAmount) as Pro From Sales Group by InvoiceDate";
        public static string qByMonth = "select  DATEPART(MM, InvoiceDate)as Month, sum(Qty) as QTY, sum(MRP) as MRP, SUM(Discount) as Discount, Sum(TaxAmount) as Tax, Sum(BillAmount) as BillAmount from SalesRegister group by DATEPART(MM, InvoiceDate)";
        public static string qByMonthP = "select DATEPART(MM, InvoiceDate)as Month , Sum(MRP) as MRP,sum(Discount) as Dis, sum(BillAmount) as Bill,sum(TaxAmount) as Tax, Sum(MRP)*0.40-sum(Discount)-sum(TaxAmount) as Pro From Sales Group by DATEPART(MM, InvoiceDate)";
        public static string qByYear = "select  DATEPART(YEAR, InvoiceDate)as Year, sum(Qty) as QTY, sum(MRP) as MRP, SUM(Discount) as Discount, Sum(TaxAmount) as Tax, Sum(BillAmount) as BillAmount from SalesRegister group by DATEPART(YEAR, InvoiceDate)";
        public static string qByYearP = "select DATEPART(YEAR, InvoiceDate)as Year,  Sum(MRP) as MRP,sum(Discount) as Dis, sum(BillAmount) as Bill,sum(TaxAmount) as Tax, Sum(MRP)*0.40-sum(Discount)-sum(TaxAmount) as Pro From Sales Group by DATEPART(Year, InvoiceDate)";
        //public static string qAllPurchase = "select * from Purchase";
    }

    class Cust
    {
        public Cust()
        {
            Gen = 0;
            FirstName = "";
            LastName = "";
            Address = "";
            MobileNo = "";
        }

        public string Address { get; set; }
        public string FirstName { get; set; }
        public int Gen { get; set; }
        public string LastName { get; set; }
        public string MobileNo { get; set; }
    }

    class ExcelToDataBase
    {
        ObjectToDataBase Db;
        public ExcelToDataBase()
        {
            Db = new ObjectToDataBase();
        }

        public string FileName { get; set; }
                public int ReadCustomer(string fname, int start, int end, ProgressBar pBar, string tablename)
        {
            DataTable dt = new DataTable(tablename);
            int Row = 0;
            int r = 0, c = 0;
            Cust sr;
            Logs.LogMe("Started Reading Excel Sheet for table: " + tablename);
            foreach (var worksheet in Workbook.Worksheets(fname))
            {
                Logs.LogMe(worksheet.ToString());

                foreach (var row in worksheet.Rows)
                {
                    Logs.LogMe("Row=" + row.ToString() + "RowNo=" + Row);
                    if (Row <= end)
                    {
                        if (Row >= start)
                        {
                            Logs.LogMe("iRow=" + r);
                            sr = new Cust();
                            c = 0;
                            foreach (var cell in row.Cells)
                            {
                                if (cell != null)
                                {
                                    c = AddColCustomer(cell, ref sr, c);
                                }
                                else
                                {
                                    Logs.LogMe("C=" + c + "Null");
                                }
                                c++;
                            }
                            if (Db.SaveRowData(sr) > 0)
                            {
                                r++;
                                pBar.BeginInvoke(new Action(() =>
                              {
                                  pBar.PerformStep();
                              }));
                                Logs.LogMe("Row=" + r + " got saved");

                            }
                        }
                        Row++;
                        Logs.LogMe("Row will be" + Row + "\tr=" + r);
                    }
                    else
                    {
                        Logs.LogMe("End Target Matched , Breaking out now");
                        break;
                    }
                }
            }
            Logs.LogMe("End of line");
            return r;
        }

        // Reader Caller Section Start Here 
        public int ReadDataSaleRegister(string fname, int start, int end, ProgressBar pBar, string tablename)
        {
            //GST Features Added
            DataTable dt = new DataTable(tablename);
            int Row = 0;
            int r = 0, c = 0;
            SaleRegister sr;
            Logs.LogMe("Started reading");
            foreach (var worksheet in Workbook.Worksheets(fname))
            {
                Logs.LogMe(worksheet.ToString());

                foreach (var row in worksheet.Rows)
                {
                    //Logs.LogMe ("Row=" + row.ToString () + "RowNo=" + Row);
                    if (Row <= end)
                    {
                        if (Row >= start)
                        {
                            Logs.LogMe("iRow=" + r);
                            sr = new SaleRegister();
                            c = 0;
                            foreach (var cell in row.Cells)
                            {
                                if (cell != null)
                                {
                                    c = AddCol(cell, ref sr, c);
                                }
                                else
                                {
                                    Logs.LogMe("C=" + c + "Null");
                                }
                                c++;
                            }
                            if (Db.SaveRowData(sr) > 0)
                            {
                                r++;
                                pBar.BeginInvoke(new Action(() =>
                              {
                                  pBar.PerformStep();
                              }));
                                Logs.LogMe("Row=" + r + " got saved");

                            }
                        }
                        Row++;
                        // Logs.LogMe ("Row will be" + Row + "\tr=" + r);
                    }
                    else
                    {
                        Logs.LogMe("End Target Matched , Breaking out now");
                        break;
                    }
                }
            }
            Logs.LogMe("end , record=" + r);
            return r;
        }

        public int ReadDataSales(string fname, int start, int end, ProgressBar pBar, string tablename)
        {
            //TODO: GST Sale Invoice is implemented. Fine tune can be done in future.
            DataTable dt = new DataTable(tablename);

            int Row = 0;
            int r = 0, c = 0;
            SaleItemWise sr;
            Logs.LogMe("Started reading");
            foreach (var worksheet in Workbook.Worksheets(fname))
            {

                foreach (var row in worksheet.Rows)
                {
                    // Logs.LogMe ("Row=" + row.ToString () + "RowNo=" + Row);
                    if (Row <= end)
                    {
                        if (Row >= start)// TODO: It will Start from 8 . Do check execl file
                        {
                            //       Logs.LogMe ("iRow=" + r);
                            sr = new SaleItemWise();
                            c = 0;
                            foreach (var cell in row.Cells)
                            {
                                if (cell != null)
                                {
                                    c = AddColSale(cell, ref sr, c);
                                }
                                else
                                {
                                    if (c == 6)
                                        Logs.LogMe("C=" + c + " is Null");
                                    c++;

                                }

                            }
                            if (Db.SaveRowData(sr) > 0)
                            {
                                r++;
                                pBar.BeginInvoke(new Action(() =>
                              {
                                  pBar.PerformStep();
                              }));
                                Logs.LogMe("Row=" + r + " got saved");

                            }
                        }
                        Row++;
                        // Logs.LogMe ("Row will be" + Row + "\tr=" + r);
                    }
                    else
                    {
                        Logs.LogMe("End Target Matched , Breaking out now");
                        break;
                    }
                }
                break;
            }
            Logs.LogMe("end , record=" + r);
            return r;
        }

        public int ReadPurchase(string fname, int start, int end, ProgressBar pBar, string tablename)
        {
            DataTable dt = new DataTable(tablename);
            int Row = 0;
            int r = 0, c = 0;
            Purchase sr;
            Logs.LogMe("Started Reading Excel Sheet");
            foreach (var worksheet in Workbook.Worksheets(fname))
            {
                Logs.LogMe(worksheet.ToString());

                foreach (var row in worksheet.Rows)
                {
                    Logs.LogMe("Row=" + row.ToString() + "RowNo=" + Row);
                    if (Row <= end)
                    {
                        if (Row >= start)
                        {
                            Logs.LogMe("iRow=" + r);
                            sr = new Purchase();
                            c = 0;
                            foreach (var cell in row.Cells)
                            {
                                if (cell != null)
                                {
                                    c = AddColPurchase(cell, ref sr, c);
                                    
                                }
                                else
                                {
                                    Logs.LogMe("C=" + c + "Null");
                                }
                                c++;
                            }
                            if (Db.SaveRowData(sr) > 0)
                            {
                                r++;
                                pBar.BeginInvoke(new Action(() =>
                              {
                                  pBar.PerformStep();
                              }));
                                Logs.LogMe("Row=" + r + " got saved");

                            }
                        }
                        Row++;
                        Logs.LogMe("Row will be" + Row + "\tr=" + r);
                    }
                    else
                    {
                        Logs.LogMe("End Target Matched , Breaking out now");
                        break;
                    }
                }
            }
            Logs.LogMe("End of line");
            return r;
        }

        // Extra Functions start from here
        

        private int AddCol(Cell cell, ref SaleRegister sr, int c)
        {
            //Logs.LogMe ("cell(" + cell.ColumnIndex + ")=" + cell.Text);
            switch (cell.ColumnIndex)
            {
                case 0:
                    sr.InvoiceNo = cell.Text;
                    c++;
                    break;
                case 1:
                    sr.InvDate = DataConvertor.DateFromExcelFormatString(cell.Text);
                    c++;
                    break;
                case 2:
                    sr.InvType = cell.Text;
                    c++;
                    break;
                case 3:
                    sr.QTY = (int)cell.Amount;
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

        // Adding Col start from Here
        private int AddColCustomer(Cell cell, ref Cust sr, int c)
        {
            Logs.LogMe("Customer:cell(" + cell.ColumnIndex + ")=" + cell.Text);
            switch (cell.ColumnIndex)
            {
                case 6:
                    sr.FirstName = cell.Text;
                    c++;
                    break;
                case 7:
                    sr.Address = cell.Text;
                    c++;
                    break;
                case 8:
                    sr.MobileNo = cell.Text;
                    c++;
                    break;
                    //case 3:
                    //    sr.QTY = (int) cell.Amount;
                    //    c++;
                    //    break;
                    //case 4:
                    //    sr.MRP = cell.Amount;
                    //    c++;
                    //    break;
                    //case 6:
                    //    sr.BasicRate = cell.Amount;
                    //    c++;
                    //    break;
                    //case 5:
                    //    sr.Discount = cell.Amount;
                    //    c++;
                    //    break;
                    //case 7:
                    //    sr.Tax = cell.Amount;
                    //    c++;
                    //    break;
                    //case 8:
                    //    sr.RoundOff = cell.Amount;
                    //    c++;
                    //    break;
                    //case 9:
                    //    sr.BillAmnt = cell.Amount;
                    //    c++;
                    //    break;
                    //case 10:
                    //    sr.paymentType = cell.Text;
                    //    c++;
                    //    break;
                    //    // case 11: sr.coupon = cell.Text; c++; break; case 12: sr.couponAmt = cell.Text;
                    // c++; break; case 13: sr.LP = cell.Value; c++; break; case 14: sr.instaorder =
                    // cell.Text; c++; break; case 15: sr.Tailoring = cell.Text; c++; break;
            }

            return c;
        }

        private int AddColPurchase(Cell cell, ref Purchase sr, int c)
        {
            Logs.LogMe("cell(" + cell.ColumnIndex + ")=" + cell.Text);
            switch (cell.ColumnIndex)
            {
                case 0:
                    sr.GRNNo = cell.Text;
                    c++;
                    break;
                case 1:
                    sr.GRNDate = DataConvertor.DateFromExcelFormat(cell.Text);
                    c++;
                    break;
                case 2:
                    sr.InvoiceNo = cell.Text;
                    c++;
                    break;
                case 3:
                    sr.InvoiceDate = DataConvertor.DateFromExcelFormat(cell.Text);
                    c++;
                    break;
                case 4:
                    sr.SupplierName = cell.Text;
                    c++;
                    break;
                case 5:
                    sr.Barcode = cell.Text;
                    c++;
                    break;
                case 6:
                    sr.ProductName= cell.Text;
                    c++;
                    break;
                case 7:
                    sr.StyleCode = cell.Text;
                    c++;
                    break;
                case 8:
                    sr.ItemDesc = cell.Text;
                    c++;
                    break;
                case 9:
                    sr.Quantity = cell.Amount;
                    c++;
                    break;
                case 10:
                    sr.MRP = cell.Amount;
                    c++;
                    break;
                case 11:
                    sr.MRPValue = cell.Amount;
                    c++;
                    break;
                case 12:
                    sr.Cost = cell.Amount;
                    c++;
                    break;
                case 13:
                    sr.CostValue = cell.Amount;
                    c++;
                    break;
                case 14:
                    sr.TaxAmt = cell.Amount;
                    c++;
                    break;
            }

            return c;
        }

        private int AddColSale(Cell cell, ref SaleItemWise sr, int c)
        {
            switch (cell.ColumnIndex)
            {
                case 0:
                    //Logs.LogMe("cell(" + cell.ColumnIndex + ")=" + cell.Text);
                    sr.InvoiceNo = cell.Text;
                    c++;
                    break;
                case 1:
                    //Logs.LogMe ("cell(" + cell.ColumnIndex + ")=" + cell.Text);
                    sr.InvDate = cell.Text; //DataConvertor.DateFromExcelFormatString (cell.Text);
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
                    sr.HSNCode = cell.Text;
                    //Logs.LogMe("HSNCode:'" + cell.Text + "'");
                    c++;
                    break;

                case 7:
                    sr.Barcode = cell.Text;
                    c++;
                    break;
                case 8:
                    sr.StyleCode = cell.Text;
                    c++;
                    break;
                case 9:
                    sr.QTY = (int)cell.Amount;
                    c++;
                    break;
                case 10:
                    sr.MRP = cell.Amount;
                    c++;
                    break;
                case 11:
                    sr.Discount = cell.Amount;
                    c++;
                    break;
                case 12:
                    sr.BasicRate = cell.Amount;
                    c++;
                    break;

                case 13:
                    sr.Tax = cell.Amount;
                    c++;
                    break;
                case 14: sr.SGST = cell.Amount; c++; break;
                case 15: sr.CGST = cell.Amount; c++; break;

                case 16:
                    sr.RoundOff = cell.Amount;
                    c++;
                    break;
                case 17:
                    sr.LineTotal = cell.Amount;
                    c++;
                    break;
                case 18:
                    sr.BillAmnt = cell.Amount;
                    c++;
                    break;
                case 19:
                    sr.PaymentType = cell.Text;
                    c++;
                    break;
                case 20:
                    sr.Saleman = cell.Text;
                    c++;
                    break;
                case 25:
                    sr.LP = cell.Text;
                    c++;
                    break;

            }

            return c;
        }

        private int I(string num)
        {
            return Int32.Parse(num.Trim());
        }
    }

    class ObjectToDataBase
    {
        //TODO: Implementing GST Features in All Area. Remove line if completed
        DataBase vDb;
        ObjectToItem vOti;
        public ObjectToDataBase()
        {
            vDb = new DataBase(ConType.SQLDB);
            vOti = new ObjectToItem();
        }

        public bool IsCustomer(string mobile)
        {
            if (mobile == null || mobile.Length <= 0)
                return false;
            string sql = "select count(ID) from Customer where MobileNo=@mob";
            SqlCommand cmd = new SqlCommand(sql, vDb.DBCon);
            cmd.Parameters.AddWithValue("@mob", mobile);
            int x = (int)cmd.ExecuteScalar();
            if (x > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sr"></param>
        /// <returns></returns>
        public int SaveRowData(Cust sr)
        {
            Logs.LogMe("SaveRowData: Customer");
            string[] s;
            //TODO: Cust Insert
            if (sr != null && sr.FirstName.Trim().Length > 0)
            {
                if (!IsCustomer(sr.MobileNo))
                {
                    s = sr.FirstName.Split(' ');
                    if (s.Length > 0)
                        sr.FirstName = s[0] + " " + s[1];
                    if (s[0].ToLower().Contains("mr."))
                        sr.Gen = 1;
                    else if (s[0].ToLower().Contains("mrs.") || s[0].ToLower().Contains("miss."))
                        sr.Gen = 2;
                    for (int i = 2; i < s.Length; i++)
                    {
                        sr.LastName = sr.LastName + " " + s[i];
                    }
                    if (sr.MobileNo.Length <= 0)
                        sr.MobileNo = "NA";
                }
                else
                {
                    return -2;
                }
            }
            else
            {
                return -1;
            }


            string query = "INSERT INTO [dbo].[Customer] " +
                "( [Age], [FirstName], [LastName],  " +
                "[City], [MobileNo], [Gender], [NoOfBills], [TotalAmount]) " +
                " VALUES (@Age,@fname , @lname, @city, @Mob, @gen, @nof, " +
                "@TAMT)";
            SqlCommand cmd = new SqlCommand(query, vDb.DBCon);

            cmd.Parameters.AddWithValue("@fname", sr.FirstName);
            cmd.Parameters.AddWithValue("@lname", sr.LastName);
            cmd.Parameters.AddWithValue("@Mob", sr.MobileNo);
            cmd.Parameters.AddWithValue("@Age", 0);
            cmd.Parameters.AddWithValue("@gen", sr.Gen);
            cmd.Parameters.AddWithValue("@city", sr.Address);
            cmd.Parameters.AddWithValue("@nof", 0);
            cmd.Parameters.AddWithValue("@TAMT", 0);
            Logs.LogMe("Customer:Querry:=>" + query);
            return InsertQuerySql(cmd);
        }

        /// <summary>
        /// Save Row Data
        /// </summary>
        /// <param name="sr"> SaleItemWise object</param>
        /// <returns>return no of record added</returns>
        public int SaveRowData(SaleItemWise sr)
        {
            string query = "INSERT INTO [dbo].[Sales] " +
                "( InvoiceNo, InvoiceDate, InvoiceType,  " +
                "BrandName,ProductName,ItemDescrpetion,HSNCode,BarCode,StyleCode," +
                "Qty, MRP, Discount, BasicAmt, TaxAmount,SGST,CGST, " +
                "RoundOff, LineTotal,BillAmount, Salesman,PaymentMode,LP) " +
                " VALUES (@Inv,@InvD , @InvT, @BName,@PName,@IDes,@hsnCode,@BCode,@SCode," +
                "@QTY, @MRP, @Dis, @BAMT, @TAMT,@SGST, @CGST,  @ROFF,@Ltotal, @BILL,@Sman,  @PM, @lp)";
            Logs.LogMe("SqlQuery=" + query);
            SqlCommand cmd = new SqlCommand(query, vDb.DBCon);
            cmd.Parameters.AddWithValue("@Inv", sr.InvoiceNo);//ok
            cmd.Parameters.AddWithValue("@InvD", sr.InvDate);//ok
            cmd.Parameters.AddWithValue("@InvT", sr.InvType);//ok
            cmd.Parameters.AddWithValue("@hsnCode", sr.HSNCode);//ok
            cmd.Parameters.AddWithValue("@QTY", sr.QTY);//ok
            cmd.Parameters.AddWithValue("@MRP", sr.MRP);//ok
            cmd.Parameters.AddWithValue("@Dis", sr.Discount);//ok
            cmd.Parameters.AddWithValue("@BAMT", sr.BasicRate);//ok
            cmd.Parameters.AddWithValue("@TAMT", sr.Tax);//ok
            cmd.Parameters.AddWithValue("@ROFF", sr.RoundOff);//ok
            cmd.Parameters.AddWithValue("@BILL", sr.BillAmnt);//ok
            cmd.Parameters.AddWithValue("@PM", sr.PaymentType);//ok
            cmd.Parameters.AddWithValue("@Sman", sr.Saleman);//ok
            cmd.Parameters.AddWithValue("@BCode", sr.Barcode);//ok
            cmd.Parameters.AddWithValue("@SCode", sr.StyleCode);//ok
            cmd.Parameters.AddWithValue("@Ltotal", sr.LineTotal);//ok
            cmd.Parameters.AddWithValue("@BName", sr.BrandName);//ok
            cmd.Parameters.AddWithValue("@PName", sr.ProductName);//ok
            cmd.Parameters.AddWithValue("@IDes", sr.ItemDesc);//ok
            cmd.Parameters.AddWithValue("@SGST", sr.SGST);//ok
            cmd.Parameters.AddWithValue("@CGST", sr.CGST);//ok
            cmd.Parameters.AddWithValue("@lp", sr.LP);//ok
            return InsertQuerySql(cmd);
        }

        /// <summary>
        /// Save Row Data
        /// </summary>
        /// <param name="sr">SaleRegister Object</param>
        /// <returns>Return no of Object</returns>
        public int SaveRowData(SaleRegister sr)
        {
            string query = "INSERT INTO [dbo].[SalesRegister] " +
                "( [InvoiceNo], [InvoiceDate], [InvoiceType],  " +
                "[Qty], [MRP], [Discount], [BasicAmt], [TaxAmount], " +
                "[RoundOff], [BillAmount], [PaymentMode]) " +
                /*"[Coupon], [CouponAmt],   [TalioringFlag], " +
                "[InstOrderCD])" +*/
                " VALUES (@Inv,@InvD , @InvT, @QTY, @MRP, @Dis, @BAMT, " +
                "@TAMT,  @ROFF, @BILL,  @PM)";//, @CO,@CAMT,  @TFG, @INST)";
            SqlCommand cmd = new SqlCommand(query, vDb.DBCon);

            cmd.Parameters.AddWithValue("@Inv", sr.InvoiceNo);
            cmd.Parameters.AddWithValue("@InvD", sr.InvDate);
            cmd.Parameters.AddWithValue("@InvT", sr.InvType);
            cmd.Parameters.AddWithValue("@QTY", sr.QTY);
            cmd.Parameters.AddWithValue("@MRP", sr.MRP);
            cmd.Parameters.AddWithValue("@Dis", sr.Discount);
            cmd.Parameters.AddWithValue("@BAMT", sr.BasicRate);
            cmd.Parameters.AddWithValue("@TAMT", sr.Tax);
            cmd.Parameters.AddWithValue("@ROFF", sr.RoundOff);
            cmd.Parameters.AddWithValue("@BILL", sr.BillAmnt);
            cmd.Parameters.AddWithValue("@PM", sr.paymentType);
            //cmd.Parameters.AddWithValue("@CO", sr.coupon);
            //cmd.Parameters.AddWithValue("@CAMT", sr.couponAmt);
            //cmd.Parameters.AddWithValue("@TFG", sr.Tailoring);
            //cmd.Parameters.AddWithValue("@INST", sr.instaorder);
            return InsertQuerySql(cmd);
        }

        /// <summary>
        /// Save Row Data
        /// </summary>
        /// <param name="sr"> Purchase Object</param>
        /// <returns>No of recorded added</returns>
        public int SaveRowData(Purchase sr)
        {
            string query = "insert into Purchase (GRNNo, GRNDate,	InvoiceNo,	InvoiceDate,	SupplierName,	Barcode,	ProductName,	" +
                "StyleCode,  ItemDesc,	Quantity, MRP,	MRPValue	,Cost	,CostValue,	TaxAmt,ImportTime, IsDataConsumed)" +
                "Values(@GRNNo,@GRNDate,@InvoiceNo,@InvoiceDate,@SupplierName,@Barcode,@ProductName,@StyleCode," + "@ItemDesc,@Quantity,@MRP,@MRPValue,@Cost,@CostValue,@TaxAmt, @ImportTime, @IsConsumed)";
            SqlCommand cmd = new SqlCommand(query, vDb.DBCon);

            cmd.Parameters.AddWithValue("@GRNNo", sr.GRNNo );
            cmd.Parameters.AddWithValue("@GRNDate", sr.GRNDate );
            cmd.Parameters.AddWithValue("@InvoiceNo", sr.InvoiceNo);
            cmd.Parameters.AddWithValue("@InvoiceDate", sr.InvoiceDate);
            cmd.Parameters.AddWithValue("@SupplierName", sr.SupplierName);
            cmd.Parameters.AddWithValue("@Barcode", sr.Barcode);
            cmd.Parameters.AddWithValue("@ProductName", sr.ProductName);
            cmd.Parameters.AddWithValue("@StyleCode", sr.StyleCode);
            cmd.Parameters.AddWithValue("@ItemDesc", sr.ItemDesc);
            cmd.Parameters.AddWithValue("@Quantity", sr.Quantity);
            cmd.Parameters.AddWithValue("@MRP", sr.MRP);
            cmd.Parameters.AddWithValue("@MRPValue", sr.MRPValue);
            cmd.Parameters.AddWithValue("@Cost", sr.Cost);
            cmd.Parameters.AddWithValue("@CostValue", sr.CostValue);
            cmd.Parameters.AddWithValue("@TaxAmt", sr.TaxAmt);
            cmd.Parameters.AddWithValue("@ImportTime", sr.ImportTime);
            cmd.Parameters.AddWithValue("@IsConsumed", sr.IsDataConsumed);
            int x = InsertQuerySql(cmd);
            //TODO: do it in thread 
            vOti.PurchaseToStock(sr);
            return x;
        }

        /// <summary>
        /// Insert Query Sql
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        private int InsertQuerySql(SqlCommand cmd)
        {
            try
            {
                int status = cmd.ExecuteNonQuery();
                if (status > 0)
                {
                    Logs.LogMe("Insert done ");
                    return 1;
                }
                else
                {
                    Logs.LogMe("Insert Failed :" + cmd.CommandText);
                    return 0;
                }
            }
            catch (Exception e)
            {
                Logs.LogMe("Insert Error: " + e.Message + "\n\tCommandText" + cmd.CommandText);
                return -1;
            }
        }
    }

    class ObjectToItem
    {
        ProductItemsDB pIDB;
        public ObjectToItem()
        {
            pIDB = new ProductItemsDB();
        }
        public void PurchaseToStock(Purchase p)
        {
            ProductItems pItem = new ProductItems()
            {
                Barcode = p.Barcode,
                Cost = p.Cost,
                SupplierId = p.SupplierName,
                BrandName = "",
                ID = -1,
                ItemDesc = p.ItemDesc,
                MRP = p.MRP,
                Qty = p.Quantity,
                ProductName = p.ProductName,
                Size = ToSize(p.StyleCode),
                StyleCode = p.StyleCode,
                Tax = p.TaxAmt,
                //TODO: GST Correct It
                /*CGST =p.TaxRate,      HSNCode=p.HSNCode,
                IGST=p.TaxRate,SGST=p.TaxRate,PreGST=p.TaxType*/
            };
            Logs.LogMe("Insert of Data is " + pIDB.InsertDataWithVerify(pItem));


        }

        protected string Sizes(string s)
        {
            string r = "";
            s = s.Trim();
            s = s.ToLower();
            switch (s.Length)
            {
                case 1:
                    r = s;
                    break;
                case 2:
                    r = s;
                    break;
                case 3:

                    break;
                case 4:
                    break;
                default:
                    break;
            }
            return r;
        }
        protected string ToSize(string stylecode)
        {
            if (Basic.IsNumeric(stylecode))
            {
                return "-1";
            }
            else if (stylecode.Length > 8)
            {
                //TODO: do verification for is style code.
                string s1 = stylecode.Substring(0, 4);
                string s2 = stylecode.Substring(4, 4);
                string s3 = stylecode.Substring(8);
                return s3;
            }
            //else if ( stylecode.Length > 10 )
            //{
            //    string s1 = stylecode.Substring (0, 4);
            //    string s2 = stylecode.Substring (4, 6);
            //    string s3 = stylecode.Substring (10);
            //    return s3;
            //}
            else
            {
                return "-2";
            }
        }
    }

    //TODO: Implement in second stage
    class PurchaseDB : DataOps<Purchase>
    {
        public override int InsertData(Purchase sr)
        {
            string query = "insert into Purchase (GRNNo, GRNDate,	InvoiceNo,	InvoiceDate,	SupplierName,	Barcode,	ProductName,	" +
              "StyleCode,  ItemDesc,	Quantity, MRP,	MRPValue	,Cost	,CostValue,	TaxAmt,ImportTime, IsDataConsumed)" +
              "Values(@GRNNo,@GRNDate,@InvoiceNo,@InvoiceDate,@SupplierName,@Barcode,@ProductName,@StyleCode," + "@ItemDesc,@Quantity,@MRP,@MRPValue,@Cost,@CostValue,@TaxAmt, @ImportTime, @IsConsumed)";
            SqlCommand cmd = new SqlCommand(query, Db.DBCon);

            cmd.Parameters.AddWithValue("@GRNNo", sr.GRNNo);
            cmd.Parameters.AddWithValue("@GRNDate", sr.GRNDate);
            cmd.Parameters.AddWithValue("@InvoiceNo", sr.InvoiceNo);
            cmd.Parameters.AddWithValue("@InvoiceDate", sr.InvoiceDate);
            cmd.Parameters.AddWithValue("@SupplierName", sr.SupplierName);
            cmd.Parameters.AddWithValue("@Barcode", sr.Barcode);
            cmd.Parameters.AddWithValue("@ProductName", sr.ProductName);
            cmd.Parameters.AddWithValue("@StyleCode", sr.StyleCode);
            cmd.Parameters.AddWithValue("@ItemDesc", sr.ItemDesc);
            cmd.Parameters.AddWithValue("@Quantity", sr.Quantity);
            cmd.Parameters.AddWithValue("@MRP", sr.MRP);
            cmd.Parameters.AddWithValue("@MRPValue", sr.MRPValue);
            cmd.Parameters.AddWithValue("@Cost", sr.Cost);
            cmd.Parameters.AddWithValue("@CostValue", sr.CostValue);
            cmd.Parameters.AddWithValue("@TaxAmt", sr.TaxAmt);
            cmd.Parameters.AddWithValue("@ImportTime", sr.ImportTime);
            cmd.Parameters.AddWithValue("@IsConsumed", sr.IsDataConsumed);
            return cmd.ExecuteNonQuery();
        }

        public override Purchase ResultToObject(List<Purchase> data, int index)
        {
            throw new NotImplementedException();
        }

        public override Purchase ResultToObject(SortedDictionary<string, string> data)
        {
            throw new NotImplementedException();
        }

        public override List<Purchase> ResultToObject(List<SortedDictionary<string, string>> dataList)
        {
            throw new NotImplementedException();
        }
    }

    class UploaderFormVM
    {
        private SqlDataAdapter dataAdapter = new SqlDataAdapter();
        private DataTable UploadedDataTable;
        private BindingSource UploaedDataBindingSource;
        public DataGridView UploadedDataGrid { get; private set; }
        public void RefreshDGV(DataGridView dgv, string query)
        {
            UploadedDataGrid = dgv;
            UploaedDataBindingSource = new BindingSource();
            UploadedDataGrid.DataSource = UploaedDataBindingSource;
            try
            {
                DataTable table;
                dataAdapter = new SqlDataAdapter(query, (SqlConnection)DataBase.GetConnectionObject(ConType.SQLDB));
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
                table = new DataTable
                {
                    Locale = System.Globalization.CultureInfo.InvariantCulture
                };
                dataAdapter.Fill(table);
                UploadedDataTable = table;
                UploadedDataGrid.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                UploaedDataBindingSource.DataSource = UploadedDataTable;

            }
            catch (Exception)
            {
                return;
            }
        }


    }
}
