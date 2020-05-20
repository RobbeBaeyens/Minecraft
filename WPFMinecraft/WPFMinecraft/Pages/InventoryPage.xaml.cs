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
    /// Interaction logic for Inventory.xaml
    /// </summary>
    public partial class InventoryPage : Page
    {
        public InventoryPage()
        {
            InitializeComponent();

        }

        int gridNummer = 0;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            InventoryManagerPage inventoryManager = new InventoryManagerPage();
            
        }

        public void addToInventory()
        {
            //Label test = new Label();
            //Inventory_grid.Children.Insert(5, test);

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
