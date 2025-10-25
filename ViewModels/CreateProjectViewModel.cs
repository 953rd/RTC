using System.Collections.ObjectModel;
using ReactiveUI;
using RTC.Models;
using RTC.Services;

namespace RTC.ViewModels
{
    public class CreateProjectViewModel : ViewModelBase
    {
        private ObservableCollection<FormItem> _yourItems;
        private string _projectName;
        private string _projectDescription;
        private FormItem _selectedMonth;

        public CreateProjectViewModel()
        {
            var formDataService = new FormDataService();
            _yourItems = new ObservableCollection<FormItem>(formDataService.GetMonths());
        }

        public ObservableCollection<FormItem> YourItems
        {
            get => _yourItems;
            set => this.RaiseAndSetIfChanged(ref _yourItems, value);
        }

        public string ProjectName
        {
            get => _projectName;
            set => this.RaiseAndSetIfChanged(ref _projectName, value);
        }

        public string ProjectDescription
        {
            get => _projectDescription;
            set => this.RaiseAndSetIfChanged(ref _projectDescription, value);
        }

        public FormItem SelectedMonth
        {
            get => _selectedMonth;
            set => this.RaiseAndSetIfChanged(ref _selectedMonth, value);
        }
    }
}