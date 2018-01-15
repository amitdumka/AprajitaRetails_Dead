using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AprajitaRetails.Printers
{  
    
    /*
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
    class ReciptPrinter
    {
        string StoreName, StoreAddress, StoreCity, StorePhoneNo, StoreGST;
        string InvoiceTitle;

        // for Report:
        private int CurrentY;
        private int CurrentX;
        private int leftMargin;
        private int rightMargin;
        private int topMargin;
        private int bottomMargin;
        private int InvoiceWidth;
        private int InvoiceHeight;
        private string CustomerName;
        private string CustomerCity;
        // Title Font height
        private int InvTitleHeight;
        // Invoice Font
        private Font InvoiceFont = new Font ("Arial", 12, FontStyle.Regular);
        private SolidBrush BlackBrush = new SolidBrush (Color.Black);
        private void ReadSubHearder() { }
        private void ReadFooter() { }
        private void ReadInvoiceDetails() { }


        private void ReadHeader()
        {
            StoreName = "Aprajita Retails";
            StoreCity = "Dumka";
            StoreAddress = "Bhagalpur Road Dumka";
            StorePhoneNo = "06434-224461";
            StoreGST = "20AJHPA7396P1ZV";
            InvoiceTitle = "Retail Invoice";

        }
        private void ReadHeader(string headerDetails)
        {
            //TODO:Dynamic Data send
            StoreName = "Aprajita Retails";
            StoreCity = "Dumka";
            StoreAddress = "Bhagalpur Road Dumka";
            StorePhoneNo = "06434-224461";
            StoreGST = "20AJHPA7396P1ZV";
            InvoiceTitle = "Retail Invoice";

        }
        public void Print()
        {
            var doc = new PrintDocument ();
            doc.PrintPage += new PrintPageEventHandler (ProvideContent);
            doc.Print ();
        }

        public void ProvideContent(object sender, PrintPageEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Font font = new Font ("Courier New", 10);

            float fontHeight = font.GetHeight ();

            int startX = 0;
            int startY = 0;
            int Offset = 20;

            e.PageSettings.PaperSize.Width = 50;
            graphics.DrawString ("Welcome to MSST", new Font ("Courier New", 8),
                                new SolidBrush (Color.Black), startX, startY + Offset);
            Offset = Offset + 20;

            graphics.DrawString ("Ticket No:" + "4525554654545",
                        new Font ("Courier New", 14),
                        new SolidBrush (Color.Black), startX, startY + Offset);
            Offset = Offset + 20;


            graphics.DrawString ("Ticket Date :" + "21/12/215",
                        new Font ("Courier New", 14),
                        new SolidBrush (Color.Black), startX, startY + Offset);

            Offset = Offset + 20;
            String underLine = "------------------------------------------";

            graphics.DrawString (underLine, new Font ("Courier New", 14),
                        new SolidBrush (Color.Black), startX, startY + Offset);

            Offset = Offset + 20;
            String Grosstotal = "Total Amount to Pay = " + "2566";

            Offset = Offset + 20;
            underLine = "------------------------------------------";
            graphics.DrawString (underLine, new Font ("Courier New", 14),
                        new SolidBrush (Color.Black), startX, startY + Offset);
            Offset = Offset + 20;

            graphics.DrawString (Grosstotal, new Font ("Courier New", 14),
                        new SolidBrush (Color.Black), startX, startY + Offset);

        }
        private void SetInvoiceHead(Graphics g)
        {
            ReadHeader ();

            CurrentY = topMargin;
            CurrentX = leftMargin;
            int ImageHeight = 0;


            InvTitleHeight = (int) ( InvoiceFont.GetHeight (g) );
            //InvSubTitleHeight = (int) ( InvoiceFont.GetHeight (g) );

            // Get Titles Length:
            int lenStoreName = (int) g.MeasureString (StoreName, InvoiceFont).Width;
            int lenStoreAddress = (int) g.MeasureString (StoreAddress, InvoiceFont).Width;
            int lenStoreCity = (int) g.MeasureString (StoreCity, InvoiceFont).Width;
            int lenStorePhone = (int) g.MeasureString (StorePhoneNo, InvoiceFont).Width;
            int lenStoreGST = (int) g.MeasureString (StoreGST, InvoiceFont).Width;
            int lenInvoiceTitle = (int) g.MeasureString (InvoiceTitle, InvoiceFont).Width;

            // Set Titles Left:
            int xStoreName = CurrentX + ( InvoiceWidth - lenStoreName ) / 2;
            int xStoreAddress = CurrentX + ( InvoiceWidth - lenStoreAddress ) / 2;
            int xStoreCity = CurrentX + ( InvoiceWidth - lenStoreCity ) / 2;
            int xStorePhone = CurrentX + ( InvoiceWidth - lenStorePhone ) / 2;
            int xStoreGST = CurrentX + ( InvoiceWidth - lenStoreGST ) / 2;
            int xInvoiceTitle = CurrentX + ( InvoiceWidth - lenInvoiceTitle ) / 2;
            // Draw Invoice Head:
            if ( StoreName != "" )
            {
                CurrentY = CurrentY + ImageHeight;
                g.DrawString (StoreName, InvoiceFont, BlackBrush, xStoreName, CurrentY);
            }
            if ( StoreAddress != "" )
            {
                CurrentY = CurrentY + InvTitleHeight;
                g.DrawString (StoreAddress, InvoiceFont, BlackBrush, xStoreAddress, CurrentY);
            }
            if ( StoreCity != "" )
            {
                CurrentY = CurrentY + InvTitleHeight;
                g.DrawString (StoreCity, InvoiceFont, BlackBrush, xStoreCity, CurrentY);
            }
            if ( StorePhoneNo != "" )
            {
                CurrentY = CurrentY + InvTitleHeight;
                g.DrawString (StorePhoneNo, InvoiceFont, BlackBrush, xStorePhone, CurrentY);
            }
            if ( StoreGST != "" )
            {
                CurrentY = CurrentY + InvTitleHeight;
                g.DrawString (StoreGST, InvoiceFont, BlackBrush, xStoreGST, CurrentY);
            }

            // Draw line:
            CurrentY = CurrentY + InvTitleHeight + 8;
            g.DrawLine (new Pen (Brushes.Black, 2), CurrentX, CurrentY, rightMargin, CurrentY);

            if ( InvoiceTitle != "" )
            {
                CurrentY = CurrentY + InvTitleHeight;
                g.DrawString (InvoiceTitle, InvoiceFont, BlackBrush, xInvoiceTitle, CurrentY);
            }

            // Draw line:
            CurrentY = CurrentY + InvTitleHeight + 8;
            g.DrawLine (new Pen (Brushes.Black, 2), CurrentX, CurrentY, rightMargin, CurrentY);

        }
        private void SetSubHeader(Graphics g) { }
        private void SetFooter(Graphics g){}
        private void SetInvoiceDetails(Graphics g) { }
    }

        

}
