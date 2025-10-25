using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace RTC.Views
{
    public partial class CreateProject : Window
    {
        public CreateProject()
        {
            InitializeComponent();
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            // TODO: Реализовать логику создания проекта
            var dialog = new Window()
            {
                Title = "Создание проекта",
                Width = 300,
                Height = 150,
                Content = new TextBlock
                {
                    Text = "Проект успешно создан!",
                    HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Center,
                    VerticalAlignment = Avalonia.Layout.VerticalAlignment.Center
                }
            };
            dialog.ShowDialog(this);
            
            // Возврат на главное окно
            var mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            // Возврат на главное окно
            var mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }
    }
}