using ClubAssist.Model;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Windows.Forms;

namespace ClubAssist.Controller
{

    internal class ActivitiesController
    {
        private readonly string conn = ConfigurationManager.ConnectionStrings["dbClubAssist"].ConnectionString;

        // 🟩 CREATE - Nieuwe activiteit toevoegen
        public bool Create(ActivitiesModel activity)
        {
            using (SqlConnection connection = new SqlConnection(conn))
            {
                string query = @"INSERT INTO tblActivities 
                                 (Title, Description, Location, StartTime, EndTime, NeededVolunteers, CurrentVolunteers, CreatedBy)
                                 VALUES (@Title, @Description, @Location, @StartTime, @EndTime, @NeededVolunteers, @CurrentVolunteers, @CreatedBy)";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Title", activity.Title);
                command.Parameters.AddWithValue("@Description", activity.Description);
                command.Parameters.AddWithValue("@Location", activity.Location);
                command.Parameters.AddWithValue("@StartTime", activity.StartTime);
                command.Parameters.AddWithValue("@EndTime", activity.EndTime);
                command.Parameters.AddWithValue("@NeededVolunteers", activity.NeededVolunteers);
                command.Parameters.AddWithValue("@CurrentVolunteers", 0);
                command.Parameters.AddWithValue("@CreatedBy", activity.CreatedBy);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                catch (SqlException ex)
                {
                    MessageBox.Show($"Fout bij het toevoegen van de activiteit: {ex.Message}");
                    return false;
                }
            }
        }

        // 🟨 READ - Alle activiteiten ophalen (met kolomnamen)
        public List<ActivitiesModel> Read()
        {
            List<ActivitiesModel> activities = new List<ActivitiesModel>();

            using (SqlConnection connection = new SqlConnection(conn))
            {
                string query = "SELECT * FROM tblActivities";

                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        ActivitiesModel activity = new ActivitiesModel
                        {
                            ActivityId = Convert.ToInt32(reader["ActivityId"]),
                            Title = reader["Title"].ToString(),
                            Description = reader["Description"].ToString(),
                            Location = reader["Location"].ToString(),
                            StartTime = Convert.ToDateTime(reader["StartTime"]),
                            EndTime = Convert.ToDateTime(reader["EndTime"]),
                            NeededVolunteers = Convert.ToInt32(reader["NeededVolunteers"]),
                            CurrentVolunteers = Convert.ToInt32(reader["CurrentVolunteers"]),
                            CreatedBy = Convert.ToInt32(reader["CreatedBy"])
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

        // 🟦 UPDATE - Activiteit bijwerken met parameters
        public bool Update(ActivitiesModel activity)
        {
            using (SqlConnection connection = new SqlConnection(conn))
            {
                string query = @"UPDATE tblActivities SET
                                    Title = @Title,
                                    Description = @Description,
                                    Location = @Location,
                                    StartTime = @StartTime,
                                    EndTime = @EndTime,
                                    NeededVolunteers = @NeededVolunteers,
                                    CurrentVolunteers = @CurrentVolunteers,
                                    CreatedBy = @CreatedBy
                                 WHERE ActivityId = @ActivityId";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ActivityId", activity.ActivityId);
                command.Parameters.AddWithValue("@Title", activity.Title);
                command.Parameters.AddWithValue("@Description", activity.Description);
                command.Parameters.AddWithValue("@Location", activity.Location);
                command.Parameters.AddWithValue("@StartTime", activity.StartTime);
                command.Parameters.AddWithValue("@EndTime", activity.EndTime);
                command.Parameters.AddWithValue("@NeededVolunteers", activity.NeededVolunteers);
                command.Parameters.AddWithValue("@CurrentVolunteers", activity.CurrentVolunteers);
                command.Parameters.AddWithValue("@CreatedBy", activity.CreatedBy);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                catch (SqlException ex)
                {
                    MessageBox.Show($"Fout bij het updaten van de activiteit: {ex.Message}");
                    return false;
                }
            }
        }

        // 🟥 DELETE - Activiteit verwijderen met parameter
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
