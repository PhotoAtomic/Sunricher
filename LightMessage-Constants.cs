using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoAtomic.Sunricher
{
    public partial class LightMessage
    {
        /// <summary>
		///     Disable all lights message.
		/// </summary>
		public static FixedLightMessage AllOff => new FixedLightMessage( 0x2, 0x12, 0xA9 );

        /// <summary>
        ///     Enable all lights and restore to their previous state message.
        /// </summary>
        public static FixedLightMessage AllOn => new FixedLightMessage( 0x2, 0x12, 0xAB );

        
        public static ZonableFixedLightMessage Zone1Off => new ZonableFixedLightMessage( 0x2, 0xA, 0x92 );
        public static ZonableFixedLightMessage Zone1On => new ZonableFixedLightMessage( 0x2, 0xA, 0x93 );
        public static ZonableFixedLightMessage Zone2Off => new ZonableFixedLightMessage( 0x2, 0xA, 0x95 );
        public static ZonableFixedLightMessage Zone2On => new ZonableFixedLightMessage( 0x2, 0xA, 0x96 );
        public static ZonableFixedLightMessage Zone3Off => new ZonableFixedLightMessage( 0x2, 0xA, 0x98 );
        public static ZonableFixedLightMessage Zone3On => new ZonableFixedLightMessage( 0x2, 0xA, 0x99 );
        public static ZonableFixedLightMessage Zone4Off => new ZonableFixedLightMessage( 0x2, 0xA, 0x9B );
        public static ZonableFixedLightMessage Zone4On => new ZonableFixedLightMessage( 0x2, 0xA, 0x9C );
        public static ZonableFixedLightMessage Zone5Off => new ZonableFixedLightMessage( 0x2, 0xA, 0x9E );
        public static ZonableFixedLightMessage Zone5On => new ZonableFixedLightMessage( 0x2, 0xA, 0x9F );
        public static ZonableFixedLightMessage Zone6Off => new ZonableFixedLightMessage( 0x2, 0xA, 0xA1 );
        public static ZonableFixedLightMessage Zone6On => new ZonableFixedLightMessage( 0x2, 0xA, 0xA2 );
        public static ZonableFixedLightMessage Zone7Off => new ZonableFixedLightMessage( 0x2, 0xA, 0xA4 );
        public static ZonableFixedLightMessage Zone7On => new ZonableFixedLightMessage( 0x2, 0xA, 0xA5 );
        public static ZonableFixedLightMessage Zone8Off => new ZonableFixedLightMessage( 0x2, 0xA, 0xA7 );
        public static ZonableFixedLightMessage Zone8On => new ZonableFixedLightMessage( 0x2, 0xA, 0xA8 );
                      
        public static ZonableVariableLightMessage CdwBrightnessSeekbar => new ZonableVariableLightMessage( 0x8, 0x33 );

        /// <summary>
        ///     Change brightness without changing color message.
        /// </summary>
        public static ZonableVariableLightMessage RgbBrightnessSeekbar => new ZonableVariableLightMessage( 0x8, 0x23 );
                      
        public static ZonableVariableLightMessage CircleCdw => new ZonableVariableLightMessage( 0x8, 0x36 );
        public static ZonableVariableLightMessage CircleDim => new ZonableVariableLightMessage( 0x8, 0x38 );
        public static ZonableVariableLightMessage CircleRgb => new ZonableVariableLightMessage( 0x1, 0x1 );
                      
        public static ZonableFixedLightMessage CurtainOff => new ZonableFixedLightMessage( 0x2, 0x80, 0x1 );
        public static ZonableFixedLightMessage CurtainOn => new ZonableFixedLightMessage( 0x2, 0x80, 0x2 );
                      
        public static ZonableFixedLightMessage FanOff => new ZonableFixedLightMessage( 0x2, 0x83, 0x1 );
        public static ZonableFixedLightMessage FanOn => new ZonableFixedLightMessage( 0x2, 0x83, 0x2 );
        public static ZonableVariableLightMessage FanSeekbar => new ZonableVariableLightMessage( 0x8, 0x82 );
                      
        public static ZonableFixedLightMessage Learn => new ZonableFixedLightMessage( 0x9, 0x37, 0x1 );
        public static ZonableFixedLightMessage LearnZone => new ZonableFixedLightMessage( 0x1, 0x1, 0x1 );

        /// <summary>
        ///     Set Red channel message.
        /// </summary>
        public static ZonableVariableLightMessage RgbRSeekbar => new ZonableVariableLightMessage( 0x8, 0x48 );

        /// <summary>
        ///     Set Green channel message.
        /// </summary>
        public static ZonableVariableLightMessage RgbGSeekbar => new ZonableVariableLightMessage( 0x8, 0x49 );

        /// <summary>
        ///     Set Blue channel message.
        /// </summary>
        public static ZonableVariableLightMessage RgbBSeekbar => new ZonableVariableLightMessage( 0x8, 0x4A );

        public static ZonableFixedLightMessage RgbLongclickA1 => new ZonableFixedLightMessage( 0x2, 0x2, 0x81 );
        public static ZonableFixedLightMessage RgbLongclickA2 => new ZonableFixedLightMessage( 0x2, 0x3, 0x84 );
        public static ZonableFixedLightMessage RgbLongclickA3 => new ZonableFixedLightMessage( 0x2, 0x4, 0x87 );
                      
        public static ZonableFixedLightMessage RgbLongclickB1 => new ZonableFixedLightMessage( 0x2, 0x2, 0x82 );
        public static ZonableFixedLightMessage RgbLongclickB2 => new ZonableFixedLightMessage( 0x2, 0x3, 0x85 );
        public static ZonableFixedLightMessage RgbLongclickB3 => new ZonableFixedLightMessage( 0x2, 0x4, 0x88 );
                      
        public static ZonableFixedLightMessage RgbMusic => new ZonableFixedLightMessage( 0x3, 0x50, 0x1 );
        public static ZonableFixedLightMessage RgbMusicRecordOff => new ZonableFixedLightMessage( 0x3, 0x50, 0x2 );
        public static ZonableFixedLightMessage RgbMusicRecordOn => new ZonableFixedLightMessage( 0x3, 0x50, 0x3 );
                      
        public static ZonableVariableLightMessage RgbRunOff => new ZonableVariableLightMessage( 0x2, 0x4E );
        public static ZonableFixedLightMessage RgbRunOn => new ZonableFixedLightMessage( 0x2, 0x4F, 0x15 );
        public static ZonableVariableLightMessage RgbRunSeekbar => new ZonableVariableLightMessage( 0x8, 0x22 );
                      
        public static ZonableFixedLightMessage RgbWhiteLongclickOff => new ZonableFixedLightMessage( 0x2, 0x5, 0x8A );
        public static ZonableFixedLightMessage RgbWhiteLongclickOn => new ZonableFixedLightMessage( 0x2, 0x5, 0x8B );

        /// <summary>
        ///     Set White channel message.
        /// </summary>
        public static ZonableVariableLightMessage RgbWhiteSeekbar => new ZonableVariableLightMessage( 0x8, 0x4B );
                      
        public static ZonableFixedLightMessage Save1 => new ZonableFixedLightMessage( 0x2, 0xA, 0x91 );
        public static ZonableFixedLightMessage Save2 => new ZonableFixedLightMessage( 0x2, 0xB, 0x94 );
        public static ZonableFixedLightMessage Save3 => new ZonableFixedLightMessage( 0x2, 0xC, 0x97 );
        public static ZonableFixedLightMessage Save4 => new ZonableFixedLightMessage( 0x2, 0xD, 0x9A );
        public static ZonableFixedLightMessage Save5 => new ZonableFixedLightMessage( 0x2, 0xE, 0x9D );
        public static ZonableFixedLightMessage Save6 => new ZonableFixedLightMessage( 0x2, 0xF, 0xA0 );
        public static ZonableFixedLightMessage Save7 => new ZonableFixedLightMessage( 0x2, 0x10, 0xA3 );
        public static ZonableFixedLightMessage Save8 => new ZonableFixedLightMessage( 0x2, 0x11, 0xA6 );
        public static ZonableFixedLightMessage SaveClick => new ZonableFixedLightMessage( 0x2, 0x14, 0xB0 );
        public static ZonableFixedLightMessage SaveLongclick => new ZonableFixedLightMessage( 0x2, 0x14, 0xB1 );
    }
}
