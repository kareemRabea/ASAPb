﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASAP.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string BuildingCode { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int ZipCode { get; set; }
        public string DisplayAddress { get; set; }
        public Person Person { get; set; }
    }
}
