using MudBlazor;

namespace AgencyManager.Web
{
    public static class Configuration
    {
        public const string HttpClientName = "manager";
        public static string BackendUrl { get; set; } = Configuration.BackendUrl ?? string.Empty;
        
        public static MudTheme Theme = new()
        {
            Typography = new Typography
            {
                Default = new Default
                {
                    FontFamily = ["Raleway", "sans-serif"]
                }
            },

            PaletteLight = new PaletteLight
            {
                Primary = "#1E3A5F",
                Secondary = "#4A90E2",
                Tertiary = "#005B96",
                Background = "#FFFFFF",
                AppbarBackground = "#1E3A5F",
                AppbarText = "#FFFFFF",
                TextPrimary = Colors.Shades.Black,
                DrawerBackground = "#7F8C8D",
                DrawerText = "#ECF0F1"

            },
            PaletteDark = new PaletteDark
            {
                Primary = "#2C3E50",
                Secondary = "1E3A5F",
                Tertiary = "4A90E2",
                Background = "#1C1C1C",
                AppbarBackground = "#2C3E50",
                AppbarText = "#ECF0F1",
                TextPrimary = "#ECF0F1",
                DrawerBackground = "#1E3A5F",
                DrawerText = "#95A5A6"
            }
        };
    }
}
