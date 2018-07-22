using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoAtomic.Sunricher
{
    public class FixedLightMessage : LightMessage
    {
        private byte value;

        public FixedLightMessage(byte category, byte channel, byte value) : base(category, channel)
        {
            this.value = value;
        }
        
        protected override IEnumerable<byte> ValuePart()
        {
            yield return value;
        }
    }
}
