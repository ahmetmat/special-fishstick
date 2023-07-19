using System;
using Microsoft.AspNetCore.Mvc;
using DTO;

namespace demo01.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
	{
        private readonly ApplicationDbContext context;

        public AuthController(ApplicationDbContext context)
		{
            this.context = context;
		}
        [HttpPost]
        public void Login(LoginDto loginDto)
        {
            var user = context.users.Where(u => u.Username == loginDto.Username)
                .Where(u => u.Password == loginDto.Password).FirstOrDefault();

            if(user is null)
            {
                throw new Exception("Hatalı giriş bilgileri!");
            }
            HttpContext.Session.SetString("userId",user.Id.ToString());
             
        }
	}
}

