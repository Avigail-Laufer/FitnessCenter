using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Models
{
    public class BLReturnClient
    {
        public string Id { get; set; }
        public int Years { get; set; }
        public int MonthlyPayment { get; set; }
        public string Type { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? email { get; set; }
        public string Fhone { get; set; }

    }
}
