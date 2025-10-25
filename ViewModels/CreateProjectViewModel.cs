using System.Collections.ObjectModel;
using ReactiveUI;
using RTC.Models;
using RTC.Services;

namespace RTC.ViewModels
{
    public class CreateProjectViewModel : ViewModelBase
    {
        private ObservableCollection<FormItem> _yourItems;
        private string? _projectName; // сделать nullable
        private string? _projectDescription; // сделать nullable
        private string? _selectedMonth;

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

        public string? ProjectName // сделать nullable
        {
            get => _projectName;
            set => _projectName = value;
        }

         public string? ProjectDescription // сделать nullable
        {
            get => _projectDescription;
            set => _projectDescription = value;
        }

        public string? SelectedMonth // сделать nullable
        {
            get => _selectedMonth;
            set => _selectedMonth = value;
        }
    }
}