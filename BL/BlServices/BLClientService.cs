using BL.BLApi;
using BL.BO;
using BL.Models;
using Dal.DalApi;
using Server.Models;
using fitness_center;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Dal;

namespace BL.BlServices;

public class BLClientService : IClientBL
{
    IClientDal ClientBL;
    IMapper mapper;

    public BLClientService(DalManager dal)
    {
        ClientBL = dal.Clients;
        var config = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());
        mapper = config.CreateMapper();
    }

    public BLsimpleClient AddClientBL(BLsimpleClient client)
    {
        Client newClient = mapper.Map<Client>(client);
        //{
        //    Id = client.Id,
        //    FirstName = client.FirstName,
        //    LastName = client.LastName,
        //    Fhone = client.Fhone,
        //    BirthDate = client.BirtDate,
        //    TypeMemberCode = client.IdTypeMember

        //};
        if (client.email != null)
        {
            newClient.Email = client.email;
        }
        var c = ClientBL.AddClient(newClient);
       
        return client;
    }

    public List<BLReturnClient> Clients()
    {
        var list = ClientBL.GetClients(); // מקבלת רשימת דל
        // בונה רשימת בי אל ריקה
        List<BLReturnClient> ClientList = new List<BLReturnClient>();
        list.ForEach(t => ClientList.Add(mapper.Map<BLReturnClient>(t)));
        return ClientList;

    }

    public BLsimpleClient deleteClientBL(BLsimpleClient client)
    {
        Client newClient = mapper.Map<Client>(client);
        var c = ClientBL.DeleteClient(newClient);
        return client;
    }

    public BLsimpleClient UppdateClientBL(BLsimpleClient client)
    {
        Client newClient = new Client()
        {
            Id = client.Id,
            FirstName = client.FirstName,
            LastName = client.LastName,
            Fhone = client.Fhone,
            BirthDate = client.BirtDate,
            TypeMemberCode = client.IdTypeMember

        };
        if (client.email != null)
        {
            newClient.Email = client.email;
        }
       
        var clientFromDal = ClientBL.UppdateClient(newClient);
        return client;

    }

    public List<BLschedule> GetAllTimeTriningBL(string nameOfTrining)
    {
        List<BLschedule> timeTraining = new List<BLschedule>();
        List<TimeTraining> timeFromDal = new List<TimeTraining>();
        timeFromDal = ClientBL.GetAllTimeTrining(nameOfTrining);
        timeFromDal.ForEach(t => timeTraining.Add(mapper.Map<BLschedule>(t)));
        return timeTraining;

    }
    //לקבל שם של אימון ולהחזיר את כל הלקוחות של האימון הזה
    public List<BLsimpleClient> GetAllAppointmentByIdBL(string idClient)
    {
        throw new NotImplementedException();
    }

    public BLsimpleClient GetClientById(string idClient)
    {
        var client = mapper.Map<BLsimpleClient>(ClientBL.GetAllAppointmentByIdDAL(idClient));
        if(client == null)
        {
            return null;
        }
        return client;
    }
}














