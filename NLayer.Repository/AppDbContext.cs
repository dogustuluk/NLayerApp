using Microsoft.EntityFrameworkCore;
using NLayer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<ProductFeature>().HasData(
                new ProductFeature {Id = 1, Color = "kırmızı", Height = 20, Width = 30, ProductId = 1 },
                new ProductFeature { Id = 2, Color = "siyah", Height = 120, Width = 130, ProductId = 2 });//seed data mantığı aynı, ama burada bu işlemi belirtirsek seperation
            //of concern ilkesine karşı geliriz. Olabildiğince classları modüler yap.


            base.OnModelCreating(modelBuilder);
        }
    }
}
