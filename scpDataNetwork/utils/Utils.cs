using System.Collections.Generic;
using Smod2.API;


namespace scpDataNetwork.utils
{
    public class Utils
    {
        
         //序列化玩家对象的方法
        public static void SerializePlayer(Player player,string head,List<string> list){
            
            //序列化player
            string ip = player.IpAddress;
            
            list.Add(head+"."+ip);
            
            string name = player.Name;
            
            list.Add(head+"."+name);
            
            bool overwatchMode = player.OverwatchMode;
            
            list.Add(head+"."+overwatchMode);
            
            int id = player.PlayerId;
            
            list.Add(head+"."+id);
            
            string streamId = player.SteamId;
            
            list.Add(head+"."+streamId);
            
            bool donotTrack = player.DoNotTrack;
            
            list.Add(head+"."+donotTrack);
            
            bool callSetRoleEvent = player.CallSetRoleEvent;
            
            list.Add(head+"."+callSetRoleEvent);
            
            RadioStatus radioStatus = player.RadioStatus;

            list.Add(head+"."+radioStatus);
            
            TeamRole role = player.TeamRole;
            
            list.Add(head+"."+role);
            
            //序列化TeamRole
            SerializeTeamRole(role,head+".Player-role",list);
            
            
            Scp079Data data = player.Scp079Data;
            
            SerializeScp079Data(data,head+".Player-data",list);
            
            Vector camera = data.Camera;
            
            SerializeVector(camera,head+".Player-camera",list);
        }

        public static  void SerializeTeamRole(TeamRole teamRole,string head,List<string> list)
        {
            string name = teamRole.Name;
            
            list.Add(head+"."+name);
            
            bool roleDisallowed = teamRole.RoleDisallowed;
            
            list.Add(head+"."+roleDisallowed);
            
            int maxHp = teamRole.MaxHP;
            
            list.Add(head+"."+maxHp);
            
            Role role = teamRole.Role;
            
            list.Add(head+"."+role);
            
            Team team = teamRole.Team;
            
            list.Add(head+"."+team);
        }

        public static void SerializeScp079Data(Scp079Data scp079Data,string head,List<string> list) 
        {
            
            float exp = scp079Data.Exp;
            
            list.Add(head+"."+exp);
            
            int level = scp079Data.Level;
            
            list.Add(head+"."+level);
            
            float pitch = scp079Data.Pitch;
            
            list.Add(head+"."+pitch);
            
            float yaw = scp079Data.Yaw;
            
            list.Add(head+"."+yaw);
            
            float AP = scp079Data.AP;
            
            list.Add(head+"."+AP);
            
            float maxAp = scp079Data.MaxAP;
            
            list.Add(head+"."+maxAp);
            
            float apPerSecond = scp079Data.APPerSecond;
            
            list.Add(head+"."+apPerSecond);
            
            int expToLevelUp = scp079Data.ExpToLevelUp;
            
            list.Add(head+"."+expToLevelUp);
            
            float speakerApPerSecond = scp079Data.SpeakerAPPerSecond;
            
            list.Add(head+"."+speakerApPerSecond);
            
            float lockedDoorApPerSecond = scp079Data.LockedDoorAPPerSecond;
            
            list.Add(head+"."+lockedDoorApPerSecond);
            
            Vector vector = scp079Data.Camera;
            
            SerializeVector(vector,head+".Scp079Data-camera",list);
            
            Room speaker = scp079Data.Speaker;
            
            SerializeRoom(speaker,head+".Scp079Data-speaker",list);
        }

        public static void SerializeVector(Vector vector,string head,List<string> list)
        {
            float x = vector.x;
            
            list.Add(head+"."+x);
            
            float y = vector.y;
            
            list.Add(head+"."+y);
            
            float z = vector.z;
            
            list.Add(head+"."+z);
            
            float magnitude = vector.Magnitude;
            
            list.Add(head+"."+magnitude);
            
            Vector normalize = vector.Normalize;
            if (normalize == new Vector(0, 0, 0))
            {
                //如果正规化为ZERO，则序列化为0,序列化停止
                float normalizeX = 0;
                list.Add(head+"."+normalizeX);
                float normalizeY = 0;
                list.Add(head+"."+normalizeY);
                float normalizeZ = 0;
                list.Add(head+"."+normalizeZ);
                return;
            }

            SerializeVector(normalize,head+".Vector-normalize",list);
            float sqrMagnitude = vector.SqrMagnitude;
            list.Add(head+"."+sqrMagnitude);
        }

        public static void SerializeRoom(Room room,string head,List<string> list)
        {
            int genericId = room.GenericID;
            
            list.Add(head+"."+genericId);
            
            RoomType roomType = room.RoomType;

            list.Add(head+"."+roomType);
            
            ZoneType zoneType = room.ZoneType;
            
            list.Add(head+"."+zoneType);
            
            Vector forward = room.Forward;
            SerializeVector(forward,head+".Room-forward",list);
            Vector position = room.Position;
            SerializeVector(position,head+".Room-position",list);
            Vector vector = room.SpeakerPosition;
            SerializeVector(vector,head+".Room-speakerPosition",list);
        }
    }
}