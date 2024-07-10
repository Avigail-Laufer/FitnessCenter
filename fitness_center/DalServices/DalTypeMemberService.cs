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
       BlogsSiteContext _fitnessCenter;
        public DalTypeMemberService(BlogsSiteContext _fitnessCenter)
        {
            this._fitnessCenter = _fitnessCenter;
        }

        #region basic func
        public List<TypeMember> Get()=> _fitnessCenter.TypeMembers.ToList();
        #endregion

    }
}
