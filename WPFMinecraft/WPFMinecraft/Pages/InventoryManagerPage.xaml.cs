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

            List<string> slots = new List<string>()
            {
                "armor.helmet" , "armor.chestplate", "armor.leggings", "armor.boots", "inv.offhand",

                "hotbar.0", "hotbar.1", "hotbar.2", "hotbar.3", "hotbar.4",  "hotbar.5",  "hotbar.6", "hotbar.7",  "hotbar.8",

                "inv.0", "inv.1", "inv.2", "inv.3", "inv.4",  "inv.5",  "inv.6", "inv.7",  "inv.8",
                "inv.9", "inv.10", "inv.11", "inv.12", "inv.13",  "inv.14",  "inv.15", "inv.16",  "inv.17",
                "inv.18", "inv.19", "inv.20", "inv.21", "inv.22",  "inv.23",  "inv.24", "inv.25",  "inv.26",
            };

            cmb2.ItemsSource = slots;
        }

        private void btnAddItem_Click(object sender, RoutedEventArgs e)
        {
            if (cmb1.SelectedIndex != -1 && cmb2.SelectedIndex != -1)
            {


                if (int.TryParse(txtInvoerAmount.Text, out int count))
                {
                    InventoryClass inventorySet = new InventoryClass(count);
                    string valideer = inventorySet.Valideer("count");

                    if (valideer == "Ok")
                    {
                        Console.WriteLine(inventoryId + "/" + cmb1.SelectedIndex + "/" + cmb2.SelectedIndex + "/" + count);
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

        private void cmb1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void cmb2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
