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

namespace BL.BlServices;

public class BLClientService : IClientBL
{
    IClientDal ClientBL;

    public BLClientService(DalManager dal)
    {
        ClientBL = dal.Clients;
    }

    public BLsimpleClient AddClientBL(BLsimpleClient client)
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
        var c = ClientBL.AddClient(newClient);
       
        return client;
    }

    public List<BLReturnClient> Clients()
    {
        var list = ClientBL.GetClients(); // מקבלת רשימת דל
        // בונה רשימת בי אל ריקה
        List<BLReturnClient> ClientList = new List<BLReturnClient>();
        // עוברת על רשימת הדל 
        foreach (var c in list)
        {// עבור כל אחד יוצרת בי אל חדש
            var newClient = new BLReturnClient()
            {
                Id = c.Id.ToString(),
                FirstName = c.FirstName.ToString(),
                LastName = c.LastName.ToString(),
                Fhone = c.Fhone.ToString(),
                // typeMember = TypeMember(c.TypeMemberCode.ToString()),
                Years = DateTime.Now.Year - c.BirthDate.Year,
                Type = c.TypeMemberCodeNavigation.Type,
                MonthlyPayment = c.TypeMemberCodeNavigation.MonthlyPayment

            };
            if (c.Email != null)
            {
                newClient.email = c.Email;
            }
            // מוסיפה לרשימה
            ClientList.Add(newClient);
        }
        return ClientList;

    }

    public BLsimpleClient deleteClientBL(BLsimpleClient client)
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
        foreach (var t in timeFromDal)
        {
            var time = new BLschedule(t);
            


            timeTraining.Add(time);

        }
        return timeTraining;

    }
    //לקבל שם של אימון ולהחזיר את כל הלקוחות של האימון הזה
    public List<BLsimpleClient> GetAllAppointmentByIdBL(string idClient)
    {
        throw new NotImplementedException();
    }
}














