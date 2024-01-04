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
            DataContext = new SurveyQuestionViewModel();
            KeyBoardView.SelectionChanged += HandleSelectionChanged;
            InitializeComponent();
            ListBoxAnkieta.SelectionChanged += ListBoxAnkieta_SelectionChanged;

        }

        private void HandleSelectionChanged(int selectedIndex)
        {         
            // Obsługa zmiany zaznaczenia
            ListBoxAnkieta.SelectedIndex = selectedIndex;
        }
        private void ListBoxAnkieta_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Dodaj kod obsługujący zmianę zaznaczenia na liście
            var viewModel = (SurveyQuestionViewModel)DataContext;
            viewModel.SelectedPytanie = ListBoxAnkieta.SelectedItem as Pytanie;
        }

        private void ListBoxAnkieta_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            ListBoxAnkieta.SelectedIndex = 0;
        }
    }
}
