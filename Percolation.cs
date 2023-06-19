using System;

namespace percolation
{
    class Percolation
    {

        private byte[] percolationArr = new byte[0];
        private bool[] openedArr = new bool[0]; // true/false array
        private byte[] sizeArr = new byte[0];
        private byte topSite = 2;
        private int size = 0;
        private int openSites = 0;

        // creates n-by-n grid, with all sites initially blocked
        public void Init(int n)
        {
            size = n;
            percolationArr = new byte[size * size + 2];
            sizeArr = new byte[size * size + 2];
            openedArr = new bool[size * size + 2];
            for (byte i = 0; i < size * size + 2; i++)
            {
                percolationArr[i] = i;
                sizeArr[i] = 1;
            }
            percolationArr[0] = topSite;
        }

        public void RandomInit(int n)
        {
            Init(n);
            for (int i = 1; i < size * size + 1; i++)
            {
                Random random = new Random();
                int row;
                int col;
                int j = random.Next(0, 2);

                if (i % size == 0)
                {
                    row = i / size;
                    col = size; 
                } else
                {
                    row = i / size + 1;
                    col = i % size;
                }

                if (j == 1)
                {
                    Open(row, col);
                }
            }
        }

        // opens the site (row, col) if it is not open already
        public void Open(int row, int col)
        {

        }

        // is the site (row, col) open?
        public bool IsOpen(int row, int col)
        {

        }

        // is the site (row, col) full?
        public bool IsFull(int row, int col)
        {

        }

        // returns the number of open sites
        public int NumberOfOpenSites()
        {

        }

        // does the system percolate?
        public bool Percolates()
        {

        }

        // prints the matrix on the screen
        // The method should display different types of sites (open, blocked, full)
        public void Print()
        {

        }

        // weigheted-quick-union algorithm
        private void union(int x, int y)
        {
            byte rootX = root(x);
            byte rootY = root(y);
            if (rootX == rootY)
            {
                return;
            }
            
            if (sizeArr[x] > sizeArr[y])
            {
                percolationArr[rootY] = rootX;
                sizeArr[rootX] += sizeArr[y];
            } else
            {
                percolationArr[rootX] = rootY;
                sizeArr[rootY] += sizeArr[x];
            }
        }
        private byte root(int x)
        {
            byte res = percolationArr[x];

            while (res != percolationArr[res])
            {
                percolationArr[res] = percolationArr[percolationArr[res]]; // path compression (flat tree)
                res = percolationArr[res];
            }
            return res;
        }
    }
}