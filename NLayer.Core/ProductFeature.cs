using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core
{
    public class ProductFeature //bire-bir ilişkilerde her zaman base class'a bağlanmak zorunda olmayabilir.
    {
        public int Id { get; set; }
        public string Color { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public int ProductId { get; set; } //Product sonraso Id'yi boşluk veya özel karakter olmadan kullandığımız için EF Core bunun bir Foreign Key olduğunu anlayacaktır.
        public Product Product { get; set; } //Product sonraso Id'yi boşluk veya özel karakter olmadan kullandığımız için EF Core bunun bir Foreign Key olduğunu anlayacaktır.
    }
}
