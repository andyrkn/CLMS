using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using CLMS.Users.Bussines;

namespace CLMS.Users.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        [HttpGet]
        public ActionResult<IEnumerable<string>> GetAll()
        {
            return new string[] {};
        }
        
        [HttpPost]
        public void Add([FromBody] UserModel user)
        {

        }

    }
}
