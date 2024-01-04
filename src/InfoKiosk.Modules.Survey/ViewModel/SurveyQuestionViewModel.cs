using InfoKiosk.Modules.Survey.Models;

namespace InfoKiosk.Modules.Survey.ViewModel
{
    public class SurveyQuestionViewModel
    {
        public List<Pytanie> Pytania { get; set; }
        public Pytanie SelectedPytanie { get; set; }
        public SurveyQuestionViewModel()
        {
            using (var context = new SurveyDbContext())
            {
                Pytania = new List<Pytanie>(context.Pytania.ToList().Where(x => x.IdAnkiety == 1));

            }
        }
    }
}
