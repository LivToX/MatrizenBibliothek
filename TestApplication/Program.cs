using MatrizenBibliothek;
using System;

namespace TestApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            //Arrange
            Matrix matrix = new Matrix(2, 2);
            matrix.setWert(0, 0, 1);
            matrix.setWert(0, 1, -2);
            matrix.setWert(1, 0, -1);
            matrix.setWert(1, 1, 3);

            Matrix expected = new Matrix(2, 2);
            expected.setWert(0, 0, 3);
            expected.setWert(0, 1, 2);
            expected.setWert(1, 0, 1);
            expected.setWert(1, 1, 1);
            //Act
            Matrix actual = Operations.Inverse(matrix);
            //Assert

        }
    }
}
