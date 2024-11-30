using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Domain;
namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Application
{
    public class LibeyUserAggregate : ILibeyUserAggregate
    {
        private readonly ILibeyUserRepository _repository;
        public LibeyUserAggregate(ILibeyUserRepository repository)
        {
            _repository = repository;
        }
        public IEnumerable<LibeyUserResponse> FindResponse(string documentNumber)
        {
            var row = _repository.FindResponse(documentNumber);
            return row;
        }
        public void Create(UserUpdateorCreateCommand command)
        {
            _repository.Create(command);
        }
        public void Update(UserUpdateorCreateCommand command)
        {
            _repository.Update(command);
        }
        public void Delete(UserUpdateorCreateCommand command)
        {
            _repository.Delete(command);
        }
    }
}