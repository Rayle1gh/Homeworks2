using System;
using System.Collections.Generic;
using System.Text;

namespace Homework10
{
    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int AgeIn4Years { get { return Age + 4; } }
        public string Description { get { return $"{nameof(Name)}: {Name}, age in 4 years: {AgeIn4Years}."; } }
    }
}
