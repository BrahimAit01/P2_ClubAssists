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

        public bool Create(ActivitiesModel activity)
        {
            using (SqlConnection connection = new SqlConnection(conn))
            {
                string query = @"INSERT INTO tblActivities 
                                 (Title, Description, Location, StartTime, EndTime, NeededVolunteers, CreatedBy)
                                 VALUES (@Title, @Description, @Location, @StartTime, @EndTime, @NeededVolunteers, @CreatedBy)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Title", activity.Title);
                command.Parameters.AddWithValue("@Description", activity.Description);
                command.Parameters.AddWithValue("@Location", activity.Location);
                command.Parameters.AddWithValue("@StartTime", activity.StartTime);
                command.Parameters.AddWithValue("@EndTime", activity.EndTime);
                command.Parameters.AddWithValue("@NeededVolunteers", activity.NeededVolunteers);
                command.Parameters.AddWithValue("@CreatedBy", activity.CreatedBy);
                try
                {
                    connection.Open();
                    return command.ExecuteNonQuery() > 0;
                }
                catch (SqlException ex)
                {
                    MessageBox.Show($"Fout bij het toevoegen van de activiteit: {ex.Message}");
                    return false;
                }
            }
        }

        public List<ActivitiesModel> Read()
        {
            List<ActivitiesModel> activities = new List<ActivitiesModel>();
            using (SqlConnection connection = new SqlConnection(conn))
            {
                string query = @"
                    SELECT a.ActivityId, a.Title, a.Description, a.Location, a.StartTime, a.EndTime, a.NeededVolunteers, a.CreatedBy,
                           COUNT(ua.UserId) AS CurrentVolunteers
                    FROM tblActivities a
                    LEFT JOIN tblUserActivities ua ON a.ActivityId = ua.ActivityId
                    GROUP BY a.ActivityId, a.Title, a.Description, a.Location, a.StartTime, a.EndTime, a.NeededVolunteers, a.CreatedBy";
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
            }
            return activities;
        }

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
                command.Parameters.AddWithValue("@CreatedBy", activity.CreatedBy);
                try
                {
                    connection.Open();
                    return command.ExecuteNonQuery() > 0;
                }
                catch (SqlException ex)
                {
                    MessageBox.Show($"Fout bij het updaten van de activiteit: {ex.Message}");
                    return false;
                }
            }
        }

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
                    return command.ExecuteNonQuery() > 0;
                }
                catch (SqlException ex)
                {
                    MessageBox.Show($"Fout bij het verwijderen van de activiteit: {ex.Message}");
                    return false;
                }
            }
        }

        public List<ActivitiesModel> GetByOrganisator(int organisatorId)
        {
            List<ActivitiesModel> activiteiten = new List<ActivitiesModel>();
            using (SqlConnection connection = new SqlConnection(conn))
            {
                string query = @"
                    SELECT a.ActivityId, a.Title, a.Description, a.Location, a.StartTime, a.EndTime, a.NeededVolunteers, a.CreatedBy,
                           COUNT(ua.UserId) AS CurrentVolunteers
                    FROM tblActivities a
                    LEFT JOIN tblUserActivities ua ON a.ActivityId = ua.ActivityId
                    WHERE a.CreatedBy = @CreatedBy
                    GROUP BY a.ActivityId, a.Title, a.Description, a.Location, a.StartTime, a.EndTime, a.NeededVolunteers, a.CreatedBy";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@CreatedBy", organisatorId);
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
                        activiteiten.Add(activity);
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show($"Fout bij ophalen van activiteiten van organisator: {ex.Message}");
                }
            }
            return activiteiten;
        }
    }
}
