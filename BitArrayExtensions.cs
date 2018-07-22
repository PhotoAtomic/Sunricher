using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace PhotoAtomic.Sunricher
{
    public static class BitArrayExtensions
    {
        public static byte ToByte(this BitArray bits)
        {
            byte result = 0;
            for (int i = 0; i < 8; i++)
            {
                if (bits[i])
                {
                    result |= (byte)(1 << i);
                }
            }
            return result;
        }
    }
}
