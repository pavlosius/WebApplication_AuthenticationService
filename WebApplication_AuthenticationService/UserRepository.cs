namespace WebApplication_AuthenticationService
{
    public class UserRepository : IUserRepository
    {
        private readonly List<User> _users = new List<User>();

        public UserRepository()
        {
            _users.Add(new User()
            {
                Id = Guid.NewGuid(),
                FirstName = "Иван",
                LastName = "Иванов",
                Email = "ivan@gmail.com",
                Password = "11111122222qq",
                Login = "ivanov",
                Role = new Role()
                {
                    Id = 1,
                    Name = "Пользователь"
                }
            });

            _users.Add(new User()
            {
                Id = Guid.NewGuid(),
                FirstName = "BB",
                LastName = "BBB",
                Email = "B@gmail.com",
                Password = "22",
                Login = "B",
                Role = new Role()
                {
                    Id = 2,
                    Name = "Администратор"
                }
            });

            _users.Add(new User()
            {
                Id = Guid.NewGuid(),
                FirstName = "CC",
                LastName = "CCC",
                Email = "C@gmail.com",
                Password = "33",
                Login = "C",
                Role = new Role()
                {
                    Id = 1,
                    Name = "Пользователь"
                }
            });
        }
        public IEnumerable<User> GetAll()
        {
            return _users;
        }

        public User GetByLogin(string login)
        {
            return _users.FirstOrDefault(user => user.Login.Equals(login, StringComparison.OrdinalIgnoreCase));
        }
    }
}
