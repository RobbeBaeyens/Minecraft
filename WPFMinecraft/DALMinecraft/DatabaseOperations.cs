using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DALMinecraft
{
    public class DatabaseOperations
    {
        /*=====================
         * SERVERS
         =====================*/
        //ophalen
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
        //toevoegen
        public static int AddServer(Server server)
        {
            using (MinecraftEntities entities = new MinecraftEntities())
            {
                entities.Server.Add(server);
                return entities.SaveChanges();
            }
        }
        //updaten
        public static int UpdateServer(Server server)
        {
            using (MinecraftEntities entities = new MinecraftEntities())
            {
                entities.Entry(server).State = EntityState.Modified;
                return entities.SaveChanges();
            }
        }
        //verwijderen
        public static int RemoveServer(Server server)
        {
            using (MinecraftEntities entities = new MinecraftEntities())
            {
                var query = entities.Server
                    .Include(x => x.World)
                    .Where(x => x.id == server.id)
                    .SingleOrDefault();
                entities.World.Remove(query.World);
                return entities.SaveChanges();
            }
        }


        /*=====================
         * World
         =====================*/
        //ophalen
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
        //toevoegen
        public static int AddWorld(World world)
        {
            using (MinecraftEntities entities = new MinecraftEntities())
            {
                entities.World.Add(world);
                return entities.SaveChanges();
            }
        }
        //verwijderen
        public static int RemoveWorldSetting(World world)
        {
            using (MinecraftEntities entities = new MinecraftEntities())
            {
                entities.Entry(world).State = EntityState.Deleted;
                return entities.SaveChanges();
            }
        }


        /*=====================
         * WorldSetting
         =====================*/
        //toevoegen
        public static int AddWorldSetting(World_Setting world_setting)
        {
            using (MinecraftEntities entities = new MinecraftEntities())
            {
                entities.World_Setting.Add(world_setting);
                return entities.SaveChanges();
            }
        }
        //verwijderen
        public static int RemoveWorldSetting(World_Setting world_setting)
        {
            using (MinecraftEntities entities = new MinecraftEntities())
            {
                entities.Entry(world_setting).State = EntityState.Deleted;
                return entities.SaveChanges();
            }
        }


        /*=====================
         * Setting
         =====================*/
        //toevoegen
        public static int AddSetting(Setting setting)
        {
            using (MinecraftEntities entities = new MinecraftEntities())
            {
                entities.Setting.Add(setting);
                return entities.SaveChanges();
            }
        }
        //verwijderen
        public static int RemoveSetting(Setting setting)
        {
            using (MinecraftEntities entities = new MinecraftEntities())
            {
                entities.Entry(setting).State = EntityState.Deleted;
                return entities.SaveChanges();
            }
        }


        /*=====================
         * WorldDimension
         =====================*/
        //toevoegen
        public static int AddWorldDimension(World_Dimension world_dimension)
        {
            using (MinecraftEntities entities = new MinecraftEntities())
            {
                entities.World_Dimension.Add(world_dimension);
                return entities.SaveChanges();
            }
        }
        //verwijderen
        public static int RemoveWorldDimension(World_Dimension world_dimension)
        {
            using (MinecraftEntities entities = new MinecraftEntities())
            {
                entities.Entry(world_dimension).State = EntityState.Deleted;
                return entities.SaveChanges();
            }
        }


        /*=====================
         * Dimension
         =====================*/
        //toevoegen
        public static int AddDimension(Dimension dimension)
        {
            using (MinecraftEntities entities = new MinecraftEntities())
            {
                entities.Dimension.Add(dimension);
                return entities.SaveChanges();
            }
        }
        //verwijderen
        public static int RemoveDimension(Dimension dimension)
        {
            using (MinecraftEntities entities = new MinecraftEntities())
            {
                entities.Entry(dimension).State = EntityState.Deleted;
                return entities.SaveChanges();
            }
        }

        /*=====================
         * Speler
         =====================*/
        //ophalen
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
