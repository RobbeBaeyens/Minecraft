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
    /// Interaction logic for PlayerManagementPage.xaml
    /// </summary>
    public partial class PlayerManagementPage : Page
    {
        public int serverId;
        public int worldId;
        public int playerId;
        public PlayerManagementPage()
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
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Server ID: " + serverId + "\nWorld ID: " + worldId + "\n");
            }
        }

        private void btnRemovePlayer_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnUpdatePlayer_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAddPlayer_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnViewPlayer_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ListboxServers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
