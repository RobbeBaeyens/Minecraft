using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALMinecraft
{
    class DatabaseOperations
    {
        public static List<Server> OphalenServers()
        {
            using (MinecraftEntities entities = new MinecraftEntities())
            {
                var query = entities.Server
                    .OrderBy(x => x.name)
                    .ThenBy(x => x.ipadress);
                return query.ToList();
            }
        }
        public static List<World> OphalenWorlds()
        {
            using (MinecraftEntities entities = new MinecraftEntities())
            {
                var query = entities.World
                    .OrderBy(x => x.name)
                    .ThenBy(x => x.seed);
                return query.ToList();
            }
        }

        public static List<Player> OphalenSpelers()
        {
            using (MinecraftEntities entities = new MinecraftEntities())
            {
                var query = entities.Player
                    .OrderBy(x => x.name)
                    .ThenBy(x => x.uuid);
                return query.ToList();
            }
        }
    }
}
