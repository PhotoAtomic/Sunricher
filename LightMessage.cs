using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhotoAtomic.Sunricher
{

    public partial class LightMessage : SunricherMessage
    {
        private readonly byte category;
        private readonly byte channel;
        


        

        public LightMessage(byte category, byte channel)
        {
            this.category = category;
            this.channel = channel;            

        }

        internal override MessagePart Payload()
        {
            return ZonesPart().OfLength(1) +
                    CategoryPart().OfLength(1) +
                    ChannelPart().OfLength(1) +
                    ValuePart().OfLength(1);
            

        }


        protected virtual IEnumerable<byte> ValuePart()
        {
            return null;
        }


        private IEnumerable<byte> ChannelPart()
        {
            yield return channel;
        }

        private IEnumerable<byte> CategoryPart()
        {
            yield return category;
        }

        protected virtual IEnumerable<byte> ZonesPart()
        {
            return null;
        }

      
    }
}
