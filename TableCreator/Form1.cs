using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ObjectScriptingExtensions;
using AprajitaRetails.DataModel;

namespace TableCreator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent ();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog ();
            if ( openFileDialog1.FileName != "" )
            {
                textBox1.Text = openFileDialog1.FileName;
            }
            else
                textBox1.Text = "NotSelected";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //call table creatot
            //MainProgram.CreatTable (textBox1.Text, richTextBox1);
            Employee ds = new Employee ();


            TableClass tab = new TableClass (typeof (Employee));
            richTextBox1.Text = tab.CreateTableScript ();
        }
    }
}
