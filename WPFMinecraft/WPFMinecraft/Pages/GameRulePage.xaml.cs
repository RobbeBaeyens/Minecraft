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
    /// Interaction logic for GameRulePage.xaml
    /// </summary>
    public partial class GameRulePage : Page
    {
        public GameRulePage()
        {
            InitializeComponent();
        }

        private void btnElytraMovement_Click(object sender, RoutedEventArgs e)
        {
            if (txt1.Text.ToString() == "Disable elytra movement check: OFF")
            {
                txt1.Text = "Disable elytra movement check: ON";

            }
            else
            {
                txt1.Text = "Disable elytra movement check: OFF";
            }

        }

        private void btnRespawnImmediatly_Click(object sender, RoutedEventArgs e)
        {
            if (txt2.Text.ToString() == "Respawn immediatly: OFF")
            {
                txt2.Text = "Respawn immediatly: ON";

            }
            else
            {
                txt2.Text = "Respawn immediatly: OFF";
            }
        }

        private void btnRecipeCrafting_Click(object sender, RoutedEventArgs e)
        {
            if (txt3.Text.ToString() == "Require recipe for crafting: OFF")
            {
                txt3.Text = "Require recipe for crafting: ON";

            }
            else
            {
                txt3.Text = "Require recipe for crafting: OFF";
            }
        }

        private void btnDrowningDmg_Click(object sender, RoutedEventArgs e)
        {
            if (txt4.Text.ToString() == "Deal drowning damage: ON")
            {
                txt4.Text = "Deal drowning damage: OFF";

            }
            else
            {
                txt4.Text = "Deal drowning damage: ON";
            }
        }

        private void btnFallDmg_Click(object sender, RoutedEventArgs e)
        {
            if (txt5.Text.ToString() == "Deal fall damage: ON")
            {
                txt5.Text = "Deal fall damage: OFF";

            }
            else
            {
                txt5.Text = "Deal fall damage: ON";
            }
        }

        private void btnFireDmg_Click(object sender, RoutedEventArgs e)
        {
            if (txt6.Text.ToString() == "Deal fire damage: ON")
            {
                txt6.Text = "Deal fire damage: OFF";

            }
            else
            {
                txt6.Text = "Deal fire damage: ON";
            }
        }

        private void btnKeepInv_Click(object sender, RoutedEventArgs e)
        {
            if (txt7.Text.ToString() == "Keep inventory after death: OFF")
            {
                txt7.Text = "Keep inventory after death: ON";

            }
            else
            {
                txt7.Text = "Keep inventory after death: OFF";
            }
        }

        private void btnHealthRegen_Click(object sender, RoutedEventArgs e)
        {
            if (txt8.Text.ToString() == "Regenerate health: ON")
            {
                txt8.Text = "Regenerate health: OFF";

            }
            else
            {
                txt8.Text = "Regenerate health: ON";
            }
        }

        private void btnGenerateTerrain_Click(object sender, RoutedEventArgs e)
        {
            if (txt9.Text.ToString() == "Allow spectators to generate terrain: ON")
            {
                txt9.Text = "Allow spectators to generate terrain: OFF";

            }
            else
            {
                txt9.Text = "Allow spectators to generate terrain: ON";
            }
        }

        private void btnDisableRaids_Click(object sender, RoutedEventArgs e)
        {
            if (txt10.Text.ToString() == "Disable raids: OFF")
            {
                txt10.Text = "Disable raids: ON";

            }
            else
            {
                txt10.Text = "Disable raids: OFF";
            }
        }

        private void btnAllowDestructiveMob_Click(object sender, RoutedEventArgs e)
        {
            if (txt11.Text.ToString() == "Allow destructive mob actions: ON")
            {
                txt11.Text = "Allow destructive mob actions: OFF";

            }
            else
            {
                txt11.Text = "Allow destructive mob actions: ON";
            }
        }

        private void btnSpawnPhantoms_Click(object sender, RoutedEventArgs e)
        {
            if (txt12.Text.ToString() == "Spawn phantoms: ON")
            {
                txt12.Text = "Spawn phantoms: OFF";

            }
            else
            {
                txt12.Text = "Spawn phantoms: ON";
            }
        }

        private void btnSpawnMobs_Click(object sender, RoutedEventArgs e)
        {
            if (txt13.Text.ToString() == "Spawn mobs: ON")
            {
                txt13.Text = "Spawn mobs: OFF";

            }
            else
            {
                txt13.Text = "Spawn mobs: ON";
            }
        }

        private void btnPillagerPatrol_Click(object sender, RoutedEventArgs e)
        {
            if (txt14.Text.ToString() == "Spawn pillager patrols: ON")
            {
                txt14.Text = "Spawn pillager patrols: OFF";

            }
            else
            {
                txt14.Text = "Spawn pillager patrols: ON";
            }
        }

        private void btnWanderingTraders_Click(object sender, RoutedEventArgs e)
        {
            if (txt15.Text.ToString() == "Spawn wandering traders: ON")
            {
                txt15.Text = "Spawn wandering traders: OFF";

            }
            else
            {
                txt15.Text = "Spawn wandering traders: ON";
            }
        }

        private void btnEntetyEquipment_Click(object sender, RoutedEventArgs e)
        {
            if (txt16.Text.ToString() == "Drop entity equipment: ON")
            {
                txt16.Text = "Drop entity equipment: OFF";

            }
            else
            {
                txt16.Text = "Drop entity equipment: ON";
            }
        }

        private void btnMobLoot_Click(object sender, RoutedEventArgs e)
        {
            if (txt17.Text.ToString() == "Drop mob loot: ON")
            {
                txt17.Text = "Drop mob loot: OFF";

            }
            else
            {
                txt17.Text = "Drop mob loot: ON";
            }
        }

        private void btnDropBlocks_Click(object sender, RoutedEventArgs e)
        {
            if (txt18.Text.ToString() == "Drop blocks: ON")
            {
                txt18.Text = "Drop blocks: OFF";

            }
            else
            {
                txt18.Text = "Drop blocks: ON";
            }
        }

        private void btnInGameTime_Click(object sender, RoutedEventArgs e)
        {
            if (txt19.Text.ToString() == "Advance in-game time: ON")
            {
                txt19.Text = "Advance in-game time: OFF";

            }
            else
            {
                txt19.Text = "Advance in-game time: ON";
            }
        }

        private void btnUpdateFire_Click(object sender, RoutedEventArgs e)
        {
            if (txt20.Text.ToString() == "Update fire: ON")
            {
                txt20.Text = "Update fire: OFF";

            }
            else
            {
                txt20.Text = "Update fire: ON";
            }
        }

        private void btnUpdateWeather_Click(object sender, RoutedEventArgs e)
        {
            if (txt21.Text.ToString() == "Update weather: ON")
            {
                txt21.Text = "Update weather: OFF";

            }
            else
            {
                txt21.Text = "Update weather: ON";
            }
        }

        private void btnAnnounceAdvancements_Click(object sender, RoutedEventArgs e)
        {
            if (txt22.Text.ToString() == "Announce advancements: ON")
            {
                txt22.Text = "Announce advancements: OFF";

            }
            else
            {
                txt22.Text = "Announce advancements: ON";
            }
        }

        private void btnBlockOutput_Click(object sender, RoutedEventArgs e)
        {
            if (txt23.Text.ToString() == "Broadcast command block output: ON")
            {
                txt23.Text = "Broadcast command block output: OFF";

            }
            else
            {
                txt23.Text = "Broadcast command block output: ON";
            }
        }

        private void btnAdminCommands_Click(object sender, RoutedEventArgs e)
        {
            if (txt24.Text.ToString() == "Broadcast admin commands: ON")
            {
                txt24.Text = "Broadcast admin commands: OFF";

            }
            else
            {
                txt24.Text = "Broadcast admin commands: ON";
            }
        }

        private void btnFeedback_Click(object sender, RoutedEventArgs e)
        {
            if (txt25.Text.ToString() == "Send command feedback: ON")
            {
                txt25.Text = "Send command feedback: OFF";

            }
            else
            {
                txt25.Text = "Send command feedback: ON";
            }
        }

        private void btnDeathMessages_Click(object sender, RoutedEventArgs e)
        {
            if (txt26.Text.ToString() == "Show death messages: ON")
            {
                txt26.Text = "Show death messages: OFF";

            }
            else
            {
                txt26.Text = "Show death messages: ON";
            }
        }

        private void btnDebugInfo_Click(object sender, RoutedEventArgs e)
        {
            if (txt27.Text.ToString() == "Reduce debug info: OFF")
            {
                txt27.Text = "Reduce debug info: ON";

            }
            else
            {
                txt27.Text = "Reduce debug info: OFF";
            }
        }
    }
}
