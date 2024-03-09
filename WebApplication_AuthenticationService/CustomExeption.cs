namespace WebApplication_AuthenticationService
{
    public class CustomExeption : Exception
    {
        private string _message;
        public CustomExeption(string message)
        {
            _message = message;
        }
    }
}
