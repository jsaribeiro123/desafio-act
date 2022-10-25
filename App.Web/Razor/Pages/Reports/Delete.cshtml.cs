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
    public class DeleteModel : PageModel
    {
        private readonly RazorAppNftContext _context;

        public DeleteModel(RazorAppNftContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Report Report { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Report == null)
            {
                return NotFound();
            }

            var report = await _context.Report.FirstOrDefaultAsync(m => m.ID == id);

            if (report == null)
            {
                return NotFound();
            }
            else 
            {
                Report = report;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Report == null)
            {
                return NotFound();
            }
            var report = await _context.Report.FindAsync(id);

            if (report != null)
            {
                Report = report;
                _context.Report.Remove(Report);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
