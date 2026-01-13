using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TuNhanTamTinhRazorPage.Models;

namespace TuNhanTamTinhRazorPage.Data
{
    public class TuNhanTamTinhContext : DbContext
    {
        public TuNhanTamTinhContext (DbContextOptions<TuNhanTamTinhContext> options)
            : base(options)
        {
        }

        public DbSet<TuNhanTamTinhRazorPage.Models.Food> Food { get; set; } = default!;
    }
}
