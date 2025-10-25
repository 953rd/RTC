using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace RTC.Views
{
    public partial class CreateUser : Window
    {
        public CreateUser()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            // Возврат на главное окно
            var mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            // Возврат на главное окно
            var mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void CreateUserButton_Click(object sender, RoutedEventArgs e)
        {
            // TODO: Логика создания пользователя
            // Временно показываем сообщение и возвращаемся на главную
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
            
            // Возврат на главное окно
            var mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}