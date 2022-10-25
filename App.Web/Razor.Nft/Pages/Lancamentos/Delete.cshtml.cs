using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Razor.Nft.Models;

namespace Razor.Nft.Pages_Lancamentos
{
    public class DeleteModel : PageModel
    {
        private readonly RazorAppNftContext _context;

        public DeleteModel(RazorAppNftContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Lancamento Lancamento { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Lancamento == null)
            {
                return NotFound();
            }

            var lancamento = await _context.Lancamento.FirstOrDefaultAsync(m => m.ID == id);

            if (lancamento == null)
            {
                return NotFound();
            }
            else 
            {
                Lancamento = lancamento;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Lancamento == null)
            {
                return NotFound();
            }
            var lancamento = await _context.Lancamento.FindAsync(id);

            if (lancamento != null)
            {
                Lancamento = lancamento;
                _context.Lancamento.Remove(Lancamento);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
