using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace RTC.Views
{
    public partial class CreateProject : Window
    {
        public CreateProject()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}