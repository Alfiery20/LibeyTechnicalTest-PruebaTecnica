using LibeyTechnicalTestDomain.EFCore;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Domain;
namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Infrastructure
{
    public class LibeyUserRepository : ILibeyUserRepository
    {
        private readonly Context _context;
        public LibeyUserRepository(Context context)
        {
            _context = context;
        }

        public IEnumerable<LibeyUserResponse> FindResponse(string documentNumber)
        {
            var query = from libeyUser in _context.LibeyUsers
                        where libeyUser.DocumentNumber.Contains(documentNumber)
                        join typeDocu in _context.TypeDocuments on libeyUser.DocumentTypeId equals typeDocu.DocumentTypeId into typeDocuJoin
                        from typeDocu in typeDocuJoin.DefaultIfEmpty()
                        join region in _context.Regions on libeyUser.UbigeoCode.Substring(0, 2) equals region.RegionCode into regionJoin
                        from region in regionJoin.DefaultIfEmpty()
                        join province in _context.Provinces on libeyUser.UbigeoCode.Substring(2, 4) equals province.ProvinceCode into provinceJoin
                        from province in provinceJoin.DefaultIfEmpty()
                        join ubigeo in _context.Ubigeos on libeyUser.UbigeoCode equals ubigeo.UbigeoCode into ubigeoJoin
                        from ubigeo in ubigeoJoin.DefaultIfEmpty()
                        select new LibeyUserResponse()
                        {
                            DocumentNumber = libeyUser.DocumentNumber,
                            Active = libeyUser.Active,
                            Address = libeyUser.Address,
                            DocumentTypeId = libeyUser.DocumentTypeId,
                            DocumentTypeDescription = typeDocu != null ? typeDocu.DocumentTypeDescription : null,
                            Email = libeyUser.Email,
                            FathersLastName = libeyUser.FathersLastName,
                            MothersLastName = libeyUser.MothersLastName,
                            RegionCode = region != null ? region.RegionDescription : null,
                            ProvinceCode = province != null ? province.ProvinceDescription : null,
                            UbigeoCode = ubigeo != null ? ubigeo.UbigeoDescription : null,
                            Name = libeyUser.Name,
                            Phone = libeyUser.Phone
                        };

            var result = query.ToList();

            return result.Any() ? result : new List<LibeyUserResponse>();
        }

        public void Create(UserUpdateorCreateCommand libeyUser)
        {
            var command = libeyUser.Convetir();
            _context.LibeyUsers.Add(command);
            _context.SaveChanges();
        }

        public void Update(UserUpdateorCreateCommand libeyUser)
        {
            var command = libeyUser.Convetir();
            _context.LibeyUsers.Update(command);
            _context.SaveChanges();
        }
        public void Delete(UserUpdateorCreateCommand libeyUser)
        {
            var command = libeyUser.Convetir();
            _context.LibeyUsers.Remove(command);
            _context.SaveChanges();
        }
    }
}