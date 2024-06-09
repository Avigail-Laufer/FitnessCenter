using BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.BLApi
{
    public interface ISchduleBL
    {
        public List<BLschedule> DatesForTrainingDayOfTheWeek(string nameTraining, string nameDay);
        public List<BLschedule> DatesForTraining(string nameTraining);
        public List<BLschedule> datesForARoom(int numOfRoom);
        public List<BLschedule> UpcomingDatesForRoom(int numOfRoom);
        public List<BLschedule> DatesForDayOfTheWeek(string dayOfWeek);
        public List<BLschedule> DateOfTrainingForAclient(string id, string nameTraining);
        public BLschedule deletescudel(string idScudel, string nameTraining);


    }
}
