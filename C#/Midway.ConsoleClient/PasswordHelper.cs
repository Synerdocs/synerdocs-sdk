namespace Midway.ConsoleClient
{
    public class PasswordHelper
    {
        public static bool CheckPassword(string pass1, string pass2)
        {
            return !(pass1 == null || pass2 == null || pass1 != pass2);
        } 
    }
}