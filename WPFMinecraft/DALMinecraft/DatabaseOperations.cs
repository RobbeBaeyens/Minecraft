using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALMinecraft
{
    class DatabaseOperations
    {
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
