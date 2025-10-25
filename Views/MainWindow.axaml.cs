using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using System;
using Avalonia.Media;
using System.Collections.Generic;

namespace RTC.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitializeChart();

        }
    

private void InitializeChart()
{
    var chartItems = new List<ChartItem>
    {
        new ChartItem { Label = "Инициация", Value = 12, Color = Color.Parse("#7700FF") },
        new ChartItem { Label = "Анализ", Value = 8, Color = Color.Parse("#9B30FF") },
        new ChartItem { Label = "Планирование", Value = 15, Color = Color.Parse("#FF4F12") },
        new ChartItem { Label = "Дизайн", Value = 10, Color = Color.Parse("#FF6A33") },
        new ChartItem { Label = "Разработка", Value = 25, Color = Color.Parse("#00a650") },
        new ChartItem { Label = "Тестирование", Value = 18, Color = Color.Parse("#00C853") },
        new ChartItem { Label = "Внедрение", Value = 14, Color = Color.Parse("#FFD700") },
        new ChartItem { Label = "Контроль", Value = 9, Color = Color.Parse("#FFEE58") },
        new ChartItem { Label = "Поддержка", Value = 11, Color = Color.Parse("#8A33FF") },
        new ChartItem { Label = "Завершение", Value = 6, Color = Color.Parse("#A366FF") }
    };

    ProjectStagesChart.Items = chartItems;
}

        private void CreateProjectButton_Click(object sender, RoutedEventArgs e)
        {
            // Открываем окно создания проекта
            var createProject = new CreateProject();
            createProject.Show();
            this.Close(); // Закрываем текущее окно, если нужно
        }

        private void CreateAccountButton_Click(object sender, RoutedEventArgs e)
{
    var createUser = new CreateUser();
    createUser.Show();
    this.Close();
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