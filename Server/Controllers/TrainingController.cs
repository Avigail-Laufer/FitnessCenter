using BL.BLApi;
using BL.Models;
using BL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Server.Controllers;
[ApiController]
[Route("api/[controller]")]


public class TrainingController : ControllerBase
{
    ITrainingBL blTraining;
    public TrainingController(BlManager bl)
    {

        this.blTraining = bl.trining;
    }
    [HttpGet("{id}")]
    public List<BLTrining>? getgetTriningsforday(string id)
    {
     var list=   blTraining.GetTrainingsById(id);
        if (list == null)
            return null;
        return list;
    }

    [HttpGet]
    public List<BLTrining> getAllTrainings()=>blTraining.getAllTrainings();

}
