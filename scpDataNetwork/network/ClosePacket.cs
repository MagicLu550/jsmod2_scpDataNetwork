using System;
using System.Collections.Generic;

namespace scpDataNetwork.network
{
    public class ClosePacket : DataPacket
    {
        public ClosePacket():base(0x02)
        {
            
        }
        
        private List<String> close = new List<string>();
        
        public override List<string> decode(byte[] data)
        {
            return deData(data);
        }

        public override byte[] encode()
        {
            close.Add("stop");
            return toData(close);
        }
    }
}