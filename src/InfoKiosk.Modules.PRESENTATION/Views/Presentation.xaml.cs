using InfoKiosk.Modules.PRESENTATION.ViewModels;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace InfoKiosk.Modules.PRESENTATION.Views
{
    /// <summary>
    /// Logika interakcji dla klasy Presentation.xaml
    /// </summary>
    
    public partial class Presentation : UserControl
    {
        private List<Thickness> positions = new();
        private List<Media> media = new();
        private int animationLength = 0;
        private int currentIndex = 0;
        private DispatcherTimer timer = new()
        {
            Interval = TimeSpan.FromSeconds(3),
        };

        public static object Tick { get; private set; }
        public Presentation()
        {
            InitializeComponent();

            //linki do zdjęć
            List<string> mediaUri = new List<string>
            {
                @"C:\Users\matro\Documents\DES\info-kiosk\src\InfoKiosk.Modules.PRESENTATION\media\pic1.jpg",
                @"C:\Users\matro\Documents\DES\info-kiosk\src\InfoKiosk.Modules.PRESENTATION\media\pic2.jpg",
                @"C:\Users\matro\Documents\DES\info-kiosk\src\InfoKiosk.Modules.PRESENTATION\media\pic3.jpg",
                @"C:\Users\matro\Documents\DES\info-kiosk\src\InfoKiosk.Modules.PRESENTATION\media\vid4.mp4"
            };

            InitializePresentation(mediaUri);

            //długość animacji przejścia
            animationLength = 1;
        }

        private void InitializePresentation(List<string> mediaUri)
        {
            //deklaracja możliwych położeń slajdów (poprzedni > aktualny > następny)
            positions.Add(new Thickness(-800, 0, 800, 0));
            positions.Add(new Thickness(0, 0, 0, 0));
            positions.Add(new Thickness(800, 0, -800, 0));

            //dodanie funkcji do przycisków
            previousButton.Click += PreviousButton_Click;
            nextButton.Click += NextButton_Click;

            //załadowanie linków do obiektu Media
            for (int i = 0; i < mediaUri.Count; i++)
            {
                media.Add(new Media(mediaUri[i], mediaUri.Count, i));
            }

            //przygotowanie slajdów i kontrolek
            foreach (Media mediaFile in media)
            {
                MediaElement mediaElement = new()
                {
                    Source = mediaFile.currMediaUri,
                    Stretch = Stretch.Fill,
                    Margin = positions[2]
                };
                grid.Children.Add(mediaElement);

                Ellipse ellipse = new()
                {
                    Width = 10,
                    Height = 10,
                    Fill = Brushes.Gray,
                    Margin = new Thickness(10, 10, 10, 10)
                };
                fileIndicatorsPanel.Children.Add(ellipse);
            }

            //wyświetlenie pierwszego slajdu
            for (int i = 0; i < media.Count; i++)
            {
                MoveMedia(false);
            }

            //uruchomienie licznika
            timer.Interval = TimeSpan.FromSeconds(3);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void PreviousButton_Click(object sender, RoutedEventArgs e)
        {
            SuspendTimer();
            MoveMedia(true);
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            SuspendTimer();
            MoveMedia(false);
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            MoveMedia(false);
        }

        private void SuspendTimer()
        {
            if (timer.IsEnabled)
            {
                timer.Stop();

                Task.Delay(TimeSpan.FromSeconds(6)).ContinueWith(_ =>
                {
                    timer.Start();
                });
            }
        }
        private void MoveMedia(bool direction)
        {
            //deklaracja zmiennych
            MediaElement mediaElement;
            Thickness position;

            //ustawienie zmiennych w zależności od kierunku
            Thickness upcomingPosition = positions[direction ? 0 : 2];
            Thickness afterwardPosition = positions[!direction ? 0 : 2];
            Thickness currentPosition = positions[1];

            //przygotowanie położenia slajdów
            for (int i = 0; i < media.Count; i++)
            {
                mediaElement = (MediaElement)grid.Children[i];
                position = (i == currentIndex) ? currentPosition : upcomingPosition;
                Animate(mediaElement, position, 0);
            }

            //ukrycie slajdu
            mediaElement = (MediaElement)grid.Children[currentIndex];
            position = afterwardPosition;
            Animate(mediaElement, position, animationLength);

            //zmiana indeksu
            currentIndex = direction ?
                media[currentIndex].prevMediaIndex :
                media[currentIndex].nextMediaIndex;

            //pokazanie slajdu
            mediaElement = (MediaElement)grid.Children[currentIndex];
            mediaElement.Position = TimeSpan.Zero;
            position = currentPosition;
            Animate(mediaElement, position, animationLength);

            //aktualizacja kontrolki
            UpdateMediaIndicators();
        }

        private void Animate(MediaElement mediaElement, Thickness position, int duration)
        {
            ThicknessAnimation animation = new()
            {
                Duration = TimeSpan.FromSeconds(duration),
                To = position
            };
            mediaElement.BeginAnimation(MarginProperty, animation);
        }

        private void UpdateMediaIndicators()
        {
            for (int i = 0; i < media.Count; i++)
            {
                Ellipse ellipse = (Ellipse)fileIndicatorsPanel.Children[i];
                ellipse.Fill = (i == currentIndex) ? Brushes.DarkCyan : Brushes.Gray;
            }
        }
    }
}
