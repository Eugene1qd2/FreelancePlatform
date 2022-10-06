using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace FreelancePlatform.Assets.Additional_Data
{
    public enum ErrorStatus
    {
        NoError,
        NoInternetConnectionError,
        NoDatabaseConnectionError,
        InvalidLoginOrPasswordError,
        RegisteredUsernameError,
        RegisteredEmailError,
        RegistrationError,
        NotImplementedError
    }
    static class ErrorData
    {
        public static string GetErrorMessage(ErrorStatus error)
        {
            string errorString = string.Empty;
            switch (error)
            {
                case ErrorStatus.NoError:
                    errorString= string.Empty;
                    break;
                case ErrorStatus.NoInternetConnectionError:
                    errorString = "Нет подключения к интернету!";
                    break;
                case ErrorStatus.NoDatabaseConnectionError:
                    errorString= "Нет подключения к базе данных!";
                    break;
                case ErrorStatus.InvalidLoginOrPasswordError:
                    errorString= "Неверный логин или пароль!";
                    break;
                case ErrorStatus.RegisteredUsernameError:
                    errorString= "Пользователем с таким логином уже зарегистрирован!";
                    break;
                case ErrorStatus.RegisteredEmailError:
                    errorString= "Пользователь с этой электронной почтой уже зарегистрирован!";
                    break;
                case ErrorStatus.RegistrationError:
                    errorString= "Ошибка регистрации!";
                    break;
                case ErrorStatus.NotImplementedError:
                    errorString= "Ошибка не имплементированна!";
                    break;
                default:
                    errorString= "Ошибка существует за гранью вашего понимания!";
                    break;
            }
            return errorString;
        }

        public static string SecureStringToString(SecureString value)
        {
            IntPtr valuePtr = IntPtr.Zero;
            try
            {
                valuePtr = Marshal.SecureStringToGlobalAllocUnicode(value);
                return Marshal.PtrToStringUni(valuePtr);
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(valuePtr);
            }
        }

    }
}
