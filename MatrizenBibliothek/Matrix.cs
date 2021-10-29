using System;

namespace MatrizenBibliothek
{
    public class Matrix
    {
        double[,] chart;
        int width;
        int heigth;

        public Matrix(int m, int n)
        {
            chart = new double[m, n];
            heigth = m;
            width = n;
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
