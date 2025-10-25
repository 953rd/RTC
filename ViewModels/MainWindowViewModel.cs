using System;
using System.Collections.ObjectModel;
using System.Reactive;    // для Unit
using System.Reactive.Linq; // для IObservable, Observable
using ReactiveUI;         // для ReactiveCommand, ViewModelBase
using RTC.Models;
using RTC.Services;

namespace RTC.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly IDataService _dataService;
        private readonly IAnalysisService _analysisService;
        private readonly AuthService _authService;

        private ViewModelBase _currentContent;
        private bool _isAuthenticated;

        public ViewModelBase CurrentContent
        {
            get => _currentContent;
            set => this.RaiseAndSetIfChanged(ref _currentContent, value);
        }

        public MainWindowViewModel()
        {
            _authService = new AuthService();
            _dataService = new DataService();
            _analysisService = new AnalysisService(_dataService);

            ShowLoginView();
        }

        private void ShowLoginView()
        {
            var loginVm = new AuthViewModel(_authService);
            loginVm.LoginSucceeded += OnLoginSuccessful;
            CurrentContent = loginVm;
            _isAuthenticated = false;
        }

        private void OnLoginSuccessful()
        {
            _isAuthenticated = true;
            
            var dashboardVm = new DashboardViewModel(
                new ObservableCollection<Project>(),
                new ObservableCollection<Project>(),
                new ProjectMetrics(),
                _authService
            );

            // Подписываемся на событие выхода из дашборда
            dashboardVm.LogoutSucceeded += OnLogoutFromDashboard;

            CurrentContent = dashboardVm;
        }

        private void OnLogoutFromDashboard()
        {
            // Эта логика выполняется при выходе из дашборда
            _authService.Logout();
            ShowLoginView();
        }
    }
}