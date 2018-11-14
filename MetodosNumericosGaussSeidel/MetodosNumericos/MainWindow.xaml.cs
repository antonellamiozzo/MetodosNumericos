using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MetodosNumericos
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            for (int i = 3; i < 10; i++)
            {
                cbx.Items.Add(i);
            }
        }

        void mt_Completo(object sender, MatrizEventArgs e)
        {
            tbkResult.Text = e.Text;
        }

        void mt_cambio(object sender, MatrizEventArgs e)
        {
            tbxMatrix.Text += e.Text;
        }

        private void btnGauss_Click(object sender, RoutedEventArgs e)
        {
			tbxMatrix.Clear();
			
            GaussSeidel mt = new GaussSeidel(matrixIn.CantidadEcuaciones, matrixIn.CantidadEcuaciones + 1);

            double[,] matIn = matrixIn.Matrix;

            for (int i = 0; i < matrixIn.CantidadEcuaciones; i++)
            {
                for (int j = 0; j < matrixIn.CantidadEcuaciones + 1; j++)
                {
                    mt.SetValue(i, j, matIn[i, j]);
                }
            }

            mt.Cambio += new EventHandler<MatrizEventArgs>(mt_cambio);
            mt.Completo += new EventHandler<MatrizEventArgs>(mt_Completo);

            mt.ApplyMethod();
        }

        private void tbxNoEq_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            //Solo aceptar numeros
            if (!char.IsDigit(e.Text, 0))
                e.Handled = true;
        }

        private void cbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            matrixIn.CantidadEcuaciones = (int)(cbx.SelectedItem);
        }
    }
}
