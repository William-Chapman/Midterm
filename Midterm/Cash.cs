using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Midterm
{
    class Cash : Payment
    {
        public double Change { set; get; }
        public double AmountGiven { set; get; }

        public double GetChange(double grandTotal)
        {
            return grandTotal - AmountGiven;
        }
    }
}
