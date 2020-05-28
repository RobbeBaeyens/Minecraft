using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
    /// Interaction logic for AdvancementsPage.xaml
    /// </summary>
    public partial class AdvancementsPage : Page
    {
        public int serverId;
        public int worldId;
        public int playerId;

        public Player player;

        public List<ToggleButton> advButtons;


        public AdvancementsPage()
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
                worldId = DatabaseOperations.OphalenWorldViaSpeler(playerId).id;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Server ID: " + serverId + "\nWorld ID: " + worldId + "\nPlayer ID: " + playerId + "\n");
            }

            advButtons = new List<ToggleButton>()
            {
                btnAdvancementGrasBlok, btnAdvancementHoutenPikhouweel, btnAdvancementStenenPikhouweel, btnAdvancementIjzerKlomp,
                btnAdvancementIjzerBorst, btnAdvancementHoutenSchild, btnAdvancementEmmerLava, btnAdvancementObsidiaan, btnAdvancementVuursteen,
                btnAdvancementGoudenAppel, btnAdvancementEnderOog, btnAdvancementEindeSteen, btnAdvancementIjzerenPikhouweel,
                btnAdvancementDiamant, btnAdvancementDiamantenBorst, btnAdvancementBetoverdBoek,
            };

            player = DatabaseOperations.OphalenAdvancements(playerId);

            Style brown = (Style)FindResource("normalAdvancementBrown");
            Style specialbrown = (Style)FindResource("specialAdvancementBrown");
            Style grey = (Style)FindResource("normalAdvancementGrey");
            Style specialgrey = (Style)FindResource("specialAdvancementGrey");

            var count = 0;
            foreach (Player_Advancement advancement in player.Player_Advancement)
            {
                if (advancement.advancementObtained)
                {
                    if(advancement.Advancement.type == "normal")
                        advButtons[count].Style = brown;
                    else
                        advButtons[count].Style = specialbrown;
                }
                else
                {
                    if (advancement.Advancement.type == "normal")
                        advButtons[count].Style = grey;
                    else
                        advButtons[count].Style = specialgrey;
                }
                count++;
            }
        }

        private void btnGrantAdvancement_Click(object sender, RoutedEventArgs e)
        {
            Style brown = (Style)FindResource("normalAdvancementBrown");
            Style specialbrown = (Style)FindResource("specialAdvancementBrown");

            var count = 1;

            foreach (ToggleButton button in advButtons)
            {
                if (button.IsChecked == true)
                {
                    button.Style = brown;
                    button.IsChecked = false;


                }

                count++;
            }

            if (btnAdvancementGoudenAppel.IsChecked == true)
            {
                btnAdvancementGoudenAppel.Style = specialbrown;
                btnAdvancementGoudenAppel.IsChecked = false;
            }
        }


        private void btnRevokeAdvancement_Click(object sender, RoutedEventArgs e)
        {

            Style grey = (Style)FindResource("normalAdvancementGrey");
            Style specialgrey = (Style)FindResource("specialAdvancementGrey");

            foreach (ToggleButton button in advButtons)
            {
                if (button.IsChecked == true)
                {
                    button.Style = grey;
                    button.IsChecked = false;
                }
            }

            if (btnAdvancementGoudenAppel.IsChecked == true)
            {
                btnAdvancementGoudenAppel.Style = specialgrey;
                btnAdvancementGoudenAppel.IsChecked = false;
            }
        }
    }
}
