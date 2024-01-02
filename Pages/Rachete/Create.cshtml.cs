using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Proiect_MDP_Web.Data;
using Proiect_MDP_Web.Models;

namespace Proiect_MDP_Web.Pages.Rachete
{
    public class CreateModel : CategorieRachetaPageModel
    {
        private readonly Proiect_MDP_Web.Data.Proiect_MDP_WebContext _context;

        public CreateModel(Proiect_MDP_Web.Data.Proiect_MDP_WebContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["MagazinID"] = new SelectList(_context.Set<Magazin>(), "ID", "DenumireMagazin");
            ViewData["FirmaID"] = new SelectList(_context.Set<Firma>(), "ID", "DenumireFirma");

            var racheta = new Racheta();
            racheta.CategoriiRacheta = new List<CategorieRacheta>();

            PopulateAssignedCategoryData(_context, racheta);

            return Page();
        }

        [BindProperty]
        public Racheta Racheta { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            var newBook = new Racheta();
            if (selectedCategories != null)
            {
                newBook.CategoriiRacheta = new List<CategorieRacheta>();
                foreach (var cat in selectedCategories)
                {
                    var catToAdd = new CategorieRacheta
                    {
                        CategorieID = int.Parse(cat)
                    };
                    newBook.CategoriiRacheta.Add(catToAdd);
                }
            }
            Racheta.CategoriiRacheta = newBook.CategoriiRacheta;
            _context.Racheta.Add(Racheta);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}
