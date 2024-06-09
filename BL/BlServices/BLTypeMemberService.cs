using AutoMapper;
using BL.BLApi;
using BL.Models;
using Dal;
using Dal.DalApi;
using fitness_center;
using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.BlServices
{
    public class BLTypeMemberService : ITypeMemberBL
    {
        ITypeMember typeMember;
        IMapper mapper;
        public BLTypeMemberService(DalManager dal) {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());
            mapper = config.CreateMapper();
            typeMember = dal.TypeMember;
        }
        public List<BLtypeMember> GettypeMembers()
        {
            var list = typeMember.Get(); // מקבלת רשימת דל
            if (list != null)
            {                               // בונה רשימת בי אל ריקה
                List<BLtypeMember> TYList = new List<BLtypeMember>();
                list.ForEach(t => TYList.Add(mapper.Map<BLtypeMember>(t)));
                return TYList;
            }
            return null;
        }
    }
}
