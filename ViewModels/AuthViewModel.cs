using System;
using System.Reactive;
using System.Reactive.Linq;
using System.Threading.Tasks;
using Avalonia.Threading;
using ReactiveUI;
using RTC.Models;
using RTC.Services;

namespace RTC.ViewModels
{
    public class AuthViewModel : ViewModelBase
    {
        private string _username = string.Empty;
        private string _password = string.Empty;
        private string _error = string.Empty;

        private readonly AuthService _authService;

        public event Action? LoginSucceeded;

        public string Username
        {
            get => _username;
            set => this.RaiseAndSetIfChanged(ref _username, value);
        }

        public string Password
        {
            get => _password;
            set => this.RaiseAndSetIfChanged(ref _password, value);
        }

        public string Error
        {
            get => _error;
            set => this.RaiseAndSetIfChanged(ref _error, value);
        }

        public ReactiveCommand<Unit, Unit> LoginCommand { get; }

        public AuthViewModel(AuthService authService)
        {
            _authService = authService;

            var canLogin = this.WhenAnyValue(
                x => x.Username,
                x => x.Password,
                (u, p) => !string.IsNullOrWhiteSpace(u) && !string.IsNullOrWhiteSpace(p)
            );

            // Используем ObserveOn для принудительного переключения на UI поток
            LoginCommand = ReactiveCommand.CreateFromObservable(ExecuteLoginObservable, canLogin);
        }

        private IObservable<Unit> ExecuteLoginObservable()
        {
            return Observable.StartAsync(ExecuteLoginAsync)
                .ObserveOn(RxApp.MainThreadScheduler);
        }

        private async Task<Unit> ExecuteLoginAsync()
        {
            if ((Username == "admin" && Password == "admin") ||
                (Username == "analyst" && Password == "analyst") ||
                (Username == "user" && Password == "user"))
            {
                _authService.Login(new User
                {
                    Username = Username,
                    Role = Username switch
                    {
                        "admin" => UserRole.Administrator,
                        "analyst" => UserRole.Analyst,
                        _ => UserRole.User
                    }
                });

                Error = string.Empty;
                LoginSucceeded?.Invoke();
            }
            else
            {
                Error = "Неверное имя пользователя или пароль";
            }

            return Unit.Default;
        }
    }
}