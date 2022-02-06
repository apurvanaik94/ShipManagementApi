using System.Linq.Expressions;       
      
namespace ShipManagementApi.DAL      
{       
    public interface IBaseRepository<T> where T : class       
    {       
       Task<IEnumerable < T >> GetAll();  
        Task<T> Get(int id);  
        void Insert(T entity);  
        void Update(T entity);  
        void Delete(int id); 
        Task<int> Save();
    }  
}