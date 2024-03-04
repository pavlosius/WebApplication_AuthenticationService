using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Security.Authentication;

namespace WebApplication_AuthenticationService.Controllers
{
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
        public User GetUser()
        {
            return new User()
            {
                Id = Guid.NewGuid(),
                FirstName = "Иван",
                LastName = "Иванов",
                Email = "ivan@gmail.com",
                Password = "11111122222qq",
                Login = "ivanov"
            };
        }

        [HttpGet]
        [Route("viewmodel")]
        public UserViewModel GetUserViewModel()
        {
            //User user = new User()
            //{
            //    Id = Guid.NewGuid(),
            //    FirstName = "Иван",
            //    LastName = "Иванов",
            //    Email = "ivan@gmail.com",
            //    Password = "11111122222qq",
            //    Login = "ivanov"
            //};

            User user = GetUser();

            var userViewModel = _mapper.Map<UserViewModel>(user);

            //UserViewModel userViewModel = new UserViewModel(user);

            return userViewModel;
        }

        [HttpPost]
        [Route("authenticate")]
        public UserViewModel Authenticate(string login, string password)
        {
            if (String.IsNullOrEmpty(login) || String.IsNullOrEmpty(password))
                throw new ArgumentNullException("Запрос не корректен");

            User user = _userRepository.GetByLogin(login);

            if (user is null)
                throw new AuthenticationException("Пользователь на найден");

            if (user.Password != password)
                throw new AuthenticationException("Введенный пароль не корректен");

            return _mapper.Map<UserViewModel>(User);

        }
    }
}
