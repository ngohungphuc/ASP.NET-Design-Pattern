using UnitOfWorkPattern.Model;

namespace UnitOfWorkPattern.Service
{
    public interface ICountryService : IEntityService<Country>
    {
        Country GetById(int id);
    }
}