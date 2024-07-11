using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingAPI.ApplicationCore.Entities
{
    public class Shipper
    {
        public int Id { get; set; }

        [MaxLength(255)]
        public string Name { get; set; }

        [MaxLength(255)]
        public string Email { get; set; }

        [RegularExpression(@"^\d{10}$")]  //For 10 digit us phone number
        public string Phone { get; set; }

        [MaxLength(255)]
        public string ContactPerson { get; set; }

        public List<ShipperRegion> ShipperRegions { get; set; }
    }
}
