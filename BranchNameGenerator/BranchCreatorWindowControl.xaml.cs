using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace BranchNameGenerator
{
    /// <summary>
    /// Interaction logic for BranchCreatorWindowControl.
    /// </summary>
    public partial class BranchCreatorWindowControl : UserControl
    {
        System.Windows.Forms.Timer timer;
        int sayac = 0;
        /// <summary>
        /// Initializes a new instance of the <see cref="BranchCreatorWindowControl"/> class.
        /// </summary>
        public BranchCreatorWindowControl()
        {
            this.InitializeComponent();
            txtBranchName.Focus();
            chcUnderline.IsChecked = true;
            timer = new System.Windows.Forms.Timer();
            timer.Tick += Timer1_Tick;
        }

        /// <summary>
        /// Handles click on the button by displaying a message box.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event args.</param>
        [SuppressMessage("Microsoft.Globalization", "CA1300:SpecifyMessageBoxOptions", Justification = "Sample code")]
        [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1300:ElementMustBeginWithUpperCaseLetter", Justification = "Default event handler naming pattern")]
        private void Generator_Click(object sender, RoutedEventArgs e)
        {
            var text = txtBranchName.Text;
            if (!string.IsNullOrEmpty(text))
            {
                var sperator = "_";
                if (chcHyphen.IsChecked == true)
                    sperator = "-";
                if(chcUnderline.IsChecked == true)
                    sperator = "_";
                txtBranchName.Text = string.Empty;
                var words = text
                    .Replace(".", "")
                    .Replace("@", "")
                    .Replace("[", "")
                    .Replace("]", "")
                    .Replace("+", "")
                    .Replace(",", "")
                    .Split(' ')
                    .Select(x=> ToCamelCase(x.Replace("-", "_").Trim()))
                    .ToList();
                text = string.Join(sperator, words);
                txtBranchName.Text = text;
            }
        }

        [SuppressMessage("Microsoft.Globalization", "CA1300:SpecifyMessageBoxOptions", Justification = "Sample code")]
        [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1300:ElementMustBeginWithUpperCaseLetter", Justification = "Default event handler naming pattern")]
        private void Copy_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtBranchName.Text))
            {
                timer.Start();
                Clipboard.SetText(txtBranchName.Text);
                lblResult.Content = "Copied";
            }
        }
        private void Timer1_Tick(object sender, EventArgs e)
        {
            sayac++;
            if (sayac == 3000)
            {
                lblResult.Content = "";
                timer.Stop();
            }
        }

        public string ToCamelCase(string str)
        {
            if (!string.IsNullOrEmpty(str) && str.Length > 1)
            {
                return char.ToUpper(str[0]) + str.Substring(1);
            }
            return str.ToLowerInvariant();
        }
    }
}