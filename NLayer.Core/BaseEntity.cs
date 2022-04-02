using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core
{
    public abstract class BaseEntity //abstract yaparak nesne örneği alınmasını engellemiş oluruz
    {
        //tüm classlar için ortak bir class'tır.
        public int Id { get; set; } //product_Id şeklinde bir isimlendirme yapmıyoruz nedeni ise EF Core bunu "Id" şeklinde olan tanımlamayı direkt olarak algılamaktadır.
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
