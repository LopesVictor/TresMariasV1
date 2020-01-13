using System;

namespace TresMariasWebApp.Models
{
    public class User
    {
        public User() { }
        public Int32 Id { get; set; }
        public string profileImage { get; set; }
        public bool IsAuthenticated { get; set; }

        public string facebookId { get; set; }

        public string googleId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public Boolean OfereceCarona { get; set; }
        public DateTime Cadastro { get; set; }
    }
}
