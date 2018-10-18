using iTextSharp.text;
using iTextSharp.text.pdf;
using RawPrint;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Forms;
using Rectangle = iTextSharp.text.Rectangle;

namespace AprajitaRetails.Printers
{      /*
    Store Name
    Address
    City
    Phone
    GST
    ++++++++++++++++++++++++++++++
    Retail Invoice
    +++++++++++++++++++++++++++++++
    Cashier :m01        Name:Manager
    Bill NO: 67676767
                        Date:8989
                        Time:909090
    Customer Name :hjhjhh
    ++++++++++++++++++++++++++++++++
    SKU Code/Description
    HSN     MRP     Qty     Disc
    cgst%   AMT    sgst%    AMT
    +++++++++++++++++++++++++++++++++

    M767676767/Tesca
            1000     1.2     0.0
    2.50     20.50   2.50    20.50
    +++++++++++++++++++++++++++++++
    Total :1.2              1041
    item(s) 1   Net Amount  1041
    ++++++++++++++++++++++++++++++++
    Tender
    Cash Amount       Rs  1041
    ++++++++++++++++++++++++++++++
    Basic Price             1000
    Cgst                    20.50
    sgst                    20.50
    ++++++++++++++++++++++++++++++=
            ** Amount included GST
    +++++++++++++++++++++++++++++++
    Thanks You
    Visit Again
    ++++++++++++++++++++++++++++++++++

    */

    internal class ReceiptItemTotal
    {
        public string TotalItem;
        public string ItemCount;
        public string CashAmount;
        public string NetAmount;
    }

    internal class ReceiptItemDetails
    {
        public string BasicPrice;
        public string HSN;
        public string SKU_Description;
        public string MRP;
        public string QTY;
        public string Discount;
        public string GSTPercentage;
        public string GSTAmount;
    }

    internal class ReceiptDetails
    {
        public string Employee = "Cashier: M0001      Name: Manager";
        public string BillNo = "Bill NO: 67676767";
        public string BillDate = "                Date:";
        public string BillTime = "                Time:";
        public string CustomerName = "Customer Name:";
        public string ItemLine1 = "SKU Code/Description";
        public string ItemLine2 = "HSN      MRP     Qty     Disc";
        public string ItemLine3 = "cgst%    AMT     sgst%   AMT";
    }

    internal class ReceiptHeader
    {
        public string StoreName = "Aprajita Retails";
        public string StoreCity = "Dumka";
        public string StoreAddress = "Bhagalpur Road Dumka";
        public string StorePhoneNo = "06434-224461";
        public string StoreGST = "20AJHPA7396P1ZV";
        public string InvoiceTitle = "Retail Invoice";
    }

    internal class ReceiptFooter
    {
        public string FirstMessage = "** Amount included GST";
        public string ThanksMessage = "Thank You";
        public string LastMessage = "Visit Again";
    }

    internal class PrintLine
    {
        public const string DotedLine = "-----------------------------------\n";
    }

    internal class PdfPrinter
    {
        public static void PrintRecipts( )
        {
            MessageBox.Show(new PrintDocument().PrinterSettings.PrinterName);
            MessageBox.Show(PrinterSettings.InstalledPrinters[0].ToString());
        }

