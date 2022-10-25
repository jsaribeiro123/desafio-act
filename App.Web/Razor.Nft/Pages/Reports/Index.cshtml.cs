using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Razor.Nft.Models;

namespace Razor.Nft.Pages_Reports
{
    public class IndexModel : PageModel
    {
        private readonly RazorAppNftContext _context;

        public IndexModel(RazorAppNftContext context)
        {
            _context = context;
        }

        public IList<Report> Report { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Report != null)
            {
                Report = await _context.Report.ToListAsync();
            }
        }
    }
}
