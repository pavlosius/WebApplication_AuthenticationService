using System.Net.Mail;
using WebApplication_AuthenticationService.BLL.Models;

namespace WebApplication_AuthenticationService.BLL.ViewModels
{
    public class UserViewModel
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public bool FromRussia { get; set; }

        public UserViewModel(User user)
        {
            Id = user.Id;
            FullName = GetFullName(user.FirstName, user.LastName);
            FromRussia = GetFromRussiaValue(user.Email);
        }


        public string GetFullName(string firstName, string lastName)
        {
            return string.Concat(firstName, " ", lastName);
        }

        public bool GetFromRussiaValue(string email)
        {
            MailAddress mailAddress = new MailAddress(email);

            if (mailAddress.Host.Contains(".ru"))
                return true;
            return false;
        }
    }
}
