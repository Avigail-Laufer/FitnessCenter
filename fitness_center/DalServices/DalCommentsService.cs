using Dal.DalApi;
using Microsoft.EntityFrameworkCore;
using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.DalServices
{
    public class DalCommentsService:IComments
    {
        BlogsSiteContext _fitnessCenter;
        public DalCommentsService(BlogsSiteContext _fitnessCenter)
        {
            this._fitnessCenter = _fitnessCenter;
        }
        #region basic func

        public List<Comment> GetComments() => _fitnessCenter.Comments.Include(c=>c.IdClientNavigation).ToList();
        public Comment AddComment(Comment c)
        {
            _fitnessCenter.Comments.Add(c);
            _fitnessCenter.SaveChanges();
            return c;
        }
        #endregion


    }
}
