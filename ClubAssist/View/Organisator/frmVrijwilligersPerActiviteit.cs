using ClubAssist.Controller;
using ClubAssist.Model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ClubAssist.View.Organisator
{
    public partial class frmVrijwilligersPerActiviteit : Form
    {
        private readonly int _activityId;
        private readonly UserActivityController userActivityController;

        public frmVrijwilligersPerActiviteit(int activityId)
        {
            InitializeComponent();
            _activityId = activityId;
            userActivityController = new UserActivityController();
        }

        private void frmVrijwilligersPerActiviteit_Load(object sender, EventArgs e)
        {
            lvVrijwilligers.Columns.Add("Voornaam", 150);
            lvVrijwilligers.Columns.Add("Achternaam", 150);
            lvVrijwilligers.Columns.Add("Email", 200);
            lvVrijwilligers.Columns.Add("Telefoon", 150);
            lvVrijwilligers.Columns.Add("Gebruikersnaam", 150);
            lvVrijwilligers.FullRowSelect = true;
            lvVrijwilligers.View = System.Windows.Forms.View.Details;
            LoadVrijwilligers();
        }

        private void LoadVrijwilligers()
        {
            lvVrijwilligers.Items.Clear();
            List<modelUser> vrijwilligers = userActivityController.GetVrijwilligersVoorActiviteit(_activityId);
            foreach (var v in vrijwilligers)
            {
                ListViewItem item = new ListViewItem(v.Firstname);
                item.SubItems.Add(v.Lastname);
                item.SubItems.Add(v.Email);
                item.SubItems.Add(v.PhoneNumber);
                item.SubItems.Add(v.Username);
                lvVrijwilligers.Items.Add(item);
            }
        }
    }
}
