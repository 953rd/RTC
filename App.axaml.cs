using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using System;

namespace RTC
{
    public partial class App : Application
    {
        public override void Initialize()
        {
            try
            {
                Console.WriteLine("Инициализация приложения...");
            AvaloniaXamlLoader.Load(this);
                Console.WriteLine("XAML загружен успешно");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка инициализации: {ex}");
                throw;
            }
        }

        public override void OnFrameworkInitializationCompleted()
        {
            try
            {
                Console.WriteLine("Инициализация фреймворка завершена...");
                
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                    Console.WriteLine("Создание главного окна...");
                    desktop.MainWindow = new Views.MainWindow();
                    Console.WriteLine("Главное окно создано");

                    // Обработка закрытия приложения
                    desktop.Exit += (sender, e) =>
                    {
                        Console.WriteLine("Приложение завершено");
                    };
                    desktop.MainWindow.WindowState = WindowState.Maximized;
                desktop.MainWindow.CanResize = true;
                
                // Опционально: установить минимальный размер
                desktop.MainWindow.MinWidth = 1024;
                desktop.MainWindow.MinHeight = 768;
            }

            base.OnFrameworkInitializationCompleted();
                Console.WriteLine("Базовая инициализация завершена");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка создания окна: {ex}");
                throw;
            }
        }
        
    }
}