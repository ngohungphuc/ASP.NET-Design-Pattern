using System.Data.Entity;
using System.Linq;
using UnitOfWorkPattern.Model;

namespace UnitOfWorkPattern.Repository
{
    public class CountryRepository : GenericRepository<Country>, ICountryRepository
    {
        public CountryRepository(DbContext context) : base(context)
        {
        }

        public Country GetById(int id)
        {
            return FindBy(x => x.Id == id).FirstOrDefault();
        }
    }
}