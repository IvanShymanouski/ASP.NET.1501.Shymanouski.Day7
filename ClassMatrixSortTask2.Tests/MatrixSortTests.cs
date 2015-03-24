using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using ClassMatrixSortTask2;

namespace ClassMatrixSortTask2.Tests
{
    [TestClass]
    public class MatrixSortTests
    {
        #region Delegate
        [TestMethod]
        public void MatrixSortSum()
        {
            const int xSize = 10;

            int[][] matrix = new int[xSize][];
            Random random = new Random();

            for (int i = 0; i < xSize; i++)
            {
                int ySize = random.Next(1, 11);
                matrix[i] = new int[ySize];
                for (int j = 0; j < ySize; j++)
                {
                    matrix[i][j] = random.Next(-1000, 1000);
                }
            }
            int[][] matrix1 = (Int32[][])matrix.Clone();

            Func<int[], int[], int> comparer = (i, j) => i.Sum() - j.Sum();

            MatrixSort.Sort(matrix, comparer);

            Comparison<int[]> sysComparer = (i, j) =>
            {
                if (i.Sum() > j.Sum()) return 1;
                else if (i.Sum() < j.Sum()) return -1;
                else return 0;
            };

            Array.Sort<int[]>(matrix1, sysComparer);

            CollectionAssert.AreEqual(matrix, matrix1);

        }

