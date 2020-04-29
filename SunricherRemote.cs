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

        private IPEndPoint endPoint;

        public IEnumerable<byte> remoteId = null;


        public  SunricherRemote(IPEndPoint endPoint)
        {
            this.endPoint = endPoint;
        }

        public SunricherRemote(int id, IPEndPoint endPoint) : this(endPoint)
        {
            remoteId = BitConverter.GetBytes(id).Skip(1).Take(3);
        }

        public SunricherRemote(int id, IPAddress serverIP, int serverPort = 8899): this(id, new IPEndPoint(serverIP, serverPort))
        {            
        }

        public SunricherRemote(byte a, byte b, byte c, IPEndPoint endPoint) : this(endPoint)
        {
            remoteId = new[] { a, b, c };
        }

        public SunricherRemote(byte a, byte b, byte c, IPAddress serverIP, int serverPort = 8899) : this(a,b,c,new IPEndPoint(serverIP, serverPort))
        {            
        }

        private IEnumerable<byte> RemoteId()
        {
            return remoteId;
        }


        public async Task Send(SunricherMessage message)
        {
            using (message.WithRemoteIdGenerator(RemoteId))                                            
            using (var tcp = new TcpClient())
            {
                var buffer = message.ToArray();
                tcp.Connect(endPoint);
                //await tcp.ConnectAsync(endPoint.Address,endPoint.Port);

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
