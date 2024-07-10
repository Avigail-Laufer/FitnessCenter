
using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.DalApi
{
    public  interface IAppointment
    {
        public List<SignTo> GetAllAppointmentByIdBL();
        public SignTo AddApointment(SignTo signTo);
        public SignTo RemoveApointment(SignTo signTo);

    }
}
