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
    public List<Training> GetAllTrainings() 
    {
     
     return _fitnessCenter.Trainings.ToList();
    }
    public Training addTraining(Training training)
    {
        _fitnessCenter.Trainings.Add(training);
        _fitnessCenter.SaveChanges();
        return training;
    }
    public Training? updateTraining(Training training) 
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
    public Training deleteTraining(Training training) 
    {
        _fitnessCenter.Trainings.Remove(training);
        _fitnessCenter.SaveChanges();
        return training;

    }

    public List<Training> GetTrainingById()
    {
        throw new NotImplementedException();
    }
}
