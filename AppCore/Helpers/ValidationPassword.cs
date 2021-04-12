using BC = BCrypt.Net.BCrypt;

namespace AppCore.validacoes
{
    public static class ValidationPassword
    {
        public static string SecretPassWord(string password) => BC.HashPassword(password, 10);

        public static bool IsPassWord(string password, string passWordComp)
        {   
            var tt = BC.HashPassword(passWordComp, 10);

            var tes = BC.Verify(password, passWordComp);

            return tes;
        }

        
    }
}
