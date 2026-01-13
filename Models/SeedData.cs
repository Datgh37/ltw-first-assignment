using Microsoft.EntityFrameworkCore;
using System.Globalization;
using TuNhanTamTinhRazorPage.Data;

namespace TuNhanTamTinhRazorPage.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new TuNhanTamTinhContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<TuNhanTamTinhContext>>()))
            {
                if (context == null || context.Food == null)
                {
                    throw new ArgumentNullException("Null RazorPagesMovieContext");
                }

                // Look for any movies.
                if (context.Food.Any())
                {
                    return;   // DB has been seeded
                }

                context.Food.AddRange(
                    new Food
                    {
                        FoodName = "Pizza",
                        Manufacturer = "Pizza Hut",
                        ManufacturingDate = DateTime.ParseExact("11-09-2025", "dd-MM-yyyy", CultureInfo.InvariantCulture),
                        ExpiryDate = DateTime.ParseExact("21-09-2025", "dd-MM-yyyy", CultureInfo.InvariantCulture),
                        Price = 150000M,
                        Rating = "A",    
                    },

                    new Food
                    {
                        FoodName = "Ratatouille",
                        Manufacturer = "Chuột Remy",
                        ManufacturingDate = DateTime.ParseExact("11-04-2025", "dd-MM-yyyy", CultureInfo.InvariantCulture),
                        ExpiryDate = DateTime.ParseExact("15-04-2025", "dd-MM-yyyy", CultureInfo.InvariantCulture),
                        Price = 500000M,
                        Rating = "B",
                    },

                    new Food
                    {
                        FoodName = "Phở",
                        Manufacturer = "Bà 5 đầu ngõ",
                        ManufacturingDate = DateTime.ParseExact("11-03-2025", "dd-MM-yyyy", CultureInfo.InvariantCulture),
                        ExpiryDate = DateTime.ParseExact("13-03-2025", "dd-MM-yyyy", CultureInfo.InvariantCulture),
                        Price = 35000M,
                        Rating = "A",
                    },
                    new Food
                    {
                        FoodName = "Cơm",
                        Manufacturer = "Mẹ nấu",
                        ManufacturingDate = DateTime.Now,
                        ExpiryDate = DateTime.Now,
                        Price = 0,
                        Rating = "S",
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
