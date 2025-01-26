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

namespace Proiect_MDP_Web.Pages.Recenzii
{
    public class EditModel : PageModel
    {
        private readonly Proiect_MDP_Web.Data.Proiect_MDP_WebContext _context;

        public EditModel(Proiect_MDP_Web.Data.Proiect_MDP_WebContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Recenzie Recenzie { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Recenzie == null)
            {
                return NotFound();
            }

            var recenzie =  await _context.Recenzie.FirstOrDefaultAsync(m => m.ID == id);
            if (recenzie == null)
            {
                return NotFound();
            }
            Recenzie = recenzie;
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Recenzie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecenzieExists(Recenzie.ID))
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

        private bool RecenzieExists(int id)
        {
          return (_context.Recenzie?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
