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
       
       public SurveyQuestionView()
        {
            DataContext = new SurveyQuestionViewModel(1);
            KeyBoardView.SelectionChanged += HandleSelectionChanged;
            InitializeComponent();
            ListBoxPytanie.SelectionChanged += ListBoxPytanie_SelectionChanged;

        }

        private void HandleSelectionChanged(int selectedIndex)
        {         
            // Obsługa zmiany zaznaczenia
            ListBoxPytanie.SelectedIndex = selectedIndex;
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