        public static void PrintRecipts( ReceiptHeader header, ReceiptFooter footer, ReceiptItemTotal itemTotals, ReceiptDetails details, ReceiptItemDetails itemDetails )
        {
            //Exporting to PDF
            string folderPath = "D:\\pdf\\";
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            using (FileStream stream = new FileStream(Application.CommonAppDataPath + "\\reciptsPrint.pdf", FileMode.Create))
            {
                Document pdfDoc = new Document(PageSize.A6, 10f, 10f, 10f, 0f);
                PdfWriter.GetInstance(pdfDoc, stream);
                pdfDoc.Open();
                //Header
                Paragraph p = new Paragraph(header.StoreName)
                {
                    Alignment = PdfAppearance.ALIGN_CENTER
                };
                p.Add(header.StoreAddress + "\n");
                p.Add(header.StoreCity + "\n");
                p.Add(header.StorePhoneNo + "\n");
                p.Add(header.StoreGST + "\n");
                p.Add(PrintLine.DotedLine);
                p.Add(header.InvoiceTitle + "\n");
                p.Add(PrintLine.DotedLine);
                pdfDoc.Add(p);
                //Details
                Paragraph dP = new Paragraph
                {
                    details.Employee + "\n",
                    details.BillNo + "\n",
                    details.BillDate + "\n",
                    details.BillTime + "\n",
                    details.CustomerName + "\n",
                    PrintLine.DotedLine,
                    details.ItemLine1 + "\n",
                    details.ItemLine2 + "\n",
                    details.ItemLine3 + "\n",
                    PrintLine.DotedLine,
                    "\n"
                };
                pdfDoc.Add(dP);
                //ItemDetails
                //TODO: Need to iterate for Each Item
                Paragraph ip = new Paragraph
                {
                    itemDetails.SKU_Description + "\n",
                    itemDetails.HSN + "\t" + itemDetails.MRP + "\t",
                    itemDetails.QTY + "\t" + itemDetails.Discount + "\n",
                    itemDetails.GSTPercentage + "\t" + itemDetails.GSTAmount + "\t",
                    itemDetails.GSTPercentage + "\t" + itemDetails.GSTAmount + "\n",
                    PrintLine.DotedLine,
                    "Total: " + itemTotals.TotalItem + "\t\t\t" + itemTotals.NetAmount + "\n",

                    "item(s): " + itemTotals.ItemCount + "\tNet Amount:\t" + itemTotals.NetAmount + "\n",
                    PrintLine.DotedLine,
                    "Tender\n Cash Amount:\t\t Rs. " + itemTotals.CashAmount,
                    PrintLine.DotedLine
                };
                double gstPrice = 0.00;    //TODO: Add Item Price
                ip.Add("Basic Price:\t\t" + itemDetails.BasicPrice);
                ip.Add("CGST:\t\t" + gstPrice);
                ip.Add("SGST:\t\t" + gstPrice);
                ip.Add(PrintLine.DotedLine);

                pdfDoc.Add(ip);
                //Footer
                Paragraph foot = new Paragraph(PrintLine.DotedLine)
                {
                    footer.FirstMessage,
                    PrintLine.DotedLine,
                    footer.ThanksMessage,
                    footer.LastMessage,
                    PrintLine.DotedLine,
                    "\n"// Just to Check;
                };
                pdfDoc.Add(foot);
                pdfDoc.Close();
                stream.Close();

                string PrinterName = "Microsoft Print to PDF";
                // Create an instance of the Printer
                IPrinter printer = new Printer();
                // Print the file
                printer.PrintRawFile(PrinterName, Application.CommonAppDataPath + "\\reciptsPrint.pdf");
                // printer.PrintRawFile()
            }
        }

