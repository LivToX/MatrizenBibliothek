using MatrizenBibliothek;
using System;

namespace TestApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            //Arrange
            Matrix matrix = new Matrix(3, 3);
            matrix.setWert(0, 0, -7);
            matrix.setWert(0, 1, -1);
            matrix.setWert(0, 2, 2);
            matrix.setWert(1, 0, 0);
            matrix.setWert(1, 1, 1);
            matrix.setWert(1, 2, 4);
            matrix.setWert(2, 0, -1);
            matrix.setWert(2, 1, 0);
            matrix.setWert(2, 2, 1);

            Matrix expected = new Matrix(3, 3);
            expected.setWert(0, 0, -1);
            expected.setWert(0, 1, -1);
            expected.setWert(0, 2, 6);
            expected.setWert(1, 0, 4);
            expected.setWert(1, 1, 5);
            expected.setWert(1, 2, -28);
            expected.setWert(2, 0, -1);
            expected.setWert(2, 1, -1);
            expected.setWert(2, 2, 7);
            //Act
            Matrix actual = Operations.Inverse(matrix,0);
            //Assert



        }
    }
}
