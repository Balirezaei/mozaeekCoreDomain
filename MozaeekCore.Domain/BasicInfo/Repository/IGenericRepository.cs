namespace MozaeekCore.Domain.BasicInfo.Repository
{
    public interface IGenericRepository<T>
    {
        void Add(T entity);

        void Delete(T entity);

        

    }
}