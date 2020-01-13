using Dao.Sql;
using Entities;
using Framework;
using System;
using System.Collections.Generic;
using System.Data;

namespace Dao
{
    public class MessageDao : ICrud<Message>
    {
        public void Delete(int Id)
        {
            string sql = "DELETE FROM Message WHERE Id = @Id";

            object[] parms = { "Id", Id };

            Db.ExecuteNonQuery(sql, parms);
        }

        public Message Get(int Id)
        {
            string sql = "SELECT ChatId, Text, Id, UserId FROM Message WHERE Id = @Id";

            object[] parms = { "Id", Id };

            return Db.Read<Message>(sql, make, parms);
        }

        public int Insert(Message ent)
        {
            string query = @"INSERT INTO Mensagem (UserId, ChatId, Text) 
                            VALUES (@UserFrom, @UserTo, @ChatId, @Text);";

            object[] parms = { "@UserFrom", ent.User };

            return Convert.ToInt32(Db.ExecuteScalar(query));
        }

        public List<Message> List()
        {
            string sql = "SELECT ChatId, Text, Id, UserId FROM Message";

            return Db.ReadList<Message>(sql, make);
        }

        public List<Message> Search(string term)
        {
            string sql = "SELECT ChatId, Text, Id, UserId FROM Message";

            return Db.ReadList<Message>(sql, make);
        }

        public void Update(Message ent)
        {
            throw new NotImplementedException();
        }

        private Func<IDataReader, Message> make = reader =>
            new Message()
            {
                Chat = new Chat(reader["ChatId"].AsInt()),
                Text = reader["Text"].AsString(),
                Id = reader["Id"].AsInt(),
                User = new User(reader["UserId"].AsInt())
            };
    }
}
