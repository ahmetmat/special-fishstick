using DTO;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace demo01.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            this.context = context;
            _logger = logger;
        }

        [UserAuthentication]
        [UserAuthorization]
        [HttpGet]
        public IActionResult Get()
        {
            var users = context.users.Select(p => UserToDTO(p)).ToList();
            return Ok(users);
        }

        [UserAuthentication]
        [UserAuthorization]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var users = context.users.ToList();
            var user = users.FirstOrDefault(u => u.Id == id);

            if (user == null)
            {
                return NotFound("Kullanıcı bulunamadı");
            }
            return Ok(user);
        }

        [UserAuthorization]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] userDto model)
        {
            var user = context.users.FirstOrDefault(u => u.Id == id);

            if (user == null)
            {
                return NotFound("Kullanıcı bulunamadı");
            }

            var validationResult = UserDtoValidator(model);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            if (id == 15)
            {
                return BadRequest("Bu kullanıcıya erişemezsiniz");
            }

            if (!string.IsNullOrEmpty(model.Username))
            {
                user.Username = model.Username;
            }
            if (!string.IsNullOrEmpty(model.Email))
            {
                user.Email = model.Email;
            }
            if (!string.IsNullOrEmpty(model.Password))
            {
                user.Password = model.Password;
            }
            if (model.Yas != null)
            {
                user.yas = model.Yas;
            }

            context.SaveChanges();

            return Ok("Kullanıcı bilgileri başarıyla güncellendi.");
        }

        [UserAuthorization]
        [HttpPost]
        public IActionResult Post([FromBody] userDto model)
        {
            var validationResult = UserDtoValidator(model);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var newUser = new Users
            {
                Username = model.Username,
                Email = model.Email,
                Password = model.Password,
                yas = model.Yas,
                roles = model.Roles
            };

            context.users.Add(newUser);
            context.SaveChanges();

            return Ok("Yeni kullanıcı başarıyla oluşturuldu.");
        }

        [UserAuthorization]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var user = context.users.FirstOrDefault(u => u.Id == id);

            if (user == null)
            {
                return NotFound("Kullanıcı bulunamadı");
            }

            context.users.Remove(user);
            context.SaveChanges();

            return Ok("Kullanıcı başarıyla silindi.");
        }

        private ValidationResult UserDtoValidator(userDto model)
        {
            var validator = new UserDtoValidator();
            return validator.Validate(model);
        }

        private static userDto UserToDTO(Users p)
        {
            return new userDto()
            {
                Id = p.Id,
                Username = p.Username,
                Email = p.Email,
                Password = p.Password,
                Yas = p.yas,
                Roles = p.roles
            };
        }
    }
}
