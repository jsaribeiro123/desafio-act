using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Razor.Nft.Models;

    public class RazorAppNftContext : DbContext
    {
        public RazorAppNftContext (DbContextOptions<RazorAppNftContext> options)
            : base(options)
        {
        }

        public DbSet<Razor.Nft.Models.Lancamento> Lancamento { get; set; } = default!;

        public DbSet<Razor.Nft.Models.Report>? Report { get; set; }
    }
