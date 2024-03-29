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

namespace BL.BlServices
{
    public class BLSchduleSevices:ISchduleBL
    {
        ISchedule timeTrainingBL;
        public BLSchduleSevices(DalManager dal)
        {
            timeTrainingBL = dal.Schedule;

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
            // var schedule = time
            //.Where(item => item.CoachForTrainingCodeNavigation.CodeTrainingNavigation.Name.Equals(nameTraining))
            //.Select(item => new BLschedule(item))
            //.ToList();
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
            // var schedule = time
            //.Where(item => item.CoachForTrainingCodeNavigation.CodeTrainingNavigation.Name.Equals(nameTraining) && item.Day.Equals(nameDay))
            //.Select(item => new BLschedule(item))
            //.ToList();

        }
        //למה לא עשינו משתנה מסוג תאריך ??
        //קבל תאריכים קרובים לחדר ספציפי
        //public List<BLschedule> UpcomingDatesForRoom(int numOfRoom) =>
        //timeTrainingBL.GetSchedule()
        //.Where(item => item.NumberRoom == numOfRoom && item.Day >= DateTime.Today.Day)
        //.OrderBy(item => item.Date)
        //.Select(item => new BLschedule(item))
        //.ToList();

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
    }
}

