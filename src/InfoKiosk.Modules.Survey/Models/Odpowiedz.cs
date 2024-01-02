using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace InfoKiosk.Modules.Survey.Models
{
    public class Odpowiedz
    {
        [Key]
        public int IdOdpowiedzi { get; set;}

        public string TresćOdpowiedzi { get; set;}

        public int IdPytania { get; set;}
        public Pytanie Pytanie { get; set;}


    }
}
