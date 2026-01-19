using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace we_r_of_milo.PacketHandlers.v26
{
    internal class CloseFileHandlerV26 : IPacketHandler
    {
        public ConnectedClient Client { get; set; }
        public CloseFileHandlerV26(ConnectedClient _client)
        {
            Client = _client;
        }

        public void HandlePacket(Stream stream)
        {
            int fd = stream.ReadInt32LE();

            FileManager.CloseFile(fd);
            Client._openFiles.Remove(fd);

            // No response?
            //stream.WriteByte((byte)HolmesPacketsV24.kCloseFile);
        }
    }
}
