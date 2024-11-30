using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Domain
{
    public class LibeyUserUpdate
    {
        public string DocumentNumber { get; private set; }
        public string Name { get; private set; }
        public string FathersLastName { get; private set; }
        public string MothersLastName { get; private set; }
        public string Address { get; private set; }
        public string UbigeoCode { get; private set; }
        public string Phone { get; private set; }
        public bool Active { get; private set; }
        
    }
}
