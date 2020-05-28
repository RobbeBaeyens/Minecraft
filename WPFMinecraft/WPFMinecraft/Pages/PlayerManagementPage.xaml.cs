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
    /// Interaction logic for PlayerManagementPage.xaml
    /// </summary>
    public partial class PlayerManagementPage : Page
    {
        public int serverId;
        public int worldId;
        public int playerId;
        List<Player> players;
        public PlayerManagementPage()
        {
            InitializeComponent();
        }

        private void getPlayers()
        {
            ListboxPlayers.ItemsSource = players;
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

            players = DatabaseOperations.OphalenSpelers(worldId);
            getPlayers();
        }

        private void btnAddPlayer_Click(object sender, RoutedEventArgs e)
        {
            string playerName = textBoxPlayerName.Text;
            if (!String.IsNullOrWhiteSpace(playerName) && playerName.Length <= 16 && playerName.Length >= 3)
            {
                Player player = createNewPlayer(playerName, worldId);

                players = DatabaseOperations.OphalenSpelers(worldId);
                ListboxPlayers.ItemsSource = players;
            }
            else
            {
                MessageBox.Show("Insert a player name (3-16)", "No Name");
            }
        }

        public Player createNewPlayer(string playerName, int worldId)
        {
            Random rand = new Random();
            Player player = new Player();
            Dimension dimension = DatabaseOperations.OphalenPlayerDimension(worldId);
            player.name = playerName;
            player.uuid = Guid.NewGuid().ToString();
            player.health = 20;
            player.food = 20;
            player.armor = 0;
            player.skin = null;
            player.posX = rand.Next(-30000, 30000);
            player.posY = rand.Next(0, 255);
            player.posZ = rand.Next(-30000, 30000);
            player.dimensionId = dimension.id;
            DatabaseOperations.AddPlayer(player);
            return player;
        }

        private void btnRemovePlayer_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnUpdatePlayer_Click(object sender, RoutedEventArgs e)
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
