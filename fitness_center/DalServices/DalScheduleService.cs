using Dal.DalApi;
using Microsoft.EntityFrameworkCore;
using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.DalServices
{
    public class DalScheduleService:ISchedule
    {
        BlogsSiteContext _fitnessCenter;
        public DalScheduleService(BlogsSiteContext _fitnessCenter)
        {
            this._fitnessCenter = _fitnessCenter;
        }

        #region basic func
        public List<TimeTraining> GetSchedule()
        {
            return _fitnessCenter.TimeTrainings
                .Include(c => c.CoachForTrainingCodeNavigation)
                .ThenInclude(c => c.CodeTrainingNavigation)
                .ToList();
        }
        #endregion
    }
}
