using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEulerSharp
{
    public class Triplet
    {
        public Triplet(long first, long second, long third)
        {
            First = first;
            Second = second;
            Third = third;
        }

        public long First;

        public long Second;

        public long Third;

        public override string ToString()
        {
            return First + " :: " + Second + " :: " + Third;
        }
    }
}
