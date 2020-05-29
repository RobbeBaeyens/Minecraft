using System;
using System.Collections;
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
    /// Interaction logic for EffectPage.xaml
    /// </summary>
    public partial class EffectPage : Page
    {
     
        public EffectPage()
        {
            InitializeComponent();
        

        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Listbox1.Items.Add(Listbox.SelectedItem);

            if (Listbox1.SelectedIndex != -1)
            {
                Listbox.Items.Add(Listbox1.SelectedValue);
                Listbox1.Items.Remove(Listbox1.SelectedValue);
            }
            else if (Listbox.SelectedIndex != -1)
            {
                Listbox1.Items.Add(Listbox.SelectedValue);
                Listbox.Items.Remove(Listbox.SelectedValue);
            }

         
        }
        
    }
}
