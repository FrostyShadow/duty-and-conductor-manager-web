using MudBlazor;

namespace DutyAndConductorManager.Web.Helpers;

public interface IThemeLibrary
{
    MudTheme DarkTheme {get;}
    MudTheme LightTheme {get;}
}

public class ThemeLibrary : IThemeLibrary
{
    public MudTheme DarkTheme {get; private set;}
    public MudTheme LightTheme {get; private set;}

    public ThemeLibrary()
    {
        DarkTheme = new MudTheme()
        {
            Palette = new Palette()
            {
                Black = "#27272f",
                Background = "#32333d",
                BackgroundGrey = "#27272f",
                Surface = "#373740",
                DrawerBackground = "#27272f",
                DrawerText = "rgba(255,255,255, 0.50)",
                DrawerIcon = "rgba(255,255,255, 0.50)",
                AppbarBackground = "#27272f",
                AppbarText = "rgba(255,255,255, 0.70)",
                TextPrimary = "rgba(255,255,255, 0.70)",
                TextSecondary = "rgba(255,255,255, 0.50)",
                ActionDefault = "#adadb1",
                ActionDisabled = "rgba(255,255,255, 0.26)",
                ActionDisabledBackground = "rgba(255,255,255, 0.12)",
                Divider = "rgba(255,255,255, 0.12)",
                DividerLight = "rgba(255,255,255, 0.06)",
                TableLines = "rgba(255,255,255, 0.12)",
                LinesDefault = "rgba(255,255,255, 0.12)",
                LinesInputs = "rgba(255,255,255, 0.3)",
                TextDisabled = "rgba(255,255,255, 0.2)",
                Primary = "#4fc3f7",
                PrimaryLighten = "#8bf6ff",
                PrimaryDarken = "#0093c4"
            }
        };

        LightTheme = new MudTheme()
        {
            Palette = new Palette()
            {
                Black = "#272c34",
                Primary = "#0093c4",
                PrimaryLighten = "#5bc3f7",
                PrimaryDarken = "#006593",
                AppbarBackground = "#0093c4"
            }
        };
    }
}