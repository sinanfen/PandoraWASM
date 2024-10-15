using MudBlazor;

namespace PandoraWASM.Theme;

//public class PandoraAdminDashboard : MudTheme
//{
//    public PandoraAdminDashboard()
//    {
//        PaletteLight = new PaletteLight()
//        {
//            Primary = Colors.Blue.Darken1,
//            Secondary = Colors.DeepPurple.Accent2,
//            Background = Colors.Gray.Lighten5,
//            AppbarBackground = Colors.Shades.White,
//            AppbarText = Colors.Shades.Black,
//            DrawerBackground = "#FFF",
//            DrawerText = "rgba(0,0,0, 0.7)",
//            Success = "#06d79c"
//        };
//        PaletteDark = new PaletteDark()
//        {
//            Primary = Colors.Blue.Lighten1,
//            Dark = Colors.Gray.Lighten1,
//        };
//        LayoutProperties = new LayoutProperties()
//        {
//            DefaultBorderRadius = "5px",
//            DrawerWidthLeft = "260px",
//            DrawerWidthRight = "300px"
//        };
//        Typography = new Typography()
//        {
//            Default = new Default()
//            {
//                FontFamily = new[] { "Montserrat", "Helvetica", "Arial", "Roboto", "Verdana" },
//                FontSize = ".875rem",
//                FontWeight = 400,
//                LineHeight = 1.43,
//                LetterSpacing = ".01071em"
//            },
//            H1 = new H1()
//            {
//                FontFamily = new[] { "Montserrat", "Helvetica", "Arial", "Roboto", "Georgia" },
//                FontSize = "6rem",
//                FontWeight = 300,
//                LineHeight = 1.167,
//                LetterSpacing = "-.01562em"
//            },
//            H2 = new H2()
//            {
//                FontFamily = new[] { "Montserrat", "Helvetica", "Arial", "Roboto", "Georgia" },
//                FontSize = "3.75rem",
//                FontWeight = 300,
//                LineHeight = 1.2,
//                LetterSpacing = "-.00833em"
//            },
//            H3 = new H3()
//            {
//                FontFamily = new[] { "Montserrat", "Helvetica", "Arial", "Roboto", "Georgia" },
//                FontSize = "3rem",
//                FontWeight = 400,
//                LineHeight = 1.167,
//                LetterSpacing = "0"
//            },
//            H4 = new H4()
//            {
//                FontFamily = new[] { "Montserrat", "Helvetica", "Arial", "Roboto", "Georgia" },
//                FontSize = "2.125rem",
//                FontWeight = 400,
//                LineHeight = 1.235,
//                LetterSpacing = ".00735em"
//            },
//            H5 = new H5()
//            {
//                FontFamily = new[] { "Montserrat", "Helvetica", "Arial", "Roboto", "Verdana", "sans-serif" },
//                FontSize = "1.5rem",
//                FontWeight = 400,
//                LineHeight = 1.334,
//                LetterSpacing = "0"
//            },
//            H6 = new H6()
//            {
//                FontFamily = new[] { "Montserrat", "Helvetica", "Arial", "Roboto", "Verdana", "sans-serif" },
//                FontSize = "1.25rem",
//                FontWeight = 400,
//                LineHeight = 1.6,
//                LetterSpacing = ".0075em"
//            },
//            Button = new Button()
//            {
//                FontFamily = new[] { "Montserrat", "Helvetica", "Arial", "Roboto", "Verdana", "sans-serif" },
//                FontSize = ".875rem",
//                FontWeight = 500,
//                LineHeight = 1.75,
//                LetterSpacing = ".02857em"
//            },
//            Body1 = new Body1()
//            {
//                FontFamily = new[] { "Montserrat", "Helvetica", "Arial", "Roboto", "Verdana", "sans-serif" },
//                FontSize = "1rem",
//                FontWeight = 400,
//                LineHeight = 1.5,
//                LetterSpacing = ".00938em"
//            },
//            Body2 = new Body2()
//            {
//                FontFamily = new[] { "Montserrat", "Helvetica", "Arial", "Roboto", "Verdana", "sans-serif" },
//                FontSize = ".875rem",
//                FontWeight = 400,
//                LineHeight = 1.43,
//                LetterSpacing = ".01071em"
//            },
//            Caption = new Caption()
//            {
//                FontFamily = new[] { "Montserrat", "Helvetica", "Arial", "Roboto", "Verdana", "sans-serif" },
//                FontSize = ".75rem",
//                FontWeight = 400,
//                LineHeight = 1.66,
//                LetterSpacing = ".03333em"
//            },
//            Subtitle2 = new Subtitle2()
//            {
//                FontFamily = new[] { "Montserrat", "Helvetica", "Arial", "Roboto", "Verdana", "sans-serif" },
//                FontSize = ".875rem",
//                FontWeight = 500,
//                LineHeight = 1.57,
//                LetterSpacing = ".00714em"
//            }
//        };
//        Shadows = new Shadow();
//        ZIndex = new ZIndex();
//    }
//}

