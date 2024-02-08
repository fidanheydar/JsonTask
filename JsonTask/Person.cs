using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonTask
{
    public class Person
    {
        public string Fullname { get; set; }
        public byte Age { get; set; }
        public override string ToString()
        {
            return Fullname + ':' + Age;
        }
    }
}
