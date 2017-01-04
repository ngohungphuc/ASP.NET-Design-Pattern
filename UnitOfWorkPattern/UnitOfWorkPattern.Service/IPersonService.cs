using UnitOfWorkPattern.Model;

namespace UnitOfWorkPattern.Service
{
    public interface IPersonService : IEntityService<Person>
    {
        Person GetById(long id);
    }
}