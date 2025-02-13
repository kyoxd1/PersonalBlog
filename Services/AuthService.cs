namespace PersonalBlog.Services
{
    public class AuthService
    {
        private const string HardcodedUser = "admin";
        private const string HardcodedPass = "password";

        public bool Authenticate(string username, string password)
        {
            return username == HardcodedUser && password == HardcodedPass;
        }
    }
}