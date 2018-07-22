using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoAtomic.Sunricher
{
    public class VariableLightMessage : LightMessage
    {        

        public VariableLightMessage(byte category, byte channel) : base(category, channel)
        {
            
        }
       
        public byte Value { get; set; }

        protected override IEnumerable<byte> ValuePart()
        {
            yield return Value;
        }

    }
}
