using System;
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
    public class IndexModel : PageModel
    {
        private readonly Proiect_MDP_Web.Data.Proiect_MDP_WebContext _context;

        public IndexModel(Proiect_MDP_Web.Data.Proiect_MDP_WebContext context)
        {
            _context = context;
        }

        public IList<Serviciu> Serviciu { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Serviciu != null)
            {
                Serviciu = await _context.Serviciu
                .Include(s => s.Client)
                .Include(s => s.Racheta)
                    .ThenInclude(s => s.Firma)
                .ToListAsync();
            }
        }
    }
}
