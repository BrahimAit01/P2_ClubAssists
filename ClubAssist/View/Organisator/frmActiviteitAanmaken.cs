using System;
using System.Windows.Forms;
using ClubAssist.Controller;
using ClubAssist.Model;

namespace ClubAssist.View.Organisator
{
    public partial class frmActiviteitAanmaken : Form
    {
        private readonly ActivitiesController controller = new ActivitiesController();
        private readonly int _ingelogdeOrganisatorId;
        private readonly string _ingelogdeOrganisatorNaam;

        public frmActiviteitAanmaken(int organisatorId, string naam)
        {
            InitializeComponent();
            _ingelogdeOrganisatorId = organisatorId;
            _ingelogdeOrganisatorNaam = naam;

        }

        private void frmActiviteitAanmaken_Load(object sender, EventArgs e)
        {
            this.Text = $"Activiteitenscherm - Ingelogd als {_ingelogdeOrganisatorNaam}";

            // Vul combobox met waarden van 1 t/m 15 voor vrijwilligers
            for (int i = 1; i <= 15; i++)
            {
                cbBenodigd.Items.Add(i);
            }

            cbBenodigd.DropDownStyle = ComboBoxStyle.DropDownList;
            cbBenodigd.SelectedIndex = 0;
        }

        private void btnAanmaken_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTitel.Text) ||
                string.IsNullOrWhiteSpace(txtOmschrijving.Text) ||
                string.IsNullOrWhiteSpace(txtLocatie.Text))
            {
                MessageBox.Show("Vul alle velden in voordat je verdergaat.", "Fout", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dtpEindtijd.Value <= dtpStarttijd.Value)
            {
                MessageBox.Show("De eindtijd moet later zijn dan de starttijd.", "Ongeldige tijd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int benodigdeVrijwilligers = Convert.ToInt32(cbBenodigd.SelectedItem);

            ActivitiesModel newActivity = new ActivitiesModel
            {
                Title = txtTitel.Text.Trim(),
                Description = txtOmschrijving.Text.Trim(),
                Location = txtLocatie.Text.Trim(),
                StartTime = dtpStarttijd.Value,
                EndTime = dtpEindtijd.Value,
                NeededVolunteers = benodigdeVrijwilligers,
                CurrentVolunteers = 0,
                CreatedBy = _ingelogdeOrganisatorId 
            };

            bool success = controller.Create(newActivity);

            if (success)
            {
                MessageBox.Show("Activiteit succesvol aangemaakt!", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close(); // sluit dit formulier na succesvol aanmaken
            }
            else
            {
                MessageBox.Show("Er is een fout opgetreden bij het aanmaken van de activiteit.", "Fout", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAnnuleren_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
