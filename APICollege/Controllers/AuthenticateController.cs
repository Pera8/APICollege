using Microsoft.AspNetCore.Mvc;
using Service;
using Share.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APICollege.Controllers
{
    [Route("api/Authenticate")]
    public class AuthenticateController : Controller
    {
        private readonly AuthenticateService authenticateService;

        public AuthenticateController(AuthenticateService authenticateService)
        {
            this.authenticateService = authenticateService;
        }

        [HttpPost("Register")]
        public async Task<ActionResult> RegisterUser(RegisterUser registerUser)
        {
            var result = await authenticateService.RegisterUserAuth(registerUser);
            return Ok(result);
        }

        [HttpPost("Login")]
        public async Task<ActionResult> LoginUser(LoginUser loginUser)
        {
            var result = await authenticateService.LoginUser(loginUser);
            return Ok(result);
        }
    }
}
