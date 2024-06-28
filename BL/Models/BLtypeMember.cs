using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Models
{
    public class BLtypeMember
    {
        public int Id { get; set; }

        public string Type { get; set; } = null!;

        public int MonthlyPayment { get; set; }
        public string Description { get; set; } = null!;
    }
}
