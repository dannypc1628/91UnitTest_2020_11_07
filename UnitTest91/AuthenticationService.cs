using System.Text;

namespace UnitTest91
{
    public class AuthenticationService
    {
        private IProfile _profile;
        private IToken _token;


        public AuthenticationService(IProfile profile, IToken token)
        {
            _profile = profile;
            _token = token;
        }

        public AuthenticationService()
        {
            _profile = new ProfileDao();
            _token = new RsaTokenDao();
        }
        public bool IsValid(string account, string password)
        {
            // 根據 account 取得自訂密碼
            var passwordFromDao = _profile.GetPassword(account);

            // 根據 account 取得 RSA token 目前的亂數
            var randomCode = _token.GetRandom(account);

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
