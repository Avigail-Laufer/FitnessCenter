using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Models;

public  class BLschedule
{
    public int Id { get; set; }
    public string Day { get; set; }

    public TimeSpan Time { get; set; }

    public int? NumberRoom { get; set; }
    public BLschedule(TimeTraining t)
    {
        Id= t.Id;
        Day = t.Day;
        Time = t.Time;
        NumberRoom = t.NumberRoom;


    }

}
