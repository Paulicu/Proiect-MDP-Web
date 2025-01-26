using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;

namespace Proiect_MDP_Web.Models
{
    public enum TipServiciu
    {
        Cumparare,
        Inchiriere,
        Racordare
    }

    public class Serviciu
    {
        public int ID { get; set; }

        [Display(Name = "Tip Serviciu")]
        public TipServiciu TipServiciu { get; set; }
        
        [Display(Name = "Client")]
        public int? ClientID { get; set; }

        public Client? Client { get; set; } 
        
        [Display(Name = "Racheta")]
        public int? RachetaID { get; set; }

        public Racheta? Racheta { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Data Finalizarii")]
        public DateTime ReturnDate { get; set; }

        public string NumeDataSpecifica
        {
            get
            {
                switch (TipServiciu)
                {
                    case TipServiciu.Cumparare:
                        return "Data de ridicare din magazin";
                    case TipServiciu.Inchiriere:
                        return "Data de returnare";
                    case TipServiciu.Racordare:
                        return "Data finalizarii reparatiei";
                    default:
                        return "Data";
                }
            }
        }

    }
}
