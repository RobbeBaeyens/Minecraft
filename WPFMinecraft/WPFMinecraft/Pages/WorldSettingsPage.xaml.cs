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
    /// Interaction logic for WorldSettingsPage.xaml
    /// </summary>
    public partial class WorldSettingsPage : Page
    {

        public int serverId;
        public int worldId;
        World world = new World();
        public WorldSettingsPage()
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
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Server ID: " + serverId + "\n");
            }


            world = DatabaseOperations.OphalenWorld(serverId);

            textBoxWorldName.Text = world.name;

            List<string> difficulties = new List<string>()
            {
                "Peacefull" , "Easy", "Normal", "Hard"
            };
            cmbDifficulty.ItemsSource = difficulties;
            int difficulty = world.difficulty;
            cmbDifficulty.SelectedIndex = difficulty;




            List<string> gamemodes = new List<string>()
            {
                "Survival", "Creative", "Adventure", "Spectator"
            };
            cmbGameMode.ItemsSource = gamemodes;
            int gamemode = world.gamemode;
            cmbGameMode.SelectedIndex = gamemode;


            List<bool> cheats = new List<bool>()
            {
                false, true
            };
            cmbCheats.ItemsSource = cheats;
            int cheat = world.cheats ? 1 : 0;
            cmbCheats.SelectedIndex = cheat;
        }

        private void btnSaveOption_Click(object sender, RoutedEventArgs e)
        {
            string worldname = textBoxWorldName.Text;
            int difficulty = cmbDifficulty.SelectedIndex;
            int gamemode = cmbGameMode.SelectedIndex;
            bool cheats = cmbCheats.SelectedIndex == 1 ? true : false;
            if (!String.IsNullOrWhiteSpace(worldname) && worldname.Length <= 20)
            {
                world.name = worldname;
                world.difficulty = difficulty;
                world.gamemode = gamemode;
                world.cheats = cheats;
                if (DatabaseOperations.UpdateWorld(world) == 1) {
                    MessageBox.Show("Settings saved!");
                }
                

            }
        }

        private void btnViewPlayers_Click(object sender, RoutedEventArgs e)
        {

            worldId = world.id;
            

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
                    windowViewModel.CurrentPage = ApplicationPage.PlayerManagement;
                    windowViewModel.WorldId = worldId;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Server ID: " + serverId + "\nWorld ID: " + worldId + "\n");
                }
            
        }
    }



}
