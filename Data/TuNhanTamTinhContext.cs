using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TuNhanTamTinh.Models;

namespace TuNhanTamTinh.Data
{
    public class TuNhanTamTinhContext : DbContext
    {
        public TuNhanTamTinhContext (DbContextOptions<TuNhanTamTinhContext> options)
            : base(options)
        {
        }

        public DbSet<TuNhanTamTinh.Models.Food> Food { get; set; } = default!;
    }
}
