using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassMatrixSortTask2
{
    public class SumArrayComparer:IComparer
    {
        public int Comparer(int[] a, int[] b)
        {
            return a.Sum() - b.Sum();
        }
    }
}
