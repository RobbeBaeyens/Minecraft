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
            lblPlayerNameTag.Content = player.name;
            lblPlayerName.Content = player.name;
            lblPlayerUUID.Content = player.uuid;
            lblPlayerCoords.Content = "x:" + player.posX + " y:" +player.posY + " z:" + player.posZ;
            lblPlayerNameTag.Content = player.name;
        }

        private void btnEffects_Click(object sender, RoutedEventArgs e)
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
                windowViewModel.CurrentPage = ApplicationPage.Effects;
                windowViewModel.WorldId = worldId;
                windowViewModel.PlayerId = playerId;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Server ID: " + serverId + "\nWorld ID: " + worldId + "\nPlayer ID: " + serverId + "\n");
            }
        }

        private void btnAdvancements_Click(object sender, RoutedEventArgs e)
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
                windowViewModel.CurrentPage = ApplicationPage.Advancements;
                windowViewModel.WorldId = worldId;
                windowViewModel.PlayerId = playerId;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Server ID: " + serverId + "\nWorld ID: " + worldId + "\nPlayer ID: " + serverId + "\n");
            }
        }

        private void btnRecipes_Click(object sender, RoutedEventArgs e)
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
                windowViewModel.CurrentPage = ApplicationPage.Recipes;
                windowViewModel.WorldId = worldId;
                windowViewModel.PlayerId = playerId;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Server ID: " + serverId + "\nWorld ID: " + worldId + "\nPlayer ID: " + serverId + "\n");
            }
        }

        private void btnInventory_Click(object sender, RoutedEventArgs e)
        {// Find the frame.
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
                windowViewModel.CurrentPage = ApplicationPage.Inventory;
                windowViewModel.WorldId = worldId;
                windowViewModel.PlayerId = playerId;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Server ID: " + serverId + "\nWorld ID: " + worldId + "\nPlayer ID: " + serverId + "\n");
            }
        }

        private void btnFlip_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
