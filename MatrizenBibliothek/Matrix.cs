using System;

namespace MatrizenBibliothek
{
    public class Matrix
    {
        double[,] chart;
        public int width { get; }
        public int heigth {  get; }

        public Matrix(int m, int n)
        {
            chart = new double[m, n];
            heigth = m;
            width = n;
        }

        public Matrix(int m, int n, int NullOrEinheit)
        {
            chart = new double[m, n];
            heigth = m;
            width = n;
            if (NullOrEinheit == 0)   //erstelle Nullmatrix
                for (int i = 0; i < heigth; i++)
                    for (int j = 0; j < width; j++)
                    {
                        chart[i, j] = 0;
                    }
            if (NullOrEinheit == 1) //erstelle Einheitsmatrix
                for (int i = 0; i < heigth; i++)
                {
                    chart[i, i] = 1;
                }
        }

        public void setWert(int i, int j, double wert)
        {
            if (i > heigth || j > width)
                throw new Exception("Bereich liegt außerhalb der Matrix");

            chart[i, j] = wert;
        }

        public double getWert(int i, int j)
        {
            if (i > heigth || j > width)
                throw new Exception("Bereich liegt außerhalb der Matrix");

            return chart[i, j];
        }




    }
}
