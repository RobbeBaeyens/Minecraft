using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace WPFMinecraft.Pages
{
    /// <summary>
    /// Interaction logic for ServerManagementPage.xaml
    /// </summary>
    public partial class ServerManagementPage : Page
    {
        Server selectedserver = new Server();
        List<Server> servers = DatabaseOperations.OphalenServers();

        public ServerManagementPage()
        {
            InitializeComponent();
        }

        private void getServers()
        {
            ListboxServers.ItemsSource = servers;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            getServers();
        }

        private void btnAddServer_Click(object sender, RoutedEventArgs e)
        {
            World world = new World();
            world.name = "world";
            Random rand = new Random();
            world.seed = rand.Next(111111111, 999999999).ToString();
            Server server = new Server();


            string serverName = textBoxServerName.Text;
            string serverIp = textBoxServerIp.Text;
            if (!String.IsNullOrWhiteSpace(serverName) && serverName.Length <= 20)
            {
                if (!String.IsNullOrWhiteSpace(serverIp) && Regex.IsMatch(serverIp, @"\b\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}\b") && serverIp.Length < 22)
                {
                    DatabaseOperations.AddWorld(world);
                    server.name = serverName;
                    server.ipadress = serverIp;
                    server.image = null;
                    server.worldId = world.id;
                    DatabaseOperations.AddServer(server);
                    servers = DatabaseOperations.OphalenServers();
                    ListboxServers.ItemsSource = servers;
                }
                else
                {
                    MessageBox.Show("Insert a valid IP adress", "No IP");
                }
            }
            else
            {
                MessageBox.Show("Insert a server name (max length: 20)", "No Name");
            }
        }

        private void ListboxServers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedserver = (Server)ListboxServers.SelectedItem;
            if(ListboxServers.SelectedIndex == -1)
            {
                textBoxServerName.Text = "";
                textBoxServerIp.Text = "";
            }
            else
            {
                textBoxServerName.Text = selectedserver.name;
                textBoxServerIp.Text = selectedserver.ipadress;
            }
        }

        private void btnRemoveServer_Click(object sender, RoutedEventArgs e)
        {
            if (ListboxServers.SelectedIndex != -1)
            {
                DatabaseOperations.RemoveServer(selectedserver);
                servers = DatabaseOperations.OphalenServers();
                ListboxServers.ItemsSource = servers;
            }
        }

        private void btnUpdateServer_Click(object sender, RoutedEventArgs e)
        {
            if (ListboxServers.SelectedIndex != -1)
            {
                Server server = selectedserver;
                string serverName = textBoxServerName.Text;
                string serverIp = textBoxServerIp.Text;
                if (!String.IsNullOrWhiteSpace(serverName) && serverName.Length <= 20)
                {
                    if (!String.IsNullOrWhiteSpace(serverIp) && Regex.IsMatch(serverIp, @"\b\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}\b") && serverIp.Length < 22)
                    {
                        server.name = serverName;
                        server.image = null;
                        server.ipadress = serverIp;
                        server.worldId = null;
                        DatabaseOperations.UpdateServer(server);
                        servers = DatabaseOperations.OphalenServers();
                        ListboxServers.ItemsSource = servers;
                    }
                    else
                    {
                        MessageBox.Show("Insert a valid IP adress", "No IP");
                    }
                }
                else
                {
                    MessageBox.Show("Insert a server name (max length: 20)", "No Name");
                }
            }
        }

        private void btnOpenServer_Click(object sender, RoutedEventArgs e)
        {
            if (ListboxServers.SelectedIndex != -1)
            {
            }
        }
    }
}
