using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
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
        //ophalenviaworldid
        public static Server OphalenServer(int worldId)
        {
            using (MinecraftEntities entities = new MinecraftEntities())
            {
                var query = entities.Server
                    .Where(x => x.worldId == worldId)
                    .OrderBy(x => x.name)
                    .ThenBy(x => x.ipadress);
                return query.SingleOrDefault();
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
        //ophalen
        public static Setting OphalenSetting(int settingId)
        {
            using (MinecraftEntities entities = new MinecraftEntities())
            {
                var query = entities.Setting
                    .Where(x => x.id == settingId)
                    .OrderBy(x => x.name);
                return query.SingleOrDefault();
            }
        }

        //ophalen World settings
        public static World OphalenSettings(int worldId)
        {
            using (MinecraftEntities entities = new MinecraftEntities())
            {
                var query = entities.World
                    .Include(x => x.World_Setting.Select(y => y.Setting))
                    .Where(x => x.id == worldId)
                    .OrderBy(x => x.id)
                    .SingleOrDefault();
                return query ;
            }
        }

        //Updaten
        public static int UpdateWorldSetting(World_Setting worldsetting)
        {
            using (MinecraftEntities entities = new MinecraftEntities())
            {
                entities.Entry(worldsetting).State = EntityState.Modified;
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
        /*=====================
         * Recipes
         =====================*/
        //toevoegen
        public static int AddPlayerRecipe(Player_Recipe playerrecipe)
        {
            using (MinecraftEntities entities = new MinecraftEntities())
            {
                entities.Player_Recipe.Add(playerrecipe);
                return entities.SaveChanges();
            }
        }
        //ophalen
        public static List<Player_Recipe> OphalenPlayerRecipes(int playerId)
        {
            using (MinecraftEntities entities = new MinecraftEntities())
            {
                var query = entities.Player
                    .Include(x => x.Player_Recipe.Select(y => y.Recipe.Item))
                    .Where(x => x.id == playerId)
                    .SingleOrDefault();
                return query.Player_Recipe.ToList();
            }
        }
        //ophalen
        public static List<Recipe_Item> OphalenRecipeItems(int recipeId)
        {
            using (MinecraftEntities entities = new MinecraftEntities())
            {
                var query = entities.Recipe_Item
                    .Include(x => x.Recipe)
                    .Include(x => x.Item)
                    .Where(x => x.recipeId == recipeId);
                return query.ToList();
            }
        }
        //Update
        public static int UpdatePlayerRecipe(Player_Recipe recipe)
        {
            using (MinecraftEntities entities = new MinecraftEntities())
            {
                entities.Entry(recipe).State = EntityState.Modified;
                return entities.SaveChanges();
            }
        }


        /*=====================
        * Inventory & items
        =====================*/

        //Ophalen inventory
        public static List<Inventory> OphalenInventory()
        {
            using (MinecraftEntities entities = new MinecraftEntities())
            {
                var query = entities.Inventory
                    .OrderBy(x => x.name);

                return query.ToList();
            }
        }
        //Ophalen inventory
        public static Inventory OphalenInventory(int playerId)
        {
            using (MinecraftEntities entities = new MinecraftEntities())
            {
                var query = entities.Player
                    .Include(x => x.Inventory)
                    .Where(x => x.id == playerId)
                    .SingleOrDefault();

                return query.Inventory.SingleOrDefault();
            }
        }
        //Ophalen items
        public static List<Item> OphalenItems()
        {
            using (MinecraftEntities entities = new MinecraftEntities())
            {
                var query = entities.Item
                    .OrderBy(x => x.id);

                return query.ToList();
            }
        }

        //Ophalen inventoryItems
        public static List<Inventory_Item> OphalenInventoryItems(int inventoryid)
        {
            using (MinecraftEntities entities = new MinecraftEntities())
            {
                var query = entities.Inventory
                    .Include(x => x.Inventory_Item.Select(y => y.Item))
                    .Where(x => x.id == inventoryid)
                    .SingleOrDefault();

                return query.Inventory_Item.ToList();
            }
        }
        //Ophalen inventoryItem
        public static Inventory_Item OphalenInventoryItem(int slotid, int inventoryId)
        {
            using (MinecraftEntities entities = new MinecraftEntities())
            {
                var query = entities.Inventory_Item
                    .Where(x => x.slotId == slotid)
                    .Where(x => x.inventoryId == inventoryId)
                    .SingleOrDefault();

                return query;
            }
        }
        //Update inventoryitems
        public static int UpdateInventoryItem(Inventory_Item invItem)
        {
            using (MinecraftEntities entities = new MinecraftEntities())
            {
                entities.Entry(invItem).State = EntityState.Modified;
                return entities.SaveChanges();
            }
        }
        //toevoegen
        public static int AddPlayerInventoryItem(Inventory_Item inventoryitem)
        {
            using (MinecraftEntities entities = new MinecraftEntities())
            {
                entities.Inventory_Item.Add(inventoryitem);
                return entities.SaveChanges();
            }
        }
        //toevoegen
        public static int AddInventory(Inventory inventory)
        {
            using (MinecraftEntities entities = new MinecraftEntities())
            {
                entities.Inventory.Add(inventory);
                return entities.SaveChanges();
            }
        }
    }
}
