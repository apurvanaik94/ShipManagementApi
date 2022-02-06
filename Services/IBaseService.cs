using System.Linq.Expressions;       
      
namespace ShipManagementApi.BL     
{       
    public interface IBaseService<T> where T : class       
    {       
        Task<IEnumerable < T >> GetAll();  
        Task<T> Get(int id);  
        Task<int> Insert(T entity);  
        Task<int> Update(T entity);  
        Task<int> Delete(int id);      
    }       
} 