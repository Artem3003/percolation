using System;
using NUnit.Framework;

namespace percolation
{
    class Program
    {
        static void Main(string[] args)
        {
            InitTest();
            OpenTest();
            IsFullTest();
            NumberOfOpenSitesTest();
            PercolatesTest();
        }

        // Unit tests
        public static void InitTest()
        {
            Percolation percolation = new Percolation();

            percolation.Init(5);

            for (int row = 1; row <= 5; row++)
            {
                for (int col = 1; col <= 5; col++)
                {
                    Assert.IsFalse(percolation.IsOpen(row, col));
                }
            }
        }

        public static void OpenTest()
        {
            Percolation percolation = new Percolation();
            
            percolation.Init(5);
            percolation.Open(3, 3);

            Assert.IsTrue(percolation.IsOpen(3, 3));
            Assert.IsFalse(percolation.IsOpen(1, 3));
            Assert.Throws<IndexOutOfRangeException>(() => percolation.IsOpen(6, 6));
        }

        public static void IsFullTest()
        {
            Percolation percolation = new Percolation();
            
            percolation.Init(5);
            percolation.Open(1, 3);
            percolation.Open(5, 5);

            Assert.IsTrue(percolation.IsFull(1, 3));
            Assert.IsFalse(percolation.IsFull(3, 3));
            Assert.IsFalse(percolation.IsFull(2, 2));
        }

        public static void NumberOfOpenSitesTest()
        {
            Percolation percolation = new Percolation();
            percolation.Init(5);

            Assert.AreEqual(0, percolation.NumberOfOpenSites());

            percolation.Open(1, 1);
            percolation.Open(2, 2);
            percolation.Open(3, 3);

            Assert.AreEqual(3, percolation.NumberOfOpenSites());
        }

        public static void PercolatesTest()
        {
            Percolation percolation = new Percolation();
            percolation.Init(3);

            Assert.IsFalse(percolation.Percolates());

            percolation.Open(1, 1);
            percolation.Open(2, 1);
            percolation.Open(3, 1);

            Assert.IsTrue(percolation.Percolates());
        }
    }
}