﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_MDP_Web.Data;
using Proiect_MDP_Web.Models;

namespace Proiect_MDP_Web.Pages.Firme
{
    public class DetailsModel : PageModel
    {
        private readonly Proiect_MDP_Web.Data.Proiect_MDP_WebContext _context;

        public DetailsModel(Proiect_MDP_Web.Data.Proiect_MDP_WebContext context)
        {
            _context = context;
        }

      public Firma Firma { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Firma == null)
            {
                return NotFound();
            }

            var firma = await _context.Firma.FirstOrDefaultAsync(m => m.ID == id);
            if (firma == null)
            {
                return NotFound();
            }
            else 
            {
                Firma = firma;
            }
            return Page();
        }
    }
}
