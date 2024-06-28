using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Models
{
    public class BLCreditCard
    {
        public int Id { get; set; }

        public string number { get; set; } = null!;

        public string expiry { get; set; } = null!;

        public string cvc { get; set; } = null!;

    }
}
