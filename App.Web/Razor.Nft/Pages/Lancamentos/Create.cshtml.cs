using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Razor.Nft.Models;

namespace Razor.Nft.Pages_Lancamentos
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
        public Lancamento Lancamento { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Lancamento == null || Lancamento == null)
            {
                return Page();
            }

            _context.Lancamento.Add(Lancamento);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