public class PandoraAdminDashboard : MudTheme
{
    public PandoraAdminDashboard()
    {

        SetTypography("Montserrat"); // Set default font

        // Light Mode Palette
        PaletteLight = new PaletteLight()
        {
            Primary = Colors.Orange.Darken1,
            Secondary = Colors.Lime.Darken1,
            Tertiary = Colors.Yellow.Darken2,
            Background = Colors.Gray.Lighten4,
            AppbarBackground = Colors.Orange.Lighten5,
            DrawerBackground = Colors.Gray.Lighten5,
            DrawerText = "rgba(0,0,0, 0.7)",
            AppbarText = Colors.Shades.Black,
            Surface = Colors.Gray.Lighten4,
            Success = Colors.Green.Accent3,
            Info = Colors.Teal.Accent3,
            Warning = Colors.Yellow.Darken3,
            Error = Colors.Red.Darken2
        };

        // Dark Mode Palette
        PaletteDark = new PaletteDark()
        {
            Primary = Colors.Orange.Lighten2,
            Secondary = Colors.Lime.Lighten2,
            Tertiary = Colors.Yellow.Accent2,
            Background = Colors.Gray.Darken4,
            AppbarBackground = Colors.Orange.Darken1,
            DrawerBackground = Colors.Gray.Darken4,
            DrawerText = "rgba(255,255,255, 0.8)",
            Surface = Colors.Gray.Darken3,
            Success = Colors.Green.Lighten3,
            Info = Colors.Teal.Lighten2,
            Warning = Colors.Yellow.Accent3,
            Error = Colors.Red.Lighten1
        };

        LayoutProperties = new LayoutProperties()
        {
            DefaultBorderRadius = "6px",
            DrawerWidthLeft = "250px",
            DrawerWidthRight = "300px"
        };

        // Typography settings to match the mystical feel of Pandora
        Typography = new Typography()
        {
            Default = new Default()
            {
                FontFamily = new[] { "Roboto", "Montserrat", "Arial" },
                FontSize = "1rem",
                FontWeight = 400,
                LineHeight = 1.5,
                LetterSpacing = "0.009em"
            },
            H1 = new H1()
            {
                FontFamily = new[] { "Montserrat", "Georgia" },
                FontSize = "4rem",
                FontWeight = 300,
                LineHeight = 1.2,
                LetterSpacing = "-.015em"
            },
            // Add further typography settings for other elements like H2, H3, Button, Body, etc.
        };

        Shadows = new Shadow();
        ZIndex = new ZIndex();

    }

    public void SetTypography(string fontFamily)
    {
        Typography = new Typography()
        {
            Default = new Default()
            {
                FontFamily = new[] { fontFamily, "Arial", "sans-serif" },
                FontSize = "1rem",
                FontWeight = 400,
                LineHeight = 1.5,
                LetterSpacing = "0.009em"
            },
            H1 = new H1()
            {
                FontFamily = new[] { fontFamily, "Georgia", "serif" },
                FontSize = "4rem",
                FontWeight = 300,
                LineHeight = 1.2,
                LetterSpacing = "-.015em"
            },
            H2 = new H2()
            {
                FontFamily = new[] { fontFamily, "Georgia", "serif" },
                FontSize = "3.75rem",
                FontWeight = 300,
                LineHeight = 1.2,
                LetterSpacing = "-.00833em"
            },
            // Add more typography settings as needed
        };
    }
}