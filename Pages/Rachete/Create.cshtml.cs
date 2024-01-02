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
    public class CreateModel : PageModel
    {
        private readonly Proiect_MDP_Web.Data.Proiect_MDP_WebContext _context;

        public CreateModel(Proiect_MDP_Web.Data.Proiect_MDP_WebContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["MagazinID"] = new SelectList(_context.Set<Magazin>(), "ID", "DenumireMagazin");
            return Page();
        }

        [BindProperty]
        public Racheta Racheta { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Racheta == null || Racheta == null)
            {
                return Page();
            }

            _context.Racheta.Add(Racheta);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
