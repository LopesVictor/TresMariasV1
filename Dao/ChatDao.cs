using Dao.Sql;
using Entities;
using Framework;
using System;
using System.Collections.Generic;
using System.Data;

namespace Dao
{
    public class ChatDao : ICrud<Chat>
    {
        public void Delete(int Id)
        {
            string sql = "DELETE FROM Chat WHERE Id = @Id";

            object[] parms = { "Id", Id };

            Db.ExecuteNonQuery(sql, parms);
        }

        public Chat Get(int Id)
        {
            string sql = "SELECT Id, UserFrom, UserTo, CreatedAt FROM Chat WHERE Id = @Id";

            object[] parms = { "Id", Id };

            return Db.Read<Chat>(sql, make, parms);
        }

        public int Insert(Chat ent)
        {
            string sql = "INSERT INTO Chat (UserFrom, UserTo) VALUES (@UserFrom, @UserTo)";

            object[] parms = { "UserFrom", ent.userFrom.Id, "Userto", ent.userTo.Id };

            Db.ExecuteNonQuery(sql, parms);

            ent.Id = Convert.ToInt32(Db.ExecuteScalar("SELECT TOP 1 Id FROM Chat ORDER BY ID Desc"));

            return ent.Id;
        }

        public List<Chat> List()
        {
            throw new NotImplementedException();
        }

        public List<Chat> Search(string term)
        {
            throw new NotImplementedException();
        }

        public void Update(Chat ent)
        {
            throw new NotImplementedException();
        }

        private Func<IDataReader, Chat> make = reader =>
            new Chat() { 
                Id = reader["Id"].AsInt(),
                CreatedAt = Convert.ToDateTime(reader["CreatedAt"]),
                userFrom = new User(reader["userFrom"].AsInt()),
                userTo = new User(reader["userTo"].AsInt())
            };
    }
}
