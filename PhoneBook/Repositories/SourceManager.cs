using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using PhoneBook.Models;

namespace PhoneBook.Repositories
{
    public class SourceManager
    {
        private const string _connectionString = "Integrated Security=SSPI;" +
                                                 "Initial Catalog=PhoneBookDb;" +
                                                 "Data Source=.\\SQLEXPRESS;";

        private readonly SqlConnection _conn = new SqlConnection(_connectionString);

        private SqlCommand GetCommand(string query)
        {
            return new SqlCommand(query, _conn);
        }

        public List<PersonModel> Get(int start, int take)
        {
           string selectAll = "select Id, FirstName, LastName, Phone, Email, Created, Updated " +
                              "from People " +
                              "order by Id";

            var personList = new List<PersonModel>();

            //using (var conn = new SqlConnection(_connectionString))
            //using (var command = new SqlCommand(selectAll, conn))
            using (var command = GetCommand(selectAll))
            {
                _conn.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        personList.Add(new PersonModel()
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            FirstName = reader["FirstName"].ToString(),
                            LastName = reader.IsDBNull(reader.GetOrdinal("LastName")) ? null : reader["LastName"].ToString(),
                            Phone = reader["Phone"].ToString(),
                            Email = reader.IsDBNull(reader.GetOrdinal("Email")) ? null : reader["Email"].ToString(),
                            Created = Convert.ToDateTime(reader["Created"]),
                            Updated = Convert.ToDateTime(reader["Updated"])
                        });
                    }
                }
                _conn.Close();
            }

            return personList;
        }

        public PersonModel GetByID(int id)
        {
            var selectByID = "select Id, FirstName, LastName, Phone, Email, Created, Updated " +
                             "from People " +
                             "where Id = @id";

            PersonModel person = new PersonModel();

            //using (var conn = new SqlConnection(_connectionString))
            //using (var command = new SqlCommand(selectByID, conn))
            using (var command = GetCommand(selectByID))
            {
                command.Parameters.Add(new SqlParameter("@id", DbType.Int32) {Value = id});

                _conn.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        person = new PersonModel()
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            FirstName = reader["FirstName"].ToString(),
                            LastName = reader.IsDBNull(reader.GetOrdinal("LastName")) ? null : reader["LastName"].ToString(),
                            Phone = reader["Phone"].ToString(),
                            Email = reader.IsDBNull(reader.GetOrdinal("Email")) ? null : reader["Email"].ToString(),
                            Created = Convert.ToDateTime(reader["Created"]),
                            Updated = Convert.ToDateTime(reader["Updated"])
                        };
                    }
                }
                _conn.Close();
            }

            return person;
        }

        public int Add(PersonModel personModel)
        {
            string insert = "insert into People(FirstName, LastName, Phone, Email, Created, Updated) " +
                            "values (@firstname, @lastname, @phone, @email, @created, @updated); select scope_identity()";

            int id = 0;

            //using (var conn = new SqlConnection(_connectionString))
            //using (var command = new SqlCommand(insert, conn))
            using (var command = GetCommand(insert))
            {
                var sqlParameters = new List<SqlParameter>()
                {
                    new SqlParameter("@firstname", DbType.String){ Value = personModel.FirstName },
                    new SqlParameter("@lastname", DbType.String){ Value = (object) personModel.LastName ?? DBNull.Value},
                    new SqlParameter("@phone", DbType.String){ Value = personModel.Phone },
                    new SqlParameter("@email", DbType.String){ Value = (object) personModel.Email ?? DBNull.Value },
                    new SqlParameter("@created", DbType.DateTime){ Value = personModel.Created },
                    new SqlParameter("@updated", DbType.DateTime){ Value = personModel.Updated }
                };
                
                command.Parameters.AddRange(sqlParameters.ToArray());

                _conn.Open();
                id = Convert.ToInt32(command.ExecuteScalar());
                _conn.Close();
            }

            return id;
        }

        public void Update(PersonModel personModel)
        {
            string update = "update People " +
                            "set FirstName = @firstname, " +
                            "LastName = @lastname, " +
                            "Phone = @phone, " +
                            "Email = @email, " +
                            "Updated = @updated " +
                            "where Id = @id";

            //using (var conn = new SqlConnection(_connectionString))
            //using (var command = new SqlCommand(update, conn))
            using (var command = GetCommand(update))
            {
                var sqlParameters = new List<SqlParameter>()
                {
                    new SqlParameter("@id", DbType.Int32){ Value = personModel.Id },
                    new SqlParameter("@firstname", DbType.String){ Value = personModel.FirstName },
                    new SqlParameter("@lastname", DbType.String){ Value = (object) personModel.LastName ?? DBNull.Value},
                    new SqlParameter("@phone", DbType.String){ Value = personModel.Phone },
                    new SqlParameter("@email", DbType.String){ Value = (object) personModel.Email ?? DBNull.Value },
                    new SqlParameter("@updated", DbType.DateTime){ Value = personModel.Updated }
                };

                command.Parameters.AddRange(sqlParameters.ToArray());

                _conn.Open();
                command.ExecuteNonQuery();
                _conn.Close();
            }

        }

        public void Remove(int id)
        {
            string delete = "delete from People " +
                            "where Id = @id";

            //using (var conn = new SqlConnection(_connectionString))
            //using (var command = new SqlCommand(delete, conn))
            using (var command = GetCommand(delete))
            {
                command.Parameters.Add(new SqlParameter("@id", DbType.Int32) {Value = id});

                _conn.Open();
                command.ExecuteNonQuery();
                _conn.Close();
            }
        }
    }
}
