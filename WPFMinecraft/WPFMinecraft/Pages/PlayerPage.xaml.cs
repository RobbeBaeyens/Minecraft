using DALMinecraft;
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
using WPFMinecraft.ViewModel;

namespace WPFMinecraft.Pages
{
    /// <summary>
    /// Interaction logic for PlayerPage.xaml
    /// </summary>
    public partial class PlayerPage : Page
    {
        public int serverId;
        public int worldId;
        public int playerId;
        public Player player;
        public World world;
        public Server server;

        public PlayerPage()
        {
            InitializeComponent();
        }
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
                playerId = windowViewModel.PlayerId;
                worldId = DatabaseOperations.OphalenWorldViaSpeler(playerId).id;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Server ID: " + serverId + "\nWorld ID: " + worldId + "\nPlayer ID: " + playerId + "\n");
            }

            player = DatabaseOperations.OphalenSpeler(playerId);
            world = DatabaseOperations.OphalenWorldViaSpeler(playerId);
            server = DatabaseOperations.OphalenServer(worldId);
            lblPlayerNameTag.Content = player.name;
            lblPlayerName.Content = player.name;
            lblPlayerUUID.Content = player.uuid;
            lblPlayerCoords.Content = "x:" + Math.Round(player.posX,0) + " y:" + Math.Round(player.posY, 0) + " z:" + Math.Round(player.posZ, 0);
            lblPlayerNameTag.Content = player.name;
            lblWorldSeed.Content = world.seed;
            lblWorldName.Content = world.name;
            lblServerNameAndIP.Content = server.name + "   -   " + server.ipadress;

            drawStats(0);
            drawStats(1);
            drawStats(2);
        }

        private void btnEffects_Click(object sender, RoutedEventArgs e)
        {
            goToNewPage(ApplicationPage.Effects);
        }

        private void btnAdvancements_Click(object sender, RoutedEventArgs e)
        {
            goToNewPage(ApplicationPage.Advancements);
        }

        private void btnRecipes_Click(object sender, RoutedEventArgs e)
        {
            goToNewPage(ApplicationPage.Recipes);
        }

        private void btnInventory_Click(object sender, RoutedEventArgs e)
        {
            goToNewPage(ApplicationPage.Inventory);
        }

        public void goToNewPage(ApplicationPage applicationPage)
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
                windowViewModel.CurrentPage = applicationPage;
                windowViewModel.WorldId = worldId;
                windowViewModel.PlayerId = playerId;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Server ID: " + serverId + "\nWorld ID: " + worldId + "\nPlayer ID: " + serverId + "\n");
            }
        }

        private void btnFlip_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnHealthMin_Click(object sender, RoutedEventArgs e)
        {
            if (player.health > 0)
            {
                player.health--;
                drawStats(0);
            }
        }

        private void btnHealthPlus_Click(object sender, RoutedEventArgs e)
        {
            if (player.health < 20)
            { 
                player.health++;
                drawStats(0);
            }
        }

        private void btnFoodMin_Click(object sender, RoutedEventArgs e)
        {
            if (player.food > 0)
            {
                player.food--;
                drawStats(1);
            }
        }

        private void btnFoodPlus_Click(object sender, RoutedEventArgs e)
        {
            if (player.food < 20)
            {
                player.food++;
                drawStats(1);
            }
        }

        private void btnArmorMin_Click(object sender, RoutedEventArgs e)
        {
            if (player.armor > 0)
            {
                player.armor--;
                drawStats(2);
            }
        }

        private void btnArmorPlus_Click(object sender, RoutedEventArgs e)
        {
            if (player.armor < 20)
            {
                player.armor++;
                drawStats(2);
            }
        }

        public void drawStats(int type)
        {
            DatabaseOperations.UpdateSpeler(player);
            List<StackPanel> statHolders    = new List<StackPanel>(){ stckpnlPlayerHealth,  stckpnlPlayerFood,  stckpnlPlayerArmor  };
            List<string> ImagePartialPaths  = new List<string>()    { "Health/health",      "Food/food",        "Armor/armor"       };
            double health  = (double)player.health;
            double food    = (double)player.food;
            double armor   = (double)player.armor;
            string startImagePath   = "pack://application:,,,/Images/Player/" + ImagePartialPaths[type];
            var ImagePath_Empty     = new Uri(startImagePath + "_empty.png");
            var ImagePath_Half      = new Uri(startImagePath + "_half.png");
            var ImagePath_Full      = new Uri(startImagePath + "_full.png");

            List<int> Stat_Halfs = new List<int>() { (int)health % 2, (int)food % 2, (int)armor % 2 };
            List<int> Stat_Fulls = new List<int>() { (int)Math.Floor(health / 2), (int)Math.Floor(food / 2), (int)Math.Floor(armor / 2) };
            List<int> Stat_Empties = new List<int>() { 10 - Stat_Fulls[0] - Stat_Halfs[0], 10 - Stat_Fulls[1] - Stat_Halfs[1], 10 - Stat_Fulls[2] - Stat_Halfs[2] };

            statHolders[type].Children.Clear();
            for (int i = 0; i < Stat_Fulls[type]; i++)
            {
                Image image = new Image();
                image.Source = new BitmapImage(ImagePath_Full);
                image.Width = 15;
                statHolders[type].Children.Add(image);
            }
            for (int i = 0; i < Stat_Halfs[type]; i++)
            {
                Image image = new Image();
                image.Source = new BitmapImage(ImagePath_Half);
                image.Width = 15;
                statHolders[type].Children.Add(image);
            }
            for (int i = 0; i < Stat_Empties[type]; i++)
            {
                Image image = new Image();
                image.Source = new BitmapImage(ImagePath_Empty);
                image.Width = 15;
                statHolders[type].Children.Add(image);
            }
        }
    }
}
