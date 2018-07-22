using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace PhotoAtomic.Sunricher
{
    public class ZonableFixedLightMessage : FixedLightMessage, IZonable
    {        

        public ZonableFixedLightMessage(byte category, byte channel, byte value) : base(category, channel, value)
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
