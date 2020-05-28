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
        //ophalen
        public static World OphalenWorldViaSpeler(int playerId)
        {
            using (MinecraftEntities entities = new MinecraftEntities())
            {
                var query = entities.Player
                    .Include(x => x.Dimension.World)
                    .Where(x => x.id == playerId)
                    .SingleOrDefault();
                return query.Dimension.World;

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
        //ophalen
        public static Dimension OphalenPlayerDimension(int worldId)
        {
            using (MinecraftEntities entities = new MinecraftEntities())
            {
                var query = entities.Dimension
                    .Include(x => x.World)
                    .Where(x => x.worldId == worldId)
                    .Where(x => x.name.Contains("overworld"))
                    .SingleOrDefault();
                return query;
            }
        }

        /*=====================
         * Speler
         =====================*/
        //ophalen
        public static List<Player> OphalenSpelers(int worldId)
        {
            using (MinecraftEntities entities = new MinecraftEntities())
            {
                var query = entities.Player
                    .Include(x => x.Dimension.World)
                    .Where(x => x.Dimension.World.id == worldId)
                    .OrderBy(x => x.name)
                    .ThenBy(x => x.uuid);
                return query.ToList();
            }
        }
        //ophalen
        public static List<Player> OphalenSpelers()
        {
            using (MinecraftEntities entities = new MinecraftEntities())
            {
                var query = entities.Player
                    .Include(x => x.Dimension.World.Server)
                    .OrderBy(x => x.name)
                    .ThenBy(x => x.uuid);
                return query.ToList();
            }
        }
        //ophalen
        public static Player OphalenSpeler(int playerId)
        {
            using (MinecraftEntities entities = new MinecraftEntities())
            {
                var query = entities.Player
                    .Include(x => x.Dimension.World.Server)
                    .Where(x => x.id == playerId)
                    .OrderBy(x => x.name)
                    .ThenBy(x => x.uuid);
                return query.SingleOrDefault();
            }
        }
        //toevoegen
        public static int AddPlayer(Player player)
        {
            using (MinecraftEntities entities = new MinecraftEntities())
            {
                entities.Player.Add(player);
                return entities.SaveChanges();
            }
        }
        //verwijderen
        public static int RemoveSpeler(Player player)
        {
            using (MinecraftEntities entities = new MinecraftEntities())
            {
                entities.Entry(player).State = EntityState.Deleted;
                return entities.SaveChanges();
            }
        }
        //updaten
        public static int UpdateSpeler(Player player)
        {
            using (MinecraftEntities entities = new MinecraftEntities())
            {
                entities.Entry(player).State = EntityState.Modified;
                return entities.SaveChanges();

            }
        }
        /*=====================
         * Advancement
         =====================*/
        //toevoegen
        public static int AddPlayerAdvancement(Player_Advancement player_advancement)
        {
            using (MinecraftEntities entities = new MinecraftEntities())
            {
                entities.Player_Advancement.Add(player_advancement);
                return entities.SaveChanges();
            }
        }
        //Ophalen
        public static Player OphalenAdvancements(int playerId)
        {
            using (MinecraftEntities entities = new MinecraftEntities())
            {
                var query = entities.Player
                    .Include(x => x.Player_Advancement.Select(y => y.Advancement))
                    .Where(x => x.id == playerId)
                    .SingleOrDefault();

                return query;

            }
        }
        //Update
        public static int UpdatePlayerAdvancement(Player_Advancement advancement)
        {
            using (MinecraftEntities entities = new MinecraftEntities())
            {
                entities.Entry(advancement).State = EntityState.Modified;


                return entities.SaveChanges();
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

        public static List<Item> OphalenItems()
        {
            using (MinecraftEntities entities = new MinecraftEntities())
            {
                var query = entities.Item
                    .OrderBy(x => x.name);

                return query.ToList();
            }
        }

        //inventoryManagerPage
        public static List<Inventory_Item> OphalenInventoryItem()
        {
            using (MinecraftEntities entities = new MinecraftEntities())
            {
                var query = entities.Inventory_Item
                    .OrderBy(x => x.Item);

                return query.ToList();
            }
        }
    }
}
