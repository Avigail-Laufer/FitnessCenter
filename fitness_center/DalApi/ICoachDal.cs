
using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.DalApi;

public interface ICoachDal
{
    public List<Coach> GetAllCoachDal();
    public Coach RemoveCoachDal(Coach coach);
    public Coach AddCoachDal(Coach coach);
    public Coach UpdateCoachDal(Coach coach);
    //האם פותחים ממש לכל אחד אינרפייס או רק שתיים ולפי מה
    //public List<Coach> GetAllCoachforThisTraining(string nameOfTraining);
    public List<TimeTraining> GetCoachWithAvailableTimes(int coachId);
    public Coach GetCoachContactInfo(string CoachId);
    public List<TimeTraining> AllDate();
    




}
