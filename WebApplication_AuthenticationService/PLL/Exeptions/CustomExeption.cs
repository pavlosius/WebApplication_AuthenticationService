namespace WebApplication_AuthenticationService.PLL.Exeptions
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
