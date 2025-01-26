using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proiect_MDP_Web.Data;
using Proiect_MDP_Web.Models;

namespace Proiect_MDP_Web.Pages.Servicii
{
    public class CreateModel : PageModel
    {
        private readonly Proiect_MDP_Web.Data.Proiect_MDP_WebContext _context;

        public CreateModel(Proiect_MDP_Web.Data.Proiect_MDP_WebContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            var rachetaList = _context.Racheta
                .Include(b => b.Firma)
                .Select(x => new
                {
                    x.ID,
                    RachetaFullName = x.Denumire + " - " + x.Firma.DenumireFirma
                });
            ViewData["ClientID"] = new SelectList(_context.Client, "ID", "NumeComplet");
            ViewData["RachetaID"] = new SelectList(rachetaList, "ID", "RachetaFullName");
            return Page();
        }

        [BindProperty]
        public Serviciu Serviciu { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Serviciu == null || Serviciu == null)
            {
                return Page();
            }

            _context.Serviciu.Add(Serviciu);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
