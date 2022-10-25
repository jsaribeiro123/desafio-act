using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Razor.Nft.Models;

namespace Razor.Nft.Pages_Lancamentos
{
    public class EditModel : PageModel
    {
        private readonly RazorAppNftContext _context;

        public EditModel(RazorAppNftContext context)
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

            var lancamento =  await _context.Lancamento.FirstOrDefaultAsync(m => m.ID == id);
            if (lancamento == null)
            {
                return NotFound();
            }
            Lancamento = lancamento;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Lancamento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LancamentoExists(Lancamento.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool LancamentoExists(int id)
        {
          return (_context.Lancamento?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
