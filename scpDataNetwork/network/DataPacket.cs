/**
 * @author MagicLu550 #(code) jsmod2
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace scpDataNetwork.network
{
    public abstract class DataPacket
    {

     private int id;

     public DataPacket(int id)
     {
      this.id = id;

     }
     
     public const string PLAYER = "player:";
        /**
         * 当要发包时，解析为byte数据发出
         */
     public abstract byte[] encode();
        
        
        /**
         * 当收到byte数据包时，解析数据
         */
        
        
       public abstract List<string> decode(byte[] datas);
        
        /**
         * 编码
         */
     public byte[] toData(List<string> datas)
        {
         StringBuilder builder =new StringBuilder("["+id+"]");
         foreach (var data in datas)
         {
           builder.Append(data+",");
         }
         return Encoding.ASCII.GetBytes(builder.ToString());
        }
        
        /**
         * 解码
         */

     public List<string> deData(byte[] datas)
        {
         List<string> list = new List<string>();
         String data = Encoding.ASCII.GetString(datas);
         String[] strs = data.Split(",");
         foreach (var str in strs)
         {
          list.Add(str);
         }

         return list;
        }
    }
}