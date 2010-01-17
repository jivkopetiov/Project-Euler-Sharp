using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEulerSharp
{
    public class MetadataAttribute : Attribute
    {
        public long Result { get; set; }

        public string Name { get; set; }

        public string Url { get; set; }
    }
}
