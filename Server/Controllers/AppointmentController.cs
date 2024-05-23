using BL.BLApi;
using BL;
using Microsoft.AspNetCore.Mvc;
using BL.Models;

namespace Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppointmentController : Controller
    {
        IAppointmentBL appointment;
        public AppointmentController(BlManager bl)
        {

            this.appointment = bl.Appointment;
        }
        [HttpPost]
        public BLgetAppointment getApo(BLgetAppointment a) {
           
                if (appointment.AddAppointmentBL(a) != null)
                    return a;
            return null;
        }
    }
}
