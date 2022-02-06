using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace ShipManagementApi.DAL
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private DataContext _context = null;
        private DbSet<T> table = null;
        public BaseRepository(DataContext context)
        {
            _context = context;
            table=_context.Set< T >();
        }
        public async Task<IEnumerable<T>> GetAll()
        {
            return await table.ToListAsync<T>();
        }
        public async Task<T> Get(int id)
        {
            return await table.FindAsync(id);
        }
        public void Insert(T obj)
        {
            if (obj == null) {  
                throw new ArgumentNullException("Object is empty");  
            } 
            table.Add(obj);
        }
        public void Update(T obj)
        {
            if (obj == null) {  
                throw new ArgumentNullException("Object is empty");  
            } 
            table.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
        }
        public void Delete(int id)
        {
            T existing = table.Find(id);
            if (existing == null) {  
                throw new ArgumentNullException("Object is empty");  
            } 
            table.Remove(existing);
        }
        public async Task<int> Save()
        {
            return await _context.SaveChangesAsync();
        }
    }
}