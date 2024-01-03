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
            InitializeComponent();
        }
    }
}
