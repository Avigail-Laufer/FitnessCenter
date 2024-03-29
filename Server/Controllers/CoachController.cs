using BL.BLApi;
using BL.Models;
using BL;
using Microsoft.AspNetCore.Mvc;
using Dal.DalApi;
using BL.BO;

namespace Server.Controllers;
[ApiController]
[Route("api/[controller]")]

public class CoachController : ControllerBase
{
    ICoachBL blCoach;
    public CoachController(BlManager bl)
    {

        this.blCoach = bl.coach;
    }
    [HttpGet]
    public List<BLCoach> GetCoaches() => blCoach.GetAllCoachBL();

    [HttpGet("{trining}")]
    public ActionResult<List<BLCoach>> GetCoachforTraining(string trining)
    {
       List<BLCoach> c= blCoach.GetAllCoachforThisTraining(trining);
        if(c==null)
        {
            return null;
        }
        return c;
    }

    [HttpGet("Info/{CoachId}")]
    public BLCoach GetCoachContactInfo(string CoachId) => blCoach.GetCoachContactInfo(CoachId);
    [HttpGet("WorkMoreOneAweek")]
    public List<BLCoach>GetCoachWhoWorkMore(int coachId) => blCoach.GetCoachWhoWorkMoreThanOneAWeek();
    //[HttpGet("/Times/{CoachId}")]
    //public List<BLTimeOfTraining> GetCoachWithAvailableTimes(int coachId) => blCoach.GetCoachWithAvailableTimes(coachId);
    //[HttpPost]
    //public BLCoach AddCoachBL(BLCoach coach)=>blCoach.AddCoachBL(coach);
    //[HttpPut]
    //public Coach Convert(BLCoach coach) => blCoach.Convert(coach);

}


