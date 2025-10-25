using ReactiveUI;

namespace RTC.Models
{
    public enum UserRole
    {
        Administrator,
        Analyst,
        User
    }

    public class User : ReactiveObject
    {
        private string _username = string.Empty;
        public string Username
        {
            get => _username;
            set => this.RaiseAndSetIfChanged(ref _username, value);
        }

        private string _password = string.Empty;
        public string Password
        {
            get => _password;
            set => this.RaiseAndSetIfChanged(ref _password, value);
        }

        private UserRole _role;
        public UserRole Role
        {
            get => _role;
            set => this.RaiseAndSetIfChanged(ref _role, value);
        }
    }
}
