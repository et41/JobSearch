using JobApi.Models;
using Microsoft.EntityFrameworkCore;
namespace JobApi.DataAccess
{
    //TEntity: type of our entity in our database(Posts, Category, Type, Location)
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetAll();
        Task<TEntity> GetById(int id);
        Task Create(TEntity entity);
        Task Update(TEntity entity);
        Task Delete(int id);
    }
}
