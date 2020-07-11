using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace graph.simplify.api.Entities
{
    public enum EnumeratorField
    {
        first,
        midle,
        last
    }

    public class Sample
    {
        public bool BooleanProperty { get; set; }
        public byte ByteProperty { get; set; }
        public char CharProperty { get; set; }
        public DateTime DateTimeProperty { get; set; }
        public decimal DecimalProperty { get; set; }
        public double DoubleProperty { get; set; }
        public float FloatProperty { get; set; }
        public int IntProperty { get; set; }
        public long LongProperty { get; set; }
        public short ShortProperty { get; set; }
        public string StringProperty { get; set; }
        public EnumeratorField EnumeratorProperty { get; set; }
        public Guid GuidProperty { get; set; }
    }
}
