using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TabloidCLI.Models;

namespace TabloidCLI.Repositories
{
    internal class NoteRepository : DatabaseConnector, IRepository<Note>
    {
        public NoteRepository(string connectionString) : base(connectionString) { }

        public List<Note> GetAll()
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT id,
                                            Title,
                                            Content
                                        FROM Note";
                    List<Note> notes = new List<Note>();

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Note note = new Note()
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            Title = reader.GetString(reader.GetOrdinal("Title")),
                            Content = reader.GetString(reader.GetOrdinal("Content")),

                        };

                        notes.Add(note);
                    }
                    reader.Close();

                    return notes;
                }
            }
        }

        public Note Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Note note)
        {
            throw new NotImplementedException();
        }

        public void Insert(Note note)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO Note (Title, Content)
                                                     VALUES (@Title, @Content)";
                    cmd.Parameters.AddWithValue("@Title", note.Title);
                    cmd.Parameters.AddWithValue("@Content", note.Content);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int id)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using(SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"DELETE FROM note WHERE id = @id";
                    cmd.Parameters.AddWithValue("@id", id);
                }
            }
        }
    }
}
