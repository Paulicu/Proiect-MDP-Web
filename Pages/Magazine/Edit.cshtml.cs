using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proiect_MDP_Web.Data;
using Proiect_MDP_Web.Models;

namespace Proiect_MDP_Web.Pages.Magazine
{
    [Authorize(Roles = "Admin")]
    public class EditModel : PageModel
    {
        private readonly Proiect_MDP_Web.Data.Proiect_MDP_WebContext _context;

        public EditModel(Proiect_MDP_Web.Data.Proiect_MDP_WebContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Magazin Magazin { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Magazin == null)
            {
                return NotFound();
            }

            var magazin =  await _context.Magazin.FirstOrDefaultAsync(m => m.ID == id);
            if (magazin == null)
            {
                return NotFound();
            }
            Magazin = magazin;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Magazin).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MagazinExists(Magazin.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool MagazinExists(int id)
        {
          return (_context.Magazin?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
