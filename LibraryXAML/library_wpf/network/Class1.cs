using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;

namespace network
{
    public class Client
    {

        public Client(string ip, int port)
        {
            sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            if (ip.Length == 0 || port <= 0)
            {
                return;
            }
            this.ip = ip;
            this.port = port;
        }
        public async void Connect() 
        {
            if (!ValidateIpAddr(ip))
            {
                return;
            }
            if (port <= 0 )
            {
                return;
            }
            

            try
            {
                await sock.ConnectAsync(ip, port);
            }
            catch (SocketException)
            {
                
            }
        }
        public void close_connection() 
        {
            sock.Close();

        }
        public async Task<int> Receive(byte[] buffer) 
        {
            return await sock.ReceiveAsync(buffer);
        }
        public async Task<int> SendAsync(byte[] buf) 
        {
            return await sock.SendAsync(buf);
        }

        

        public string GetRemoteHostName()
        {
            DnsEndPoint dns = new DnsEndPoint(ip, port);
            return dns.Host;
        }

        public string GetRemoteAddress()
        {
            return (!IsConnected()) ? "" : sock.RemoteEndPoint.ToString();
        }
        public bool IsConnected()
        {
            return sock.Connected;
        }


        private bool ValidateIpAddr(string addr)
        {
            int i = 0, times = 0;
            bool valid = false;
            while (addr[i] != '\0')
            {
                if (addr[i] == '.')
                {
                    times++;
                }
            }


            return (times == 3) ? true : false;
        }
        

        
        

        private string ip;
        private int port;

        private Socket sock;
    }

    public class Server
    {
        
        public Server()
        {
            sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }
        
        public void Listen(int max_clients)
        {
            sock.Listen(max_clients);
        }

        public void close_connection()
        {
            sock.Close();

        }
        public async Task<int> Receive(byte[] buffer)
        {
            return await sock.ReceiveAsync(buffer);
        }
        public async Task<int> SendAsync(byte[] buf)
        {
            return await sock.SendAsync(buf);
        }

        public async Task<Socket> Accept()
        {
            var s = await sock.AcceptAsync();
            return s;
        }

        public void Bind(IPEndPoint i)
        {
            sock.Bind(i);
        }



        
        private Socket sock;

    }

}