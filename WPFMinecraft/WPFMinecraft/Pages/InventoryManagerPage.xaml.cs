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
using MODELSMinecraft;

namespace WPFMinecraft.Pages
{
    /// <summary>
    /// Interaction logic for Inventory_ManagerPage.xaml
    /// </summary>
    public partial class InventoryManagerPage : Page
    {
        public int serverId;
        public int worldId;
        public int playerId;
        public int inventoryId;

        Inventory_Item invItem = new Inventory_Item();
        List<Item> invItems = DatabaseOperations.OphalenItems();
        List<Inventory_Item> inventoryitems;



        public InventoryManagerPage()
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

            inventoryitems = DatabaseOperations.OphalenInventoryItem(inventoryId);


            foreach (Item item in invItems)
            {
                string str = item.name;
                str = str.Substring(10);
                item.name = char.ToUpper(str[0]).ToString() + str.Substring(1);
            }

            cmb1.ItemsSource = invItems;

            
            

        }

        private void btnAddItem_Click(object sender, RoutedEventArgs e)
        {
            if (cmb1.SelectedIndex != -1 && cmb2.SelectedIndex != -1)
            {


                if (int.TryParse(txtInvoerAmount.Text, out int count))
                {
                    InventoryClass inventorySet = new InventoryClass(count);
                    string valideer = inventorySet.Valideer("count");

                    if (valideer == "ok")
                    {
                        Inventory_Item inventoryItem = new Inventory_Item();
                        inventoryItem.inventoryId = inventoryId;
                        inventoryItem.itemId = cmb1.SelectedIndex;
                        inventoryItem.slotId = cmb2.SelectedIndex;
                        inventoryItem.count = count;

                        DatabaseOperations.UpdateInventoryItem(inventoryItem);
                    }
                    else
                    {
                        MessageBox.Show(valideer);
                    }
                }
                else
                {
                    MessageBox.Show("Only nummeric alowed in Amount");
                }
            }
            else
            {
                MessageBox.Show("You need to select Item & Slot");
            }


        }
    }
}
