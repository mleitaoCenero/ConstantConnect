namespace Cenero.Repository.Helpers
{
    public static class Validate
    {
        public static bool ValidatePassword(string password, string correctHash)
        {
            //$2a$08$UBr5tl4c5OU6eIn0philBuuYHQjwCoSPSvgSPs6uacEs.yMwtQXv2

            var r = global::BCrypt.Net.BCrypt.Verify(password, correctHash);
            return r;
        }
    }
}
