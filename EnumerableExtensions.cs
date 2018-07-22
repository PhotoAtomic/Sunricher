using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace PhotoAtomic.Sunricher
{
    public static class MessagePartExtensions
    {
        public static MessagePart OfLength(this IEnumerable<byte> sequence, int requiredLength, byte fill = default)
        {
            sequence = sequence ?? Enumerable.Empty<byte>();
            
            return new MessagePart( sequence.Take(requiredLength).Concat(Enumerable.Repeat(fill,requiredLength - Math.Min(sequence.Count(),requiredLength))) );
        }

        public static MessagePart OfLength(this byte value, int requiredLength, byte fill = default)
        {

            return ToEnumerable(value).OfLength(requiredLength, fill);
            
            IEnumerable<byte> ToEnumerable(byte singleValue)
            {
                yield return singleValue;
            }
            
        }

    }
}
