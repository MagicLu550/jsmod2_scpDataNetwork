using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using scpDataNetwork.listener;
using scpDataNetwork.network;
using Smod2;
using Smod2.Attributes;


/**
 * @author MagicLu550 #(code) jsmod2
 */

namespace scpDataNetwork
{
    [PluginDetails(
        author = "Magiclu550",
        name = "Network",
        description = "connect with java smod2",
        id = "net.noyark.NetWork",
        configPrefix = "ep",
        langFile = "scpDataNetwork",
        version = "1.0",
        SmodMajor = 3,
        SmodMinor = 4,
        SmodRevision = 1
    )]
    class MainClass : Plugin
    {
        public static void Main(string[]args)
        {
            ip = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 19935);//connect the java smod2
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            new MainClass().sendPacket(new ClosePacket());
        }
        private static IPEndPoint ip;
        
        private static MainClass main;

        private static Socket socket;
        public override void Register()
        {
            AddEventHandlers(new AdminQueryHandler());
        }

        public override void OnEnable()
        {
            main = this;
            Message.load("the dataNetwork is starting");
            Message.load("请确保您的java服务器的指定端口是开启的，使得java服务器可以连接");
            //配置文件，指向端口
            if (!Directory.Exists("../jsmod2"))
            {
                Directory.CreateDirectory("../jsmod2");
                FileStream stream = File.Create("../jsmod2/conn.properties");
                StreamWriter writer = new StreamWriter(stream);
                writer.Write("port: 19398");
                writer.Close();
            }

            StreamReader reader = File.OpenText(@"../jsmod2/conn.properties");
            String msg = null;
            while ((msg = reader.ReadLine())!=null)
            {
                if (msg.StartsWith("port:"))
                {
                    string[] entry = msg.Replace(" ", "").Split(":");
                    if (entry.Length > 1)
                    {
                        msg = entry[1];
                    }
                    else
                    {
                        msg = "19398";
                    }
                    break;
                }
            }
            int port = 0;
            int.TryParse(msg,out port);
            ip = new IPEndPoint(IPAddress.Parse(Server.IpAddress), port);//connect the java smod2
            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            server.Bind(ip);//with ip
            socket = server;
            //把server对象发包
        }

        public void sendPacket(DataPacket packet)
        {
            byte[] data = packet.encode();
            socket.SendTo(data, data.Length, SocketFlags.None, ip);
        }
        public override void OnDisable()
        {
            sendPacket(new ClosePacket());
        }

        public static MainClass getInstance()
        {
            return main;
        }

        public static Socket getSocket()
        {
            return socket;
        }
    }
}