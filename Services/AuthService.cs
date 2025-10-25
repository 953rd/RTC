using RTC.Models;

namespace RTC.Services
{
    public class AuthService
    {
        // Текущий авторизованный пользователь
        public User? CurrentUser { get; private set; }

        public AuthService()
        {
            // Для демонстрации можно установить пользователя по умолчанию
            CurrentUser = null;
        }

        // Метод входа
        public void Login(User user)
        {
            CurrentUser = user;
        }

        // Метод выхода
        public void Logout()
        {
            CurrentUser = null;
        }
    }
}
