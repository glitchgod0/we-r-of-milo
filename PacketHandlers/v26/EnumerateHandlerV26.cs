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

            // stubbed response for now
            stream.WriteByte((byte)HolmesPacketsV24.kEnumerate);
            //stream.WriteByte(0);

            //// WIP

            //if (dir == ".")
            //{
            //    stream.WriteByte(0);
            //    return;
            //}

            dir = dir.Replace("..", "(..)");
            Console.WriteLine(dir);
            DirectoryInfo dirInfo = new DirectoryInfo("files/" + dir);

            if (!dirInfo.Exists)
            {
                stream.WriteByte(0);
                Console.WriteLine("EXIT 1");
                return;
            }

            FileInfo[] Files = dirInfo.GetFiles();

            if (Files.Length == 0)
            {
                stream.WriteByte(0);
                Console.WriteLine("EXIT 2");
            } else {
                
                foreach (FileInfo i in Files)
                {
                    Console.WriteLine("Dir Name - {0}", dir);
                    Console.WriteLine("File Name - {0}", i.Name);

                    stream.WriteByte(1);
                    stream.WriteLengthPrefixedString(Encoding.UTF8, dir);
                    stream.WriteLengthPrefixedString(Encoding.UTF8, i.Name); //idk what the 2nd string is
                }
                stream.WriteByte(0);
            }

        }
    }
}
