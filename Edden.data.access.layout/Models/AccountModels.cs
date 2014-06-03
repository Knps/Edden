namespace Edden.data.access.layout.Models
{
    public class AccountCreateModel
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public int CommunityIdentity { get; set; }

        public int Levelidentity { get; set; }

        public string Pseudo { get; set; }

        public string SecretAnswer { get; set; }

        public string SecretQuestion { get; set; }
    }
}
