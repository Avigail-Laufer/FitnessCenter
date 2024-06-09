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
   BlogsSiteContext _fitnessCenter;
    public DalAppointmentService(BlogsSiteContext fitnessCenter)
    {
        _fitnessCenter = fitnessCenter;    
    }

    public SignTo addApointment(SignTo signTo)
    {
        _fitnessCenter.SignTos.Add(signTo);
        _fitnessCenter.SaveChanges();
        return signTo; 


    }

    public List<SignTo> GetAllAppointmentByIdBL()
    {
        return _fitnessCenter.SignTos
        .Include(t => t.CodeDateNavigation)
        .ThenInclude(t => t.CoachForTrainingCodeNavigation)
        .ThenInclude(t => t.CodeTrainingNavigation)
        .ToList();
    }

    public SignTo RemoveApointment(SignTo signTo)
    {
        _fitnessCenter.SignTos.Remove(signTo);
        _fitnessCenter.SaveChanges();
        return signTo;
    }
}
