using Dal.DalApi;
using Microsoft.EntityFrameworkCore;
using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.DalServices;

public class DalSighnToService:ISighnToDal
{

    FitnessCenterContext _fitnessCenter;
    public DalSighnToService(FitnessCenterContext _fitnessCenter)
    {
        this._fitnessCenter = _fitnessCenter;
    }


    public List<SignTo> GetTimes()
    {
        return _fitnessCenter.SignTos
        .Include(t => t.CodeDateNavigation)
        .ThenInclude(t => t.CoachForTrainingCodeNavigation)
        .ThenInclude(t => t.CodeTrainingNavigation)
        .ToList();
    }

    
}
