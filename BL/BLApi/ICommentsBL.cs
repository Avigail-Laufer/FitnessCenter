using BL.Models;
using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.BLApi
{
    public interface ICommentsBL
    {
        public List<BLComments> GetComments();
        public BLComments AddComment(BLComments c);
    }
}
