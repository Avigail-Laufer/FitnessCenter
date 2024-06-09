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
    public class BLCommentService : ICommentsBL
    {
        IComments comments;
        IMapper mapper;
       public BLCommentService(DalManager dal)
        {

            comments = dal.comment;
                var config = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());
                mapper = config.CreateMapper();

            

        }

        public BLComments AddComment(BLComments c)
        {
            comments.AddComment(mapper.Map<Comment>(c));
            return c;
        }

        public List<BLComments> GetComments()
        {
            List<Comment>list =comments.GetComments();
            if (list != null)
            {
                List<BLComments> newComments = new List<BLComments>();
                list.ForEach(t => newComments.Add(mapper.Map<BLComments>(t)));
                return newComments;
            }
            return null;

        }
    }
}
