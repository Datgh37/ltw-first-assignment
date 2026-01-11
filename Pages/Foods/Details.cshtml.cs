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
    public class DetailsModel : PageModel
    {
        private readonly TuNhanTamTinh.Data.TuNhanTamTinhContext _context;

        public DetailsModel(TuNhanTamTinh.Data.TuNhanTamTinhContext context)
        {
            _context = context;
        }

        public Food Food { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var food = await _context.Food.FirstOrDefaultAsync(m => m.Id == id);
            if (food == null)
            {
                return NotFound();
            }
            else
            {
                Food = food;
            }
            return Page();
        }
    }
}
