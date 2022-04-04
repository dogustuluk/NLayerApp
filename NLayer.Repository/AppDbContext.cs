using Microsoft.EntityFrameworkCore;
using NLayer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Repository
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options):base(options) //options alacak çünkü veri tabanı yolunu startup.cs'den veriyor olucaz.
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductFeature> ProductFeatures { get; set; }  //best practice olması açısından bu kodu kapatmamız
        //gerekmektedir çünkü product feature'un olması için mutlaka product girilmesi gereklidir. 18.satırdaki kod
        //ile bunu gerçekleştirmiş oluruz.
    }
}
