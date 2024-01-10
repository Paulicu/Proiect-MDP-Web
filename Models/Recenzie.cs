using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;

namespace Proiect_MDP_Web.Models
{
    public class Recenzie
    {
        public int ID { get; set; }

        public string Titlu { get; set; }

        public string Comentariu { get; set; }

        public int Rating { get; set; }

        [Display(Name = "Client")]
        public int? ClientID { get; set; }
        public Client? Client { get; set; }

        [Display(Name = "Racheta")]
        public int? RachetaID { get; set; }
        public Racheta? Racheta { get; set; }
    }
}
