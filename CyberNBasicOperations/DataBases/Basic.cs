using System;
using System.Linq;
using System.Windows.Forms;

namespace CyberNBasicOperations
{
    public class Basic
    {
        /// <summary>
        /// Validate if the textboxes is empty or not
        /// </summary>
        /// <param name="Con"></param>
        /// <returns></returns>
        public static bool ValidateForm(Control Con)
        {
            var textBoxes = Con.Controls.Cast<Control> ()
                                     .OfType<TextBox> ()
                                     .OrderBy (control => control.TabIndex);
            var comBoxes = Con.Controls.Cast<Control> ()
                                     .OfType<ComboBox> ()
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

            return true;
        }

        /// <summary>
        /// Clear All TextBoxes Mapped to ViewLayout
        /// </summary>
        /// <param name="Con"></param>
        /// <returns></returns>
        public static bool ClearTextBox(Control Con)
        {
            var textBoxes = Con.Controls.Cast<Control> ()
                                     .OfType<TextBox> ()
                                     .OrderBy (control => control.TabIndex);
            var comBoxes = Con.Controls.Cast<Control> ()
                                     .OfType<ComboBox> ()
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

            return true;
        }
    }
}