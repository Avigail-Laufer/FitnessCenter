using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Models;

public class BLCoach
{
    public string Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; } 

    public decimal SalaryForHower { get; set; }

    public int Age { get; set; }

    public string Fhone { get; set; } 

    public string? Email { get; set; }
//האם זה טוב לעשות פה קונסטרקטור?
    public BLCoach(Coach c) { 
        Id = c.Id;
        FirstName = c.FirstName;
        LastName = c.LastName;
        SalaryForHower = c.SalaryForHower;
        Age = c.Age;
        Email = c.Email;
        SalaryForHower = c.SalaryForHower;
        
    }
    public BLCoach()
    {
       

    }

}
