using BL.BLApi;
using BL.Models;
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
    public BLTriningService(DalManager dal)
    {
        dalTraining = dal.Trainings;
        dalClint = dal.Clients;
        sighnTo = dal.sighnTo;
    }

    public List<BLTrining> getAllTrainings()
    {
        var listFromDall=dalTraining.GetAllTrainings();
        List<BLTrining> list = new List<BLTrining>();
        foreach(var v in listFromDall) 
        {
            BLTrining bLTrining=new BLTrining() { Name= v.Name };
            list.Add(bLTrining);       
        
        }
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
                if(v.IdClientNavigation.Id.Equals(id))
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


   

    
}
