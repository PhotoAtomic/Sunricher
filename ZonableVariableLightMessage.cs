using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace PhotoAtomic.Sunricher
{
    public class ZonableVariableLightMessage : VariableLightMessage, IZonable
    {        

        public ZonableVariableLightMessage(byte category, byte channel) : base(category, channel)
        {
            Zones = new BitArray(8);
        }

        public BitArray Zones { get; set; }

        protected override IEnumerable<byte> ZonesPart()
        {
            yield return Zones.ToByte();
        }
    }
}
