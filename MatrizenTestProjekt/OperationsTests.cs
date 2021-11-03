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
            Matrix b = new Matrix(3, 3);
            for (int i = 0; i < a.heigth; i++)
                for (int j = 0; j < a.width; j++)
                {
                    a.setWert(i, j, 3);
                    b.setWert(i, j, 5);
                }
            a.setWert(2, 2, 1);
            b.setWert(2, 2, 1);
            //Act
            Matrix actual = Operations.Multiplikation(a, b);
            //Assert
            Assert.Equal(45, actual.getWert(0, 0));
            Assert.Equal(45, actual.getWert(0, 1));
            Assert.Equal(45, actual.getWert(1, 0));
            Assert.Equal(45, actual.getWert(1, 1));

            Assert.Equal(33, actual.getWert(0, 2));
            Assert.Equal(33, actual.getWert(1, 2));

            Assert.Equal(35, actual.getWert(2, 0));
            Assert.Equal(35, actual.getWert(2, 1));

            Assert.Equal(31, actual.getWert(2, 2));
        }
    }
}
