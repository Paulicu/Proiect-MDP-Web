using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_MDP_Web.Data;
using Proiect_MDP_Web.Models;
using Proiect_MDP_Web.Models.ViewModels;

namespace Proiect_MDP_Web.Pages.Categorii
{
    public class IndexModel : PageModel
    {
        private readonly Proiect_MDP_Web.Data.Proiect_MDP_WebContext _context;

        public IndexModel(Proiect_MDP_Web.Data.Proiect_MDP_WebContext context)
        {
            _context = context;
        }

        public IList<Categorie> Categorie { get;set; } = default!;
        public CategorieIndexData CategorieData { get; set; }
        public int CategorieID { get; set; }
        public int RachetaID { get; set; }
        public async Task OnGetAsync(int? id, int? rachetaID)
        {
            CategorieData = new CategorieIndexData();
            CategorieData.Categorii = await _context.Categorie
                .Include(i => i.CategoriiRacheta)
                    .ThenInclude(i => i.Racheta)
                    .ThenInclude(c => c.Firma)
                .OrderBy(i => i.DenumireCategorie)
                .ToListAsync();

            if (id != null)
            {
                CategorieID = id.Value;
                Categorie category = CategorieData.Categorii
                    .Where(i => i.ID == id.Value).Single();
                CategorieData.CategoriiRacheta = category.CategoriiRacheta;
            }
        }
    }
}
