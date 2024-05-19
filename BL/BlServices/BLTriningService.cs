using AutoMapper;
using BL.BLApi;
using BL.Models;
using Dal;
using Dal.DalApi;
using Dal.DalServices;
using fitness_center;
using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.BlServices;

internal class BLTriningService : ITrainingBL
{
    ITraining dalTraining;
    IClientDal dalClint;
    ISighnToDal sighnTo;
    ISchedule schdule;
    IMapper mapper;
    public BLTriningService(DalManager dal)
    {
        dalTraining = dal.Trainings;
        dalClint = dal.Clients;
        sighnTo = dal.sighnTo;
        schdule = dal.Schedule;
        var config = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());
        mapper = config.CreateMapper();
    }

    public List<BLTrining> getAllTrainings()
    {
        var listFromDall=dalTraining.GetAllTrainings();
        List<BLTrining> list = new List<BLTrining>();
        listFromDall.ForEach(t => list.Add(mapper.Map<BLTrining>(t)));
        return list;
    }

    public List<BLTrining>? getTriningsforday(string id, string day)
    {
        var tDal = dalTraining.GetAllTrainings();
        var client = dalClint.GetClients().FirstOrDefault(c=>c.Id==id);
        if (client == null)
            return null;
       List<SignTo>b=new List<SignTo>();
        foreach (var v in sighnTo.GetTimes()) 
        {
            if(v.CodeDateNavigation.Day==day) 
            {
                if(v.IdClient.Equals(id))
                    b.Add(v);            
            }
        }         
        //var b= sighnTo.GetTimes().Where(v => v.CodeDateNavigation.Day == day).Where(v => v.Id.Equals(client.Id));
        List<BLTrining> bLTrinings=new List<BLTrining>();
        foreach(var n in b) 
        {
            var s = n.CodeDateNavigation.CoachForTrainingCodeNavigation.CodeTrainingNavigation.Name;
            BLTrining newbl= new BLTrining() { Name= s };
            bLTrinings.Add(newbl);
        }
        return bLTrinings;
      
    }

    List<Training> ITrainingBL.GetTrainingsByDay(string day)
    {
        throw new NotImplementedException();
    }

    //public List<Training> GetTrainingsByDay(string day)
    //{
    //    List<TimeTraining> trainings = schdule.GetSchedule();
    //    var schedule = trainings
    //    .Where(item => item.Day == day)
    //    .Select(item => new BLschedule(item))
    //    .ToList();
    //    return schedule;

    //}





}
