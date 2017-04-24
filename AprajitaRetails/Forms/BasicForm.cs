using System;
using System.Windows.Forms;

namespace AprajitaRetails.Forms
{
    abstract public class BasicForm<T> : Form
    {
        public BasicForm()
        {

        }
        abstract protected Button BTNAdd { set; get; }
        abstract protected Button BTNUpdate { set; get; }
        abstract protected Button BTNDelete { set; get; }
        abstract protected Button BTNCancel { set; get; }


        abstract protected T ReadFields();
        abstract protected bool ValidateFields();
        abstract protected void PerformSave();
        abstract protected void PerformAdd();
        abstract protected void ClearUiFields();

        /// <summary>
        /// Cancel Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cancel_Click(object sender, EventArgs e)
        {
            ClearUiFields ();
            BTNAdd.Text = "Add";
            BTNUpdate.Text = "Update";
        }

        /// <summary>
        /// Add Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BTNAdd_Click(object sender, EventArgs e)
        {
            if ( BTNAdd.Text == "Add" )
            {

                PerformAdd ();
            }
            else if ( BTNAdd.Text == "Save" )
            {
                PerformSave ();
            }
        }



    }
}
