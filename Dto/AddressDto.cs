using ASAP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASAP.Dto
{
    public class AddressDto
    {
        public int Id { get; set; }
        public string BuildingCode { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int ZipCode { get; set; }
        public int MyProperty { get; set; }
        public PersonDto Person { get; set; }
    }
}
