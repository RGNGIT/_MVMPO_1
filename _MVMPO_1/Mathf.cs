using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _MVMPO_1
{
    internal class Mathf
    {
        private Func<double, double, double> Function = (x, n) => (double)(Math.Pow(x, n) / Math.Pow(7, n));

        public virtual IEnumerable<Tuple<double, double>> FuncResultRange(double x, double epsilon) 
        {
            int i = 0;
            double currentTerm = Function(x, i);
            while (Math.Abs(currentTerm) > epsilon)
            {


                currentTerm = Function(x, i);
                i++;
                yield return new Tuple<double, double>(i, currentTerm);
            }
        }
    }
}
