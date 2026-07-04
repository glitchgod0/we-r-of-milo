using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace we_r_of_milo.PacketHandlers.v26
{
    internal class SysExecHandlerV26 : IPacketHandler
    {
        public ConnectedClient Client { get; set; }
        public SysExecHandlerV26(ConnectedClient _client)
        {
            Client = _client;
        }
        public void HandlePacket(Stream stream)
        {
            string command = stream.ReadLengthPrefixedString(Encoding.UTF8);

            
            Console.WriteLine("kSysExec blocked: {0}", command);

            // kSysExec
            // Stub response
            stream.WriteByte((byte)HolmesPacketsV26.kCacheFile);
            stream.WriteInt32LE(0);
        }
    }
}
