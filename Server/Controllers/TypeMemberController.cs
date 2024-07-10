using BL.BLApi;
using BL;
using Microsoft.AspNetCore.Mvc;
using BL.Models;

namespace Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TypeMemberController : Controller
{

    ITypeMemberBL typemember;
    public TypeMemberController(BlManager bl)
    {

        this.typemember = bl.TypeMember;
    }

    #region Get
    [HttpGet]
    public ActionResult <List<BLtypeMember>> Get()=>typemember.GettypeMembers();
    #endregion





}
