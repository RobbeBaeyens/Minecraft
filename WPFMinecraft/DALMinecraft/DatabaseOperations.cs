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
                entities.Server.Remove(query);
                return entities.SaveChanges();
            }
        }


        /*=====================
 * World
 =====================*/
        //ophalen
        public static World OphalenWorld(int serverId)
        {
            using (MinecraftEntities entities = new MinecraftEntities())
            {
                var query = entities.Server
                    .Include(x => x.World)
                    .Where(x => x.id == serverId)
                    .SingleOrDefault();
                return query.World;

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
        //updaten
        public static int UpdateWorld(World world)
        {
            using (MinecraftEntities entities = new MinecraftEntities())
            {
                entities.Entry(world).State = EntityState.Modified;
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






        //inventoryPage
        public static List<Inventory> OphalenInventory()
        {
            using (MinecraftEntities entities = new MinecraftEntities())
            {
                var query = entities.Inventory
                    .OrderBy(x => x.name);

                return query.ToList();
            }
        }

        public static List<Item> OphalenItem(string naam)
        {
            using (MinecraftEntities entities = new MinecraftEntities())
            {
                var query = entities.Item
                    .Where(x => x.name.Contains(naam))
                    .OrderBy(x => x.name);

                return query.ToList();
            }
        }
        public static int AddItem(Item item)
        {
            using (MinecraftEntities entities = new MinecraftEntities())
            {
                entities.Item.Add(item);
                return entities.SaveChanges();
            }
        }
        public static int RemoveItem(Item item)
        {
            using (MinecraftEntities entities = new MinecraftEntities())
            {
                entities.Entry(item).State = EntityState.Deleted;
                return entities.SaveChanges();
            }
        }

        //inventoryManagerPage
        public static List<Inventory_Item> OphalenInventoryItem()
        {
            using (MinecraftEntities entities = new MinecraftEntities())
            {
                var query = entities.Inventory_Item
                    .OrderBy(x => x.Item)
                    .ThenBy(x => x.itemId);

                return query.ToList();
            }
        }

        //AdvancementsPage
        public static List<Player_Advancement> OphalenAdvancement()
        {
            using (MinecraftEntities entities = new MinecraftEntities())
            {
                var query = entities.Player_Advancement
                    .Include(x => x.Advancement);

                return query.ToList();
            }
        }

        public static List<Player_Advancement> OphalenPlayerAdvancements()
        {
            using (MinecraftEntities entities = new MinecraftEntities())
            {
                var query = entities.Player_Advancement
                    .OrderBy(x => x.Advancement);

                return query.ToList();
            }
        }

        public static int UpdateAdvancement(Player_Advancement advancement)
        {
            using (MinecraftEntities entities = new MinecraftEntities())
            {
                var query = entities.Player_Advancement
                    .Include(x => x.Advancement)
                    .Where(x => x.id == advancement.id);
                entities.Entry(advancement).State = EntityState.Modified;
                return entities.SaveChanges();
            }
        }
    }
}
