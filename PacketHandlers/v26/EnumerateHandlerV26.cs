using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace we_r_of_milo.PacketHandlers.v26
{
    internal class EnumerateHandlerV26 : IPacketHandler
    {
        public ConnectedClient Client { get; set; }
        public EnumerateHandlerV26(ConnectedClient _client)
        {
            Client = _client;
        }

        public void HandlePacket(Stream stream)
        {
            string dir = stream.ReadLengthPrefixedString(Encoding.UTF8);
            byte unk1 = stream.ReadUInt8();
            string match = stream.ReadLengthPrefixedString(Encoding.UTF8);
            byte unk2 = stream.ReadUInt8();

            Console.WriteLine(" dir: " + dir);
            Console.WriteLine(" match: " + dir);
            Console.WriteLine(" unk1:" + unk1.ToString("X2") + " unk2:" + unk2.ToString("X2"));


            stream.WriteByte((byte)HolmesPacketsV24.kEnumerate);

            dir = dir.Replace("..", "(..)");
            DirectoryInfo dirInfo = new DirectoryInfo("files/" + dir);

            if (!dirInfo.Exists)
            {
                stream.WriteByte(0);
                return;
            }

            FileInfo[] Files = dirInfo.GetFiles();


            foreach (FileInfo i in Files)
            {
                stream.WriteByte(1);
                stream.WriteLengthPrefixedString(Encoding.UTF8, dir);
                stream.WriteLengthPrefixedString(Encoding.UTF8, i.Name);
            }
            stream.WriteByte(0);
           

        }
    }
}
