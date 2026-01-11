using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TuNhanTamTinh.Data;
using TuNhanTamTinh.Models;

namespace TuNhanTamTinh.Pages.Foods
{
    public class IndexModel : PageModel
    {
        private readonly TuNhanTamTinh.Data.TuNhanTamTinhContext _context;

        public IndexModel(TuNhanTamTinh.Data.TuNhanTamTinhContext context)
        {
            _context = context;
        }

        public IList<Food> Food { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Food = await _context.Food.ToListAsync();
        }
    }
}
