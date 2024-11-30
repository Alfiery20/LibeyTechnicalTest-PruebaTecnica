using LibeyTechnicalTestDomain.LibeyUserAggregate.Domain;
using System.Net;
using System.Numerics;

namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO
{
    public record UserUpdateorCreateCommand
    {
        public string DocumentNumber { get; init; }
        public int DocumentTypeId { get; init; }
        public string Name { get; init; }
        public string FathersLastName { get; init; }
        public string MothersLastName { get; init; }
        public string Address { get; init; }
        public string UbigeoCode { get; init; }
        public string Phone { get; init; }
        public string Email { get; init; }
        public string Password { get; init; }
        public LibeyUser Convetir() 
        {
            return new LibeyUser(this.DocumentNumber, this.DocumentTypeId, this.Name, this.FathersLastName, this.MothersLastName, this.Address,
                                this.UbigeoCode, this.Phone, this.Email, this.Password);    
        }
    }
}