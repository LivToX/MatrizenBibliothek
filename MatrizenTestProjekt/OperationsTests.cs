using MatrizenBibliothek;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MatrizenTests
{

    public class OperationsTests
    {

        [Fact]
        public void AdditionTest()
        {
            //Arrange
            Matrix a = new Matrix(3, 3, 1);
            Matrix b = new Matrix(3, 3, 1);
            Matrix actual = new Matrix(3, 3);
            //Act
            actual = Operations.Addition(a, b);
            //Assert
            Assert.Equal(2, actual.getWert(0, 0));
            Assert.Equal(2, actual.getWert(1, 1));
            Assert.Equal(2, actual.getWert(2, 2));

            Assert.Equal(0, actual.getWert(1, 0));
            Assert.Equal(0, actual.getWert(2, 0));
            Assert.Equal(0, actual.getWert(1, 2));
        }

        [Fact]
        public void MultiplikationMitScalarTest()
        {
            //Arrange
            Matrix a = new Matrix(3, 3);
            for (int i = 0; i < a.heigth; i++)
                for (int j = 0; j < a.width; j++)
                    a.setWert(i, j, 3);
            //Act
            Matrix actual = Operations.Multiplikation(a, 5);
            //Assert
            for (int i = 0; i < a.heigth; i++)
                for (int j = 0; j < a.width; j++)
                    Assert.Equal(15, actual.getWert(i, j));
        }

        [Fact]
        public void MultiplikationMitMatrixTest()
        {
            //Arrange
            Matrix a = new Matrix(3, 3);
            Matrix b = new Matrix(3, 1);

            a.setWert(0, 0, 0.9);
            a.setWert(0, 1, 0.3);
            a.setWert(0, 2, 0.4);
            a.setWert(1, 0, 0.2);
            a.setWert(1, 1, 0.8);
            a.setWert(1, 2, 0.2);
            a.setWert(2, 0, 0.1);
            a.setWert(2, 1, 0.5);
            a.setWert(2, 2, 0.6);

            b.setWert(0, 0, 0.9);
            b.setWert(1, 0, 0.1);
            b.setWert(2, 0, 0.8);

            //Act
            Matrix actual = Operations.Multiplikation(a, b);
            //Assert
            Assert.Equal(1.1600000000000001, actual.getWert(0, 0));
            Assert.Equal(0.42000000000000004, actual.getWert(1, 0));
            Assert.Equal(0.62, actual.getWert(2, 0));

        }

        [Fact]
        public void InverseTest()
        {
            //Arrange
            Matrix matrix = new Matrix(3, 3);
            matrix.setWert(0, 0, 0);
            matrix.setWert(0, 1, 1);
            matrix.setWert(0, 2, 4);
            matrix.setWert(1, 0, -7);
            matrix.setWert(1, 1, -1);
            matrix.setWert(1, 2, 2);
            matrix.setWert(2, 0, -1);
            matrix.setWert(2, 1, 0);
            matrix.setWert(2, 2, 1);

            Matrix expected = new Matrix(3, 3);
            expected.setWert(0, 0, -1);
            expected.setWert(0, 1, -1);
            expected.setWert(0, 2, 6);
            expected.setWert(1, 0, 5);
            expected.setWert(1, 1, 4);
            expected.setWert(1, 2, -28);
            expected.setWert(2, 0, -1);
            expected.setWert(2, 1, -1);
            expected.setWert(2, 2, 7);
            //Act
            Matrix actual = Operations.Inverse(matrix, 0);
            //Assert
            Assert.Equal(expected.getWert(0, 0), actual.getWert(0, 0));
            Assert.Equal(expected.getWert(0, 1), actual.getWert(0, 1));
            Assert.Equal(expected.getWert(0, 2), actual.getWert(0, 2));
            Assert.Equal(expected.getWert(1, 0), actual.getWert(1, 0));
            Assert.Equal(expected.getWert(1, 1), actual.getWert(1, 1));
            Assert.Equal(expected.getWert(1, 2), actual.getWert(1, 2));
            Assert.Equal(expected.getWert(2, 0), actual.getWert(2, 0));
            Assert.Equal(expected.getWert(2, 1), actual.getWert(2, 1));
            Assert.Equal(expected.getWert(2, 2), actual.getWert(2, 2));
        }

        [Fact]
        public void LgsLoesenTest()
        {
            //Arrange
            Matrix links = new Matrix(4, 5);
            links.setWert(0, 0, 0);
            links.setWert(0, 1, 10);
            links.setWert(0, 2, 0);
            links.setWert(0, 3, 12);
            links.setWert(0, 4, -6);

            links.setWert(1, 0, 4);
            links.setWert(1, 1, -5);
            links.setWert(1, 2, -2);
            links.setWert(1, 3, -8);
            links.setWert(1, 4, -17);

            links.setWert(2, 0, 0);
            links.setWert(2, 1, -5);
            links.setWert(2, 2, 0);
            links.setWert(2, 3, -4);
            links.setWert(2, 4, -23);

            links.setWert(3, 0, 4);
            links.setWert(3, 1, -10);
            links.setWert(3, 2, 0);
            links.setWert(3, 3, -16);
            links.setWert(3, 4, 2);




            Matrix expected = new Matrix(4, 5);
            expected.setWert(0, 4, -14);
            expected.setWert(1, 4, 15);
            expected.setWert(2, 4, -5);
            expected.setWert(3, 4, -13);

            //Act
            Matrix actual = Operations.LgsLoesen(links);

            //Assert
            Assert.Equal(expected.getWert(0, 4), actual.getWert(0, 4));
            Assert.Equal(expected.getWert(1, 4), actual.getWert(1, 4));
            Assert.Equal(expected.getWert(2, 4), actual.getWert(2, 4));
            Assert.Equal(expected.getWert(3, 4), actual.getWert(3, 4));
        }
    }
}
