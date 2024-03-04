using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication_AuthenticationService.Controllers
{
    [ApiController]
    [Route("controller")]
    public class UserController : ControllerBase
    {
        private ILogger _logger;
        private IMapper _mapper;

        public UserController(ILogger logger, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;

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
    }
}
