using System.ComponentModel.DataAnnotations;

namespace Proiect_MDP_Web.Models
{
    public class Firma
    {
        public int ID { get; set; }

        [Display(Name = "Nume Firma")]
        public string? DenumireFirma { get; set; }

        public string? Locatie { get; set; }
    }
}
