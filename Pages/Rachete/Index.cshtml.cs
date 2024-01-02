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
    public class IndexModel : PageModel
    {
        private readonly Proiect_MDP_Web.Data.Proiect_MDP_WebContext _context;

        public IndexModel(Proiect_MDP_Web.Data.Proiect_MDP_WebContext context)
        {
            _context = context;
        }

        public IList<Racheta> Racheta { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Racheta != null)
            {
                Racheta = await _context.Racheta
                    .Include(b => b.Magazin)
                    .ToListAsync();
            }
        }
    }
}
