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
    internal class DalCoachForTrainingService : ICoachForTraining
    {
        BlogsSiteContext _fitnessCenter;
        public DalCoachForTrainingService(BlogsSiteContext fitnessCenter) {
            _fitnessCenter = fitnessCenter; 
        } 
        public List<CoachForTraining> GetCoachForTraining()
        {
           return _fitnessCenter
                .CoachForTrainings
                .Include(c=>c.CodeCoachNavigation)
                .Include(c=>c.CodeTrainingNavigation)
                .ToList();
        }
    }
}
