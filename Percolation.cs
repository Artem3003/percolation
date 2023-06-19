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
            int rowIndex = row - 1;
            int colIndex = col - 1;
            int index = rowIndex * size + colIndex + 1;
            if (!IsOutOfRange(row, col))
            {
                openedArr[index] = true;
                openSites++;

                // top row
                if (row == 1)
                {
                   Union(percolationArr[index], percolationArr[0]);
                }
                //bottom row
                if (row == size)
                {
                    Union(percolationArr[index], percolationArr[size * size + 1]);
                }
                // up
                if (row > 1 && IsOpenIndex(row - 1, col))
                {
                    Union(percolationArr[index], percolationArr[(rowIndex - 1) * size + colIndex + 1]);
                }
                // down
                if (row < size && IsOpenIndex(row + 1, col))
                {
                    Union(percolationArr[index], percolationArr[(rowIndex + 1) * size + colIndex + 1]);
                }
                // right
                if (col < size && IsOpenIndex(row, col + 1))
                {
                    Union(percolationArr[index], percolationArr[rowIndex * size + (colIndex + 1) + 1]);
                }
                // left
                if (col > 1 && IsOpenIndex(row, col - 1))
                {
                    Union(percolationArr[index], percolationArr[rowIndex * size + (colIndex - 1) + 1]);
                }
            } else 
            {
                Console.WriteLine($"I couldn't find site ({row}, {col})");
            }
        }

        private bool IsOpenIndex(int row, int col)
        {
            return openedArr[Index(row, col)];
        }

        private int Index(int row, int col)
        {
            row--;
            col--;
            int index = row * size + col + 1;
            return index;
        }

        private bool IsOutOfRange(int row, int col)
        {
            if (row > size || row <= 0 || col > size || col <= 0)
            {
                return true;
            }
            return false;
        }

        // is the site (row, col) open?
        public bool IsOpen(int row, int col)
        {
            Console.WriteLine($"This is open site ({row}, {col}): {openedArr[Index(row, col)]}");
            return openedArr[Index(row, col)];
        }

        // is the site (row, col) full?
        public bool IsFull(int row, int col)
        {
            return openedArr[Index(row, col)];
        }

        private bool IsFullIndex(int index)
        {
            return Root(topSite) == Root(index);
        }

        // returns the number of open sites
        public int NumberOfOpenSites()
        {
            Console.WriteLine($"The number of open sites is {openSites}");
            return openSites;
        }

        // does the system percolate?
        public bool Percolates()
        {
            byte rootX = Root(topSite);
            byte rootY = Root(percolationArr[size * size + 1]);
            Console.WriteLine($"It is perculates: {rootX == rootY}");
            return rootX == rootY;
        }

        // prints the matrix on the screen
        // The method should display different types of sites (open, blocked, full)
        public void Print()
        {
            Console.WriteLine("Percolation:");
            for (int i = 1; i <= openedArr.Length - 2; i++)
            {
                if (openedArr[i] && IsFullIndex(i))
                {
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.Write("■ ");
                } else if (openedArr[i])
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("□ ");
                }
                else 
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write("□ ");
                }

                if (i % size == 0)
                {
                    Console.WriteLine();
                }
            } 
            Console.ResetColor();
            Console.WriteLine();
        }

        // weigheted-quick-Union algorithm
        private void Union(int x, int y)
        {
            byte rootX = Root(x);
            byte rootY = Root(y);
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
        private byte Root(int x)
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