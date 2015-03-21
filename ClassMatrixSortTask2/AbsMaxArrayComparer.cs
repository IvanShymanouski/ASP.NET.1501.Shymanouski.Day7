using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassMatrixSortTask2
{
    public class AbsMaxArrayComparer:IComparer
    {
        public int Comparer(int[] a, int[] b)
        {
            return a.Max((k) => Math.Abs(k)) - b.Max((k) => Math.Abs(k));
        }
    }
}