        [TestMethod]
        public void MatrixSortAbs()
        {
            const int xSize = 10;

            int[][] matrix = new int[xSize][];
            Random random = new Random();

            for (int i = 0; i < xSize; i++)
            {
                int ySize = random.Next(1, 11);
                matrix[i] = new int[ySize];
                for (int j = 0; j < ySize; j++)
                {
                    matrix[i][j] = random.Next(-1000, 1000);
                }
            }
            int[][] matrix1 = (Int32[][])matrix.Clone();

            Func<int[], int[], int> comparer = (i, j) => i.Max((k) => Math.Abs(k)) - j.Max((k) => Math.Abs(k));

            MatrixSort.Sort(matrix, comparer);

            Comparison<int[]> sysComparer = (i, j) =>
            {
                if (i.Max((k) => Math.Abs(k)) > j.Max((k) => Math.Abs(k))) return 1;
                else if (i.Max((k) => Math.Abs(k)) < j.Max((k) => Math.Abs(k))) return -1;
                else return 0;
            };

            Array.Sort<int[]>(matrix1, sysComparer);

            CollectionAssert.AreEqual(matrix, matrix1);

        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void MatrixSortAbsOperationExeption()
        {
            const int xSize = 10;

            int[][] matrix = new int[xSize][];
            Random random = new Random();

            for (int i = 0; i < xSize; i++)
            {
                int ySize = random.Next(1, 11);
                if (i==4) continue;
                matrix[i] = new int[ySize];
                for (int j = 0; j < ySize; j++)
                {
                    matrix[i][j] = random.Next(-1000, 1000);
                }
            }

            Func<int[], int[], int> comparer = (i, j) => i.Max((k) => Math.Abs(k)) - j.Max((k) => Math.Abs(k));

            MatrixSort.Sort(matrix, comparer);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MatrixSortAbsArgumentNullExeption()
        {
            int[][] matrix = null;

            Func<int[], int[], int> comparer = (i, j) => i.Max((k) => Math.Abs(k)) - j.Max((k) => Math.Abs(k));

            MatrixSort.Sort(matrix, comparer);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MatrixSortSumComparerNullExeption()
        {
            const int xSize = 10;

            int[][] matrix = new int[xSize][];
            Random random = new Random();

            for (int i = 0; i < xSize; i++)
            {
                int ySize = random.Next(1, 11);
                matrix[i] = new int[ySize];
                for (int j = 0; j < ySize; j++)
                {
                    matrix[i][j] = random.Next(-1000, 1000);
                }
            }
            int[][] matrix1 = (Int32[][])matrix.Clone();

            Func<int[], int[], int> comparer = null;

            MatrixSort.Sort(matrix, comparer);

        }
        #endregion

        [TestMethod]
        public void MatrixSortSumInterface()
        {
            const int xSize = 10;

            int[][] matrix = new int[xSize][];
            Random random = new Random();

            for (int i = 0; i < xSize; i++)
            {
                int ySize = random.Next(1, 11);
                matrix[i] = new int[ySize];
                for (int j = 0; j < ySize; j++)
                {
                    matrix[i][j] = random.Next(-1000, 1000);
                }
            }
            int[][] matrix1 = (Int32[][])matrix.Clone();

            SumArrayComparer comparer = new SumArrayComparer();

            MatrixSort.Sort(matrix, comparer);

            Comparison<int[]> sysComparer = comparer.Comparer;

            Array.Sort<int[]>(matrix1, sysComparer);

            CollectionAssert.AreEqual(matrix, matrix1);

        }

        [TestMethod]
        public void MatrixSortAbsInterface()
        {
            const int xSize = 10;

            int[][] matrix = new int[xSize][];
            Random random = new Random();

            for (int i = 0; i < xSize; i++)
            {
                int ySize = random.Next(1, 11);
                matrix[i] = new int[ySize];
                for (int j = 0; j < ySize; j++)
                {
                    matrix[i][j] = random.Next(-1000, 1000);
                }
            }
            int[][] matrix1 = (Int32[][])matrix.Clone();

            AbsMaxArrayComparer comparer = new AbsMaxArrayComparer();

            MatrixSort.Sort(matrix, comparer);

            Comparison<int[]> sysComparer = comparer.Comparer;

            Array.Sort<int[]>(matrix1, sysComparer);

            CollectionAssert.AreEqual(matrix, matrix1);

        }

        [TestMethod]
        public void MatrixSortLenInterface()
        {
            const int xSize = 10;

            int[][] matrix = new int[xSize][];
            Random random = new Random();

            for (int i = 0; i < xSize; i++)
            {
                int ySize = random.Next(1, 11);
                matrix[i] = new int[ySize];
                for (int j = 0; j < ySize; j++)
                {
                    matrix[i][j] = random.Next(-1000, 1000);
                }
            }

            ArrayLenComparer comparer = new ArrayLenComparer();

            MatrixSort.Sort(matrix, comparer);

            for (int i = 1; i < matrix.Length; i++)
            {
                if (matrix[i].Length < matrix[i - 1].Length) Assert.Fail("Error arrary[" + i + "] length < " + "arrary[" + (i - 1) + "] length");
            }

        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void MatrixSortLenOperationExeptionInterface()
        {
            const int xSize = 10;

            int[][] matrix = new int[xSize][];
            Random random = new Random();

            for (int i = 0; i < xSize; i++)
            {
                int ySize = random.Next(1, 11);
                if (i == 4) continue;
                matrix[i] = new int[ySize];
                for (int j = 0; j < ySize; j++)
                {
                    matrix[i][j] = random.Next(-1000, 1000);
                }
            }

            ArrayLenComparer comparer = new ArrayLenComparer();

            MatrixSort.Sort(matrix, comparer);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MatrixSortAbsArgumentNullExeptionInterface()
        {
            int[][] matrix = null;

            AbsMaxArrayComparer comparer = new AbsMaxArrayComparer();

            MatrixSort.Sort(matrix, comparer);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MatrixSortSumComparerNullExeptionInterface()
        {
            const int xSize = 10;

            int[][] matrix = new int[xSize][];
            Random random = new Random();

            for (int i = 0; i < xSize; i++)
            {
                int ySize = random.Next(1, 11);
                matrix[i] = new int[ySize];
                for (int j = 0; j < ySize; j++)
                {
                    matrix[i][j] = random.Next(-1000, 1000);
                }
            }
            int[][] matrix1 = (Int32[][])matrix.Clone();

            SumArrayComparer comparer = null;

            MatrixSort.Sort(matrix, comparer);

        }
    }
}
