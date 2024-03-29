using BL.BlServices;
using BL.BO;
using BL.Models;
using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.BLApi;

public interface IClientBL
{
    public List<BLReturnClient> Clients();
    public BLsimpleClient AddClientBL(BLsimpleClient client);
    public BLsimpleClient deleteClientBL(BLsimpleClient client);
    public List<BLschedule> GetAllTimeTriningBL(string nameOfTrining);
    public BLsimpleClient UppdateClientBL(BLsimpleClient client);
    public List<BLsimpleClient> GetAllAppointmentByIdBL(string idClient);

}
