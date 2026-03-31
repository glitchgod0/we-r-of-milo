using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace we_r_of_milo.PacketHandlers.v26
{
    internal class CacheResourceHandlerV26 : IPacketHandler
    {
        public ConnectedClient Client { get; set; }
        public CacheResourceHandlerV26(ConnectedClient _client)
        {
            Client = _client;
        }
        public void HandlePacket(Stream stream)
        {
            string resourceName = stream.ReadLengthPrefixedString(Encoding.UTF8);
            Console.WriteLine(" resourceName: " + resourceName);

            stream.WriteByte((byte)HolmesPacketsV24.kCacheResource);
            stream.WriteByte((byte)0); // success
        }
    }
}