        public static void PrintRecipts( ReceiptHeader header, ReceiptFooter footer, ReceiptItemTotal itemTotals, ReceiptDetails details, List<ReceiptItemDetails> itemDetail )
        {
            //Exporting to PDF
            //string folderPath = "c:\\pdf\\";
            //if ( !Directory.Exists (folderPath) )
            //{
            //    Directory.CreateDirectory (folderPath);
            //}
            using (FileStream stream = new FileStream(Application.CommonAppDataPath + "\\reciptsPrint.pdf", FileMode.Create))
            {
                System.Console.WriteLine(Application.CommonAppDataPath);

                Document pdfDoc = new Document(new Rectangle(225, 5000), 10f, 10f, 10f, 0f);
                PdfWriter.GetInstance(pdfDoc, stream);
                pdfDoc.Open();
                //Header
                Paragraph p = new Paragraph(header.StoreName + "\n")
                {
                    Alignment = PdfAppearance.ALIGN_CENTER
                };
                p.Add(header.StoreAddress + "\n");
                p.Add(header.StoreCity + "\n");
                p.Add(header.StorePhoneNo + "\n");
                p.Add(header.StoreGST + "\n");
                p.Add(PrintLine.DotedLine);
                p.Add(header.InvoiceTitle + "\n");
                p.Add(PrintLine.DotedLine);
                pdfDoc.Add(p);
                //Details
                Paragraph dP = new Paragraph
                {
                    //dP.Alignment = PdfAppearance.ALIGN_CENTER;
                    details.Employee + "\n",
                    details.BillNo + "\n",
                    details.BillDate + "\n",
                    details.BillTime + "\n",
                    details.CustomerName + "\n",
                    PrintLine.DotedLine,
                    details.ItemLine1 + "\n",
                    details.ItemLine2 + "\n",
                    details.ItemLine3 + "\n",
                    PrintLine.DotedLine,
                    "\n"
                };
                pdfDoc.Add(dP);
                //ItemDetails

                Paragraph ip = new Paragraph();
                // ip.Alignment = PdfAppearance.ALIGN_CENTER;
                double gstPrice = 0.00;
                double basicPrice = 0.00;
                string tab = "    ";
                foreach (ReceiptItemDetails itemDetails in itemDetail)
                {
                    if (itemDetails != null)
                    {
                        ip.Add(itemDetails.SKU_Description + "\n");
                        ip.Add(itemDetails.HSN + tab + tab + itemDetails.MRP + tab + tab);
                        ip.Add(itemDetails.QTY + tab + tab + itemDetails.Discount + "\n");
                        ip.Add(itemDetails.GSTPercentage + "%" + tab + tab + itemDetails.GSTAmount + tab + tab);
                        ip.Add(itemDetails.GSTPercentage + "%" + tab + tab + itemDetails.GSTAmount + "\n");
                        gstPrice += Double.Parse(itemDetails.GSTAmount);
                        basicPrice += Double.Parse(itemDetails.BasicPrice);
                    }
                }
                ip.Add("\n" + PrintLine.DotedLine);
                ip.Add("Total: " + itemTotals.TotalItem + tab + tab + tab + itemTotals.NetAmount + "\n");
                ip.Add("item(s): " + itemTotals.ItemCount + tab + "Net Amount:" + tab + itemTotals.NetAmount + "\n");
                ip.Add(PrintLine.DotedLine);
                ip.Add("Tender\n Paid Amount:\t\t Rs. " + itemTotals.CashAmount);
                ip.Add("\n" + PrintLine.DotedLine);
                ip.Add("Basic Price:\t\t" + basicPrice);
                ip.Add("\nCGST:\t\t" + gstPrice);
                ip.Add("\nSGST:\t\t" + gstPrice + "\n");
                //ip.Add (PrintLine.DotedLine);
                pdfDoc.Add(ip);
                //Footer
                Paragraph foot = new Paragraph(PrintLine.DotedLine)
                {
                    Alignment = PdfAppearance.ALIGN_CENTER
                };
                foot.Add(footer.FirstMessage + "\n");
                foot.Add(PrintLine.DotedLine);
                foot.Add(footer.ThanksMessage + "\n");
                foot.Add(footer.LastMessage + "\n");
                foot.Add(PrintLine.DotedLine);
                foot.Add("\n");// Just to Check;
                pdfDoc.Add(foot);
                pdfDoc.NewPage();

                pdfDoc.Close();

                stream.Close();
                // Create an instance of the Printer
                IPrinter printer = new Printer();
                // Print the file
                printer.PrintRawFile(AprajitaRetailsDataBase.SqlDataBase.ViewModel.UtilOps.PrinterName, Application.CommonAppDataPath + "\\reciptsPrint.pdf");
            }
        }
    }
}