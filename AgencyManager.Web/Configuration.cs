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
                DrawerBackground = "#21508e",
                DrawerText = "#ECF0F1"

            },
            PaletteDark = new PaletteDark
            {
                Primary = "#21508e",
                Secondary = "1E3A5F",
                Tertiary = "4A90E2",
                Background = "#343434",
                AppbarBackground = "#21508e",
                AppbarText = "#ECF0F1",
                TextPrimary = "#ECF0F1",
                DrawerBackground = "#1C1C1C",
                DrawerText = "#95A5A6"
            }
        };
    }
}
