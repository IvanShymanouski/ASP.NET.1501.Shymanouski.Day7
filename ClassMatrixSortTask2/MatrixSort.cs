using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassMatrixSortTask2
{
    public class MatrixSort
    {
        /// <summary>
        /// Sort strings of matrix by custom function
        /// </summary>
        /// <param name="array"></param>
        /// <param name="comparer"></param>
        public static void Sort(int[][] array, Func<int[], int[], int> comparer)
        {
            int[] index;

            //Initialization
            try
            {
                index = new int[array.Length];
            }
            catch (NullReferenceException ex)
            {
                throw new ArgumentNullException("array parameter must not be null", ex);
            }
            for (int i = 0; i < array.Length; i++)
            {
                index[i] = i;
            }
            try
            {
                Qsort(array, 0, array.Length - 1, comparer, index);
            }
            catch (ArgumentException ex)
            {
                throw new InvalidOperationException("", ex);
            }
            catch (NullReferenceException ex)
            {
                if (object.Equals(comparer, null))
                    throw new ArgumentNullException("comparer parameter must not be null", ex);
                else
                    throw new InvalidOperationException("", ex);
            }
            RearrangementOfArrayByIndex(array, index);
        }

        /// <summary>
        /// Sort strings of matrix by comparer
        /// </summary>
        /// <param name="array"></param>
        /// <param name="comparer"></param>
        public static void Sort(int[][] array, IComparer comparer)
        {
            if (object.Equals(comparer, null))
                throw new ArgumentNullException("comparer parameter must not be null");
            Sort(array, comparer.Comparer);
        }


        private static void Qsort(int[][] array, int left, int right, Func<int[], int[], int> comparer, int[] index)
        {
            int i = left;
            int j = right;
            int[] medium = array[index[(left + right) / 2]];

            while (i <= j)
            {
                while (comparer(array[index[i]], medium)<0) i++;
                while (comparer(medium, array[index[j]])<0) j--;
                if (i <= j)
                {
                    Swap(ref index[i], ref index[j]);
                    i++; j--;
                }
            }

            if (left < j) Qsort(array, left, j, comparer, index);
            if (i < right) Qsort(array, i, right, comparer, index);

        }

        private static void Swap(ref int a1, ref int a2)
        {
            int temp = a1;
            a1 = a2;
            a2 = temp;
        }

        private static void RearrangementOfArrayByIndex(int[][] array, int[] index)
        {
            int[][] newArray = new int[array.Length][];
            for (int i = 0; i < array.Length; i++)
            {
                newArray[i] = array[index[i]];
            }
            Array.Copy(newArray, array, array.Length);
        }
    }
}
