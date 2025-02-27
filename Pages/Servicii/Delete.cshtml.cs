﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_MDP_Web.Data;
using Proiect_MDP_Web.Models;

namespace Proiect_MDP_Web.Pages.Servicii
{
    public class DeleteModel : PageModel
    {
        private readonly Proiect_MDP_Web.Data.Proiect_MDP_WebContext _context;

        public DeleteModel(Proiect_MDP_Web.Data.Proiect_MDP_WebContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Serviciu Serviciu { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Serviciu == null)
            {
                return NotFound();
            }

            var serviciu = await _context.Serviciu
                .Include(s => s.Client)
                .Include(s => s.Racheta)
                .FirstOrDefaultAsync(m => m.ID == id);

            if (serviciu == null)
            {
                return NotFound();
            }
            else 
            {
                Serviciu = serviciu;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Serviciu == null)
            {
                return NotFound();
            }
            var serviciu = await _context.Serviciu.FindAsync(id);

            if (serviciu != null)
            {
                Serviciu = serviciu;
                _context.Serviciu.Remove(Serviciu);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
