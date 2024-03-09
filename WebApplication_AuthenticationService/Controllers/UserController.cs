using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Authentication;
using System.Security.Claims;

namespace WebApplication_AuthenticationService.Controllers
{
    [ExeptionHandler]
    [ApiController]
    [Route("controller")]
    public class UserController : ControllerBase
    {
        private ILogger _logger;
        private IMapper _mapper;
        private IUserRepository _userRepository;

        public UserController(ILogger logger, IMapper mapper, IUserRepository userRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _userRepository = userRepository;

            logger.WriteEvent("Сообщение о событии в программе");
            logger.WriteError("Сообщение об ошибке в программе");

        }

        [HttpGet]
        public User GetUser(string login)
        {
            var user = _userRepository.GetByLogin(login);

            return user;

            //return new User()
            //{
            //    Id = Guid.NewGuid(),
            //    FirstName = "Иван",
            //    LastName = "Иванов",
            //    Email = "ivan@gmail.com",
            //    Password = "11111122222qq",
            //    Login = "ivanov"
            //};
        }

        [Authorize(Roles = "Администратор")]
        [HttpGet]
        [Route("viewmodel")]
        public UserViewModel GetUserViewModel(string login)
        {
            User user = GetUser(login);

            var userViewModel = _mapper.Map<UserViewModel>(user);

            //UserViewModel userViewModel = new UserViewModel(user);

            return userViewModel;
        }

        [HttpPost]
        [Route("authenticate")]
        public async Task<UserViewModel> Authenticate(string login, string password)
        {
            if (String.IsNullOrEmpty(login) || String.IsNullOrEmpty(password))
                throw new ArgumentNullException("Запрос не корректен");

            User user = _userRepository.GetByLogin(login);

            if (user is null)
                throw new AuthenticationException("Пользователь на найден");

            if (user.Password != password)
                throw new AuthenticationException("Введенный пароль не корректен");

            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType,user.Login),

                new Claim(ClaimsIdentity.DefaultRoleClaimType,user.Role.Name)
            };

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(
                claims,
                "AppCookie",
                ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

            //return _mapper.Map<UserViewModel>(User);
            var userViewModel = _mapper.Map<UserViewModel>(user);

            return userViewModel;
        }
    }
}
