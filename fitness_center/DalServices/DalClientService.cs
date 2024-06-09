using Dal.DalApi;
using Microsoft.EntityFrameworkCore;
using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.DalServices;

public class DalClientService : IClientDal
{
    BlogsSiteContext _fitnessCenter;
    public DalClientService(BlogsSiteContext _fitnessCenter) { 
        this._fitnessCenter = _fitnessCenter;
    }

    public Client AddClient(Client client)
    {
        _fitnessCenter.Clients.Add(client);
        _fitnessCenter.SaveChanges();
        return client;  
    }

    public List<Client> GetClients()
    {
       return _fitnessCenter.Clients.Include(client=>client.TypeMemberCodeNavigation).ToList();
    }


   public Client? GetAllAppointmentByIdDAL(string id)
    { 
       var trainings = _fitnessCenter.Clients
         .Include(client => client.SignTos)
         .ThenInclude(client => client.CodeDateNavigation)
         .ThenInclude(client => client.CoachForTrainingCodeNavigation)
         .ThenInclude(client => client.CodeTrainingNavigation)
         .FirstOrDefault(client => client.Id == id);
        if (trainings == null) { return null; }
        return trainings;
    }

    public Client? DeleteClient(Client client)
    {
        var clients = _fitnessCenter.Clients
            .ToList().FirstOrDefault(c=>c.Id==client.Id);
        if (clients == null) { return null; };
        _fitnessCenter.Clients.Remove(clients);
        _fitnessCenter.SaveChanges();
        return client;


    }

    public List<TimeTraining> GetAllTimeTrining(string nameOfTrining)
    {
        var idTrining = _fitnessCenter.Trainings
            .ToList()
            .FirstOrDefault(t => t.Name == nameOfTrining);
        List<TimeTraining> signTo = _fitnessCenter.TimeTrainings
             .Include(t => t.CoachForTrainingCodeNavigation)
             .ThenInclude(t => t.CodeTrainingNavigation)
             .Where(t => t.Id == idTrining.Id)
             .ToList();
        return signTo;

    }

    public Client UppdateClient(Client client)
    {
        var clients = _fitnessCenter.Clients
            .FirstOrDefault(c => c.Id==client.Id);
        clients.FirstName=client.FirstName;  
        clients.LastName=client.LastName; 
        clients.BirthDate=client.BirthDate; 
        clients.Fhone=client.Fhone;
        clients.Email = client.Email;
        clients.TypeMemberCode= client.TypeMemberCode;
        _fitnessCenter.SaveChanges();
        return clients;

    }
    public Client GetClientWhithTypeMember(string id)
    {
        var trainings = _fitnessCenter.Clients
        .Include(Client => Client.SignTos)
        .FirstOrDefault(client => client.Id == id);
        if (trainings == null) { return null; }
        return trainings;
    }
}
