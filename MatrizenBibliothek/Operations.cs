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
            for (int i = 0; i < a.heigth; i++)
                for (int j = 0; j < b.width; j++)
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

        public static Matrix Inverse(Matrix matrix, int rundenAufNachKomma)
        {
            if (matrix.heigth != matrix.width)
                throw new Exception("Matrix ist nicht auadratisch. Nur quadratische Matrizen besitzen Inverse.");

            Matrix result = new Matrix(matrix.heigth, matrix.width, 1);

            for (int i = 0; i < matrix.heigth; i++)     //Check ob Nullen auf Diagonale, dann Zeilen Tauschen
                if (matrix.getWert(i, i) == 0)
                {
                    for (int h = i + 1; h < matrix.heigth; h++)
                        if (matrix.getWert(h, i) != 0)
                        {
                            matrix = TauscheZeilen(matrix, i, h);
                            result = TauscheZeilen(result, i, h);
                        }
                }

            for (int i = 0; i < matrix.heigth; i++)
            {
                if (matrix.getWert(i, i) != 1)  //wenn noch keine 1 auf Diagonale steht
                {
                    double divider = matrix.getWert(i, i);
                    for (int j = 0; j < matrix.width; j++) //teile Zeile durch Diagonalwert für 1 auf Diagonale
                    {
                        matrix.setWert(i, j, matrix.getWert(i, j) / divider);
                        result.setWert(i, j, result.getWert(i, j) / divider);
                    }
                }

                for (int k = i + 1; k < matrix.heigth; k++)  //Werte unter Diagonalelement auf Null
                {
                    if (matrix.getWert(k, i) < 0)
                    {
                        double factor = matrix.getWert(k, i);
                        matrix = ZeileMinusZeile(matrix, k, i, factor);
                        result = ZeileMinusZeile(result, k, i, factor);
                    }
                    else if (matrix.getWert(k, i) > 0)
                    {
                        double factor = matrix.getWert(k, i);
                        matrix = ZeileMinusZeile(matrix, k, i, factor);
                        result = ZeileMinusZeile(result, k, i, factor);
                    }
                    else
                    {
                        continue;
                    }
                }
            }

            for (int i = matrix.width - 1; i > 0; i--)          //Werte über Diagonalelementen auf Null
            {
                for (int j = i - 1; j >= 0; j--)
                    if (matrix.getWert(j, i) < 0)
                    {
                        double factor = matrix.getWert(j, i);
                        matrix = ZeileMinusZeile(matrix, j, i, factor);
                        result = ZeileMinusZeile(result, j, i, factor);
                    }
                    else if (matrix.getWert(j, i) > 0)
                    {
                        double factor = matrix.getWert(j, i);
                        matrix = ZeileMinusZeile(matrix, j, i, factor);
                        result = ZeileMinusZeile(result, j, i, factor);
                    }
                    else
                    {
                        continue;
                    }
            }

            result = Round(result, rundenAufNachKomma);

            return result;
        }

        public static Matrix LgsLoesen(Matrix matrix)
        {


            for (int i = 0; i < matrix.heigth; i++)     //Check ob Nullen auf Diagonale, dann Zeilen Tauschen
                if (matrix.getWert(i, i) == 0)
                {
                    for (int h = i + 1; h < matrix.heigth; h++)
                        if (matrix.getWert(h, i) != 0)
                        {
                            matrix = TauscheZeilen(matrix, i, h);
                        }
                }

            for (int i = 0; i < matrix.heigth; i++)
            {
                if (matrix.getWert(i, i) != 1)  //wenn noch keine 1 auf Diagonale steht
                {
                    double divider = matrix.getWert(i, i);
                    for (int j = 0; j < matrix.width; j++) //teile Zeile durch Diagonalwert für 1 auf Diagonale
                    {
                        matrix.setWert(i, j, matrix.getWert(i, j) / divider);
                    }
                }

                for (int k = i + 1; k < matrix.heigth; k++)  //Werte unter Diagonalelement auf Null
                {
                    if (matrix.getWert(k, i) < 0)
                    {
                        double factor = matrix.getWert(k, i);
                        matrix = ZeileMinusZeile(matrix, k, i, factor);
                    }
                    else if (matrix.getWert(k, i) > 0)
                    {
                        double factor = matrix.getWert(k, i);
                        matrix = ZeileMinusZeile(matrix, k, i, factor);
                    }
                    else
                    {
                        continue;
                    }
                }
            }

            for (int i = matrix.width - 2; i > 0; i--)          //Werte über Diagonalelementen auf Null
            {
                for (int j = i - 1; j >= 0; j--)
                    if (matrix.getWert(j, i) < 0)
                    {
                        double factor = matrix.getWert(j, i);
                        matrix = ZeileMinusZeile(matrix, j, i, factor);
                    }
                    else if (matrix.getWert(j, i) > 0)
                    {
                        double factor = matrix.getWert(j, i);
                        matrix = ZeileMinusZeile(matrix, j, i, factor);
                    }
                    else
                    {
                        continue;
                    }
            }

          //  result = Round(result, rundenAufNachKomma);

            return matrix;
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

        private static Matrix ZeileMinusZeile(Matrix matrix, int ZeileA, int ZeileB, double factor)
        {
            //Zeile A minus Zeile B

            for (int j = 0; j < matrix.width; j++)
            {
                matrix.setWert(ZeileA, j, matrix.getWert(ZeileA, j) - matrix.getWert(ZeileB, j) * factor);
            }

            return matrix;
        }

        private static Matrix Round(Matrix matrix, int rundenAufNachKomma)
        {    //Rundet Matrix auf angegebene nachkomma Stelle
            for (int i = 0; i < matrix.heigth; i++)
                for (int j = 0; j < matrix.width; j++)
                {
                    if (rundenAufNachKomma > 0)
                        matrix.setWert(i, j, Math.Round(matrix.getWert(i, j), rundenAufNachKomma));
                    else
                        matrix.setWert(i, j, Math.Round(matrix.getWert(i, j)));
                }

            return matrix;
        }


    }
}
