using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace we_r_of_milo.PacketHandlers.v26
{
    internal class DeleteHandlerV26 : IPacketHandler
    {
        public ConnectedClient Client { get; set; }
        public DeleteHandlerV26(ConnectedClient _client)
        {
            Client = _client;
        }

        public void HandlePacket(Stream stream)
        {
            string dir = stream.ReadLengthPrefixedString(Encoding.UTF8);


            // Send back a stub
            stream.WriteByte((byte)HolmesPacketsV24.kEnumerate);
            stream.WriteInt32LE(0);
        }
    }
}
