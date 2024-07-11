using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerAPI.ApplicationCore.Models.Request
{
    public class CustomerRequestModel
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string phone { get; set; }
        public int addressID { get; set; }
    }
}
