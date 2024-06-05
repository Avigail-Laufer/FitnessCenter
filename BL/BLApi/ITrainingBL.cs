using BL.Models;
using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.BLApi;

public interface ITrainingBL
{
    public List<BLTrining>? getTriningsforday(string id, string day);
    public List<BLTrining> getAllTrainings();
    public List<Training> GetTrainingsByDay(string day);
    //public BLTrining deleteTraining(BLTrining);


}
