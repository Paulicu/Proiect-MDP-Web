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
        public TipServiciu TipServiciu { get; set; }
        public int? ClientID { get; set; }
        public Client? Client { get; set; }
        public int? RachetaID { get; set; }
        public Racheta? Racheta { get; set; }

        [DataType(DataType.Date)]
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
