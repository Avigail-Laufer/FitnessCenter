using BL.BO;
using BL.Models;
using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.BLApi;

public interface ICoachBL
{
    public List<BLCoach> GetAllCoachBL();
    public BLCoach RemoveCoachBL(BLCoach coach);
    public BLCoach AddCoachBL(BLCoach coach);
    public BLCoach UpdateCoachBL(BLCoach coach);
    public List<BLCoach> GetAllCoachforThisTraining(string nameOfTraining);
    public List<BLschedule> GetCoachWithAvailableTimes(string coachId);
    public BLCoach GetCoachContactInfo(string CoachId);
    public List<BLCoach> GetCoachWhoWorkMoreThanOneAWeek();
    public List<BLCoach> CoachInAlphabeticalOrder(char start);
    

}
