using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace RTC.Views
{
    public partial class CreateUserWindow : Window
    {
        public CreateUserWindow()
        {
            this.InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void CreateUserButton_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new Window()
            {
                Title = "Создание пользователя",
                Width = 400,
                Height = 200,
                Content = new TextBlock 
                { 
                    Text = "Пользователь успешно создан!", 
                    HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Center,
                    VerticalAlignment = Avalonia.Layout.VerticalAlignment.Center
                }
            };
            dialog.ShowDialog(this);
            
            var mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}