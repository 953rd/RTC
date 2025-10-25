using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using System;
using System.IO; // Добавьте эту строку

namespace RTC
{
    internal class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Запуск приложения...");
                BuildAvaloniaApp()
                    .StartWithClassicDesktopLifetime(args);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Критическая ошибка: {ex}");
                // Запись в файл лога или показ сообщения
                File.WriteAllText("error.log", ex.ToString());
            }
        }

        public static AppBuilder BuildAvaloniaApp()
            => AppBuilder.Configure<App>()
                .UsePlatformDetect()
                .LogToTrace()
                .WithInterFont();
    }
}