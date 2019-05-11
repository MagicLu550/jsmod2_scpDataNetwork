using System.Collections.Generic;
using scpDataNetwork.network;
using scpDataNetwork.utils;
using Smod2.API;
using Smod2.EventHandlers;
using Smod2.Events;

/**
 * @author MagicLu550 #(code) jsmod2
 */

namespace scpDataNetwork.listener
{
    public class AdminQueryHandler : IEventHandlerAdminQuery
    {
        private const string ADMIN_QUERY = "event.AdminQuery";
        
        public void OnAdminQuery(AdminQueryEvent ev)
        {
            List<string> datas = new List<string>();
            
            Player player = ev.Admin;
            
            Utils.SerializePlayer(player,ADMIN_QUERY,datas);
            
            bool handled = ev.Handled;
            
            datas.Add(ADMIN_QUERY+"."+handled);
            
            string ouput = ev.Output;
            
            datas.Add(ADMIN_QUERY+"."+ouput);
            
            string query = ev.Query;
            
            datas.Add(ADMIN_QUERY+"."+query);
            
            bool successful  =ev.Successful;
            
            datas.Add(ADMIN_QUERY+"."+successful);
            
            AdminQueryPacket packet = new AdminQueryPacket();
            packet.datas = datas;
            MainClass.getInstance().sendPacket(packet);
        }
    }
}