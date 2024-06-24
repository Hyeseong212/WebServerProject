using System.Security.Cryptography;
using System.Text;

public static class Utils
{
    /// <summary>
    /// 비밀번호를 SHA-256 알고리즘을 사용하여 해시합니다.
    /// </summary>
    /// <param name="password">해싱할 비밀번호</param>
    /// <returns>해시된 비밀번호 문자열</returns>
    public static string HashPassword(string password)
    {
        using (SHA256 sha256Hash = SHA256.Create())
        {
            byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));
            }
            return builder.ToString();
        }
    }

    /// <summary>
    /// 입력된 비밀번호가 해시된 비밀번호와 일치하는지 확인합니다.
    /// </summary>
    /// <param name="password">입력된 비밀번호</param>
    /// <param name="hashedPassword">해시된 비밀번호</param>
    /// <returns>비밀번호가 일치하면 true, 그렇지 않으면 false</returns>
    public static bool VerifyPassword(string password, string hashedPassword)
    {
        string hashOfInput = HashPassword(password);
        return StringComparer.OrdinalIgnoreCase.Compare(hashOfInput, hashedPassword) == 0;
    }
}
