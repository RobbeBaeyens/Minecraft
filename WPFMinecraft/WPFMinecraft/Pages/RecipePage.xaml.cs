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
    /// Interaction logic for RecipePage.xaml
    /// </summary>
    public partial class RecipePage : Page
    {
        List<Item> RecipeItems = DatabaseOperations.OphalenItems();

        public RecipePage()
        {
            InitializeComponent();
        }

        public int serverId;
        public int worldId;
        public int playerId;
        public List<Player_Recipe> player_Recipes;
        public Player player;

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
                worldId = DatabaseOperations.OphalenWorldViaSpeler(playerId).id;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Server ID: " + serverId + "\nWorld ID: " + worldId + "\nPlayer ID: " + playerId + "\n");
            }

            player_Recipes = DatabaseOperations.OphalenPlayerRecipes(playerId);

            Style RedBlock = (Style)FindResource("rectangle");

            var count = 0;
            foreach (Player_Recipe player_Recipe in player_Recipes)
            {
                Image image = new Image();
                image.Source = new BitmapImage(new Uri(player_Recipe.Recipe.Item.image));
                ListBoxItem listBoxItem = new ListBoxItem();
                listBoxItem.Style = RedBlock;
                listBoxItem.Selected += new RoutedEventHandler(lstBx_select);
                listBoxItem.Content = image; 
                
                lstBxRecipes.Items.Add(listBoxItem);
                count++;
            }

        }

        private void lstBx_select(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnAddRecipe_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnRemoveRecipe_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
