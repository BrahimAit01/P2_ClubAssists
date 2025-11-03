using ClubAssist.Model;
using ClubAssist.Security;
using Microsoft.Data.SqlClient;
using System;
using System.Windows.Forms;

namespace ClubAssist.Controller
{
    internal class UserController
    {
        private string conn = "Data Source=localhost;Database=dbClubAssist;Integrated Security=True;Encrypt=False;TrustServerCertificate=True;";

        public bool RegisterUser(modelUser user)
        {
            var (hash, salt) = PasswordHasher.HashPassword(user.Password);

            using (SqlConnection connection = new SqlConnection(conn))
            {
                string query = @"INSERT INTO Users (Firstname, Lastname, Email, Username, [Password], [Role], Salt) 
                                 VALUES (@Firstname, @Lastname, @Email, @Username, @Password, @Role, @Salt)";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Firstname", user.Firstname);
                command.Parameters.AddWithValue("@Lastname", user.Lastname);
                command.Parameters.AddWithValue("@Email", user.Email);
                command.Parameters.AddWithValue("@Username", user.Username);
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
                    MessageBox.Show($"Fout bij registratie: {ex.Message}");
                    return false;
                }
            }
        }


        public bool VerifyLogin(string username, string password)
        {
            using (SqlConnection connection = new SqlConnection(conn))
            {
                string query = "SELECT [Password], Salt FROM Users WHERE Username = @Username";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Username", username);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        string storedHash = reader.GetString(0);
                        string storedSalt = reader.GetString(1);

                        // Controleer of ingevoerd wachtwoord overeenkomt
                        bool isValid = PasswordHasher.VerifyPassword(password, storedHash, storedSalt);
                        return isValid;
                    }
                    else
                    {
                        MessageBox.Show("Gebruiker niet gevonden.");
                        return false;
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Fout bij inloggen: " + ex.Message);
                    return false;
                }
            }
        }
    }
}
