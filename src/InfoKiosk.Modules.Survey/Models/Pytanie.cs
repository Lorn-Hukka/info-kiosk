using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoKiosk.Modules.Survey.Models
{
    public class Pytanie
    {
        [Key]
        public int IdPytania {get; set;}
        public string TrescPytania {get; set;}

        public string TypPytania {get; set;}

        public ICollection<Odpowiedz> Odpowiedzi {get; set;} 

        public int IdAnkiety { get; set;}
        public Ankieta Ankieta { get; set;}



    }
}
