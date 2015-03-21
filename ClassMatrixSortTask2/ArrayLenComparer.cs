using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassMatrixSortTask2
{
    public class ArrayLenComparer:IComparer
    {
        public int Comparer(int[] a, int[] b)
        {
            return a.Length - b.Length;
        }
    }
}
