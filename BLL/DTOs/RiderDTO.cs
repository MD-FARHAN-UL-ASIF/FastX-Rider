using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class RiderDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string UserName { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string NID { get; set; }

        public DateTime DOB { get; set; }

        public string Gender { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string Station { get; set; }

        public string VehicaleType { get; set; }

        public double Salary { get; set; }

        public string Status { get; set; }

        public DateTime Created_at { get; set; }
    }
}
