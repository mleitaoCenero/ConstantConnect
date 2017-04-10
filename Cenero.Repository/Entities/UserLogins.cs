namespace Cenero.Repository.Entities
{
    public class UserLogins
    {
        public string Subject { get; set; }
        public string LoginProvider { get; set; }
        public string ProviderKey { get; set; }
    }
}