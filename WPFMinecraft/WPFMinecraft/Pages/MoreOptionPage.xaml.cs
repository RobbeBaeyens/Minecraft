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
    /// Interaction logic for MoreOptionPage.xaml
    /// </summary>
    public partial class MoreOptionPage : Page
    {
        public MoreOptionPage()
        {
            InitializeComponent();
        }
        public int serverId;
        public int worldId;
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

            List<bool> structures = new List<bool>()
            {
                false,true
            };
            cmbStructures.ItemsSource = structures;
            bool structure = world.structures;
            cmbStructures.SelectedItem = structure;

            List<bool> bonusChests = new List<bool>()
            {
                false,true
            };
            cmbBonusChest.ItemsSource = bonusChests;
            bool bonusChest = world.bonusChest;
            cmbBonusChest.SelectedItem = bonusChest;

            List<string> worldTypes = new List<string>()
            {
                "Default", "Superflat", "Large Biome", "Amplified", "Single Biomes", "Caves", "Floating ils."
            };
            cmbWorldType.ItemsSource = worldTypes;
            int worldType = world.worldType;
            cmbBonusChest.SelectedIndex = worldType;

        }

        private void btnSaveMoreOption_Click(object sender, RoutedEventArgs e)
        {
            bool BonusChest = cmbBonusChest.SelectedIndex == 1 ? true :false;
            bool Structures = cmbStructures.SelectedIndex == 1 ? true : false;
            int WorldType = cmbWorldType.SelectedIndex;

            world.bonusChest = BonusChest;
            world.structures = Structures;
            world.worldType = WorldType;

            if (DatabaseOperations.UpdateWorld(world) == 1)
            {
                MessageBox.Show("Settings saved!");
            }
        }
    }
}
