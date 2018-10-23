using System;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Forms;

namespace AprajitaRetails.Forms
{
    public partial class FormTest : Form
    {
        private Button printPreviewButton;

        private PrintPreviewDialog printPreviewDialog1 = new PrintPreviewDialog();
        private PrintDocument printDocument1 = new PrintDocument();

        // Declare a string to hold the entire document contents.
        private string documentContents;

        // Declare a variable to hold the portion of the document that
        // is not printed.
        private string stringToPrint;

        public FormTest( )
        {
            this.printPreviewButton=new System.Windows.Forms.Button
            {
                Location=new System.Drawing.Point( 12, 12 ),
                Size=new System.Drawing.Size( 125, 23 ),
                Text="Print Preview"
            };
            this.printPreviewButton.Click+=new System.EventHandler( this.PrintPreviewButton_Click );
            this.ClientSize=new System.Drawing.Size( 292, 266 );
            this.Controls.Add( this.printPreviewButton );
            printDocument1.PrintPage+=
                new PrintPageEventHandler( PrintDocument1_PrintPage );
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage( "Microsoft.Usage", "CA2202:Do not dispose objects multiple times" )]
        private void ReadDocument( )
        {
            string docName = "db.sql";
            string docPath = @"..\..\";
            printDocument1.DocumentName=docName;
            using (FileStream stream = new FileStream( docPath+docName, FileMode.Open ))
            using (StreamReader reader = new StreamReader( stream ))
            {
                documentContents=reader.ReadToEnd();
            }
            stringToPrint=documentContents;
        }

        private void PrintDocument1_PrintPage( object sender, PrintPageEventArgs e )
        {
            // Sets the value of charactersOnPage to the number of characters
            // of stringToPrint that will fit within the bounds of the page.
            e.Graphics.MeasureString( stringToPrint, this.Font,
                e.MarginBounds.Size, StringFormat.GenericTypographic,
                out int charactersOnPage, out int linesPerPage );

            // Draws the string within the bounds of the page.
            e.Graphics.DrawString( stringToPrint, this.Font, Brushes.Black,
            e.MarginBounds, StringFormat.GenericTypographic );

            // Remove the portion of the string that has been printed.
            stringToPrint=stringToPrint.Substring( charactersOnPage );

            // Check to see if more pages are to be printed.
            e.HasMorePages=(stringToPrint.Length>0);

            // If there are no more pages, reset the string to be printed.
            if (!e.HasMorePages)
            {
                stringToPrint=documentContents;
            }
        }

        private void PrintPreviewButton_Click( object sender, EventArgs e )
        {
            ReadDocument();
            printPreviewDialog1.Document=printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        private void FormTest_Load( object sender, EventArgs e )
        {
        }
    }
}