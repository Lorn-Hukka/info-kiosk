using InfoKiosk.Modules.Survey.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoKiosk.Modules.Survey.ViewModel
{
    public class SurveyQuestionViewModel
    {
        public List<Pytanie> Pytania { get; set; }

        public SurveyQuestionViewModel()
        {
            using (var context = new SurveyDbContext())
            {
                Pytania = new List<Pytanie>(context.Pytania.ToList().Where(x => x.IdAnkiety == 1));

            }
        }
    }
}
