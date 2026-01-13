using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TuNhanTamTinhRazorPage.Data;
using TuNhanTamTinhRazorPage.Models;

namespace TuNhanTamTinhRazorPage.Pages.Foods
{
    public class CreateModel : PageModel
    {
        private readonly TuNhanTamTinhRazorPage.Data.TuNhanTamTinhContext _context;

        public CreateModel(TuNhanTamTinhRazorPage.Data.TuNhanTamTinhContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Food Food { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Food.Add(Food);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
