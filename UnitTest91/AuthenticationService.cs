using System.Text;

namespace UnitTest91
{
    public class AuthenticationService
    {
        public bool IsValid(string account, string password)
        {
            // 根據 account 取得自訂密碼
            var profileDao = new ProfileDao();
            var passwordFromDao = profileDao.GetPassword(account);

            // 根據 account 取得 RSA token 目前的亂數
            var rsaToken = new RsaTokenDao();
            var randomCode = rsaToken.GetRandom(account);

            // 驗證傳入的 password 是否等於自訂密碼 + RSA token亂數
            var validPassword = passwordFromDao + randomCode;
            var isValid = password == validPassword;

            if (isValid)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
