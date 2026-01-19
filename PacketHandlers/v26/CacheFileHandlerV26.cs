using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace we_r_of_milo.PacketHandlers.v24
{
    internal class CacheFileHandlerV26 : IPacketHandler
    {
        public ConnectedClient Client { get; set; }
        public CacheFileHandlerV26(ConnectedClient _client)
        {
            Client = _client;
        }

        public void HandlePacket(Stream stream)
        {
            uint Size = stream.ReadUInt32LE();
            string FilePath = stream.ReadASCIINullTerminated();

            Console.WriteLine("Output not implemented fully, hack used");

            //i think if the file doesnt exist on the console but does on the pc, it sends true and i guess copy the file over?
            //if not, idk. panic.

            //hack
            stream.WriteByte((byte)HolmesPacketsV26.kCacheFile);
            stream.WriteByte(0x00);
        
            //return;
        }
    }
}