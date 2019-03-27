using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web
{
    public class SomeGenericClass
    {
        public SomeGenericClass(string water, string fire)
        {
            this.water = water;
            this.fire = fire;
        }

        public string water { get; set; }

        public string fire { get; set; }
    }
}
