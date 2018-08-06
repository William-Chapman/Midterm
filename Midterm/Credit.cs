using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Midterm
{
    class Credit : Payment
    {
        public string CardNum { set; get; }
        public string ExpDate { set; get; }
        public string CVV { set; get; }
    }
}
