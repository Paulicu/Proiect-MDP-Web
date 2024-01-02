using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Policy;

namespace Proiect_MDP_Web.Models
{
    public class Racheta
    {
        public int ID { get; set; }

        [Display(Name = "Nume Racheta")]
        public string Denumire { get; set; }

        public string Material { get; set; }

        public string Tehnologie { get; set; }

        public int Greutate { get; set; }

        public int DimensiuneCap { get; set; }

        [Column(TypeName = "decimal(6, 2)")]
        public decimal Pret {  get; set; }

        [DataType(DataType.Date)]
        public DateTime Editie { get; set; }

        public int? MagazinID { get; set; }
        public Magazin? Magazin { get; set; } // navigation property

        public int? FirmaID { get; set; }
        public Firma? Firma { get; set; } // navigation property

        public ICollection<CategorieRacheta>? CategoriiRacheta { get; set; }

    }
}
