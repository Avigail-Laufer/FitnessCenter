using BL.BLApi;
using BL;
using Microsoft.AspNetCore.Mvc;
using BL.Models;
using Server.Models;

namespace Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]


    public class ScheduleController : ControllerBase
    {
        ISchduleBL schdule;
        public ScheduleController(BlManager bl)
        {

            schdule = bl.schedule;
        }
        [HttpGet("{nameTraining}/{nameDay}")]
        public ActionResult<List<BLschedule>> Get(string nameTraining, string nameDay) 
        {
            List<BLschedule> bLschedules = schdule.DatesForTrainingDayOfTheWeek(nameTraining, nameDay);
            if(bLschedules == null)
            {
                return null;
            }
            return bLschedules;
            
        }
        [HttpGet("name/{nameTraining}")]
        public ActionResult<List<BLschedule>> GetDatesForTraining(string nameTraining) 
        { 
            List<BLschedule>bLschedules= schdule.DatesForTraining(nameTraining);
            return bLschedules;
        }
        [HttpGet("numOfRoom/{numOfRoom}")]
        public ActionResult<List<BLschedule>> GetdatesForARoom(int numOfRoom)
        {
            List<BLschedule> bLschedules = schdule.datesForARoom(numOfRoom);
            return bLschedules;
        }

        //public List<BLschedule> GetUpcomingDatesForRoom(int numOfRoom)
        //{ 

        //}
        [HttpGet("dayOfWeek/{dayOfWeek}")]
        public List<BLschedule> GetDatesForDayOfTheWeek(string dayOfWeek)
        {
            List<BLschedule> bLschedules = schdule.DatesForDayOfTheWeek(dayOfWeek);
            return bLschedules;

        }
        [HttpGet]
        public List<BLschedule> DateOfTrainingForAclient(string id,string training)
        {
            return schdule.DateOfTrainingForAclient(id,training);
        }
        [HttpDelete]
        public BLschedule deletescudel(string idScudel, string nameTraining) 
        {
            return schdule.deletescudel(idScudel, nameTraining);
        }


    }
   
}
