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

namespace WPFMinecraft.Pages
{
    /// <summary>
    /// Interaction logic for Inventory_ManagerPage.xaml
    /// </summary>
    public partial class InventoryManagerPage : Page
    {
        Inventory_Item invItem = new Inventory_Item();
        List<Item> invItems = DatabaseOperations.OphalenItems();

        public InventoryManagerPage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (Item item in invItems)
            {
                string str = item.name;
                str = str.Substring(10);
                item.name = char.ToUpper(str[0]).ToString() + str.Substring(1);
            }

            cmb1.ItemsSource = invItems;
        }



    }
}
