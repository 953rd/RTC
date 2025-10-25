using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System.Collections.ObjectModel; // для ObservableCollection<>
using RTC.ViewModels; // для DashboardViewModel
using RTC.Models;     // для Project и ProjectMetrics
using RTC.Services;   // для AuthService

namespace RTC.Views
{
    public partial class DashboardView : UserControl
    {
        public DashboardView()
        {
            InitializeComponent();
            DataContext = new DashboardViewModel(
                new ObservableCollection<Project>(), 
                new ObservableCollection<Project>(), 
                new ProjectMetrics(), 
                new AuthService()
            );
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}