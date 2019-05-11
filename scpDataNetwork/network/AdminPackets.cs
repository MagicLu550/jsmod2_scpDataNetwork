

using System.Collections.Generic;

/**
 * @author MagicLu550 #(code) jsmod2
 */

namespace scpDataNetwork.network
{
    public class AdminQueryPacket : DataPacket
    {
        public AdminQueryPacket() : base(0x01)
        {
            
        }

        public List<string> datas;
        
        public override byte[] encode()
        {
            return toData(datas);
        }

        public override List<string> decode(byte[] datas)
        {
            return deData(datas);
        }
    }
}