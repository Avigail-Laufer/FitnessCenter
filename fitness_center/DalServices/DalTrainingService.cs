using Dal.DalApi;
using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.DalServices;

public class DalTrainingService:ITraining
{
    BlogsSiteContext _fitnessCenter;
    public DalTrainingService(BlogsSiteContext _fitnessCenter)
    {
        this._fitnessCenter = _fitnessCenter;
    }

    #region basic func
    public List<Training> GetAllTrainings() 
    {
     
     return _fitnessCenter.Trainings.ToList();
    }
    public Training AddTraining(Training training)
    {
        _fitnessCenter.Trainings.Add(training);
        _fitnessCenter.SaveChanges();
        return training;
    }
    public Training? UpdateTraining(Training training) 
    {
        var trainings=GetAllTrainings();
        var t=trainings.FirstOrDefault(t=>t.Id==training.Id);
        if (t==null) { return null; }
        t.Id= training.Id;
        t.CoachForTrainings=training.CoachForTrainings;
        t.PurposeOfTraining=training.PurposeOfTraining;
        t.Name=training.Name;
        return t;
    }
    public Training DeleteTraining(Training training) 
    {
        _fitnessCenter.Trainings.Remove(training);
        _fitnessCenter.SaveChanges();
        return training;

    }
    public List<Training> GetTrainingById()
    {
        throw new NotImplementedException();
    }
    #endregion
}
