using Dal.DalApi;
using Microsoft.EntityFrameworkCore;
using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.DalServices;

internal class DalAppointmentService : IAppointment
{
    FitnessCenterContext _fitnessCenter;
    public DalAppointmentService(FitnessCenterContext fitnessCenter)
    {
        _fitnessCenter = fitnessCenter;    
    }
    public List<SignTo> GetAllAppointmentByIdBL()
    {
        return _fitnessCenter.SignTos
        .Include(t => t.CodeDateNavigation)
        .ThenInclude(t => t.CoachForTrainingCodeNavigation)
        .ThenInclude(t => t.CodeTrainingNavigation)
        .ToList();
    }
}
