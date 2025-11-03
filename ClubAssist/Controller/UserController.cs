using ClubAssist.Model;
using ClubAssist.Security;
using Microsoft.Data.SqlClient;
using System;
using System.Configuration;
using System.Windows.Forms;

namespace ClubAssist.Controller
{
    internal class UserController
    {
        private readonly string conn = ConfigurationManager.ConnectionStrings["dbClubAssist"].ConnectionString;

        public bool RegisterUser(modelUser user)
        {
            var (hash, salt) = PasswordHasher.HashPassword(user.Password);

            using (SqlConnection connection = new SqlConnection(conn))
            {
                string query = @"
                    INSERT INTO tblUsers 
                    (Firstname, Lastname, Email, Username, PhoneNumber, [Password], [Role], Salt) 
                    VALUES 
                    (@Firstname, @Lastname, @Email, @Username, @PhoneNumber, @Password, @Role, @Salt)";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Firstname", user.Firstname);
                command.Parameters.AddWithValue("@Lastname", user.Lastname);
                command.Parameters.AddWithValue("@Email", user.Email);
                command.Parameters.AddWithValue("@Username", user.Username);
                command.Parameters.AddWithValue("@PhoneNumber", user.PhoneNumber);
                command.Parameters.AddWithValue("@Password", hash);
                command.Parameters.AddWithValue("@Role", user.Role);
                command.Parameters.AddWithValue("@Salt", salt);

                try
                {
                    connection.Open();
                    int result = command.ExecuteNonQuery();
                    return result > 0;
                }
                catch (SqlException ex)
                {
                    MessageBox.Show($"Fout bij registratie: {ex.Message}", "Databasefout", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }

        public bool VerifyLogin(string username, string password)
        {
            using (SqlConnection connection = new SqlConnection(conn))
            {
                string query = "SELECT [Password], Salt FROM tblUsers WHERE Username = @Username";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Username", username);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        string storedHash = reader["Password"].ToString();
                        string storedSalt = reader["Salt"].ToString();

                        bool isValid = PasswordHasher.VerifyPassword(password, storedHash, storedSalt);
                        return isValid;
                    }
                    else
                    {
                        MessageBox.Show("Gebruiker niet gevonden.", "Inloggen mislukt", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Fout bij inloggen: " + ex.Message, "Databasefout", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }

        public modelUser GetUserByUsername(string username)
        {
            using (SqlConnection connection = new SqlConnection(conn))
            {
                string query = @"SELECT UserId, Firstname, Lastname, Email, Username, PhoneNumber, [Password], [Role], Salt 
                         FROM tblUsers WHERE Username = @Username";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Username", username);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        return new modelUser
                        {
                            Id = reader.GetInt32(0),
                            Firstname = reader.GetString(1),
                            Lastname = reader.GetString(2),
                            Email = reader.GetString(3),
                            Username = reader.GetString(4),
                            PhoneNumber = reader.IsDBNull(5) ? string.Empty : reader.GetString(5),
                            Password = reader.GetString(6),
                            Role = reader.GetString(7),
                            Salt = reader.IsDBNull(8) ? string.Empty : reader.GetString(8)
                        };
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Fout bij ophalen van gebruiker: " + ex.Message);
                }
            }

            return null;
        }

    }
}
