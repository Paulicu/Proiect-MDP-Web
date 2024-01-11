using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proiect_MDP_Web.Data;
using Proiect_MDP_Web.Models;

namespace Proiect_MDP_Web.Pages.Rachete
{
    [Authorize(Roles = "Admin")]
    public class EditModel : CategorieRachetaPageModel
    {
        private readonly Proiect_MDP_Web.Data.Proiect_MDP_WebContext _context;

        public EditModel(Proiect_MDP_Web.Data.Proiect_MDP_WebContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Racheta Racheta { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Racheta == null)
            {
                return NotFound();
            }

            Racheta =  await _context.Racheta
                .Include(b => b.Magazin)
                .Include(b => b.Firma)
                .Include(b => b.CategoriiRacheta).ThenInclude(b => b.Categorie)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Racheta == null)
            {
                return NotFound();
            }

            PopulateAssignedCategoryData(_context, Racheta);
            ViewData["MagazinID"] = new SelectList(_context.Set<Magazin>(), "ID", "DenumireMagazin");
            ViewData["FirmaID"] = new SelectList(_context.Set<Firma>(), "ID", "DenumireFirma");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedCategories)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rachetaDeUpdatat = await _context.Racheta
            .Include(i => i.Magazin)
            .Include(i => i.Firma)
            .Include(i => i.CategoriiRacheta)
            .ThenInclude(i => i.Categorie)
            .FirstOrDefaultAsync(s => s.ID == id);

            if (rachetaDeUpdatat == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Racheta>(
            rachetaDeUpdatat,
            "Racheta",
            i => i.Denumire, i => i.Material, i => i.Tehnologie, i => i.Greutate, i => i.DimensiuneCap, i => i.Firma, i => i.FirmaID,
            i => i.Pret, i => i.Editie, i => i.MagazinID))
            {
                UpdateRachetaCategories(_context, selectedCategories, rachetaDeUpdatat);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
       
            UpdateRachetaCategories(_context, selectedCategories, rachetaDeUpdatat);
            PopulateAssignedCategoryData(_context, rachetaDeUpdatat);
            return Page();
        }

        private bool RachetaExists(int id)
        {
          return (_context.Racheta?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
