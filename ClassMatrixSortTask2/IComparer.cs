using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassMatrixSortTask2
{
    public interface IComparer
    {
        /// <summary>
        /// Represents the method that compares two arrays of the int type.
        /// </summary>
        /// <param name="a">The first array to compare.</param>
        /// <param name="b">The second array to compare.</param>
        /// <returns>
        ///     A signed integer that indicates the relative values of x and y, as shown
        ///     in the following table.Value Meaning Less than 0 a is less than b.0 a equals
        ///     b.Greater than 0 a is greater than b.
        /// </returns>
        int Comparer(int[] a, int[] b);
    }
}
