using MatrizenBibliothek;
using System;

namespace TestApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Matrix links = new Matrix(4, 5);
            links.setWert(0, 0, 4);
            links.setWert(0, 1, 4);
            links.setWert(0, 2, 5);
            links.setWert(0, 3, 7);
            links.setWert(0, 4, 6);

            links.setWert(1, 0, 3);
            links.setWert(1, 1, 3);
            links.setWert(1, 2, 3);
            links.setWert(1, 3, 12);
            links.setWert(1, 4, 2);

            links.setWert(2, 0, 1);
            links.setWert(2, 1, 1);
            links.setWert(2, 2, 5);
            links.setWert(2, 3, -5);
            links.setWert(2, 4, 8);

            links.setWert(3, 0, 2);
            links.setWert(3, 1, 3);
            links.setWert(3, 2, 1);
            links.setWert(3, 3, 4);
            links.setWert(3, 4, 1);




            Matrix expected = new Matrix(4, 1);
            expected.setWert(0, 0, 0.1);
            expected.setWert(1, 0, 0.1);
            expected.setWert(2, 0, 1.3);
            expected.setWert(3, 0, -0.2);

            //Act
            Matrix actual = Operations.LgsLoesen(links);
        }
        }
    }
