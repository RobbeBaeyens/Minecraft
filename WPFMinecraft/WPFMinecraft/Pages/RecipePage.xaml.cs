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
        public List<Recipe_Item> recipes;
        public Player player;
        public ListBoxItem selectedListBox;
        public string selectedRecipeItem;

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

            drawRecipes(0);
        }

        private void drawRecipes(int functie)
        {
            Style RedBlock = (Style)FindResource("rectangleRed");
            Style GreenBlock = (Style)FindResource("rectangleGreen");
            if(functie != 3)
                lstBxRecipes.Items.Clear();
            var count = 0;
            foreach (Player_Recipe player_Recipe in player_Recipes)
            {
                string str = player_Recipe.Recipe.Item.name;
                str = str.Substring(10);
                string itemname = char.ToUpper(str[0]).ToString() + str.Substring(1);

                if(functie == 3 && selectedRecipeItem == itemname)
                {
                    Style gridRecipe = (Style)FindResource("GridRecipe");
                    Console.WriteLine("recipeId: " + player_Recipe.recipeId);
                    recipes =  DatabaseOperations.OphalenRecipeItems(player_Recipe.recipeId);
                    var gridRow = 0;
                    var gridColumn = 0;
                    RecipeGrid.Children.Clear();
                    for (int i = 0; i < 9; i++)
                    {
                        if (gridColumn > 2)
                        {
                            gridColumn = 0;
                            gridRow++;
                        }
                        TextBlock textblock = new TextBlock();
                        textblock.Style = gridRecipe;
                        textblock.SetValue(Grid.ColumnProperty, gridColumn);
                        textblock.SetValue(Grid.RowProperty, gridRow);
                        RecipeGrid.Children.Add(textblock);
                        gridColumn++;
                    }
                    Console.WriteLine("Count: " + recipes.Count());
                    foreach (Recipe_Item recipeitem in recipes)
                    {
                        Console.WriteLine(recipeitem.itemId);
                        TextBlock textblock = new TextBlock();
                        textblock.Style = gridRecipe;
                        textblock.SetValue(Grid.ColumnProperty, recipeitem.column);
                        textblock.SetValue(Grid.RowProperty, recipeitem.row);
                        Image secondimage = new Image();
                        secondimage.Source = new BitmapImage(new Uri(recipeitem.Item.image));
                        textblock.Inlines.Add(secondimage);
                        RecipeGrid.Children.Add(textblock);
                    }
                    //< TextBlock x: Name = "txtGrid1" Style = "{StaticResource GridRecipe}" Grid.Column = "0" />
                }

                if (functie == 1 && selectedRecipeItem == itemname && !player_Recipe.recipeObtained)
                {
                    Console.WriteLine("Granted " + itemname);
                    player_Recipe.recipeObtained = true;
                    DatabaseOperations.UpdatePlayerRecipe(player_Recipe);
                }
                if (functie == 2 && selectedRecipeItem == itemname && player_Recipe.recipeObtained)
                {
                    Console.WriteLine("Revoked " + itemname);
                    player_Recipe.recipeObtained = false;
                    DatabaseOperations.UpdatePlayerRecipe(player_Recipe);
                }

                if (functie != 3)
                {
                    Image image = new Image();
                    image.Source = new BitmapImage(new Uri(player_Recipe.Recipe.Item.image));

                    ListBoxItem listBoxItem = new ListBoxItem();

                    listBoxItem.Name = itemname;
                    listBoxItem.Style = player_Recipe.recipeObtained ? GreenBlock : RedBlock;
                    listBoxItem.Selected += new RoutedEventHandler(lstBx_select);
                    listBoxItem.Content = image;

                    lstBxRecipes.Items.Add(listBoxItem);
                }
                count++;
            }
        }

        private void lstBx_select(object sender, RoutedEventArgs e)
        {
            selectedListBox = sender as ListBoxItem;
            selectedRecipeItem = selectedListBox.Name;
            drawRecipes(3);
        }

        private void btnAddRecipe_Click(object sender, RoutedEventArgs e)
        {
            drawRecipes(1);
        }

        private void btnRemoveRecipe_Click(object sender, RoutedEventArgs e)
        {
            drawRecipes(2);
        }
    }
}
