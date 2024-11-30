using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LibeyTechnicalTestAPI.Controllers.Location
{
    [ApiController]
    [Route("[controller]")]
    public class LocationController : Controller
    {
        private readonly ILocateAggregate locateAggregate;

        public LocationController(ILocateAggregate locateAggregate)
        {
            this.locateAggregate = locateAggregate;
        }

        [HttpGet]
        [Route("region")]
        public IActionResult FindRegion()
        {
            var row = locateAggregate.FindRegion();
            return Ok(row);
        }

        [HttpGet]
        [Route("province/{codRegion}")]
        public IActionResult FindProvince(string codRegion)
        {
            var row = locateAggregate.FindProvince(codRegion);
            return Ok(row);
        }

        [HttpGet]
        [Route("ubigeo/{codProvince}")]
        public IActionResult FindUbigeo(string codProvince)
        {
            var row = locateAggregate.FindUbigeo(codProvince);
            return Ok(row);
        }
    }
}
