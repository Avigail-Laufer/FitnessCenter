using Azure;
using BL.BLApi;
using BL.BO;
using BL.Models;
using Dal.DalApi;
using Server.Models;
using fitness_center;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Dal;

namespace BL.BlServices;

public class BLCoachService : ICoachBL
{
    #region prop
    ICoachDal CoachBL;
    ICoachForTraining CoachForTrainingBL;
    ITraining trainingBL;
    ISchedule timeTrainingBL;
    IMapper mapper;
    #endregion

    #region func
    public BLCoachService(DalManager dal)
    {
        CoachBL = dal.Coaches;
        CoachForTrainingBL = dal.CoachForTrainings;
        trainingBL = dal.Trainings;
        timeTrainingBL = dal.Schedule;
        var config = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());
        mapper = config.CreateMapper();

    }

    public Coach Convert(BLCoach coach)
    {
        var c = new Coach()
        {
            Age = coach.Age,
            Id = coach.Id,
            Fhone = coach.Fhone,
            FirstName = coach.FirstName,
            LastName = coach.LastName,
            Email = coach.Email,
            SalaryForHower = coach.SalaryForHower,
           
        };
        return c;
    }
    public BLCoach AddCoachBL(BLCoach coach)
    {
        var c = Convert(coach);
        var coachfromDal = CoachBL.AddCoachDal(c);
        if (coachfromDal == null)
        {
            return null;
        }
        return coach;
    }

    public List<BLCoach> GetAllCoachBL()
    {
        var listFormDall = CoachBL.GetAllCoachDal();
        List<BLCoach> list = new List<BLCoach>();
        listFormDall.ForEach(t => list.Add(mapper.Map<BLCoach>(t)));
        return list;
    }

    public List<BLCoach> GetAllCoachforThisTraining(string nameOfTraining)
    {
        //מביא את כל רשימת מאמן לאימון
        List<CoachForTraining> list = CoachForTrainingBL.GetCoachForTraining();

        //מביא את כל רשימת האימונים
        List<Training> training = trainingBL.GetAllTrainings();

        //פותח רשימת מאמנים חדשה
        List<BLCoach> coaches = new List<BLCoach>();
        for (int i = nameOfTraining.Length; i <= 39; i++)
        {
            nameOfTraining += " ";
        }
        //מוצא את האימון שעונה לשם שקיבל
        var newTrining = training.FirstOrDefault(t => t.Name.Equals(nameOfTraining));
        //אם מצא כזה אימון
        if (newTrining != null)
        {

            int x = newTrining.Id;
            //עובר על טבלת מאמן לאימון ועבור כל אימון שעונה לשם שקיבל מוסיף לרשימת המאמנים
            foreach (var item in list)
            {
                if (item.CodeTraining == x)
                {
                    Coach c = CoachBL.GetAllCoachDal().FirstOrDefault(c => c.Id == item.CodeCoach);
                    coaches.Add(new BLCoach(c));
                }

            }
            //מחזיר את הרשימה
            return coaches;
        }
        return null;

    }

    public BLCoach GetCoachContactInfo(string CoachId)
    {
        List<Coach>c= CoachBL.GetAllCoachDal();
        Coach coach = CoachBL.GetCoachContactInfo(CoachId);
        if (coach == null)
        {
            return null;
        }
        return new BLCoach(coach);
    }

    public List<BLCoach> GetCoachWhoWorkMoreThanOneAWeek()
    {

        //מביא את כל זמני האימון
        List<TimeTraining> dates = CoachBL.AllDate();

        //מביא את כל המאמנים
        List<Coach> coaches = CoachBL.GetAllCoachDal();
        //פותח רשימה של מאמנים מסוג ביל 
        List<BLCoach> moreOneDate = new List<BLCoach>();
        int count = 0;
        //עובר על כל רשימת המאמנים ועבור כל מאמן בודק אם עובד יותר מפעם בשבוע
        foreach (var coach in coaches)
        {
            foreach (var date in dates)
            {
                if (coach.Id.Equals(date.CoachForTrainingCodeNavigation.CodeCoach))
                {
                    count++;
                }
            }
            //אם עובד יותר מפעם בשבוע מוסיף לרשימה את המאמן
            if(count > 1) {
                var newCoach = new BLCoach(coach);
                moreOneDate.Add(newCoach);
            }

        }
        return moreOneDate;
    }

    public BLCoach RemoveCoachBL(BLCoach coach)
    {

        Coach c = Convert(coach);
        Coach c2= CoachBL.RemoveCoachDal(c);
        if(c2 != null) {
            return coach;
        }
        return null;
    }

    public BLCoach UpdateCoachBL(BLCoach coach)
    {
        Coach newCoach = Convert(coach);
        CoachBL.UpdateCoachDal(newCoach);
        return coach;
    }
    //להביא את כל המאמנים שמתחילים באות מסוימת
    public List<BLCoach> CoachInAlphabeticalOrder(char start)
    {
        List<Coach> coach = CoachBL.GetAllCoachDal();
        List<BLCoach> bLCoaches = new List<BLCoach>();
        foreach (var c in coach)
        {
            if (c.FirstName.Substring(0, 1).Equals(start))
            {
                bLCoaches.Add(new BLCoach(c));
            }
        }
        return bLCoaches;
    }
    //להביא את כל הלוח זמנים של מאמן מסוים
    public List<BLschedule> GetCoachWithAvailableTimes(string coachId)
    {
        Coach c = CoachBL.GetCoachContactInfo(coachId);
        List<TimeTraining> Coachtime =timeTrainingBL.GetSchedule();
        List<BLschedule> timeTrainingCoach = new List<BLschedule>();
        foreach (var item in Coachtime)
        {
            if (c.Id.Equals(item.CoachForTrainingCodeNavigation.CodeCoach))
                //להמיר פה...
                timeTrainingCoach.Add(new BLschedule(item));
        }
        return timeTrainingCoach;
    }
    #endregion
}
