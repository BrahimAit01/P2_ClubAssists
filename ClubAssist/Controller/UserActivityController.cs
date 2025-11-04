using ClubAssist.Model;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Windows.Forms;

namespace ClubAssist.Controller
{
    internal class UserActivityController
    {
        private readonly string conn = ConfigurationManager.ConnectionStrings["dbClubAssist"].ConnectionString;

        public bool IsReedsAangemeld(int userId, int activityId)
        {
            using (SqlConnection connection = new SqlConnection(conn))
            {
                string query = @"SELECT COUNT(*) FROM tblUserActivities WHERE UserId = @UserId AND ActivityId = @ActivityId";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@UserId", userId);
                command.Parameters.AddWithValue("@ActivityId", activityId);
                try
                {
                    connection.Open();
                    return (int)command.ExecuteScalar() > 0;
                }
                catch
                {
                    return false;
                }
            }
        }

        public bool AanmeldenVoorActiviteit(int userId, int activityId)
        {
            using (SqlConnection connection = new SqlConnection(conn))
            {
                connection.Open();

                string checkQuery = "SELECT NeededVolunteers, (SELECT COUNT(*) FROM tblUserActivities WHERE ActivityId = @ActivityId) AS CurrentVolunteers FROM tblActivities WHERE ActivityId = @ActivityId";
                SqlCommand checkCmd = new SqlCommand(checkQuery, connection);
                checkCmd.Parameters.AddWithValue("@ActivityId", activityId);
                SqlDataReader reader = checkCmd.ExecuteReader();

                if (!reader.Read())
                {
                    MessageBox.Show("Activiteit niet gevonden.", "Fout", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                int needed = Convert.ToInt32(reader["NeededVolunteers"]);
                int current = Convert.ToInt32(reader["CurrentVolunteers"]);
                reader.Close();

                if (current >= needed)
                {
                    MessageBox.Show("Het maximum aantal vrijwilligers voor deze activiteit is bereikt.", "Volgeboekt", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }

                if (IsReedsAangemeld(userId, activityId))
                {
                    MessageBox.Show("Je bent al aangemeld voor deze activiteit.", "Opgelet", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }

                string insertQuery = @"INSERT INTO tblUserActivities (UserId, ActivityId) VALUES (@UserId, @ActivityId)";
                SqlCommand insertCmd = new SqlCommand(insertQuery, connection);
                insertCmd.Parameters.AddWithValue("@UserId", userId);
                insertCmd.Parameters.AddWithValue("@ActivityId", activityId);
                return insertCmd.ExecuteNonQuery() > 0;
            }
        }

        public List<ActivitiesModel> GetMijnActiviteiten(int userId)
        {
            List<ActivitiesModel> activiteiten = new List<ActivitiesModel>();
            using (SqlConnection connection = new SqlConnection(conn))
            {
                string query = @"SELECT a.ActivityId, a.Title, a.Description, a.Location, a.StartTime, a.EndTime, a.NeededVolunteers, a.CreatedBy,
                                        COUNT(ua.UserId) AS CurrentVolunteers
                                 FROM tblActivities a
                                 INNER JOIN tblUserActivities ua ON a.ActivityId = ua.ActivityId
                                 WHERE ua.UserId = @UserId
                                 GROUP BY a.ActivityId, a.Title, a.Description, a.Location, a.StartTime, a.EndTime, a.NeededVolunteers, a.CreatedBy";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@UserId", userId);
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
            return activiteiten;
        }

        public List<modelUser> GetVrijwilligersVoorActiviteit(int activityId)
        {
            List<modelUser> users = new List<modelUser>();
            using (SqlConnection connection = new SqlConnection(conn))
            {
                string query = @"SELECT u.Firstname, u.Lastname, u.Email, u.PhoneNumber, u.Username 
                                 FROM tblUsers u
                                 INNER JOIN tblUserActivities ua ON u.UserId = ua.UserId
                                 WHERE ua.ActivityId = @ActivityId";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ActivityId", activityId);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    modelUser user = new modelUser
                    {
                        Firstname = reader["Firstname"].ToString(),
                        Lastname = reader["Lastname"].ToString(),
                        Email = reader["Email"].ToString(),
                        PhoneNumber = reader["PhoneNumber"].ToString(),
                        Username = reader["Username"].ToString()
                    };
                    users.Add(user);
                }
            }
            return users;
        }
    }
}
