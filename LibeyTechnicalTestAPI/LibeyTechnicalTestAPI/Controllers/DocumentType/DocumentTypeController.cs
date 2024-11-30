using LibeyTechnicalTestDomain.LibeyUserAggregate.Application;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LibeyTechnicalTestAPI.Controllers.DocumentType
{
    [ApiController]
    [Route("[controller]")]
    public class DocumentTypeController : Controller
    {
        private readonly ITypeDocumentAggregate _typeDocumentAggregate;

        public DocumentTypeController(ITypeDocumentAggregate typeDocumentAggregate)
        {
            this._typeDocumentAggregate = typeDocumentAggregate;
        }
        [HttpGet]
        [Route("")]
        public IActionResult FindRegion()
        {
            var row = _typeDocumentAggregate.Find();
            return Ok(row);
        }
    }
}
