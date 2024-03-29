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
    public class DalCoachService : ICoachDal
    {
       FitnessCenterContext _fitnessCenter;
        public DalCoachService(FitnessCenterContext _fitnessCenter)
        {
            this._fitnessCenter = _fitnessCenter;
        }
        //הוספת מאמן
        public Coach AddCoachDal(Coach coach)
        {
            _fitnessCenter.Coaches.Add(coach);
            _fitnessCenter.SaveChanges();
            return coach;

        }
        //קבלת כל המאמנים
        public List<Coach> GetAllCoachDal()
        {
            List<Coach> getAllCoach = _fitnessCenter.Coaches.ToList();
            return getAllCoach;
        }
     
        //קבלת מאמן לפי id
        public Coach? GetCoachContactInfo(string CoachId)
        {
            var coach = GetAllCoachDal().FirstOrDefault(c => c.Id.Equals(CoachId));
            if (coach == null)
                return null;
            return coach;

        }

        //מחיקת מאמן
        public Coach? RemoveCoachDal(Coach coach)
        {
            var newCoach=_fitnessCenter.Coaches.FirstOrDefault(c=>c.Id==coach.Id);
            if(newCoach == null) 
            {
                return null; 
            }
            _fitnessCenter.Remove(coach);
            _fitnessCenter.SaveChanges();
            return newCoach;
        }
        //עדכון מאמן הקיים כבר 
        public Coach UpdateCoachDal(Coach coach)
        {
            var UpdateCoach = _fitnessCenter.Coaches
            .FirstOrDefault(c => c.Id == coach.Id);
            UpdateCoach.Id = coach.Id;
            UpdateCoach.FirstName = coach.FirstName;
            UpdateCoach.LastName = coach.LastName;
            UpdateCoach.SalaryForHower = coach.SalaryForHower;
            UpdateCoach.Age = coach.Age;    
            UpdateCoach.Email = coach.Email;
            _fitnessCenter.SaveChanges();
            return UpdateCoach;
        }

        public List<TimeTraining> GetCoachWithAvailableTimes(int coachId)
        {
            throw new NotImplementedException();
        }

        public List<TimeTraining> AllDate()
        {
            //איך שולפים ב-בל רק את הקוד של המאמן כי אי אפשר לעשות פה זן אינקלוד
            return _fitnessCenter.TimeTrainings
                .Include(t=>t.CoachForTrainingCodeNavigation)
                .ThenInclude(t=>t.CodeCoachNavigation)
                .ToList();
                
        }
    }
}
