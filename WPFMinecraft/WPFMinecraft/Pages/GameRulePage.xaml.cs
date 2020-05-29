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
       

        public List<Button> settingButton;
        World world = new World();
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
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Server ID: " + serverId + "\n");
            }


            world = DatabaseOperations.OphalenWorld(serverId);



            settingButton = new List<Button>()
            {
                btnEltyraMovement, btnRespawnImmediatly ,btnRecipeCrafting, btnDrowningDmg, btnFallDmg, btnFireDmg, btnKeepInv, btnHealthRegen,
                btnGenerateTerrain, btnDisableRaids, btnAllowDestructiveMob, btnSpawnPhantoms, btnSpawnMobs, btnPillagerPatrol, btnWanderingTraders,
                btnEntetyEquipment, btnMobLoot, btnDropBlocks, btnInGameTime, btnUpdateFire, btnUpdateWeather, btnAnnounceAdvancements, btnBlockOutput,
                btnAdminCommands, btnFeedback, btnDeathMessages, btnDebugInfo
            };
            LoadGameRules();
            
        }

        public void LoadGameRules()
        {
            var count = 0;

            if (settingButton[count].IsEnabled == true )
            {

            }

            count++;
        }
        private void btnElytraMovement_Click(object sender, RoutedEventArgs e)
        {

            

        }

        private void btnRespawnImmediatly_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void btnRecipeCrafting_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnDrowningDmg_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnFallDmg_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void btnFireDmg_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnKeepInv_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnHealthRegen_Click(object sender, RoutedEventArgs e)
        {
          
        }

        private void btnGenerateTerrain_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnDisableRaids_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnAllowDestructiveMob_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnSpawnPhantoms_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnSpawnMobs_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void btnPillagerPatrol_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnWanderingTraders_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnEntetyEquipment_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnMobLoot_Click(object sender, RoutedEventArgs e)
        {
          
        }

        private void btnDropBlocks_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnInGameTime_Click(object sender, RoutedEventArgs e)
        {
          
        }

        private void btnUpdateFire_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void btnUpdateWeather_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnAnnounceAdvancements_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnBlockOutput_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnAdminCommands_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void btnFeedback_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void btnDeathMessages_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnDebugInfo_Click(object sender, RoutedEventArgs e)
        {
            
        }

        
    }
}
