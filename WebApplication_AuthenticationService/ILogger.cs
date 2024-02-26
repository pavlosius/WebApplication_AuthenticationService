namespace WebApplication_AuthenticationService
{
    public interface ILogger
    {
        void WriteEvent(String eventMessage);
        void WriteError(String errorMessage);
    }
}
