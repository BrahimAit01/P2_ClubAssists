using ClubAssist.Model;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ClubAssist.Controller
{
    internal class ActivitiesController
    {
        private string conn = "Data Source=localhost;Database=dbClubAssist;Integrated Security=True;Encrypt=False;TrustServerCertificate=True;";

        // Functie om alle activiteiten op te halen
        public List<ActivitiesModel> Read()
        {
            List<ActivitiesModel> activities = new List<ActivitiesModel>();

            using (SqlConnection connection = new SqlConnection(conn))
            {
                string query = "SELECT ActivityId, Title, Description, Location, StartTime, EndTime, NeededVolunteers, CurrentVolunteers, CreatedBy FROM tblActivities";

                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        ActivitiesModel activity = new ActivitiesModel
                        {
                            ActivityId = reader.GetInt32(0),
                            Title = reader.GetString(1),
                            Description = reader.GetString(2),
                            Location = reader.GetString(3),
                            StartTime = reader.GetDateTime(4),
                            EndTime = reader.GetDateTime(5),
                            NeededVolunteers = reader.GetInt32(6),
                            CurrentVolunteers = reader.GetInt32(7),
                            CreatedBy = reader.GetInt32(8)
                        };

                        activities.Add(activity);
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show($"Fout bij het ophalen van activiteiten: {ex.Message}");
                }

                return activities;
            }
        }

        // Functie om een activiteit te verwijderen
        public bool Delete(int activityId)
        {
            using (SqlConnection connection = new SqlConnection(conn))
            {
                string query = "DELETE FROM tblActivities WHERE ActivityId = @ActivityId";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ActivityId", activityId);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        return true; // Verwijderen gelukt
                    }
                    else
                    {
                        MessageBox.Show("Geen activiteit gevonden met dit ID.");
                        return false;
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show($"Fout bij het verwijderen van de activiteit: {ex.Message}");
                    return false;
                }
            }
        }
    }
}
