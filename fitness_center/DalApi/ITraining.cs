﻿
using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.DalApi;

public interface ITraining
{
    public List<Training> GetAllTrainings();
    public List<Training> GetTrainingById();
    public Training? UpdateTraining(Training training);
    public Training? DeleteTraining(Training training);
}
