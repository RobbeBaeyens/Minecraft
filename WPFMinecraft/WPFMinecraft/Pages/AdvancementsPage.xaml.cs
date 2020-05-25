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
    /// Interaction logic for AdvancementsPage.xaml
    /// </summary>
    public partial class AdvancementsPage : Page
    {
        public AdvancementsPage()
        {
            InitializeComponent();
        }

        private void btnGrantAdvancement_Click(object sender, RoutedEventArgs e)
        {
            Style brown = (Style)FindResource("normalAdvancementBrown");
            Style specialbrown = (Style)FindResource("specialAdvancementBrown");

            if (btnAdvancementBetoverdBoek.IsChecked == true)
            {
                btnAdvancementBetoverdBoek.Style = brown;
                btnAdvancementBetoverdBoek.IsChecked = false;
            }

            if (btnAdvancementDiamant.IsChecked == true)
            {
                btnAdvancementDiamant.Style = brown;
                btnAdvancementDiamant.IsChecked = false;
            }

            if (btnAdvancementDiamantenBorst.IsChecked == true)
            {
                btnAdvancementDiamantenBorst.Style = brown;
                btnAdvancementDiamantenBorst.IsChecked = false;
            }

            if (btnAdvancementEindeSteen.IsChecked == true)
            {
                btnAdvancementEindeSteen.Style = brown;
                btnAdvancementEindeSteen.IsChecked = false;
            }

            if (btnAdvancementEmmerLava.IsChecked == true)
            {
                btnAdvancementEmmerLava.Style = brown;
                btnAdvancementEmmerLava.IsChecked = false;
            }

            if (btnAdvancementEnderOog.IsChecked == true)
            {
                btnAdvancementEnderOog.Style = brown;
                btnAdvancementEnderOog.IsChecked = false;
            }

            if (btnAdvancementGoudenAppel.IsChecked == true)
            {
                btnAdvancementGoudenAppel.Style = specialbrown;
                btnAdvancementGoudenAppel.IsChecked = false;
            }

            if (btnAdvancementGrasBlok.IsChecked == true)
            {
                btnAdvancementGrasBlok.Style = brown;
                btnAdvancementGrasBlok.IsChecked = false;
            }

            if (btnAdvancementHoutenPikhouweel.IsChecked == true)
            {
                btnAdvancementHoutenPikhouweel.Style = brown;
                btnAdvancementHoutenPikhouweel.IsChecked = false;
            }

            if (btnAdvancementHoutenSchild.IsChecked == true)
            {
                btnAdvancementHoutenSchild.Style = brown;
                btnAdvancementHoutenSchild.IsChecked = false;
            }

            if (btnAdvancementIjzerBorst.IsChecked == true)
            {
                btnAdvancementIjzerBorst.Style = brown;
                btnAdvancementIjzerBorst.IsChecked = false;
            }

            if (btnAdvancementIjzerenPikhouweel.IsChecked == true)
            {
                btnAdvancementIjzerenPikhouweel.Style = brown;
                btnAdvancementIjzerenPikhouweel.IsChecked = false;
            }

            if (btnAdvancementIjzerKlomp.IsChecked == true)
            {
                btnAdvancementIjzerKlomp.Style = brown;
                btnAdvancementIjzerKlomp.IsChecked = false;
            }

            if (btnAdvancementObsidiaan.IsChecked == true)
            {
                btnAdvancementObsidiaan.Style = brown;
                btnAdvancementObsidiaan.IsChecked = false;
            }

            if (btnAdvancementStenenPikhouweel.IsChecked == true)
            {
                btnAdvancementStenenPikhouweel.Style = brown;
                btnAdvancementStenenPikhouweel.IsChecked = false;
            }

            if (btnAdvancementVuursteen.IsChecked == true)
            {
                btnAdvancementVuursteen.Style = brown;
                btnAdvancementVuursteen.IsChecked = false;
            }

        }


        private void btnRevokeAdvancement_Click(object sender, RoutedEventArgs e)
        {

            Style grey = (Style)FindResource("normalAdvancementGrey");
            Style specialgrey = (Style)FindResource("specialAdvancementGrey");


            if (btnAdvancementBetoverdBoek.IsChecked == true)
            {
                btnAdvancementBetoverdBoek.Style = grey;
                btnAdvancementBetoverdBoek.IsChecked = false;
            }

            if (btnAdvancementDiamant.IsChecked == true)
            {
                btnAdvancementDiamant.Style = grey;
                btnAdvancementDiamant.IsChecked = false;
            }

            if (btnAdvancementDiamantenBorst.IsChecked == true)
            {
                btnAdvancementDiamantenBorst.Style = grey;
                btnAdvancementDiamantenBorst.IsChecked = false;
            }

            if (btnAdvancementEindeSteen.IsChecked == true)
            {
                btnAdvancementEindeSteen.Style = grey;
                btnAdvancementEindeSteen.IsChecked = false;
            }

            if (btnAdvancementEmmerLava.IsChecked == true)
            {
                btnAdvancementEmmerLava.Style = grey;
                btnAdvancementEmmerLava.IsChecked = false;
            }

            if (btnAdvancementEnderOog.IsChecked == true)
            {
                btnAdvancementEnderOog.Style = grey;
                btnAdvancementEnderOog.IsChecked = false;
            }

            if (btnAdvancementGoudenAppel.IsChecked == true)
            {
                btnAdvancementGoudenAppel.Style = specialgrey;
                btnAdvancementGoudenAppel.IsChecked = false;
            }

            if (btnAdvancementGrasBlok.IsChecked == true)
            {
                btnAdvancementGrasBlok.Style = grey;
                btnAdvancementGrasBlok.IsChecked = false;
            }

            if (btnAdvancementHoutenPikhouweel.IsChecked == true)
            {
                btnAdvancementHoutenPikhouweel.Style = grey;
                btnAdvancementHoutenPikhouweel.IsChecked = false;
            }

            if (btnAdvancementHoutenSchild.IsChecked == true)
            {
                btnAdvancementHoutenSchild.Style = grey;
                btnAdvancementHoutenSchild.IsChecked = false;
            }

            if (btnAdvancementIjzerBorst.IsChecked == true)
            {
                btnAdvancementIjzerBorst.Style = grey;
                btnAdvancementIjzerBorst.IsChecked = false;
            }

            if (btnAdvancementIjzerenPikhouweel.IsChecked == true)
            {
                btnAdvancementIjzerenPikhouweel.Style = grey;
                btnAdvancementIjzerenPikhouweel.IsChecked = false;
            }

            if (btnAdvancementIjzerKlomp.IsChecked == true)
            {
                btnAdvancementIjzerKlomp.Style = grey;
                btnAdvancementIjzerKlomp.IsChecked = false;
            }

            if (btnAdvancementObsidiaan.IsChecked == true)
            {
                btnAdvancementObsidiaan.Style = grey;
                btnAdvancementObsidiaan.IsChecked = false;
            }

            if (btnAdvancementStenenPikhouweel.IsChecked == true)
            {
                btnAdvancementStenenPikhouweel.Style = grey;
                btnAdvancementStenenPikhouweel.IsChecked = false;
            }

            if (btnAdvancementVuursteen.IsChecked == true)
            {
                btnAdvancementVuursteen.Style = grey;
                btnAdvancementVuursteen.IsChecked = false;
            }
        }
    }
}
