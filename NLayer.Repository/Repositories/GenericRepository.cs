using Microsoft.EntityFrameworkCore;
using NLayer.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Repository.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly AppDbContext _context;
        //protected > ilerleyen süreçte product sınıfına ait temel crud operasyonları dışında; örneğin product'la ilgili kategorileri, product'la ilgili feature'ları almak
        //istersek protected yerine private yaparsak yapamayız. private yaparsak ProductRepository, IProductRepository, IProductService, ProductService gibi sadece product
        //sınıfı için özelleştirilmiş sınıflar oluşturmamız gereklidir. Herhangi bir entity için buradaki temel crud işlemleri işimize yaramazsa tabii. Dolayısıyla bu gibi
        //durumlarda miras almamız için erişim belirleyici metot olan "protected" erişim belirleyicisini private yerine kullanıyoruz.
        private readonly DbSet<T> _dbSet;
        //constructor'da geçilecek olanlar genellikle readonly olur. Çünkü kazara diğer metotlarda herhangi bir değişikliğe gidilmemesi için. Best practise açısından uygun olan budur.
        public GenericRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await _dbSet.AddRangeAsync(entities);
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
        {
            return await _dbSet.AnyAsync(expression);
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> expression)
        {
            return _dbSet.AsNoTracking().AsQueryable();
            //AsNoTracking() > burada Ef Core çektiği dataları memory'e almasın ki daha performanslı çalışsın istiyoruz. eğer bunu kullanmazsak çekilen datalar memory'de
            //dispose edilene kadar bekler.
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public void Remove(T entity)
        {
            //_context.Entry(entity).State = EntityState.Deleted; alttaki kod ile aynı işlemi yapmaktadır.
            _dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> expression)
        {
            return _dbSet.Where(expression);
        }
    }
}
