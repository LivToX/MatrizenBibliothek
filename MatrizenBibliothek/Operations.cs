using System;

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
                    result.setWert(i, j, Product(a, b, i, j));

            return result;
        }

        private static double Product(Matrix a, Matrix b, int i, int j)
        {
            double result = 0;
            for (int k = 0; k < b.heigth; k++)
                result += a.getWert(i, k) * b.getWert(k, j);


            return result;
        }

        public static Matrix Inverse(Matrix matrix)
        {
            //Check for 0 in Diagonalen oder Determinante != 0
            //for (int i = 0; i < matrix.heigth; i++)
            //    if (matrix.getWert(i, i) == 0)
            //        throw new Exception("Matrix besitzt keine Inverse.");

            Matrix result = new Matrix(matrix.heigth, matrix.width,1);

            for (int i = 0; i < matrix.heigth; i++)
            {
                for (int j = i; j < matrix.width; j++)  //Teile Zeile durch Diagonalwert
                {
                    matrix.setWert(i, j, matrix.getWert(i, j) / matrix.getWert(i, i));                        
                    result.setWert(i, j, result.getWert(i, j) / matrix.getWert(i, i));
                    if (matrix.getWert(i, i) < 0)       //wenn diagonalwert < 0
                    {
                        matrix.setWert(i, j, matrix.getWert(i, j) *-1);
                        result.setWert(i, j, result.getWert(i, j) *-1);
                    }
                }
                for (int k = i + 1; k < matrix.width; k++)  //erschaffe Nullen unter Diagonalelementen
                {
                    matrix.setWert(k, i, matrix.getWert(k, i) - matrix.getWert(i, i) * matrix.getWert(k, i));
                    result.setWert(k, i, result.getWert(k, i) - matrix.getWert(i, i) * result.getWert(k, i));
                }
                for (int l = i - 1; l >= 0; l--)      //erschaffe Nullen ueber Diagonalelementen
                {
                    matrix.setWert(l, i, matrix.getWert(l, i) - matrix.getWert(i, i) * matrix.getWert(l, i));
                    result.setWert(l, i, matrix.getWert(l, i) - result.getWert(i, i) * result.getWert(l, i));
                }
            }

            return result;
        }

        private static Matrix TauscheZeilen(Matrix matrix, int zeileVon, int zeileNach)
        {
            double swap;
            for (int j = 0; j < matrix.width; j++)
            {
                swap = matrix.getWert(zeileNach, j);
                matrix.setWert(zeileNach, j, matrix.getWert(zeileVon, j));
                matrix.setWert(zeileVon, j, swap);
            }
            return matrix;
        }


    }
}
