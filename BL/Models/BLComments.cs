using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Models
{
    public class BLComments
    {
        public int Id { get; set; }

        public string Comments { get; set; } = null!;

        public string IdClient { get; set; } = null!;
        public string ?ClientName { get; set; }
    }
}
