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
    public class DetailsModel : PageModel
    {
        private readonly RazorAppNftContext _context;

        public DetailsModel(RazorAppNftContext context)
        {
            _context = context;
        }

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
    }
}
