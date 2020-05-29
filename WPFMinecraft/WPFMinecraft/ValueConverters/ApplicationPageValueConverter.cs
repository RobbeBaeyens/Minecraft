using System;
using System.Diagnostics;
using System.Globalization;
using WPFMinecraft.Pages;

namespace WPFMinecraft.ValueConverters
{
    /// <summary>
    /// Converts the <see cref="ApplicationPage"/> to an actual view/page
    /// </summary>
    public class ApplicationPageValueConverter : BaseValueConverter<ApplicationPageValueConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Find the appropriate page
            switch ((ApplicationPage)value)
            {
                case ApplicationPage.Home:
                    return new HomePage();


                case ApplicationPage.PlayerManagement:
                    return new PlayerManagementPage();


                case ApplicationPage.ServerManagement:
                    return new ServerManagementPage();


                case ApplicationPage.Inventory:
                    return new InventoryPage();

                case ApplicationPage.InventoryManager:
                    return new InventoryManagerPage();

                case ApplicationPage.Advancements:
                    return new AdvancementsPage();


                case ApplicationPage.Player:
                    return new PlayerPage();

                case ApplicationPage.Effects:
                    return new EffectPage();

                case ApplicationPage.Recipes:
                    return new RecipePage();

                case ApplicationPage.Settings:
                    return new WorldSettingsPage();

                case ApplicationPage.GameRule:
                    return new GameRulePage();

                case ApplicationPage.MoreOption:
                    return new MoreOptionPage();

                default:
                    Debugger.Break();
                    return null;
            }
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
