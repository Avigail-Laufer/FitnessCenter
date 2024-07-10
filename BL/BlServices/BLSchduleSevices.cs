using BL.BLApi;
using BL.Models;
using Dal.DalApi;
using Server.Models;
using fitness_center;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.BlServices;

public class BLSchduleSevices : ISchduleBL
{
    #region prop
    ISchedule timeTrainingBL;
    IClientDal clientDal;
    ISighnToDal signTo;
    #endregion

    #region func
    public BLSchduleSevices(DalManager dal)
    {
        timeTrainingBL = dal.Schedule;
        clientDal = dal.Clients;
        signTo = dal.sighnTo;

    }

    //לקבל את כל התאריכים שמתקיימים בחדר מסוים
    public List<BLschedule> datesForARoom(int numOfRoom)
    {
        List<TimeTraining> time = timeTrainingBL.GetSchedule();
        var schedule = time
       .Where(item => item.NumberRoom == numOfRoom)
       .Select(item => new BLschedule(item))
       .ToList();
        return schedule;
    }

    //קבלת כל התאריכים של אימון מסוים
    public List<BLschedule> DatesForTraining(string nameTraining)
    {
        List<TimeTraining> time = timeTrainingBL.GetSchedule();
        List<BLschedule> schedule = new List<BLschedule>();
        foreach (var item in time)
        {
            if (item.CoachForTrainingCodeNavigation
                .CodeTrainingNavigation.Name
                .Equals(nameTraining))
                schedule.Add(new BLschedule(item));
        }
        return schedule;
    }

    //קבלת כל התאריכים שמתקימים ביום מסוים ועונים לאימון מסוים
    public List<BLschedule> DatesForTrainingDayOfTheWeek(string nameTraining, string nameDay)
    {

        List<TimeTraining> time = timeTrainingBL.GetSchedule();
        List<BLschedule> schedule = new List<BLschedule>();
        foreach (var item in time)
        {

            if (item.CoachForTrainingCodeNavigation
                .CodeTrainingNavigation.Name
                .Equals(nameTraining) && item.Day.Equals(nameDay))
                schedule.Add(new BLschedule(item));
        }
        return schedule;
    }

    //קבל תאריכים ליום מסוים בשבוע
    public List<BLschedule> DatesForDayOfTheWeek(string dayOfWeek)
    {
        List<TimeTraining> time = timeTrainingBL.GetSchedule();
        var schedule = time
            .Where(item => item.Day == dayOfWeek)
            .Select(item => new BLschedule(item))
            .ToList();
        return schedule;
    }

    public List<BLschedule> UpcomingDatesForRoom(int numOfRoom)
    {
        throw new NotImplementedException();
    }

    public List<BLschedule> DateOfTrainingForAclient(string id, string nameTraining)
    {
        List<SignTo> time = signTo.GetTimes();
        List<BLschedule> s = new List<BLschedule>();
        foreach (var item in time)
        {

            if (item.CodeDateNavigation.CoachForTrainingCodeNavigation.CodeTrainingNavigation.Name.Equals(nameTraining))
                if (item.IdClient.Equals(id))
                    s.Add(new BLschedule(item.CodeDateNavigation));

        }
        return s;
    }
    public BLschedule deletescudel(string idScudel, string nameTraining)
    {
        List<SignTo> time = signTo.GetTimes();
        BLschedule s = null;
        foreach (var item in time)
        {

            if (item.CodeDateNavigation.CoachForTrainingCodeNavigation.CodeTrainingNavigation.Name.Equals(nameTraining))
                if (item.IdClient.Equals(idScudel))
                {
                    time.Remove(item);
                }

        }
        return s;

    }

    #endregion
}

