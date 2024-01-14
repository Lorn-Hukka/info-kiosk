using DryIoc;
using InfoKiosk.Modules.Survey.Models;
using InfoKiosk.Modules.Survey.ViewModel;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows;
using static InfoKiosk.Modules.Survey.Views.SurveyQuestionView;

namespace InfoKiosk.Modules.Survey.Views
{
    /// <summary>
    /// Logika interakcji dla klasy SurveyQuestionView.xaml
    /// </summary>
    public partial class SurveyQuestionView : UserControl
    {
        public List<Pytanie> Pytania { get; set; }
        public List<Ankieta> Ankiety { get; set; }
        private SurveyDbContext _surveyDbContext { get; set; }

        public int currentIndex;
        public int currentQuestionId;

        public delegate void IdproviderEventHandler(int idSurvey);
        public static event IdproviderEventHandler idSurveyProvider;

        public delegate void CurrentQuestionEventHandler(int currentQuestion);
        public static event CurrentQuestionEventHandler CurrentQuestion;

        public SurveyQuestionView(SurveyDbContext surveyDbContext)
        {
            _surveyDbContext = surveyDbContext;
            Ankiety = new List<Ankieta>(_surveyDbContext.Ankiety.ToList());
            KeyBoardView.SelectionChanged += HandleSelectionChanged;
            
            InitializeComponent();

            ListBoxAnkieta.ItemsSource = Ankiety;
            ListBoxAnkieta.SelectedIndex = 0;
            
            ListBoxAnkieta.Visibility = Visibility.Visible;
            ListBoxPytanie.Visibility = Visibility.Hidden;
            End_Label.Visibility = Visibility.Hidden;
        }

        private void HandleSelectionChanged(string type)
        {
            if (ListBoxPytanie.IsVisible)
            {
                if (type == "Next" && ListBoxPytanie.SelectedIndex < ListBoxPytanie.Items.Count)
                {
                    currentIndex = ListBoxPytanie.SelectedIndex;
                    ListBoxPytanie.SelectedIndex = currentIndex + 1;

                    Pytanie currentPytanie = ListBoxPytanie.SelectedItem as Pytanie;
                    currentQuestionId = currentPytanie.IdPytania;
                    idSurveyProvider.Invoke(currentQuestionId);
                    CurrentQuestion.Invoke(currentIndex + 2);

                }
                else if(type == "Previous" && ListBoxPytanie.SelectedIndex > 0)
                {
                    currentIndex = ListBoxPytanie.SelectedIndex;
                    ListBoxPytanie.SelectedIndex = currentIndex - 1;
                }

            }
            if (ListBoxAnkieta.IsVisible) 
            {
                if (type == "Next" && ListBoxAnkieta.SelectedIndex < ListBoxAnkieta.Items.Count)
                {
                    currentIndex = ListBoxAnkieta.SelectedIndex;
                    ListBoxAnkieta.SelectedIndex = currentIndex + 1;

                }
                else if (type == "Previous" && ListBoxAnkieta.SelectedIndex > 0)
                {
                    currentIndex = ListBoxAnkieta.SelectedIndex;
                    ListBoxAnkieta.SelectedIndex = currentIndex - 1;
                }
            }
            if (type == "Select")
            {
                if (ListBoxAnkieta.IsVisible)
                {
                    currentIndex = ListBoxAnkieta.SelectedIndex + 1;
                    Pytania = new List<Pytanie>(_surveyDbContext.Pytania.Where(x => x.IdAnkiety == currentIndex ));
                    ListBoxPytanie.ItemsSource = Pytania;

                    ListBoxAnkieta.Visibility = Visibility.Hidden;
                    ListBoxPytanie.Visibility = Visibility.Visible
                        ;
                    ListBoxPytanie.SelectedIndex = 0;

                    Pytanie currentPytanie = ListBoxPytanie.SelectedItem as Pytanie;
                    currentQuestionId = currentPytanie.IdPytania;

                    idSurveyProvider.Invoke(currentQuestionId);

                }
            }
            else if (type == "Last")
            {
                ListBoxAnkieta.ItemsSource = Ankiety;
                ListBoxAnkieta.Visibility = Visibility.Hidden;
                ListBoxPytanie.Visibility = Visibility.Hidden;
                End_Label.Visibility = Visibility.Visible;
                if (End_Label.IsVisible)
                {
                    TimerAsync();
                }
                idSurveyProvider.Invoke(0);
            }
        }
        private async void TimerAsync()
        {
            await Task.Delay(5000);
            End_Label.Visibility = Visibility.Hidden;
            ListBoxAnkieta.Visibility = Visibility.Visible;
        }

        private void ListBoxPytanie_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            ListBoxPytanie.SelectedIndex = 0;
        }

        private void ListBoxAnkieta_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            ListBoxAnkieta.SelectedIndex = 0;
        }
    }
}
