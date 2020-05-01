using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PhotoAtomic.Sunricher
{
    public partial class SunricherRemote
    {

        ZonableFixedLightMessage[] OnCommandByZone = new ZonableFixedLightMessage[]
        {
            LightMessage.Zone1On,
            LightMessage.Zone2On,
            LightMessage.Zone3On,
            LightMessage.Zone4On,
            LightMessage.Zone5On,
            LightMessage.Zone6On,
            LightMessage.Zone7On,
            LightMessage.Zone8On,
        };

        ZonableFixedLightMessage[] OffCommandByZone = new ZonableFixedLightMessage[]
        {
            LightMessage.Zone1Off,
            LightMessage.Zone2Off,
            LightMessage.Zone3Off,
            LightMessage.Zone4Off,
            LightMessage.Zone5Off,
            LightMessage.Zone6Off,
            LightMessage.Zone7Off,
            LightMessage.Zone8Off,
        };
        

        public Task On(int? zone)
        {            
            return Send(PickZone(zone, OnCommandByZone, LightMessage.AllOn));
        }

        public Task Off(int? zone)
        {
            return Send(PickZone(zone, OffCommandByZone, LightMessage.AllOff));
        }

        public Task Dim(int zone, byte value)
        {            
            //var m = LightMessage.RgbBrightnessSeekbar;
            var m = LightMessage.CircleDim;            
            m.Value = value;
            m.Zones.SetAll(false);
            m.Zones[zone-1] = true;
            return Send(m);
        }

        private LightMessage PickZone(int? zone, ZonableFixedLightMessage[] commandByZone, LightMessage defaultCommand)
        {            
            if (zone is int i)
            {
                if (i < 1 || i > 8) throw new ArgumentOutOfRangeException("Zone can be from 1 to 8 only");
                var m = commandByZone[i-1];
                m.Zones.SetAll(false);
                m.Zones[i-1] = true;
                return m;
            }
            else
            {
                return defaultCommand;
            }            
        }
    }
}
