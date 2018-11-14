using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MetodosNumericos
{
    public class MatrizEventArgs : EventArgs
    {
        private string text;

        public MatrizEventArgs(string text)
            : base()
        {
            this.text = text;
        }

        public string Text { get { return text; } }
    }

    abstract class Matriz
    {
        protected int filas;
        protected int columnas;
        protected double[,] matrix;


        public Matriz(int filas, int columnas)
        {
            this.filas = filas;
            this.columnas = columnas;
            this.matrix = new double[filas, columnas];
        }
             

        public void SetValue(int fila, int columna, double value)
        {
            this.matrix[fila, columna] = value;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            List<int> Max = new List<int>();

            for (int j = 0; j < columnas; j++)
            {
                Max.Add(GetMaxLength(j));
            }

            int dsd = GetLine(Max);

            for (int i = 0; i < filas; i++)
            {
                sb.AppendLine(" +" + "+".PadLeft(dsd - 2, '-'));

                for (int j = 0; j < columnas; j++)
                {
                    string str = matrix[i, j].ToString().PadLeft(Max[j]);
                    sb.Append(" | " + str);
                }

                sb.AppendLine(" |");
            }

            sb.AppendLine(" +" + "+".PadLeft(dsd - 2, '-'));
            sb.AppendLine();

            return sb.ToString();
        }

        private static int GetLine(List<int> Max)
        {
            int dsd = 0;

            foreach (int length in Max)
            {
                dsd += length + 3;
            }

            dsd += 2;

            return dsd;
        }

        private int GetMaxLength(int j)
        {
            int maxLength = 6;

            for (int i = 0; i < filas; i++)
            {
                maxLength = Math.Max(maxLength, matrix[i, j].ToString().Length);
            }

            return maxLength;
        }
    }
}
