using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

//Version 2: Locked
namespace CyberN.Utility
{
    public enum GenderType
    {
        Male = 1, Female = 2, TransGender = 3
    }

    public class Gender
    {
        private static List<string> genders = new List<string>() { "Male", "Female", "TransGender" };

        public static int GetGenderId( string gen )
        {
            return (genders.IndexOf(gen) + 1);
        }

        public static string GetGender( int i )
        {
            if (i <= 0)
                return genders[1];
            return (genders[i -1]);
        }

        public Gender( )
        {

        }

        public static string GetGender( int? i )
        {
            if (i<=0)
                return genders[1];
            return (genders[i??-1]);
        }
    }

    public class Basic
    {
        public static void AddListToComboBox( ComboBox cb, List<string> list )
        {
            if (list != null && list.Count > 0)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    cb.Items.Add(list[i]);
                }
            }
        }

        /// <summary>
        /// set/update Checkbox State
        /// </summary>
        /// <param name="cb">CheckBox refernce</param>
        /// <param name="state">State to update</param>
        public static void SetCheckBox( CheckBox cb, int state )
        {
            if (state == 1)
                cb.Checked = true;
            else
                cb.Checked = false;
        }

        /// <summary>
        /// Read the State of Check box
        /// </summary>
        /// <param name="cb">REfernce of Check Box</param>
        /// <returns>state of checkbox</returns>

        public static int ReadChechBox( CheckBox cb )
        {
            if (cb.CheckState == CheckState.Checked)
                return 1;
            else
                return 0;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static int ToInt( string val )
        {
            if (IsNumeric(val))
            {
                return Int32.Parse(val);
            }
            else
                return -999;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static double ToDouble( string val )
        {
            if (IsNumeric(val))
            {
                return Double.Parse(val);
            }
            else
                return -999;
        }

        public static bool IsNumeric( string val )
        {
            bool status = false;
            if (val != null && val != "")
            {
                val = val.Trim();

                try
                {
                    Int64 num = Int64.Parse(val);
                    status = true;
                }
                catch (Exception)
                {
                    status = false;
                }
            }

            return status;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static bool IsDecimal( string val )
        {
            bool status = false;
            if (val != null && val != "")
            {
                val = val.Trim();

                try
                {
                    Double num = Double.Parse(val);
                    status = true;
                }
                catch (Exception)
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
        public static bool ValidateFormUI( Control Con )
        {
            var textBoxes = Con.Controls.Cast<Control>()
                                     .OfType<TextBox>()
                                     .OrderBy(control => control.TabIndex);
            var comBoxes = Con.Controls.Cast<Control>()
                                     .OfType<ComboBox>()
                                     .OrderBy(control => control.TabIndex);
            var numFiled = Con.Controls.Cast<Control>()
                                     .OfType<NumericUpDown>()
                                     .OrderBy(control => control.TabIndex);

            Console.WriteLine(Con.Text);
            foreach (var textBox in textBoxes)
            {
                Console.WriteLine(textBox.Name);
                if (textBox.Visible == true && string.IsNullOrWhiteSpace(textBox.Text))
                {
                    textBox.Focus();

                    // remove "txt" prefix:
                    var fieldName = textBox.Name.Substring(3);
                    MessageBox.Show(string.Format("Field '{0}' cannot be empty.", fieldName));

                    return false;
                }
            }
            foreach (var comBox in comBoxes)
            {
                Console.WriteLine(comBox.Name);

                if (comBox.Visible == true && string.IsNullOrWhiteSpace(comBox.Text))
                {
                    comBox.Focus();

                    // remove "txt" prefix:
                    var fieldName = comBox.Name.Substring(2);
                    MessageBox.Show(string.Format("Field '{0}' cannot be empty.", fieldName));

                    return false;
                }
            }
            foreach (var numf in numFiled)
            {
                Console.WriteLine(numf.Name);
                if (numf.Visible == true && string.IsNullOrWhiteSpace(numf.Text))
                {
                    numf.Focus();

                    // remove "txt" prefix:
                    var fieldName = numf.Name.Substring(2);
                    MessageBox.Show(string.Format("Field '{0}' cannot be empty.", fieldName));

                    return false;
                }
            }
            Console.WriteLine("Validate: true");
            return true;
        }

        /// <summary>
        /// Clear All TextBoxes Mapped to ViewLayout
        /// </summary>
        /// <param name="Con"></param>
        /// <returns></returns>
        public static bool ClearUIFields( Control Con )
        {
            var textBoxes = Con.Controls.Cast<Control>()
                                     .OfType<TextBox>()
                                     .OrderBy(control => control.TabIndex);
            var comBoxes = Con.Controls.Cast<Control>()
                                     .OfType<ComboBox>()
                                     .OrderBy(control => control.TabIndex);
            var numFields = Con.Controls.Cast<Control>()
                                    .OfType<NumericUpDown>()
                                    .OrderBy(control => control.TabIndex);

            Console.WriteLine(Con.Text);
            foreach (var textBox in textBoxes)
            {
                textBox.Text = "";
            }
            foreach (var comBox in comBoxes)
            {
                comBox.Text = "";
            }
            foreach (var numf in numFields)
            {
                numf.Value = 0;
            }

            return true;
        }

        public static List<string> PropertyList( Type t )
        {
            List<string> list = new List<string>();
            foreach (PropertyInfo p in t.GetProperties())
            {
                list.Add(p.Name);
            }
            return list;
        }

        public static List<string> FeildList( Type t )
        {
            List<string> list = new List<string>();
            foreach (FieldInfo p in t.GetFields())
            {
                list.Add(p.Name);
            }
            return list;
        }

        public static bool IsDriveExists(string drive )
        {
           
            return Directory.Exists(Path.GetPathRoot(drive));
        }
        public static bool IsPathExists( string path )
        {

            return Directory.Exists(path);
        }
        public static bool CopyFile(string source, string dest )
        {
            try
            {
                if (File.Exists(source))
                    File.Copy(source, dest);
                else return false;
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
            
        }
    }
}