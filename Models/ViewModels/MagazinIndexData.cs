using Proiect_MDP_Web.Models;
using System.Security.Policy;

namespace Proiect_MDP_Web.ViewModels
{
    public class MagazinIndexData
    {
        public IEnumerable<Magazin> Magazine { get; set; }
        public IEnumerable<Racheta> Rachete { get; set; }
    }
}
