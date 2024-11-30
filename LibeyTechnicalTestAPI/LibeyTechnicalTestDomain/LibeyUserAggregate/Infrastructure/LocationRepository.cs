using LibeyTechnicalTestDomain.EFCore;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Infrastructure
{
    public class LocationRepository : ILocationRepository
    {
        private readonly Context _context;
        public LocationRepository(Context context)
        {
            _context = context;
        }
        public IEnumerable<RegionResponse> FindRegion()
        {

            var q = from region in _context.Regions
                    select new RegionResponse()
                    {
                        RegionCode = region.RegionCode,
                        RegionDescription = region.RegionDescription,
                    };
            var list = q.ToList();
            if (list.Any()) return list.ToList();
            else return new List<RegionResponse>();
        }

        public IEnumerable<ProvinceResponse> FindProvince(string regionCode)
        {

            var q = from provinces in _context.Provinces.Where(x => x.RegionCode.Equals(regionCode))
                    select new ProvinceResponse()
                    {
                        ProvinceCode = provinces.ProvinceCode,
                        RegionCode = provinces.RegionCode,
                        ProvinceDescription = provinces.ProvinceDescription,
                    };
            var list = q.ToList();
            if (list.Any()) return list.ToList();
            else return new List<ProvinceResponse>();
        }

        public IEnumerable<UbigeoResponse> FindUbigeo(string ProvinceCode)
        {

            var q = from ubigeos in _context.Ubigeos.Where(x => x.ProvinceCode.Equals(ProvinceCode))
                    select new UbigeoResponse()
                    {
                        UbigeoCode = ubigeos.UbigeoCode,
                        ProvinceCode = ubigeos.ProvinceCode,
                        RegionCode = ubigeos.RegionCode,
                        UbigeoDescription = ubigeos.UbigeoDescription,
                    };
            var list = q.ToList();
            if (list.Any()) return list.ToList();
            else return new List<UbigeoResponse>();
        }
    }
}
