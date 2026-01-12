using Microsoft.EntityFrameworkCore;
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
                        ManufacturingDate = DateTime.Parse("11-9-2025"),
                        ExpiryDate = DateTime.Parse("21-9-2025"),
                        Price = 5.99M,
                        Rating = "A",    
                    },

                    new Food
                    {
                        FoodName = "Ratatouille",
                        Manufacturer = "Remy",
                        ManufacturingDate = DateTime.Parse("11-4-2025"),
                        ExpiryDate = DateTime.Parse("15-4-2025"),
                        Price = 7.99M,
                        Rating = "B",
                    },

                    new Food
                    {
                        FoodName = "Pho",
                        Manufacturer = "Ba 5 dau ngo",
                        ManufacturingDate = DateTime.Parse("11-3-2025"),
                        ExpiryDate = DateTime.Parse("13-3-2025"),
                        Price = 2M,
                        Rating = "A",
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
