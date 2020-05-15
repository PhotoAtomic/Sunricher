using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace PhotoAtomic.Sunricher
{
    public partial class SunricherRemote
    {
        public int id { get; }
        const int DelayAfterMessage = 100;

        private string host;
        private int port;

        public IEnumerable<byte> remoteId = null;


 
        public SunricherRemote(int id, string host, int port = 8899): this(BitConverter.GetBytes(id).Skip(1).Take(3), host, port)
        {            
        }

        public SunricherRemote(byte a, byte b, byte c, string host, int port = 8899) : this( new[] { a, b, c }, host, port)
        {
            remoteId = new[] { a, b, c };
        }


        private SunricherRemote(IEnumerable<byte> remoteId, string host, int port = 8899)
        {
            if (remoteId == null) throw new ArgumentNullException(nameof(remoteId));
            if (host == null) throw new ArgumentNullException(nameof(host));
            this.remoteId = remoteId;
            this.host = host;
            this.port = port;

        }

        private IEnumerable<byte> RemoteId()
        {
            return remoteId;
        }


        public async Task Send(SunricherMessage message)
        {
            //message.SetRemoteId(remoteId.ElementAt(0), remoteId.ElementAt(1), remoteId.ElementAt(2));
            using (message.WithRemoteIdGenerator(RemoteId))
            {
                using (var tcp = new TcpClient())
                {
                    var buffer = message.ToArray();
                    //tcp.Connect(host,port);
                    await tcp.ConnectAsync(host, port);

                    if (tcp.Client.Connected)
                    {
                        var stream = tcp.GetStream();
                        await stream.WriteAsync(buffer, 0, buffer.Length);
                        await stream.FlushAsync();
                        await Task.Delay(DelayAfterMessage);
                    }
                }
            }
        }

     
    }
}
