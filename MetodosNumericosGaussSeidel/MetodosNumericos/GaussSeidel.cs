using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MetodosNumericos
{
    class GaussSeidel : Matriz
    {
        /// <summary>
        /// se produce cuando cambia la matriz 
        /// </summary>
        public event EventHandler<MatrizEventArgs> Cambio;

        /// <summary>
        /// se produce cuando se completa el procedimiento
        /// </summary>
        public event EventHandler<MatrizEventArgs> Completo;

        public GaussSeidel(int filas, int columnas)
            : base(filas, columnas) { }

        public void ApplyMethod()
        {
            double[] sol = new double[filas];
            StringBuilder sb = new StringBuilder();

            IntercambiarFilas(filas, columnas);
            Boolean s = EsDiagonalmenteDominante(filas, columnas);
            Console.WriteLine(s);


            for (int iteraciones = 0; iteraciones < 5; iteraciones++)
            {
                for (int i = 0; i < filas; i++)
                {
                    double suma = 0;
                    for (int j = 0; j < columnas - 1; j++)
                    {
                        if (j == i) continue;
                        suma += matrix[i, j] * sol[j];
                    }
                    sol[i] = (matrix[i, columnas - 1] - suma) / matrix[i, i];
                }

                sb.Clear();

                for (int i = 0; i < filas; i++)
                {
                    sb.AppendLine("X" + (i + 1) + " = " + sol[i]);
                }

                sb.AppendLine();

                OnMatrizChange(new MatrizEventArgs(sb.ToString()));

            }

            OnGuassCompleted(new MatrizEventArgs(sb.ToString()));
        }

        /// <summary>
        /// se ejecuta cuando cambia la matriz
        /// </summary>
        /// <param name="e">string que contiene los valores de la nueva matriz</param>
        protected virtual void OnMatrizChange(MatrizEventArgs e)
        {
            if (Cambio != null)
                Cambio(this, e);
        }

        /// <summary>
        /// se ejecuta cuando se ha completado el proceso
        /// </summary>
        /// <param name="e">contiene en un string el resultado</param>
        protected virtual void OnGuassCompleted(MatrizEventArgs e)
        {
            if (Completo != null)
                Completo(this, e);
        }

        private Boolean EsDiagonalmenteDominante(int filas, int columnas)
        {
            int f = 0;
            
            try
            {

                
                for (int i = 0; i < filas ; i++)
                {

                    double sum = 0;
                    double valorDiagonal = matrix[i, i];
                    for (int j = 0; j < columnas - 1 ; j++)
                    {
                        sum = sum + Math.Abs(matrix[i, j]);
                    }
                    sum = sum - valorDiagonal;
                    if ((valorDiagonal >= sum))
                    {
                        f++;
                    }
                }
            }
            catch (Exception e) {
                return false;
            }

            if (f == 3)
                return true;
            else
                return false;
           
        }

        public void IntercambiarFilas(int filas, int columnas) {

            double[,] matrixAux;
            matrixAux = new double[filas, columnas];
            matrixAux = matrix;
            filas--;
            columnas--;
            //numero de fila = i
            for (int i = 0; i <= filas; i++) {

                //por filas
                for (int j = 0; j <= columnas   ; j++) {

                    double value = 0;
                    value = matrix[i, j];
                    //por columnas    
                    matrixAux[ filas-1, j] =value;
                    matrixAux[i, j] = matrix[filas - 1, j];



                }

                Console.WriteLine("una matrix" + matrixAux.ToString());


            }
            Console.WriteLine(matrixAux);

        }
    }
}
