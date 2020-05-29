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
                worldId = windowViewModel.WorldId;
                inventoryId = windowViewModel.InventoryId;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Server ID: " + serverId + "\nWorld ID: " + worldId + "\nPlayer ID: " + playerId + "\n");
            }

            addToInventory();
        }

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
            List<TextBlock> textblokken = new List<TextBlock>()
            {
                invArmorHelmet, invArmorChest, invArmorPants, invArmorBoots, invShield,
                inv01, inv02, inv03, inv04, inv05, inv06, inv07, inv08, inv09, inv10, inv11,
                inv12, inv13, inv14, inv15, inv16, inv17, inv18, inv19, inv20, inv21, inv22,
                inv23,inv24, inv25, inv26, inv27,
                invHand01, invHand02, invHand03, invHand04, invHand05, invHand06, invHand07, invHand08, invHand09,
            };

            var counter = 1;

            List<Inventory_Item> invitems = DatabaseOperations.OphalenInventoryItems(inventoryId);
            Console.WriteLine(invitems.Count());
            Console.WriteLine(inventoryId);
            foreach (Inventory_Item invitem in invitems)
            {
                if (invitem.count != 0)
                {
                    Image image = new Image();
                    image.Source = new BitmapImage(new Uri(invitem.Item.image));
                    Label label = new Label();
                    label.Content = invitem.count; 
                    textblokken[counter - 1].Inlines.Add(image);
                    textblokken[counter - 1].Inlines.Add(label);

                    Console.WriteLine(invitem.slotId);
                }
                counter++;

                Console.WriteLine(invitem.slotId);
            }
        }
    }
}
