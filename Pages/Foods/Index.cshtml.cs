using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TuNhanTamTinhRazorPage.Data;
using TuNhanTamTinhRazorPage.Models;

namespace TuNhanTamTinhRazorPage.Pages.Foods
{
    public class IndexModel : PageModel
    {
        private readonly TuNhanTamTinhRazorPage.Data.TuNhanTamTinhContext _context;

        public IndexModel(TuNhanTamTinhRazorPage.Data.TuNhanTamTinhContext context)
        {
            _context = context;
        }

        public IList<Food> Food { get;set; } = default!;
        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        public SelectList? Manufacturers { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? FoodManufacturer { get; set; }

        public async Task OnGetAsync()
        {
            // Use LINQ to get list of genres.
            IQueryable<string> genreQuery = from m in _context.Food
                                            orderby m.Manufacturer
                                            select m.Manufacturer;

            var foods = from m in _context.Food
                         select m;

            if (!string.IsNullOrEmpty(SearchString))
            {
                foods = foods.Where(s => s.FoodName.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(FoodManufacturer))
            {
                foods = foods.Where(x => x.Manufacturer == FoodManufacturer);
            }
            Manufacturers = new SelectList(await genreQuery.Distinct().ToListAsync());
            Food = await foods.ToListAsync();
        }
    }
}
