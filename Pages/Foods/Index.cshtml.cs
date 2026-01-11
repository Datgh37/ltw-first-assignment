using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        public SelectList? Genres { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? MovieGenre { get; set; }

        public async Task OnGetAsync()
        {
            // Use LINQ to get list of genres.
            IQueryable<string> genreQuery = from m in _context.Food
                                            orderby m.Manufacturer
                                            select m.Manufacturer;

            var movies = from m in _context.Food
                         select m;

            if (!string.IsNullOrEmpty(SearchString))
            {
                movies = movies.Where(s => s.FoodName.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(MovieGenre))
            {
                movies = movies.Where(x => x.Manufacturer == MovieGenre);
            }
            Genres = new SelectList(await genreQuery.Distinct().ToListAsync());
            Food = await movies.ToListAsync();
        }
    }
}
