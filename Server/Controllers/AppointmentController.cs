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
        [HttpGet]
        public ActionResult<BLpossibleAppointment> GetPossibleAppointment(string id) => appointment.numberOfPossibleAppointment(id);
        [HttpPost]
        public BLgetAppointment getApo(BLgetAppointment a) {
           
                if (appointment.AddAppointmentBL(a) != null)
                    return a;
            return null;
        }
        [HttpDelete]
        public BLgetAppointment deleteApo(BLgetAppointment a)
        {

            if (appointment.RemoveAppointmentBL(a) != null)
                return a;
            return null;
        }

    }
}
