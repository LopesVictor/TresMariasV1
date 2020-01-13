using Dao.Sql;
using Entities;
using Framework;
using System;
using System.Collections.Generic;
using System.Data;

namespace Dao
{
    public class UserDao : ICrud<User>
    {
        public void Delete(int Id)
        {
            string sql = "DELETE FROM User WHERE Id = @Id";

            object[] parms = { "Id", Id };

            Db.ExecuteNonQuery(sql, parms);
        }

        public User Get(int Id)
        {
            string sql = "SELECT Id, Nome, CreatedAt FROM Users WHERE Id = @Id";

            object[] parms = { "Id", Id };

            return Db.Read<User>(sql, make, parms);
        }

        public int Insert(User ent)
        {
            string sql = "INSERT INTO Users (Nome) VALUES (@Nome)";

            object[] parms = { "Nome", ent.Nome };

            Db.ExecuteNonQuery(sql, parms);
            
            ent.Id = Convert.ToInt32(Db.ExecuteScalar("SELECT TOP 1 Id FROM Users ORDER BY ID Desc"));

            return ent.Id;
        }

        public List<User> List()
        {
            string sql = "SELECT Id, Nome, CreatedAt FROM Users";

            return Db.ReadList<User>(sql, make);
        }

        public List<User> Search(string term)
        {
            string sql = "SELECT Id, Nome, CreatedAt FROM Users WHERE Nome LIKE '%" + term + "%'";

            return Db.ReadList<User>(sql, make);
        }

        public void Update(User ent)
        {
            throw new NotImplementedException();
        }

        private Func<IDataReader, User> make = reader =>
            new User()
            {
                Id = reader["Id"].AsInt(),
                Cadastro = Convert.ToDateTime(reader["CreatedAt"]),
                Nome = reader["Nome"].AsString()
            };
    }
}
