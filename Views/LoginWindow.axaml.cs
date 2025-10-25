using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using RTC.Models;
using RTC.Services;
using RTC.ViewModels;

namespace RTC.Views
{
    public partial class LoginView : UserControl
    {
        public LoginView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}