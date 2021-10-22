using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManager.Auth;
using TaskManager.Common;
using TaskManager.Core.Entities;
using TaskManager.Core.UsesCases.User;

namespace TaskManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ApiController
    {
        private readonly IUserInteractor _userInteractor;
        private readonly IJwtAuthenticationService _authService;

        public AuthController(IJwtAuthenticationService authService, IUserInteractor userInteractor)
        {
            _userInteractor = userInteractor ?? throw new ArgumentNullException(nameof(userInteractor));
            _authService = authService;
        }

        [HttpPost]
        public IActionResult Authenticate([FromBody] AuthInfo user)
        {
            var userInfo = _userInteractor.Login(user);
            if (userInfo == null)
                return Unauthorized();
            var token = _authService.Authenticate(userInfo.Id.ToString());
            if (token == null)
                return Unauthorized();
            return Ok(token);
        }
    }
}
