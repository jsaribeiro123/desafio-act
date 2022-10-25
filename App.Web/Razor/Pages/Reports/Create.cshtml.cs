using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Razor.Nft.Models;

namespace Razor.Nft.Pages_Reports
{
    public class CreateModel : PageModel
    {
        private readonly RazorAppNftContext _context;

        public CreateModel(RazorAppNftContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Report Report { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Report == null || Report == null)
            {
                return Page();
            }

            _context.Report.Add(Report);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
