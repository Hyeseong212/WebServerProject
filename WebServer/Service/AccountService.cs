using WebServer.Repository;
using WebServer.Repository.Interface;
using Microsoft.Extensions.Logging;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WebServer.Service
{
    public class AccountService
    {
        private readonly ILogger<AccountService> _logger;
        private readonly IAccountRepository _accountRepository;
        private readonly MessageHandler _messageHandler;

        public AccountService(ILogger<AccountService> logger, IAccountRepository accountRepository)
        {
            _logger = logger;
            _accountRepository = accountRepository;
            _messageHandler = new MessageHandler("Resources/MessagesInfo.csv");
        }

        public async Task<(bool, string)> CreateAsync(string id, string pw)
        {
            if (await _accountRepository.IsAlreadyExistAsync(id))
            {
                string message = _messageHandler.SetMessage("Error", 2); // ID가 중복되었습니다.
                return (false, message);
            }

            if (pw.Length < 10)
            {
                string message = _messageHandler.SetMessage("Error", 3); // 비밀번호 10자 이상 만들어 주세요.
                return (false, message);
            }

            if (!Regex.IsMatch(pw, @"[a-zA-Z]") || !Regex.IsMatch(pw, @"\d") || !Regex.IsMatch(pw, @"[!@#$%^&*(),.?:{}|<>]"))
            {
                string message = _messageHandler.SetMessage("Error", 4); // 특수문자, 숫자, 영어가 혼합되어야 합니다.
                return (false, message);
            }

            // 비밀번호 해싱
            string hashedPw = Utils.HashPassword(pw);

            if (await _accountRepository.CreateAsync(id, hashedPw))
            {
                return (true, "계정이 성공적으로 생성되었습니다.");
            }
            else
            {
                string message = _messageHandler.SetMessage("Error", 6); // 계정 생성에 실패했습니다.
                return (false, message);
            }
        }

        public async Task<(bool, string)> LoginAsync(string id, string pw)
        {
            var account = await _accountRepository.GetAccountAsync(id);
            if (account == null)
            {
                string message = _messageHandler.SetMessage("Error", 5); // ID가 존재하지 않습니다.
                return (false, message);
            }

            if (!Utils.VerifyPassword(pw, account.UserPassword))
            {
                string message = _messageHandler.SetMessage("Error", 1); // 올바르지 않은 비밀번호입니다.
                return (false, message);
            }

            return (true, "로그인 성공");
        }
    }
}