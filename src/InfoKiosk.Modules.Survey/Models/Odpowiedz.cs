using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InfoKiosk.Modules.Survey.Models
{
   
    public class Odpowiedz
    {
        [Key]
        public int IdOdpowiedzi { get; set;}

        public string TrescOdpowiedzi { get; set;}
        public DateTime CreationTime { get; set; }

        public int IdPytania { get; set;}
        public Pytanie Pytanie { get; set;}


    }
}
