using System;
using System.Security.Cryptography;
using System.Text;

namespace BankTransfers.Utils
{
    public class PasswordHelper
    {
        /// <summary>
        /// Вычисление хэша пароля (с добавлением соли)
        /// </summary>
        /// <param name="password"></param>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string GetSaltedHashedPassword(string password, out string saltText)
        {
            //генерация соли
            var rng = RandomNumberGenerator.Create();
            var saltBytes = new byte[16];
            rng.GetBytes(saltBytes);
            saltText = Convert.ToBase64String(saltBytes);

            //генерация соленого и хешированного пароля
            var sha = SHA256.Create();
            var saltedPassword = password + saltText;
            var saltedhashedPassword =
                Convert.ToBase64String(sha.ComputeHash(Encoding.Unicode.GetBytes(saltedPassword)));

            return saltedhashedPassword;
        }

        /// <summary>
        /// Проверка введенного пароля
        /// Сравнение хеша паролей (с испольсованием соли пользователя)
        /// </summary>
        /// <param name="inputPassword"></param>
        /// <param name="userPassword"></param>
        /// <param name="userSalt"></param>
        /// <returns></returns>
        public static bool CheckPassword(string inputPassword, string userPassword, string userSalt)
        {
            //повторная генерация соленого и хешированного пароля
            var sha = SHA256.Create();
            var saltedPassword = inputPassword + userSalt;
            var saltedHasgedPassword =
                Convert.ToBase64String(sha.ComputeHash(Encoding.Unicode.GetBytes(saltedPassword)));

            return (saltedHasgedPassword == userPassword);
        }
    }
}
