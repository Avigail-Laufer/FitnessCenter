using BL.BLApi;
using BL.BlServices;
using BL.BO;
using BL.Models;
using fitness_center;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication.ExtendedProtection;
using System.Text;
using System.Threading.Tasks;

namespace BL;

public class BlManager
{
    public IClientBL client { get;set; }
    public ICoachBL coach { get; set; }
    public IAppointmentBL Appointment { get; set; }
    public ISchduleBL schedule { get; set; }
    public ITrainingBL trining { get; set; }

    public BlManager() {
        ServiceCollection services = new ServiceCollection();
        services.AddSingleton<DalManager>();
        services.AddScoped<IClientBL,BLClientService>();
        services.AddScoped<ICoachBL, BLCoachService>();
        services.AddScoped<IAppointmentBL, BLAppintmentServices>();
        services.AddScoped<ISchduleBL, BLSchduleSevices>();
        services.AddScoped<ITrainingBL,BLTriningService>();
        ServiceProvider Provider = services.BuildServiceProvider();
        client = Provider.GetService<IClientBL>();
        coach = Provider.GetService<ICoachBL>();
        Appointment = Provider.GetService<IAppointmentBL>();
        schedule=Provider.GetService<ISchduleBL>();
        trining = Provider.GetService<ITrainingBL>();
        
    }
}
