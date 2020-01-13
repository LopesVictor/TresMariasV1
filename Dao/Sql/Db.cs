using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace Dao.Sql
{
    public static class Db
    {
        public static readonly string connectionString =
            @"server=localhost;user id=tresmarias;Pwd=z1x2c3;persistsecurityinfo=True;database=tresmariasdb";
        public static readonly DbFactory factory = new DbFactory(connectionString);

        public static T Read<T>(string sql, Func<IDataReader, T> make, object[] parms = null)
        {
            using (var connection = factory.CreateConnection())
            {
                using (var cmd = factory.CreateCommand())
                {
                    cmd.Connection = connection;
                    cmd.CommandText = sql;
                    cmd.SetParameters(parms);

                    connection.Open();

                    T t = default(T);
                    var reader = cmd.ExecuteReader();
                    if (reader.Read())
                        t = make(reader);

                    return t;
                }
            }
        }

        public static List<T> ReadList<T>(string sql, Func<IDataReader, T> make, object[] parms = null)
        {
            using (var connection = factory.CreateConnection())
            {
                using (var command = factory.CreateCommand())
                {
                    command.Connection = connection;
                    command.CommandText = sql;
                    command.SetParameters(parms);

                    connection.Open();

                    var list = new List<T>();
                    var reader = command.ExecuteReader();

                    while (reader.Read())
                        list.Add(make(reader));

                    return list;
                }
            }
        }

        public static void ExecuteNonQuery(string sql, object[] parms = null)
        {
            using (var connection = factory.CreateConnection())
            {
                using (var command = factory.CreateCommand())
                {
                    command.Connection = connection;
                    command.CommandText = sql;
                    command.SetParameters(parms);

                    connection.Open();

                    command.ExecuteNonQuery();
                }
            }
        }

        public static object ExecuteScalar(string sql, object[] parms = null)
        {
            using (var connection = factory.CreateConnection())
            {
                using (var command = factory.CreateCommand())
                {
                    try
                    {
                        command.Connection = connection;
                        command.CommandText = sql;
                        command.SetParameters(parms);

                        connection.Open();

                        return command.ExecuteScalar();
                    }
                    catch (Exception)
                    {
                        connection.Close();

                        return null;
                    }
                }
            }
        }

        private static void SetParameters(this MySqlCommand command, object[] parms)
        {
            if (parms != null && parms.Length > 0)
            {
                for (int i = 0; i < parms.Length; i += 2)
                {
                    string name = parms[i].ToString();

                    if (parms[i + 1] is string && (string)parms[i + 1] == "")
                        parms[i + 1] = null;

                    object value = parms[i + 1] ?? DBNull.Value;

                    var dbParameter = command.CreateParameter();
                    dbParameter.ParameterName = name;
                    dbParameter.Value = value;

                    command.Parameters.Add(dbParameter);

                }
            }
        }
    }
}
