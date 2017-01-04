using UnitOfWorkPattern.Model;

namespace UnitOfWorkPattern.Repository
{
    public interface IPersonRepository : IGenericRepository<Person>
    {
        Person GetById(long id);
    }
}