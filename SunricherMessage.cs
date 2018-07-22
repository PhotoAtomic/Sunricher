using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhotoAtomic.Sunricher
{

    public class MessagePart : IEnumerable<byte>
    {

        private readonly IEnumerable<byte> values;

        public MessagePart(IEnumerable<byte> values)
        {
            this.values = values;
        }

        public IEnumerator<byte> GetEnumerator()
        {
            return values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return values.GetEnumerator();
        }

        public static MessagePart operator +(MessagePart a, MessagePart b)
        {
            return new MessagePart(Enumerable.Concat(a ?? Enumerable.Empty<byte>(), b ?? Enumerable.Empty<byte>()));
        }


    }

    public abstract class SunricherMessage : IEnumerable<byte>
    {
        private byte[] remoteId;

        public IEnumerable<byte> GetMessage()
        {
            MessagePart payload = 
                IdMarker().OfLength(1)+ 
                Payload().OfLength(4);

            var message =
                Preamble().OfLength(1) +
                RemoteId?.Invoke().OfLength(3) +
                payload +
                Checksum(payload).OfLength(1) +
                Epilogue().OfLength(2);

            return message;

        }

        internal abstract MessagePart Payload();

        private IEnumerable<byte> Epilogue()
        {
            yield return 0xAA;
            yield return 0xAA;
        }

        private IEnumerable<byte> Checksum(IEnumerable<byte> payload)
        {
            yield return (byte)payload.Sum(x => x);
        }       

        private IEnumerable<byte> IdMarker()
        {
            yield return 0x02;
        }

        private IEnumerable<byte> Preamble()
        {
            yield return 0x55;
        }

        public void SetRemoteId(byte a, byte b , byte c)
        {
            this.remoteId = new[] { a, b, c };
        }

        public IEnumerator<byte> GetEnumerator()
        {
            return GetMessage().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        internal IDisposable WithRemoteIdGenerator(Func<IEnumerable<byte>> remoteId)
        {
            if (RemoteId != null) throw new Exception("Remote id generator already in use");
            RemoteId = remoteId;
            return new Resetter(() => { this.remoteId = null; });
        }

        public Func<IEnumerable<byte>> RemoteId { get; private set; }
    }
}
