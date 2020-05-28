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
                worldId = windowViewModel.WorldId;
                playerId = windowViewModel.PlayerId;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Server ID: " + serverId + "\nWorld ID: " + worldId + "\nPlayer ID: " + playerId + "\n");
            }
        }

        private void btnEffects_Click(object sender, RoutedEventArgs e)
        {
<<<<<<< HEAD
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
=======

>>>>>>> 3135808bac22317100f9f442cf0cf56a25d310d4
        }

        private void btnAdvancements_Click(object sender, RoutedEventArgs e)
        {
<<<<<<< HEAD
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
=======

>>>>>>> 3135808bac22317100f9f442cf0cf56a25d310d4
        }

        private void btnRecipes_Click(object sender, RoutedEventArgs e)
        {
<<<<<<< HEAD
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
=======

        }

        private void btnInventory_Click(object sender, RoutedEventArgs e)
        {

>>>>>>> 3135808bac22317100f9f442cf0cf56a25d310d4
        }

        private void btnFlip_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
