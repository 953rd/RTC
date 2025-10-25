using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using ReactiveUI;
using RTC.Models;
using RTC.Services;

namespace RTC.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly IDataService _dataService;
        private readonly IAnalysisService _analysisService;
        
        private ProjectMetrics _currentMetrics;
        private ObservableCollection<Project> _projects;
        private ObservableCollection<Project> _projectsAtRisk;


        public MainWindowViewModel()
        {
            _dataService = new DataService();
            _analysisService = new AnalysisService(_dataService);
            _projects = new ObservableCollection<Project>();
            _projectsAtRisk = new ObservableCollection<Project>();
            _currentMetrics = new ProjectMetrics();


            InitializeAsync();

        }

        private async void InitializeAsync()
        {
            await LoadDataAsync();
        }

        public async Task LoadDataAsync()
        {
            var projects = await _dataService.GetProjectsAsync();
            Projects = new ObservableCollection<Project>(projects);
            
            var metrics = await _analysisService.CalculateCurrentMetricsAsync();
            CurrentMetrics = metrics;
            
            var atRiskProjects = await _analysisService.FindProjectsAtRiskAsync();
            ProjectsAtRisk = new ObservableCollection<Project>(atRiskProjects);
        }

        public ProjectMetrics CurrentMetrics
        {
            get => _currentMetrics;
            set => this.RaiseAndSetIfChanged(ref _currentMetrics, value);
        }

        public ObservableCollection<Project> Projects
        {
            get => _projects;
            set => this.RaiseAndSetIfChanged(ref _projects, value);
        }

        public ObservableCollection<Project> ProjectsAtRisk
        {
            get => _projectsAtRisk;
            set => this.RaiseAndSetIfChanged(ref _projectsAtRisk, value);
        }

    }
}