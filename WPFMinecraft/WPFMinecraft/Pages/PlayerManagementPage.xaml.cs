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
        Player selectedplayer;
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
            ListboxPlayers.ItemsSource = getPlayers();
        }

        public List<Player> getPlayers()
        {

            if (serverId == -1)
            {
                gridChangeablePlayerPage.Visibility = Visibility.Collapsed;
                btnUpdatePlayer.Visibility = Visibility.Collapsed;
                players = DatabaseOperations.OphalenSpelers();
            }
            else
            {
                players = DatabaseOperations.OphalenSpelers(worldId);
            }
            return players;
        }

        private void btnAddPlayer_Click(object sender, RoutedEventArgs e)
        {
            string playerName = textBoxPlayerName.Text;
            if (!String.IsNullOrWhiteSpace(playerName) && playerName.Length <= 16 && playerName.Length >= 3)
            {
                Player player = createNewPlayer(playerName, worldId);
                createNewPlayerAdvancements(player);

                ListboxPlayers.ItemsSource = getPlayers();
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

        public void createNewPlayerAdvancements(Player player)
        {
            for (int i = 1; i < 17; i++)
            {
                Player_Advancement player_advancement = new Player_Advancement();
                player_advancement.playerId = player.id;
                player_advancement.advancementId = i;
                player_advancement.advancementObtained = false;
                DatabaseOperations.AddPlayerAdvancement(player_advancement);
            }
        }

        private void ListboxPlayers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedplayer = (Player)ListboxPlayers.SelectedItem;
            if (ListboxPlayers.SelectedIndex == -1)
            {
                textBoxPlayerName.Text = "";
            }
            else
            {
                textBoxPlayerName.Text = selectedplayer.name;
            }
        }

        private void btnRemovePlayer_Click(object sender, RoutedEventArgs e)
        {
            if (ListboxPlayers.SelectedIndex != -1)
            {
                DatabaseOperations.RemoveSpeler(selectedplayer);
                ListboxPlayers.ItemsSource = getPlayers();
            }
        }

        private void btnUpdatePlayer_Click(object sender, RoutedEventArgs e)
        {
            if (ListboxPlayers.SelectedIndex != -1)
            {
                Player player = selectedplayer;
                string playerName = textBoxPlayerName.Text;
                if (!String.IsNullOrWhiteSpace(playerName) && playerName.Length <= 16 && playerName.Length >= 3)
                {
                    player.name = playerName;
                    DatabaseOperations.UpdateSpeler(player);
                    ListboxPlayers.ItemsSource = getPlayers();
                }
                else
                {
                    MessageBox.Show("Insert a server name (3-16)", "No Name");
                }
            }
        }

        private void btnViewPlayer_Click(object sender, RoutedEventArgs e)
        {
            if (ListboxPlayers.SelectedIndex != -1)
            {
                selectedplayer = (Player)ListboxPlayers.SelectedItem;
                playerId = selectedplayer.id;


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
                    windowViewModel.CurrentPage = ApplicationPage.Player;
                    windowViewModel.WorldId = worldId;
                    windowViewModel.PlayerId = playerId;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Server ID: " + serverId + "\nWorld ID: " + worldId + "\nPlayer ID: " + serverId + "\n");
                }
            }
        }
    }
}
