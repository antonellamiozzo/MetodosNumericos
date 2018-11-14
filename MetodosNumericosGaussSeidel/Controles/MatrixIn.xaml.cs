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

namespace Controles
{
    /// <summary>
    /// Lógica de interacción para MatrixIn.xaml
    /// </summary>
    public partial class MatrixIn : UserControl
    {
        private int eqCount = 3;


        public MatrixIn()
        {
            InitializeComponent();
        }


        private void matrix_Loaded(object sender, RoutedEventArgs e)
        {
            CreateView();
        }

        private void CreateView()
        {
            grd.Children.Clear();

            StackPanel filasContainer = new StackPanel() { Orientation = Orientation.Vertical };

            for (int i = 0; i <= CantidadEcuaciones; i++)
            {
                AddFila(i, filasContainer);
            }

            grd.Children.Add(filasContainer);
        }

        private void AddFila(int filaCount, StackPanel container)
        {
            StackPanel fila = new StackPanel() { Orientation = Orientation.Horizontal };

            if (filaCount == 0)
            {
                AddHeader(fila);
            }
            else
            {
                AddEq(filaCount, fila);
            }

            container.Children.Add(fila);
        }

        private void AddEq(int filaCount, StackPanel fila)
        {
            fila.Children.Add(new TextBlock()
            {
                Text = "EQ" + filaCount + " ",
                Width = 45,
                TextAlignment = TextAlignment.Right,
				Foreground = Brushes.White
            });

            for (int i = 1; i <= CantidadEcuaciones + 1; i++)
            {
                fila.Children.Add(new NumericBox()
                {
                    Width = 100,
                    Name = "tbx_" + filaCount + "_" + i,
                    TextAlignment = TextAlignment.Right
                });
            }
        }

        private void AddHeader(StackPanel fila)
        {
            fila.Children.Add(new TextBlock() { Width = 50 });

            for (int i = 1; i < CantidadEcuaciones + 1; i++)
            {
                fila.Children.Add(new TextBlock()
                {
                    Text = "X" + i + "  ",
                    Width = 100,
                    TextAlignment = TextAlignment.Right,
					Foreground = Brushes.White
                });
            }
        }


        protected override void OnPreviewKeyUp(KeyEventArgs e)
        {
            if (e.Key == Key.Enter || e.Key == Key.Left || e.Key == Key.Right || e.Key == Key.Up || e.Key == Key.Down)
            {
                string name = (e.OriginalSource as TextBox).Name;
                string[] names = name.Split('_');

                int fila = int.Parse(names[1]);
                int col = int.Parse(names[2]);

                switch (e.Key)
                {
                    case Key.Enter: MoveRigth(ref fila, ref col);
                        break;
                    case Key.Left: //MoveLeft(ref fila, ref col);
                        break;
                    case Key.Right: //MoveRigth(ref fila, ref col);
                        break;
                    case Key.Up: fila = MoveUp(fila);
                        break;
                    case Key.Down: fila = MoveDown(fila);
                        break;
                }

                string newname = "tbx_" + fila + "_" + col;

                BuscarCelda(newname, grd.Children);
            }

            base.OnPreviewKeyUp(e);
        }


        private int MoveUp(int fila)
        {
            if (fila > 1) fila--;
            else fila = CantidadEcuaciones;
            return fila;
        }

        private int MoveDown(int fila)
        {
            if (fila < CantidadEcuaciones) fila++;
            else fila = 1;
            return fila;
        }

        private void MoveLeft(ref int fila, ref int col)
        {
            if (col > 1)
            {
                col--;
            }
            else
            {
                if (fila > 1) fila--;
                col = CantidadEcuaciones + 1;
            }
        }

        private void MoveRigth(ref int fila, ref int col)
        {
            if (col < CantidadEcuaciones + 1)
            {
                col++;
            }
            else
            {
                if (fila < CantidadEcuaciones) fila++;
                else fila = 1;
                col = 1;
            }
        }

        private void BuscarCelda(string name, UIElementCollection collection)
        {
            foreach (FrameworkElement child in collection)
            {
                if (child.Name == name)
                {
                    child.Focus();
                }
                else if (child is StackPanel)
                    BuscarCelda(name, (child as StackPanel).Children);
            }
        }

        public double[,] Matrix
        {
            get
            {
                double[,] mt = new double[CantidadEcuaciones, CantidadEcuaciones + 1];
                CreateMatrix(mt, grd.Children);
                return mt;
            }
        }

        private void CreateMatrix(double[,] mt, UIElementCollection collection)
        {
            foreach (FrameworkElement child in collection)
            {
                if (child is NumericBox)
                {
                    string[] names = child.Name.Split('_');
                    int fila = int.Parse(names[1]);
                    int col = int.Parse(names[2]);

                    mt[fila - 1, col - 1] = (child as NumericBox).Number;
                }

                if (child is StackPanel)
                    CreateMatrix(mt, (child as StackPanel).Children);
            }
        }


        public int CantidadEcuaciones
        {
            get
            {
                return eqCount;
            }
            set
            {
                if (value >= 3 && value <= 100)
                {
                    eqCount = value;
                    CreateView();
                }
            }
        }
    }
}
