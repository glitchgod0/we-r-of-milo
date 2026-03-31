using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace we_r_of_milo.PacketHandlers.v26
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
            string filePath = stream.ReadLengthPrefixedString(Encoding.UTF8);
            int fileRes = stream.ReadByte();

            if (fileRes == 0x1)
            {
                UInt64 fileTime = stream.ReadUInt64LE();
            }

            //TODO: process the file timestamp and verify if its older than the files on the pc
            //if it is give 0x00 and load from pc 
            //if not, continue (give 0x01)


            stream.WriteByte((byte)HolmesPacketsV26.kCacheFile);
            stream.WriteByte(0x00);

        }
    }
}