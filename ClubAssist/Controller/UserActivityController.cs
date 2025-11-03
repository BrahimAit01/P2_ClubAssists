using ClubAssist.Model;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Windows.Forms;

namespace ClubAssist.Controller
{
    internal class UserActivityController
    {
        private readonly string conn = ConfigurationManager.ConnectionStrings["dbClubAssist"].ConnectionString;

        // Vrijwilliger aanmelden voor activiteit
        public bool AanmeldenVoorActiviteit(int userId, int activityId)
        {
            using (SqlConnection connection = new SqlConnection(conn))
            {
                string query = @"INSERT INTO tblUserActivities (UserId, ActivityId) 
                                 VALUES (@UserId, @ActivityId)";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@UserId", userId);
                command.Parameters.AddWithValue("@ActivityId", activityId);

                try
                {
                    connection.Open();
                    int result = command.ExecuteNonQuery();
                    return result > 0;
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Fout bij aanmelden voor activiteit: " + ex.Message);
                    return false;
                }
            }
        }

        // Haal alle activiteiten van de vrijwilliger op
        public List<ActivitiesModel> GetMijnActiviteiten(int userId)
        {
            List<ActivitiesModel> activiteiten = new List<ActivitiesModel>();

            using (SqlConnection connection = new SqlConnection(conn))
            {
                string query = @"SELECT a.ActivityId, a.Title, a.Description, a.Location,
                                        a.StartTime, a.EndTime, a.NeededVolunteers,
                                        a.CurrentVolunteers, a.CreatedBy
                                 FROM tblActivities a
                                 INNER JOIN tblUserActivities ua ON a.ActivityId = ua.ActivityId
                                 WHERE ua.UserId = @UserId";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@UserId", userId);

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

                        activiteiten.Add(activity);
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Fout bij ophalen van activiteiten: " + ex.Message);
                }
            }

            return activiteiten;
        }

        // Controleer of gebruiker al is aangemeld
        public bool IsReedsAangemeld(int userId, int activityId)
        {
            using (SqlConnection connection = new SqlConnection(conn))
            {
                string query = @"SELECT COUNT(*) FROM tblUserActivities 
                                 WHERE UserId = @UserId AND ActivityId = @ActivityId";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@UserId", userId);
                command.Parameters.AddWithValue("@ActivityId", activityId);

                try
                {
                    connection.Open();
                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Fout bij controleren van aanmelding: " + ex.Message);
                    return false;
                }
            }
        }
    }
}
