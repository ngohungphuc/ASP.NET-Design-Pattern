using UnitOfWorkPattern.Model;

namespace UnitOfWorkPattern.Repository
{
    public interface ICountryRepository : IGenericRepository<Country>
    {
        Country GetById(int id);
    }
}