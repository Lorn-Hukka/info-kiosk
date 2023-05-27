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

namespace InfoKiosk.Modules.Home.Views
{
    /// <summary>
    /// Interaction logic for HomeView.xaml
    /// </summary>
    public partial class HomeView : UserControl
    {
        public HomeView()
        {
            string link = "https://lh3.googleusercontent.com/pw/AJFCJaVVKAyPiHSxpDXbMbKNunwcvhKKJaAt1tiL_scYC_oG9dU_UEqUVYpbC4XlWkQbwKei9NhHE10BNqT39SuN9_1tzNqvJduViW3b6ZKA6_SDNsUOGmMfl_bYKVsiYVNolTnzLUYVHCp88N4_azjZmQ5h=w1740-h979-s-no?authuser=0";

            InitializeComponent();

            //Image image = new Image();
            //BitmapImage bitmap = new BitmapImage(new Uri(link, UriKind.Absolute));
            //image.Source = bitmap;


            //Main.Background = new SolidColorBrush(Colors.Black);
            //Main.Children.Add(image);

            LinearGradientBrush linearGradientBrush = new LinearGradientBrush(
                            Color.FromArgb(204, 0, 0, 0),
                            Color.FromArgb(204, 0, 0, 0),
                            new System.Windows.Point(0.5, 0),
                            new System.Windows.Point(0.5, 1));
            Main.Background = linearGradientBrush;

            // Dodanie tła obrazka do Grid
            ImageBrush imageBrush = new ImageBrush();
            imageBrush.ImageSource = new BitmapImage(new Uri("https://lorned.net/bg.jpg", UriKind.Absolute));
            imageBrush.TileMode = TileMode.None;
            imageBrush.Stretch = Stretch.UniformToFill;
            Main.Children.Add(new Rectangle { Fill = imageBrush });

            // Dodanie gradientu promieniowego do Grid
            RadialGradientBrush radialGradientBrush = new RadialGradientBrush(
                Colors.Transparent,
                Color.FromArgb(255, 255, 255, 255));
            radialGradientBrush.GradientStops.Add(new GradientStop(Colors.Transparent, 0));
            radialGradientBrush.GradientStops.Add(new GradientStop(Color.FromArgb(255, 255, 255, 255), 0.8));
            radialGradientBrush.Center = new System.Windows.Point(0.4, 0.5);
            radialGradientBrush.RadiusX = radialGradientBrush.RadiusY = 0.5;
            Main.Children.Add(new Rectangle { Fill = radialGradientBrush });

            this.Content = Main;
        }
    }
}
