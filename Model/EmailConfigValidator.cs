using System.Text.RegularExpressions;

namespace Model
{
    public class EmailConfigValidator
    {
        public static ValidationMessage ValidateLogin(string login)
        {
            var regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");

            if (regex.Match(login).Success)
            {
                return new ValidationMessage(true);
            }

            return new ValidationMessage(false, "Invalid Login.");
        }

        public static ValidationMessage ValidatePassword(string password)
        {
            if (string.IsNullOrEmpty(password) || string.IsNullOrWhiteSpace(password))
            {
                return new ValidationMessage(false, "Invalid Password. Cannot be empty or writespace.");
            }
            return new ValidationMessage(true);
        }

        public static ValidationMessage ValidateSmtp(string smtp)
        {
            var regex = new Regex(@"^\w+\.\w+\.[a-zA-z]{1,3}$");

            if (regex.Match(smtp).Success)
            {
                return new ValidationMessage(true);
            }

            return new ValidationMessage(false, "Invalid SMTP");
        }

        public static ValidationMessage ValidatePort(string port)
        {
            var regex = new Regex(@"^([0-9]{1,4}|[1-5][0-9]{4}|6[0-4][0-9]{3}|65[0-4][0-9]{2}|655[0-2][0-9]|6553[0-5])$");

            if (regex.Match(port).Success)
            {
                return new ValidationMessage(true);
            }

            return new ValidationMessage(false, "Invalid Port.");
        }
    }
}