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

        private IPAddress serverIP;
        private int serverPort;

        public IEnumerable<byte> remoteId = null;


        public  SunricherRemote(IPAddress serverIP, int serverPort = 8899)
        {            
            this.serverIP = serverIP;
            this.serverPort = serverPort;
        }

        public SunricherRemote(int id, IPAddress serverIP, int serverPort = 8899): this(serverIP, serverPort)
        {
            remoteId = BitConverter.GetBytes(id).Skip(1).Take(3);
            
        }

        public SunricherRemote(byte a, byte b, byte c, IPAddress serverIP, int serverPort = 8899) : this(serverIP, serverPort)
        {
            remoteId = new[] { a, b, c };

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
                await tcp.ConnectAsync(serverIP, serverPort);

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
