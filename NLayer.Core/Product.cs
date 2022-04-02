using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core
{
    public class Product:BaseEntity
    {
        public string Name { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; } //public int Category_Id { get; set; } şeklinde bir custom isim verirsek
        //alttaki açıklama satırındaki kodu yazmamız gerekiyor fakat best practise açısından doğru bir yaklaşım olmaz.
        //[ForeignKey("Category_Id")]
        public Category Category { get; set; } //navigation property
        public ProductFeature ProductFeature { get; set; } // navigation property
    }
}
