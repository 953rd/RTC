using System;
using System.Collections.ObjectModel;
using System.Reactive;    // для Unit
using System.Reactive.Linq; // для IObservable, Observable
using ReactiveUI;         // для ReactiveCommand, ViewModelBase
using RTC.Models;
using RTC.Services;

namespace RTC.ViewModels
{
    public class DashboardViewModel : ViewModelBase
    {
        private readonly AuthService _authService;

        public ObservableCollection<Project> Projects { get; }
        public ObservableCollection<Project> ProjectsAtRisk { get; }
        public ProjectMetrics CurrentMetrics { get; }

        public ReactiveCommand<Unit, Unit> LogoutCommand { get; }

        public event Action? LogoutSucceeded;

        public string CurrentRole => _authService.CurrentUser?.Role.ToString() ?? "Гость";
        public bool CanManageUsers => _authService.CurrentUser?.Role == UserRole.Administrator;
        public bool CanViewReports => _authService.CurrentUser?.Role is UserRole.Analyst or UserRole.Administrator;

        public DashboardViewModel(
            ObservableCollection<Project> projects,
            ObservableCollection<Project> projectsAtRisk,
            ProjectMetrics metrics,
            AuthService authService)
        {
            Projects = projects;
            ProjectsAtRisk = projectsAtRisk;
            CurrentMetrics = metrics;
            _authService = authService;

            // Используем тот же подход, что и для входа
            LogoutCommand = ReactiveCommand.CreateFromObservable(ExecuteLogoutObservable);
        }

        private IObservable<Unit> ExecuteLogoutObservable()
        {
            return Observable.Start(() =>
            {
                _authService.Logout();
                LogoutSucceeded?.Invoke();
                return Unit.Default;
            }).ObserveOn(RxApp.MainThreadScheduler);
        }

        public DashboardViewModel() : this(
            new ObservableCollection<Project>(),
            new ObservableCollection<Project>(),
            new ProjectMetrics(),
            new AuthService())
        {
        }
    }
}