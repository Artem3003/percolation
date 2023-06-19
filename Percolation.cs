using System;

namespace percolation
{
    class Percolation
    {

        private byte[] percolationArr = new byte[0];
        private bool[] openedArr = new bool[0]; // true/false array
        private byte[] sizeArr = new byte[0];

        // creates n-by-n grid, with all sites initially blocked
        public void Init(int n)
        {

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