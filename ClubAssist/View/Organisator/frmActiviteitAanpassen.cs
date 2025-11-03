using ClubAssist.Controller;
using ClubAssist.Model;
using System;
using System.Windows.Forms;

namespace ClubAssist.View.Organisator
{
    public partial class frmActiviteitAanpassen : Form
    {
        private int activityId;
        private ActivitiesController controller = new ActivitiesController();

        public frmActiviteitAanpassen(int selectedActivityId)
        {
            InitializeComponent();
            activityId = selectedActivityId;
        }

        private void frmActiviteitAanpassen_Load(object sender, EventArgs e)
        {
            for (int i = 0; i <= 15; i++)
            {
                cbBenodigd.Items.Add(i);
            }

            LoadActivityDetails();
        }

        private void LoadActivityDetails()
        {
            var activity = controller.Read().Find(a => a.ActivityId == activityId);

            if (activity != null)
            {
                txtTitel.Text = activity.Title;
                txtOmschrijving.Text = activity.Description;
                txtLocatie.Text = activity.Location;
                dtpStarttijd.Value = activity.StartTime;
                dtpEindtijd.Value = activity.EndTime;
                cbBenodigd.SelectedItem = activity.NeededVolunteers.ToString();
            }
            else
            {
                MessageBox.Show("Activiteit niet gevonden.", "Fout", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cbBenodigd.SelectedItem == null)
            {
                MessageBox.Show("Selecteer eerst het aantal benodigde vrijwilligers.", "Fout", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var activityFromDb = controller.Read().Find(a => a.ActivityId == activityId);

            ActivitiesModel activity = new ActivitiesModel
            {
                ActivityId = activityId,
                Title = txtTitel.Text,
                Description = txtOmschrijving.Text,
                Location = txtLocatie.Text,
                StartTime = dtpStarttijd.Value,
                EndTime = dtpEindtijd.Value,
                NeededVolunteers = Convert.ToInt32(cbBenodigd.SelectedItem),
                CurrentVolunteers = activityFromDb.CurrentVolunteers,
                CreatedBy = activityFromDb.CreatedBy
            };

            if (controller.Update(activity))
            {
                MessageBox.Show("Activiteit succesvol aangepast!", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Er is een fout opgetreden bij het aanpassen van de activiteit.", "Fout", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
