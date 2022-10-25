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
    public class IndexModel : PageModel
    {
        //private readonly RazorAppNftContext _context;

        public IndexModel(IHttpClientFactory httpClientFactory) =>
            _httpClientFactory = httpClientFactory;

            public IEnumerable<GitHubBranch>? GitHubBranches { get; set; }

        public async Task OnGet()
        {
            var httpRequestMessage = new HttpRequestMessage(
                    HttpMethod.Get,
                    "https://api.github.com/repos/dotnet/AspNetCore.Docs/branches")
            {
            Headers =
            {
                { HeaderNames.Accept, "application/vnd.github.v3+json" },
                { HeaderNames.UserAgent, "HttpRequestsSample" }
            }
        };

        var httpClient = _httpClientFactory.CreateClient();
        var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

        if (httpResponseMessage.IsSuccessStatusCode)
        {
            using var contentStream =
                await httpResponseMessage.Content.ReadAsStreamAsync();
            
            GitHubBranches = await JsonSerializer.DeserializeAsync
                <IEnumerable<GitHubBranch>>(contentStream);
        }
    }


        /*
        public IndexModel(RazorAppNftContext context)
        {
            _context = context;
        }

        public IList<Lancamento> Lancamento { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Lancamento != null)
            {
                Lancamento = await _context.Lancamento.ToListAsync();
            }
        }
        */
    }
}
