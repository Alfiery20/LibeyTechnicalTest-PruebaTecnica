using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces
{
    public interface ILocationRepository
    {
        IEnumerable<RegionResponse> FindRegion();
        IEnumerable<ProvinceResponse> FindProvince(string regionCode);
        IEnumerable<UbigeoResponse> FindUbigeo(string ProvinceCode);
    }
}
