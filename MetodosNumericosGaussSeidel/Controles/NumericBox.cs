using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace Controles
{
    class NumericBox : TextBox
    {
        protected override void OnPreviewTextInput(System.Windows.Input.TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0) && e.Text != "-" && e.Text != ".")
                e.Handled = true;

            base.OnPreviewTextInput(e);
        }

        public double Number {
            get {
                double numero = 0;
                return double.TryParse(this.Text, out numero) ? numero : 0; } 
        }
    }
}
