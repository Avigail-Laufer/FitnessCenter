using BL;
using BL.BLApi;
using BL.BlServices;
using BL.BO;
using BL.Models;
using fitness_center;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientController : ControllerBase
{
  
    IClientBL blClient;
    public ClientController(BlManager bl)
    {
       
        this.blClient = bl.client;
    }
    [HttpGet]
    public List<BLReturnClient> GetClient() => blClient.Clients();
    [HttpPost]
    public BLsimpleClient Add(BLsimpleClient client) =>blClient.AddClientBL(client);
    [HttpDelete]
    public BLsimpleClient delete(BLsimpleClient client)=>blClient.deleteClientBL(client);
    [HttpGet("{nameOfTrining}")]
    public List<BLschedule> GetAllTimeTrining(string nameOfTrining) 
    {
        List<BLschedule> list= blClient.GetAllTimeTriningBL(nameOfTrining);
        if (list == null)
        {
            return null;
        }
        return list;
    }
    //public BLsimpleClient UppdateClientBL(BLsimpleClient client);
    //[HttpGet]
    //public List<BLsimpleClient> GetAllAppointmentByIdBL(string idClient);


















}










