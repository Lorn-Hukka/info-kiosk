using InfoKiosk.Modules.Survey.Models;
using InfoKiosk.Modules.Survey.ViewModel;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace InfoKiosk.Modules.Survey.Views
{
    /// <summary>
    /// Logika interakcji dla klasy SurveyQuestionView.xaml
    /// </summary>
    public partial class SurveyQuestionView : UserControl
    {

        public int currentIndex;
       public SurveyQuestionView()
        {
            DataContext = new SurveyQuestionViewModel();
            KeyBoardView.SelectionChanged += HandleSelectionChanged;
            InitializeComponent();
            ListBoxPytanie.SelectionChanged += ListBoxPytanie_SelectionChanged;

        }

        private void HandleSelectionChanged(string type)
        {
            if (ListBoxPytanie.IsVisible)
            {
                if (type == "Next" && ListBoxPytanie.SelectedIndex < ListBoxPytanie.Items.Count)
                {
                    currentIndex = ListBoxPytanie.SelectedIndex;
                    ListBoxPytanie.SelectedIndex = currentIndex + 1;
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
        }
        private void ListBoxPytanie_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            var viewModel = (SurveyQuestionViewModel)DataContext;
            viewModel.SelectedPytanie = ListBoxPytanie.SelectedItem as Pytanie;
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
