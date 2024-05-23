using BL.BO;
using BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.BLApi;

public interface IAppointmentBL
{
    public List<BLAppointment> GetAllAppointmentByIdBL(string id);
    public BLgetAppointment AddAppointmentBL(BLgetAppointment appointment);
}
