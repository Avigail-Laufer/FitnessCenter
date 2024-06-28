using Dal.DalApi;
using Dal.DalServices;
using Microsoft.Extensions.DependencyInjection;
using Server.Models;

namespace fitness_center;

public class DalManager
{
    public IClientDal Clients { get; }
    public ICoachDal Coaches { get; }
    public ICoachForTraining CoachForTrainings { get; }
    public ITraining Trainings { get; }
    public IAppointment Appointmemt { get; set; }
    public ISchedule Schedule { get; set; }
    public ISighnToDal sighnTo { get; set; }
    public ITypeMember TypeMember { get; set; }
    public IComments comment { get; set; }
    public ICreditCard card { get; set; }
    public DalManager() {
        ServiceCollection services = new ServiceCollection();
        services.AddSingleton<BlogsSiteContext>();
        // מוסיפים לאוסף את אוביקט ממחלקות השרות
        services.AddSingleton<IClientDal,DalClientService>();
        services.AddSingleton<ICoachDal, DalCoachService>();
        services.AddSingleton<ICoachForTraining, DalCoachForTrainingService>();
        services.AddSingleton<ITraining, DalTrainingService>();
        services.AddScoped<IAppointment, DalAppointmentService>();
        services.AddScoped<ISchedule, DalScheduleService>();
        services.AddScoped<ISighnToDal, DalSighnToService>();
        services.AddScoped<ITypeMember, DalTypeMemberService>();
        services.AddScoped<IComments, DalCommentsService>();
        services.AddScoped<ICreditCard, DalCreditCardService>();
        ServiceProvider Provider = services.BuildServiceProvider();
        Clients = Provider.GetService<IClientDal>();
        Coaches = Provider.GetService<ICoachDal>();
        CoachForTrainings = Provider.GetService<ICoachForTraining>();
        Trainings = Provider.GetService<ITraining>();
        Appointmemt = Provider.GetService<IAppointment>();
        Schedule= Provider.GetService<ISchedule>();
        sighnTo = Provider.GetService<ISighnToDal>();
        TypeMember= Provider.GetService<ITypeMember>();
        comment = Provider.GetService<IComments>();
        card = Provider.GetService<ICreditCard>();
    }

}