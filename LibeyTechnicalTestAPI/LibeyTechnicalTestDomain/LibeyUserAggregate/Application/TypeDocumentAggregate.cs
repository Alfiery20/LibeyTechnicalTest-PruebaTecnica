using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Application
{
    public class TypeDocumentAggregate : ITypeDocumentAggregate
    {
        private readonly ITypeDocumentRepository _typeDocumentRepository;

        public TypeDocumentAggregate(ITypeDocumentRepository typeDocumentRepository)
        {
            this._typeDocumentRepository = typeDocumentRepository;
        }

        public IEnumerable<TypeDocument> Find()
        {
            var row = _typeDocumentRepository.Find();
            return row;
        }
    }
}
