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
        #region Get
        [HttpGet]
        public ActionResult<BLpossibleAppointment> GetPossibleAppointment(string id) => appointment.NumberOfPossibleAppointment(id);

        [HttpGet("{bool}")]
        public bool ifCanAddApointment(int codeDate, string id)
        {
            return appointment.IfCanAddApointment(codeDate, id);


        }
        #endregion

        #region Post
        [HttpPost]
        public BLgetAppointment getApo(BLgetAppointment a) {

            if (appointment.AddAppointmentBL(a) != null)
                return a;
            return null;
        }
        #endregion

        #region Delete
        [HttpDelete]
        public BLgetAppointment deleteApo(BLgetAppointment a)
        {

            if (appointment.RemoveAppointmentBL(a) != null)
                return a;
            return null;
        }
        #endregion

        
       

    }
}
