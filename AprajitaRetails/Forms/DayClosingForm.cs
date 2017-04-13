using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AprajitaRetails.Forms
{
    public partial class DayClosingForm : Form
    {
        private int vTotalCount = 0;
        private int vTotalAmount = 0;
        public DayClosingForm()
        {
            InitializeComponent ();
        }



        private void TextChangedUpdate(object sender, EventArgs e)
        {
            TextBox t = (TextBox) sender;
            if ( !Basic.IsNumeric (t.Text) )
                t.Text = "0";
            string lab = t.Name;
            int count = Int32.Parse (t.Text.Trim ());
            int iValue = Int32.Parse (lab.Trim ().Substring (1));
            int iTotal = iValue * count;
            vTotalAmount = vTotalAmount + iTotal;
            vTotalCount = vTotalCount + count;

            if ( lab.StartsWith ("T") )
            {

                ( (TextBox) this.Controls.Find ("T" + lab, true) [0] ).Text = "" + iTotal;


            }
            else if ( lab.StartsWith ("C") )
            {
                ( (TextBox) this.Controls.Find ("T" + lab, true) [0] ).Text = "" + iTotal;

            }
            LBTotalAmount.Text = "" + vTotalAmount;
            LBTotalCount.Text = "" + vTotalCount;

        }

        private void TT10_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
