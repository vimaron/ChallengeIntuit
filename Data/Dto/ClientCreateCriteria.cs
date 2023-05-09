﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Dto
{
    public class ClientCreateCriteria
    { 
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string CUIT { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Mail { get; set; }
    }
}
