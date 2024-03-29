
using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.DalApi;

public interface IClientDal
{
    public List<Client> GetClients();

    public Client AddClient(Client client);

    public Client? GetAllAppointmentByIdDAL(string id);

    public Client? DeleteClient(Client client);

    public List<TimeTraining> GetAllTimeTrining(string nameOfTrining);

    public Client UppdateClient(Client client);
}
