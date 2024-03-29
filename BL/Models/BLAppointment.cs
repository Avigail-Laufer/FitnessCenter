
using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.BO;

public class BLAppointment
{
    public string Day { get; set; }
    public TimeSpan Time { get; set; } 
    public int? NumberRoom { get; set; }
    public string NameTrining { get; set; }

    public BLAppointment(SignTo s)
    {
        Day = s.CodeDateNavigation.Day;
        Time = s.CodeDateNavigation.Time;
        NumberRoom = s.CodeDateNavigation.NumberRoom;
        NameTrining = s.CodeDateNavigation.CoachForTrainingCodeNavigation.CodeTrainingNavigation.Name;



    }

}
