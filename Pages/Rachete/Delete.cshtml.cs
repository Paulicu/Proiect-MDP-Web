using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_MDP_Web.Data;
using Proiect_MDP_Web.Models;

namespace Proiect_MDP_Web.Pages.Rachete
{
    public class DeleteModel : PageModel
    {
        private readonly Proiect_MDP_Web.Data.Proiect_MDP_WebContext _context;

        public DeleteModel(Proiect_MDP_Web.Data.Proiect_MDP_WebContext context)
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

            var racheta = await _context.Racheta
                .Include(b => b.Magazin)
                .FirstOrDefaultAsync(m => m.ID == id);

            if (racheta == null)
            {
                return NotFound();
            }
            else 
            {
                Racheta = racheta;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Racheta == null)
            {
                return NotFound();
            }
            var racheta = await _context.Racheta.FindAsync(id);

            if (racheta != null)
            {
                Racheta = racheta;
                _context.Racheta.Remove(Racheta);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
