using Dal.DalApi;
using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.DalServices
{
    internal class DalTypeMemberService : ITypeMember
    {
        FitnessCenterContext _fitnessCenter;
        public DalTypeMemberService(FitnessCenterContext _fitnessCenter)
        {
            this._fitnessCenter = _fitnessCenter;
        }
        public List<TypeMember> Get()=> _fitnessCenter.TypeMembers.ToList();
        
    }
}
