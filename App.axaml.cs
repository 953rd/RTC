using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Avalonia.Styling;
using Avalonia.Threading;
using ReactiveUI;
using RTC.ViewModels;
using RTC.Views;

namespace RTC
{
    public partial class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            // Настройка планировщиков ReactiveUI для Avalonia 11+
            // В новых версиях Avalonia это настраивается автоматически
            
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                DataTemplates.Add(new ViewLocator());
                RequestedThemeVariant = ThemeVariant.Light;
                
                desktop.MainWindow = new MainWindow
                {
                    DataContext = new MainWindowViewModel()
                };
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}