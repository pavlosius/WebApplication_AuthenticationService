using Microsoft.AspNetCore.Mvc;

namespace WebApplication_AuthenticationService.Controllers
{
    [ApiController]
    [Route("controller")]
    public class UserController : ControllerBase
    {
        private ILogger _logger;
        public UserController(ILogger logger)
        {
            _logger = logger;

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

            UserViewModel userViewModel = new UserViewModel(user);

            return userViewModel;
        }
    }
}
