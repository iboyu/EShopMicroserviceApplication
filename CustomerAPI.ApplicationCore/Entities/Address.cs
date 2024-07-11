using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerAPI.ApplicationCore.Entities
{
    public class Address
    {
        public int id { get; set; }
        public string street1 { get; set; }
        public string street2 { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public int customerId { get; set; }
        public bool isDefaultAddress { get; set; }


    }
}
