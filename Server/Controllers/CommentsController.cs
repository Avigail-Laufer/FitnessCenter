using BL.BLApi;
using BL;
using Microsoft.AspNetCore.Mvc;
using BL.Models;

namespace Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommentsController : Controller
    {
        ICommentsBL comments;
        public CommentsController(BlManager bl)
        {

            comments = bl.comment;
        }
        [HttpGet]
        public ActionResult<List<BLComments>> Get()=>
            comments.GetComments();
        [HttpPost]
        public ActionResult<BLComments> Post(BLComments c) => comments.AddComment(c);


    }
}
