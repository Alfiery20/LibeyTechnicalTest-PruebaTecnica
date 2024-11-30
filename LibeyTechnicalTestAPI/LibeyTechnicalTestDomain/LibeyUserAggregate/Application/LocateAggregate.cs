using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Application
{
    public class LocateAggregate : ILocateAggregate
    {
        private readonly ILocationRepository _locationRepository;

        public LocateAggregate(ILocationRepository locationRepository)
        {
            this._locationRepository = locationRepository;
        }
        public IEnumerable<RegionResponse> FindRegion()
        {
            var response = this._locationRepository.FindRegion();
            return response;
        }

        public IEnumerable<ProvinceResponse> FindProvince(string regionCode)
        {
            var response = this._locationRepository.FindProvince(regionCode);
            return response;
        }

        public IEnumerable<UbigeoResponse> FindUbigeo(string ProvinceCode)
        {
            var response = this._locationRepository.FindUbigeo(ProvinceCode);
            return response;
        }
    }
}
