using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using System;

namespace RTC.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CreateProjectButton_Click(object sender, RoutedEventArgs e)
        {
            // Открываем окно создания проекта
            var createProjectWindow = new CreateProject();
            createProjectWindow.Show();
            this.Close(); // Закрываем текущее окно, если нужно
        }

        private void CreateAccountButton_Click(object sender, RoutedEventArgs e)
        {
            // TODO: Реализовать открытие окна создания аккаунта
            // var createAccountWindow = new CreateAccount();
            // createAccountWindow.Show();
            
            // Временно показываем сообщение
            var dialog = new Window()
            {
                Title = "Создание аккаунта",
                Width = 400,
                Height = 200,
                Content = new TextBlock 
                { 
                    Text = "Функция создания аккаунта будет реализована в будущем", 
                    HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Center,
                    VerticalAlignment = Avalonia.Layout.VerticalAlignment.Center
                }
            };
            dialog.ShowDialog(this);
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            // TODO: Реализовать логику выхода из аккаунта
            // Очистка данных сессии, возврат на окно входа и т.д.
            
            // Временно показываем сообщение
            var dialog = new Window()
            {
                Title = "Выход из системы",
                Width = 400,
                Height = 200,
                Content = new TextBlock 
                { 
                    Text = "Вы успешно вышли из системы", 
                    HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Center,
                    VerticalAlignment = Avalonia.Layout.VerticalAlignment.Center
                }
            };
            dialog.ShowDialog(this);
            
            // Закрываем приложение (временное решение)
            // Environment.Exit(0);
        }
    }
}