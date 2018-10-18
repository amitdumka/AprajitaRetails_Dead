using AprajitaRetails.Excels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AprajitaRetails
{
    public partial class Form1 : Form
    {
        private List<string> itemlist = new List<string>();
        private ExcelUploader ER;
        private ExcelToDB EDB;
        public int RecordCount = 0;

        public Form1( )
        {
            InitializeComponent();
            openFileDialog1.InitialDirectory = "C:\\Users";
            openFileDialog1.FileName = "";
            itemlist.Add("SaleRegister");
            itemlist.Add("Sales");
            itemlist.Add("Purchase");
            itemlist.Add("VoyBill");

            comboBox1.Items.Add(itemlist[0]);
            comboBox1.Items.Add(itemlist[1]);
            comboBox1.Items.Add(itemlist[2]);
            comboBox1.Items.Add(itemlist[3]);
            comboBox1.SelectedIndex = 0;
            ER = new ExcelUploader();
            EDB = new ExcelToDB();
        }

        private void BTNGetExcel_Click( object sender, EventArgs e )
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName != "")
            {
                textBox1.Text = openFileDialog1.FileName;
            }
            else
                textBox1.Text = "NotSelected";
        }

        private void button1_Click( object sender, EventArgs e )
        {
            RecordCount = 0;
            pBar.Enabled = true;
            pBar.Visible = true;
            pBar.Style = ProgressBarStyle.Continuous;
            pBar.Step = 1;
            pBar.PerformStep();
            pBar.Minimum = 7;
            pBar.Maximum = Int32.Parse(textBox3.Text);
            Task t = null;
            if (comboBox1.Text == "SaleRegister")
                t = Task.Run(( ) => RecordCount = ER.ReadDataSaleRegister(textBox1.Text,
                Int32.Parse(textBox2.Text.Trim()),
                Int32.Parse(textBox3.Text.Trim()), pBar));
            else if (comboBox1.Text == "Purchase")
                t = Task.Run(( ) => RecordCount = ER.ReadPurchase(textBox1.Text,
               Int32.Parse(textBox2.Text.Trim()),
               Int32.Parse(textBox3.Text.Trim()), pBar));
            else if (comboBox1.Text == itemlist[3])
            {
                //TODO: voy upload here count 2
                // t = Task.Run(( ) => Voy.VoyBillUpload.ReadVoyBillXML(textBox1.Text));
            }
            else
            {
                return;
            }

            Task q = Task.Run(( ) =>
            {
                t.Wait();
                if (t.IsCompleted)
                {
                    MessageBox.Show("Record save, " + RecordCount);
                }
                else
                {
                    Console.WriteLine("Sleeping for 5 sec");
                    Task.Delay(5000);
                }
            });
            //q.Wait();
            // int x = ER.ReadDataSaleRegister(textBox1.Text, Int32.Parse(textBox2.Text.Trim()), Int32.Parse(textBox3.Text.Trim()));
            //MessageBox.Show("No Of Recored Added=" + x);
        }

        private void groupBox1_Enter( object sender, EventArgs e )
        {
        }

        private void BTNReload_Click( object sender, EventArgs e )
        {
            if (comboBox1.Text == "Purchase")
                EDB.RefreshDGV(dataGridView1, Querys.qAllPurchase);
            else if (comboBox1.Text == "SaleRegister")
                EDB.RefreshDGV(dataGridView1, Querys.qAll);
        }

        private void dataGridView1_CellContentClick( object sender, DataGridViewCellEventArgs e )
        {
        }

        private void tableLayoutPanel1_Paint( object sender, PaintEventArgs e )
        {
        }

        private void button2_Click( object sender, EventArgs e )
        {
            // TableClass tab = new TableClass (typeof(Employee));
            // string q = tab.CreateTableScript ();
            //DialogResult d= MessageBox.Show (q);
            // if(d== DialogResult.OK )
            // {
            //     SqlConnection con= EDB.GetConnection ();
            //     SqlCommand cmd = con.CreateCommand ();
            //     cmd.CommandText = q;
            //     int z = cmd.ExecuteNonQuery ();
            //     MessageBox.Show ("Status="+z+"\n"+tab.CreateInsertScript());
            // }

            if (checkBox1.Checked)
                EDB.RefreshDGV(dataGridView1, Querys.qByMonthP);
            else
                EDB.RefreshDGV(dataGridView1, Querys.qByMonth);
        }

        private void button3_Click( object sender, EventArgs e )
        {
            if (checkBox1.Checked)
                EDB.RefreshDGV(dataGridView1, Querys.qByYearP);
            else
                EDB.RefreshDGV(dataGridView1, Querys.qByYear);
        }

        private void button4_Click( object sender, EventArgs e )
        {
            if (checkBox1.Checked)
                EDB.RefreshDGV(dataGridView1, Querys.qByDayP);
            else
                EDB.RefreshDGV(dataGridView1, Querys.qByDay);
        }

        private void backgroundWorker1_DoWork( object sender, DoWorkEventArgs e )
        {
        }

        private void comboBox1_SelectedIndexChanged( object sender, EventArgs e )
        {
        }
    }
}