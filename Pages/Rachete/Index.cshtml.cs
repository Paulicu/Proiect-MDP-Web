using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_MDP_Web.Data;
using Proiect_MDP_Web.Models;

namespace Proiect_MDP_Web.Pages.Rachete
{
    public class IndexModel : PageModel
    {
        private readonly Proiect_MDP_Web.Data.Proiect_MDP_WebContext _context;

        public IndexModel(Proiect_MDP_Web.Data.Proiect_MDP_WebContext context)
        {
            _context = context;
        }

        public IList<Racheta> Racheta { get; set; } = default!;
        public IList<Firma> Firme { get; set; } = default!;

        public RachetaData RachetaD { get; set; }
        public int RachetaID { get; set; }
        public int CategorieID { get; set; }

        public string DenumireSort { get; set; }
        public string FirmaSort { get; set; }

        public string CurrentFilter { get; set; }

        public async Task OnGetAsync(int? id, int? categorieID, string sortOrder, string searchString)
        {
            RachetaD = new RachetaData();

            DenumireSort = String.IsNullOrEmpty(sortOrder) ? "denumire_desc" : "";
            FirmaSort = sortOrder == "firma" ? "firma_desc" : "firma";

            CurrentFilter = searchString;

            RachetaD.Rachete = await _context.Racheta
                    .Include(b => b.Magazin)
                    .Include(b => b.Firma)
                    .Include(b => b.CategoriiRacheta)
                    .ThenInclude(b => b.Categorie)
                    .AsNoTracking()
                    .OrderBy(b => b.Denumire)
                    .ToListAsync();

            if (!String.IsNullOrEmpty(searchString))
            {
                RachetaD.Rachete = RachetaD.Rachete.Where(s => s.Firma.DenumireFirma.Contains(searchString)
               || s.Firma.DenumireFirma.Contains(searchString)
               || s.Denumire.Contains(searchString));
            }

            if (id != null)
            {
                RachetaID = id.Value;
                Racheta racheta = RachetaD.Rachete
                .Where(i => i.ID == id.Value).Single();
                RachetaD.Categorii = racheta.CategoriiRacheta.Select(s => s.Categorie);
            }

            switch (sortOrder)
            {
                case "denumire_desc":
                    RachetaD.Rachete = RachetaD.Rachete.OrderByDescending(s =>
                   s.Denumire);
                    break;
                case "firma_desc":
                    RachetaD.Rachete = RachetaD.Rachete.OrderByDescending(s =>
                   s.Firma.DenumireFirma);
                    break;
                case "firma":
                    RachetaD.Rachete = RachetaD.Rachete.OrderBy(s =>
                   s.Firma.DenumireFirma);
                    break;
                default:
                    RachetaD.Rachete = RachetaD.Rachete.OrderBy(s => s.Denumire);
                    break;
            }
        }
    }
}