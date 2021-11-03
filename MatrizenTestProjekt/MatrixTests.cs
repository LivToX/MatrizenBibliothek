using MatrizenBibliothek;
using System;
using Xunit;

namespace MatrizenTestProjekt
{
    public class MatrixTests
    {
        [Fact]
        public void CreateMatrixTest()
        {
            //Arrange
            Matrix matrix = new Matrix(1, 1);
            //Act

            //Assert
            Assert.Equal(1, matrix.heigth);
            Assert.Equal(1, matrix.width);

        }

        [Fact]
        public void SetAndGetWertTest()
        {
            //Arrange
            Matrix matrix = new Matrix(3, 3);
            //Act
            matrix.setWert(2, 2, 555);
            //Assert
            Assert.Equal(555, matrix.getWert(2, 2));

        }

        [Fact]
        public void NullMatrixTest()
        {
            //Arrange
            Matrix nullmatrix = new Matrix(3, 3, 0);
            //Act

            //Assert
            Assert.Equal(0, nullmatrix.getWert(0, 0));
            Assert.Equal(0, nullmatrix.getWert(0, 1));
            Assert.Equal(0, nullmatrix.getWert(0, 2));
            Assert.Equal(0, nullmatrix.getWert(1, 0));
            Assert.Equal(0, nullmatrix.getWert(1, 1));
            Assert.Equal(0, nullmatrix.getWert(1, 2));
            Assert.Equal(0, nullmatrix.getWert(2, 0));
            Assert.Equal(0, nullmatrix.getWert(2, 1));
            Assert.Equal(0, nullmatrix.getWert(2, 2));
        }


        [Fact]
        public void EinheitsMatrixTest()
        {
            //Arrange
            Matrix einhaitsmatrix = new Matrix(3, 3, 1);
            //Act

            //Assert
            Assert.Equal(1, einhaitsmatrix.getWert(0, 0));
            Assert.Equal(0, einhaitsmatrix.getWert(0, 1));
            Assert.Equal(0, einhaitsmatrix.getWert(0, 2));
            Assert.Equal(0, einhaitsmatrix.getWert(1, 0));
            Assert.Equal(1, einhaitsmatrix.getWert(1, 1));
            Assert.Equal(0, einhaitsmatrix.getWert(1, 2));
            Assert.Equal(0, einhaitsmatrix.getWert(2, 0));
            Assert.Equal(0, einhaitsmatrix.getWert(2, 1));
            Assert.Equal(1, einhaitsmatrix.getWert(2, 2));
        }

        //[Fact]
        //public void NullAndEinheitMatrixFailTest()
        //{
        //    //Arrange
        //    Matrix test = new Matrix(1, 25, 2);

        //    //Assert
        //    Assert.Throws<ArgumentException>( new Matrix(2, 23, 2) );
        //}
    }
}
