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

            if (command.Contains("system/run/milo_r.exe"))
            {
                string miloEditorPath = "D:\\Harmonix\\Projects\\MiloEditor\\ImMilo\\bin\\Debug\\net8.0\\ImMilo.exe";

                int index = command.IndexOf("system/run/milo_r.exe");
                string initalPath = command.Substring(index + 22);

                string correctedPath = Path.GetDirectoryName(initalPath) + "/gen/" + Path.GetFileName(initalPath) + "_xbox";

                Console.WriteLine(" Original command: {0}", command);
                Console.WriteLine(" Corrected path: {0}", correctedPath);

                Process.Start(miloEditorPath, "files/" + correctedPath);


            } else {
                Console.WriteLine("kSysExec blocked: {0}", command); 
            }
            
          
            stream.WriteByte((byte)HolmesPacketsV26.kSysExec);
            stream.WriteInt32LE(0);

        }
    }
}