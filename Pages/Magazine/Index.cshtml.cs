using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_MDP_Web.Data;
using Proiect_MDP_Web.Models;
using Proiect_MDP_Web.ViewModels;

namespace Proiect_MDP_Web.Pages.Magazine
{
    public class IndexModel : PageModel
    {
        private readonly Proiect_MDP_Web.Data.Proiect_MDP_WebContext _context;

        public IndexModel(Proiect_MDP_Web.Data.Proiect_MDP_WebContext context)
        {
            _context = context;
        }

        public IList<Magazin> Magazin { get;set; } = default!;

        public MagazinIndexData MagazinData { get; set; }
        public int MagazinID { get; set; }
        public int RachetaID { get; set; }

        public async Task OnGetAsync(int? id, int? RachetaID)
        {
            MagazinData = new MagazinIndexData();
            MagazinData.Magazine = await _context.Magazin
            .Include(i => i.Rachete)
            .ThenInclude(c => c.Firma)
            .OrderBy(i => i.DenumireMagazin)
            .ToListAsync();

            if (id != null)
            {
                //Magazin = await _context.Magazin.ToListAsync();
                MagazinID = id.Value;
                Magazin magazin = MagazinData.Magazine
                .Where(i => i.ID == id.Value).Single();
                MagazinData.Rachete = magazin.Rachete;
            }
        }
    }
}
