using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_MDP_Web.Data;
using Proiect_MDP_Web.Models;

namespace Proiect_MDP_Web.Pages.Recenzii
{
    public class DetailsModel : PageModel
    {
        private readonly Proiect_MDP_Web.Data.Proiect_MDP_WebContext _context;

        public DetailsModel(Proiect_MDP_Web.Data.Proiect_MDP_WebContext context)
        {
            _context = context;
        }

      public Recenzie Recenzie { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Recenzie == null)
            {
                return NotFound();
            }

            var recenzie = await _context.Recenzie
                .Include(s => s.Client)
                .Include(s => s.Racheta)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (recenzie == null)
            {
                return NotFound();
            }
            else 
            {
                Recenzie = recenzie;
            }
            return Page();
        }
    }
}
