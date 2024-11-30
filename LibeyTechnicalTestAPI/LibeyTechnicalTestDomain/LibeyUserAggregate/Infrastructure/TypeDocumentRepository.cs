using LibeyTechnicalTestDomain.EFCore;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Infrastructure
{
    public class TypeDocumentRepository : ITypeDocumentRepository
    {
        private readonly Context _context;
        public TypeDocumentRepository(Context context)
        {
            _context = context;
        }
        public IEnumerable<TypeDocument> Find()
        {

            var q = from typeDocument in _context.TypeDocuments
                    select new TypeDocument()
                    {
                        DocumentTypeId = typeDocument.DocumentTypeId,
                        DocumentTypeDescription = typeDocument.DocumentTypeDescription,
                    };
            var list = q.ToList();
            if (list.Any()) return list.ToList();
            else return new List<TypeDocument>();
        }
    }
}
