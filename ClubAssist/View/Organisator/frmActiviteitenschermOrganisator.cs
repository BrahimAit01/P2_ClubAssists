using ClubAssist.Controller;
using ClubAssist.Model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ClubAssist.View.Organisator
{
    public partial class frmActiviteitenschermOrganisator : Form
    {
        private readonly int _ingelogdeOrganisatorId;
        private readonly string _ingelogdeOrganisatorNaam;
        private ActivitiesController activiteitenController;

        public frmActiviteitenschermOrganisator(int organisatorId, string naam)
        {
            InitializeComponent();
            _ingelogdeOrganisatorId = organisatorId;
            _ingelogdeOrganisatorNaam = naam;
            activiteitenController = new ActivitiesController();

        }

        private void frmActiviteitenschermOrganisator_Load(object sender, EventArgs e)
        {

            // Kolommen toevoegen aan de ListView (eenmalig)
            lvActivities.Columns.Add("Titel", 200);
            lvActivities.Columns.Add("Omschrijving", 250);
            lvActivities.Columns.Add("Locatie", 200);
            lvActivities.Columns.Add("Startdatum", 200);
            lvActivities.Columns.Add("Einddatum", 200);
            lvActivities.Columns.Add("Vrijwilligers Benodigd", 100);
            lvActivities.Columns.Add("Aangemelde Vrijwilligers", 100);
            lvActivities.Columns.Add("Aangemaakt door", 200);

            lvActivities.FullRowSelect = true;
            lvActivities.HideSelection = false;
            lvActivities.View = System.Windows.Forms.View.Details;

            LoadActivities();
        }

        // 🔁 Functie om de activiteiten in te laden
        private void LoadActivities()
        {
            lvActivities.Items.Clear(); // Maak eerst leeg

            List<ActivitiesModel> activities = activiteitenController.Read();

            foreach (var activity in activities)
            {
                ListViewItem item = new ListViewItem(activity.Title);
                item.SubItems.Add(activity.Description);
                item.SubItems.Add(activity.Location);
                item.SubItems.Add(activity.StartTime.ToString("yyyy-MM-dd HH:mm"));
                item.SubItems.Add(activity.EndTime.ToString("yyyy-MM-dd HH:mm"));
                item.SubItems.Add(activity.NeededVolunteers.ToString());
                item.SubItems.Add(activity.CurrentVolunteers.ToString());
                item.SubItems.Add(activity.CreatedBy.ToString());

                // ⚠️ Koppel het ID aan het item (onzichtbaar maar belangrijk)
                item.Tag = activity.ActivityId;

                lvActivities.Items.Add(item);
            }
        }

        // Verwijderen van item functie
        private void btnVerwijderen_Click(object sender, EventArgs e)
        {
            if (lvActivities.SelectedItems.Count == 0)
            {
                MessageBox.Show("Selecteer eerst een activiteit om te verwijderen.", "Let op", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ListViewItem selectedItem = lvActivities.SelectedItems[0];
            int activityId = (int)selectedItem.Tag;
            string activityTitle = selectedItem.Text;

            DialogResult result = MessageBox.Show(
                $"Weet je zeker dat je '{activityTitle}' wilt verwijderen?",
                "Bevestigen",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.No)
                return;

            bool success = activiteitenController.Delete(activityId);

            if (success)
            {
                MessageBox.Show($"Activiteit '{activityTitle}' is succesvol verwijderd.", "Verwijderd", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadActivities(); // Vernieuw de lijst
            }
            else
            {
                MessageBox.Show("Er is iets misgegaan bij het verwijderen.", "Fout", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnActiviteitAanmaken_Click(object sender, EventArgs e)
        {
            frmActiviteitAanmaken activiteitAanmaken = new frmActiviteitAanmaken(_ingelogdeOrganisatorId, _ingelogdeOrganisatorNaam);
            activiteitAanmaken.ShowDialog();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            // Functie opnieuw uitvoeren soort van refresh na aanmaken bijvoorbeeld
            LoadActivities();
        }

        private void btnActiviteitAanpassen_Click(object sender, EventArgs e)
        {
            if (lvActivities.SelectedItems.Count == 0)
            {
                MessageBox.Show("Selecteer eerst een activiteit om aan te passen.", "Let op", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Het ID van de geselecteerde activiteit ophalen uit de Tag
            ListViewItem selectedItem = lvActivities.SelectedItems[0];
            int activityId = (int)selectedItem.Tag;

            // frmActiviteitAanpassen openen en het ID meegeven
            frmActiviteitAanpassen formAanpassen = new frmActiviteitAanpassen(activityId);
            formAanpassen.ShowDialog();

            // Na sluiten: lijst vernieuwen zodat wijzigingen zichtbaar zijn
            LoadActivities();
        }

        private void btnToonVrijwilligers_Click(object sender, EventArgs e)
        {
            if (lvActivities.SelectedItems.Count == 0)
            {
                MessageBox.Show("Selecteer eerst een activiteit.", "Geen selectie", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int selectedActivityId = (int)lvActivities.SelectedItems[0].Tag;

            frmVrijwilligersPerActiviteit frmVrijwilligersTonen = new frmVrijwilligersPerActiviteit(selectedActivityId);
            frmVrijwilligersTonen.ShowDialog();
        }

        private void pbUitloggen_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
