using UnitOfWorkPattern.Model;
using UnitOfWorkPattern.Repository;

namespace UnitOfWorkPattern.Service
{
    public class PersonService : EntityService<Person>, IPersonService
    {
        private IUnitOfWork _unitOfWork;
        private IPersonRepository _personRepository;

        public PersonService(IUnitOfWork unitOfWork, IPersonRepository personRepository)
            : base(unitOfWork, personRepository)
        {
            _unitOfWork = unitOfWork;
            _personRepository = personRepository;
        }

        public Person GetById(long id)
        {
            return _personRepository.GetById(id);
        }
    }
}