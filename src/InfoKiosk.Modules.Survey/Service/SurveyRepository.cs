using InfoKiosk.Modules.Survey.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoKiosk.Modules.Survey.Service
{
    internal class SurveyRepository
    {
        public SurveyDbContext _Context;

        public SurveyRepository(SurveyDbContext context)
        {
            _Context = context;
        }

        public List<Ankieta> GetAllSurveys()
        {
            return _Context.Ankiety.ToList ();
        }

    }
}
