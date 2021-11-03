using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrizenBibliothek
{
    public static class Operations
    {
        public static Matrix Addition(Matrix a, Matrix b)
        {
            if (a.heigth != b.heigth && a.width != b.width)
                throw new Exception("Matrizen besitzen unterscheidliche Dimensionen.");

            Matrix result = a;
            for (int i = 0; i < a.heigth; i++)
                for (int j = 0; j < a.width; j++)
                    result.setWert(i, j, a.getWert(i, j) + b.getWert(i, j));
            return result;
        }

        public static Matrix Multiplikation(Matrix a, double scalar)
        {
            Matrix result = a;
            for (int i = 0; i < a.heigth; i++)
                for (int j = 0; j < a.width; j++)
                    result.setWert(i, j, a.getWert(i, j) * scalar);
            return result;
        }

        public static Matrix Multiplikation(Matrix a, Matrix b)
        {
            if (a.width != b.heigth)
                throw new Exception("Matrizen besitzen falsche Dimensionen.");

            Matrix result = new Matrix(a.heigth, b.width);
            for (int i = 0; i < b.heigth; i++)
                for (int j = 0; j < a.width; j++)
                    result.setWert(i, j, Product(a,b,i,j));

                    return result;
        }

        private static double Product(Matrix a, Matrix b, int i, int j)
        {
            double result = 0;
            for (int k = 0; k < b.heigth; k++)
                result += a.getWert(i, k) * b.getWert(k, j);


            return result;
        }
    }
}
