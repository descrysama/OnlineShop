using System;
namespace Api.OnlineShop.Datas.Repository.Contract
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> FindAll();

        Task<T> FindByKey(object id);

        Task<T> Create(T element);

        Task<T> Update(T element, int Id);

        Task<T> Remove(T element);
    }
}

