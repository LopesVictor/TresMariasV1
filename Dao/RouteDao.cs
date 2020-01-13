using Dao.Sql;
using Entities;
using Framework;
using System;
using System.Collections.Generic;
using System.Data;

namespace Dao
{
    public class RouteDao : ICrud<Route>
    {
        public void Delete(int Id)
        {
            string sql = "DELETE FROM Route WHERE Id = @Id";

            object[] parms = { "Id", Id };

            Db.ExecuteNonQuery(sql, parms);
        }

        public Route Get(int Id)
        {
            string sql = "SELECT * FROM Route WHERE Id = @Id";

            object[] parms = { "Id", Id };

            return Db.Read<Route>(sql, make, parms);
         }

        public int Insert(Route ent)
        {
            string sql = "INSERT INTO Route (Destination, Origin, UserId) VALUES (@Destination, @Origin, @UserId)";

            object[] parms = { "@Destination", ent.Destination, "@Origin", ent.Origin, "@UserId", ent.User.Id };

            var id = Convert.ToInt32(Db.ExecuteScalar(sql, parms));

            return id;
        }

        public List<Route> List()
        {
            string sql = "SELECT * FROM Route";

            return Db.ReadList<Route>(sql, make);
        }

        public List<Route> Search(string term)
        {
            string sql = "SELECT * FROM Route";

            return Db.ReadList<Route>(sql, make);
        }

        public void Update(Route ent)
        {
            string sql = "UPDATE Route SET Destination = @Destination, Origin = @Origin WHERE Id = @Id";

            object[] parms = { "@Destination", ent.Destination, "@Origin", ent.Origin, "@UserId", ent.User.Id };

            Db.ExecuteNonQuery(sql, parms);
        }

        private Func<IDataReader, Route> make = reader =>
            new Route() { 
                CreatedAt = Convert.ToDateTime(reader["CreatedAt"]),
                Destination = reader["Destination"].ToString(),
                Origin = reader["Origin"].ToString(),
                User = new User(reader["UserId"].AsInt())
            };
    }
}
