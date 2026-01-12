using Microsoft.EntityFrameworkCore;
using System.Globalization;
using TuNhanTamTinh.Data;

namespace TuNhanTamTinh.Models
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
                        Price = 5.99M,
                        Rating = "A",    
                    },

                    new Food
                    {
                        FoodName = "Ratatouille",
                        Manufacturer = "Remy",
                        ManufacturingDate = DateTime.ParseExact("11-04-2025", "dd-MM-yyyy", CultureInfo.InvariantCulture),
                        ExpiryDate = DateTime.ParseExact("15-04-2025", "dd-MM-yyyy", CultureInfo.InvariantCulture),
                        Price = 7.99M,
                        Rating = "B",
                    },

                    new Food
                    {
                        FoodName = "Pho",
                        Manufacturer = "Ba 5 dau ngo",
                        ManufacturingDate = DateTime.ParseExact("11-03-2025", "dd-MM-yyyy", CultureInfo.InvariantCulture),
                        ExpiryDate = DateTime.ParseExact("13-03-2025", "dd-MM-yyyy", CultureInfo.InvariantCulture),
                        Price = 2M,
                        Rating = "A",
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
