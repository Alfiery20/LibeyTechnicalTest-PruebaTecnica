using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Domain;

namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces
{
    public interface ILibeyUserRepository
    {
        IEnumerable<LibeyUserResponse> FindResponse(string documentNumber);
        void Create(UserUpdateorCreateCommand libeyUser);
        void Update(UserUpdateorCreateCommand libeyUser);
        void Delete(UserUpdateorCreateCommand libeyUser);
    }
}
