using System;       
using System.Collections.Generic;       
using System.Linq.Expressions;       
using ShipManagementApi.BL;       
using ShipManagementApi.DAL;       
      
namespace ShipManagementApi.BL       
{       
    public class BaseService<T> : IBaseService<T> where T : class       
    {       
        public readonly IBaseRepository<T> _TRepository;       
        public BaseService(IBaseRepository<T> TRepository)       
        {       
            this._TRepository = TRepository;       
        }       
      
        public async Task<int> Insert(T T)       
        {       
            _TRepository.Insert(T);       
            int result = await _TRepository.Save();       
            return result;       
        }       
      
        public async Task<int> Update(T T)       
        {       
            _TRepository.Update(T);       
            int result = await _TRepository.Save();       
            return result;       
        }       
      
        public async Task<int> Delete(int id)       
        {       
            _TRepository.Delete(id);       
            int result=await _TRepository.Save();      
            return result; 
        }       
      
        public async Task<T> Get(int id)       
        {       
            return await _TRepository.Get(id);       
        }       
      
        public async Task<IEnumerable<T>> GetAll()       
        {       
            return await _TRepository.GetAll();       
        }       
    }       
}       