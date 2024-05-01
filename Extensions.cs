using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindiFy
{

    public static class Extensions
    {
        public static double Variance(this IEnumerable<double> values)
        {
            double avg = values.Average();
            return values.Sum(v => Math.Pow(v - avg, 2)) / values.Count();
        }
    }
}
