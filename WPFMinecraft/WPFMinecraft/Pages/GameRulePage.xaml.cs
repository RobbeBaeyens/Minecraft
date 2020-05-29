using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DALMinecraft;
using WPFMinecraft.Properties;
using WPFMinecraft.ViewModel;

namespace WPFMinecraft.Pages
{
    /// <summary>
    /// Interaction logic for GameRulePage.xaml
    /// </summary>
    public partial class GameRulePage : Page
    {
        public GameRulePage()
        {
            InitializeComponent();
        }

        public int serverId;
        public int worldId;

        
        public List<Button> settingButtons;
        public List<string> buttonNames;
        public World world;
        

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            // Find the frame.
            Frame pageFrame = null;
            DependencyObject currParent = VisualTreeHelper.GetParent(this);

            while (currParent != null && pageFrame == null)
            {
                pageFrame = currParent as Frame;
                currParent = VisualTreeHelper.GetParent(currParent);
            }

            //Change the page of the frame.
            if (pageFrame.DataContext != null)
            {
                WindowViewModel windowViewModel = pageFrame.DataContext as WindowViewModel;
                serverId = windowViewModel.ServerId;
                worldId = windowViewModel.WorldId;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Server ID: " + serverId + "\nWorld ID:" + worldId );
            }


            world = DatabaseOperations.OphalenWorld(serverId);



            settingButtons = new List<Button>()
            {
                btnEltyraMovement, btnRespawnImmediatly ,btnRecipeCrafting, btnDrowningDmg, btnFallDmg, btnFireDmg, btnKeepInv, btnHealthRegen,
                btnGenerateTerrain, btnDisableRaids, btnAllowDestructiveMob, btnSpawnPhantoms, btnSpawnMobs, btnPillagerPatrol, btnWanderingTraders,
                btnEntetyEquipment, btnMobLoot, btnDropBlocks, btnInGameTime, btnUpdateFire, btnUpdateWeather, btnAnnounceAdvancements, btnBlockOutput,
                btnAdminCommands, btnFeedback, btnDeathMessages, btnDebugInfo
            };

            buttonNames = new List<string>()
            {
                "Disable elytra movement check: ", "Respawn immediatly: ", "Require recipe for crafting: ", "Deal drowning damage: ", "Deal fall damage: ","Deal fire damage: ",
                "Keep inventory after death: ", "Regenerate health: ", "Allow spectators to generate terrain: ", "Disable raids: ", "Allow destructive mob actions: ",
                "Spawn phantoms: ", "Spawn mobs: ", "Spawn pillager patrols: ", "Spawn wandering traders: ", "Drop entity equipment: ", "Drop mob loot: ", "Drop blocks: ",
                "Advance in-game time: ", "Update fire: ", "Update weather: ", "Announce advancements: ", "Broadcast command block output: ", "Broadcast admin commands: ",
                "Send command feedback: ", "Show death messages: ", "Reduce debug info: "
            };

            LoadGameRules(null);
            
        }

        public void LoadGameRules(Button sender)
        {
            world = DatabaseOperations.OphalenSettings(worldId);
           
            
            var count = 0;
            foreach (World_Setting worldsetting in world.World_Setting)
            {
                if (sender == settingButtons[count] && worldsetting.value)
                {
                    worldsetting.value = false;
                    DatabaseOperations.UpdateWorldSetting(worldsetting);

                }
                else if (sender == settingButtons[count] && !worldsetting.value)
                {
                    worldsetting.value = true;
                    DatabaseOperations.UpdateWorldSetting(worldsetting);
                }
                settingButtons[count].Content = buttonNames[count] + (worldsetting.value ? "ON" : "OFF");
                count++;
            }

            
        }

        private void btnGameRuleToggle_Click(object sender, RoutedEventArgs e)
        {
            LoadGameRules(sender as Button);
        }
    }
}
