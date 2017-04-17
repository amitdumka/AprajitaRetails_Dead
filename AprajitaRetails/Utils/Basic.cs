using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace AprajitaRetails
{
    public enum GenderType
    {
        Male = 1, Female = 2, TransGender = 3

    }
    public class Gender
    {
        static List<string> genders = new List<string> () { "Male", "Female", "TransGender" };

        public static int GetGenderId(string gen)
        {
            return ( genders.IndexOf (gen) + 1 );
        }
        public static string GetGender(int i)
        {
            return ( genders [i - 1] );
        }
        public Gender()
        {

        }
    }
    public class Basic
    {

        

        /// <summary>
        /// set/update Checkbox State
        /// </summary>
        /// <param name="cb">CheckBox refernce</param>
        /// <param name="state">State to update</param>
        public static void SetCheckBox(CheckBox cb, int state)
        {
            if ( state == 1 )
                cb.Checked = true;
            else
                cb.Checked = false;
        }
        /// <summary>
        /// Read the State of Check box
        /// </summary>
        /// <param name="cb">REfernce of Check Box</param>
        /// <returns>state of checkbox</returns>

        public static int ReadChechBox(CheckBox cb)
        {
            if ( cb.CheckState == CheckState.Checked )
                return 1;
            else
                return 0;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static int ToInt(string val)
        {
            if ( IsNumeric (val) )
            {
                return Int32.Parse (val);
            }
            else
                return -999;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static bool IsNumeric(string val)
        {
            bool status = false;
            if ( val != null && val != "" )
            {
                val = val.Trim ();

                try
                {
                    Int64 num = Int64.Parse (val);
                    status = true;
                }
                catch ( Exception )
                {

                    status = false;
                }

            }

            return status;
        }

        /// <summary>
        /// Validate if the textboxes is empty or not
        /// </summary>
        /// <param name="Con"></param>
        /// <returns></returns>
        public static bool ValidateFormUI(Control Con)
        {
            var textBoxes = Con.Controls.Cast<Control> ()
                                     .OfType<TextBox> ()
                                     .OrderBy (control => control.TabIndex);
            var comBoxes = Con.Controls.Cast<Control> ()
                                     .OfType<ComboBox> ()
                                     .OrderBy (control => control.TabIndex);
            var numFiled = Con.Controls.Cast<Control> ()
                                     .OfType<NumericUpDown> ()
                                     .OrderBy (control => control.TabIndex);

            Console.WriteLine (Con.Text);
            foreach ( var textBox in textBoxes )
            {
                Console.WriteLine (textBox.Name);
                if ( string.IsNullOrWhiteSpace (textBox.Text) )
                {
                    textBox.Focus ();

                    // remove "txt" prefix:
                    var fieldName = textBox.Name.Substring (3);
                    MessageBox.Show (string.Format ("Field '{0}' cannot be empty.", fieldName));

                    return false;
                }
            }
            foreach ( var comBox in comBoxes )
            {
                Console.WriteLine (comBox.Name);
                if ( string.IsNullOrWhiteSpace (comBox.Text) )
                {
                    comBox.Focus ();

                    // remove "txt" prefix:
                    var fieldName = comBox.Name.Substring (2);
                    MessageBox.Show (string.Format ("Field '{0}' cannot be empty.", fieldName));

                    return false;
                }
            }
            foreach ( var numf in numFiled )
            {
                Console.WriteLine (numf.Name);
                if ( string.IsNullOrWhiteSpace (numf.Text) )
                {
                    numf.Focus ();

                    // remove "txt" prefix:
                    var fieldName = numf.Name.Substring (2);
                    MessageBox.Show (string.Format ("Field '{0}' cannot be empty.", fieldName));

                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Clear All TextBoxes Mapped to ViewLayout
        /// </summary>
        /// <param name="Con"></param>
        /// <returns></returns>
        public static bool ClearUIFields(Control Con)
        {
            var textBoxes = Con.Controls.Cast<Control> ()
                                     .OfType<TextBox> ()
                                     .OrderBy (control => control.TabIndex);
            var comBoxes = Con.Controls.Cast<Control> ()
                                     .OfType<ComboBox> ()
                                     .OrderBy (control => control.TabIndex);
            var numFields = Con.Controls.Cast<Control> ()
                                    .OfType<NumericUpDown> ()
                                    .OrderBy (control => control.TabIndex);

            Console.WriteLine (Con.Text);
            foreach ( var textBox in textBoxes )
            {
                textBox.Text = "";
            }
            foreach ( var comBox in comBoxes )
            {
                comBox.Text = "";
            }
            foreach ( var numf in numFields )
            {
                numf.Value = 0;
            }

            return true;
        }
    }
}