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
    /// Interaction logic for Inventory.xaml
    /// </summary>
    public partial class InventoryPage : Page
    {
        public int serverId;
        public int worldId;
        public int playerId;
        public int inventoryId;

        public InventoryPage()
        {
            InitializeComponent();

        }

        int gridNummer = 0;

        private void Button_Click(object sender, RoutedEventArgs e)
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
                windowViewModel.CurrentPage = ApplicationPage.InventoryManager;
                windowViewModel.InventoryId = inventoryId;
                serverId = windowViewModel.ServerId;
                windowViewModel.WorldId = worldId;
                windowViewModel.PlayerId = playerId;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Server ID: " + serverId + "\nWorld ID: " + worldId + "\nInventory ID : " + inventoryId + "\n" );
            }
        }

        public void addToInventory()
        {

            int testInt = 0;

            foreach (TextBlock test in Inventory_grid.Children)
            {
                Console.WriteLine(test);

                if (testInt == gridNummer)
                    test.Inlines.Add(new Label { Content = "tekst" });

                Console.WriteLine(testInt);
                testInt++;
            }
        }
    }
}
