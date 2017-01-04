using UnitOfWorkPattern.Model;
using UnitOfWorkPattern.Repository;

namespace UnitOfWorkPattern.Service
{
    public class CountryService : EntityService<Country>, ICountryService
    {
        private IUnitOfWork _unitOfWork;
        private ICountryRepository _countryRepository;

        public CountryService(IUnitOfWork unitOfWork, ICountryRepository countryRepository)
            : base(unitOfWork, countryRepository)
        {
            _unitOfWork = unitOfWork;
            _countryRepository = countryRepository;
        }

        public Country GetById(int id)
        {
            return _countryRepository.GetById(id);
        }
    }
}