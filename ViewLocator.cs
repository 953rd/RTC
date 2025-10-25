using Avalonia.Controls;
using Avalonia.Controls.Templates;
using RTC.ViewModels;
using RTC.Views;
using System;

namespace RTC
{
    public class ViewLocator : IDataTemplate
    {
        public Control Build(object data)
        {
            if (data is null)
                return new TextBlock { Text = "Data is null" };

            Control control;

            if (data is AuthViewModel)
            {
                control = new LoginView();
            }
            else if (data is DashboardViewModel)
            {
                control = new DashboardView();
            }
            else if (data is MainWindowViewModel)
            {
                control = new DashboardView();
            }
            else
            {
                control = new TextBlock { Text = $"Not Found: {data.GetType().Name}" };
            }

            control.DataContext = data;
            return control;
        }

        public bool Match(object data)
        {
            return data is ViewModelBase;
        }
    }
}