using System;

namespace Entities
{
    public class User
    {
        public User(int id)
        {
            Id = id;
        }

        public User() { }

        public Int32 Id { get; set; }
        public string Nome { get; set; }
        public DateTime Cadastro { get; set; }
    }
}
