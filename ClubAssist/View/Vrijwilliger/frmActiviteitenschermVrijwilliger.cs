using ClubAssist.Controller;
using ClubAssist.Model;



namespace ClubAssist.Pages
{
    public partial class frmActiviteitenschermVrijwilliger : Form
    {
        private readonly int _ingelogdeGebruikerId;
        private readonly string _ingelogdeGebruikerVoornaam;
        private readonly ActivitiesController activiteitenController;
        private readonly UserActivityController userActivityController;

        public frmActiviteitenschermVrijwilliger(int userId, string firstname)
        {
            InitializeComponent();
            activiteitenController = new ActivitiesController();
            userActivityController = new UserActivityController();
            _ingelogdeGebruikerId = userId;
            _ingelogdeGebruikerVoornaam = firstname;
        }

        private void frmActiviteitenscherm_Load(object sender, EventArgs e)
        {
            this.Text = $"Activiteitenscherm - Ingelogd als {_ingelogdeGebruikerVoornaam}";
            LaadAlleActiviteiten(); 
        }

        private void btnAlleActiviteiten_Click(object sender, EventArgs e)
        {
            LaadAlleActiviteiten();
        }

        private void LaadAlleActiviteiten()
        {
            lvActivities.Items.Clear();
            lvActivities.Columns.Clear();

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

            // Haal alle activiteiten op
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
                item.Tag = activity.ActivityId;
                lvActivities.Items.Add(item);
            }
        }

        private void btnAanmelden_Click(object sender, EventArgs e)
        {
            if (lvActivities.SelectedItems.Count == 0)
            {
                MessageBox.Show("Selecteer eerst een activiteit om je aan te melden.",
                    "Geen selectie", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Haal het geselecteerde item op
            ListViewItem selectedItem = lvActivities.SelectedItems[0];
            int selectedActivityId = (int)selectedItem.Tag; // we gaan zo Tag vullen met ActivityId

            // Controleer of gebruiker al is aangemeld
            if (userActivityController.IsReedsAangemeld(_ingelogdeGebruikerId, selectedActivityId))
            {
                MessageBox.Show("Je bent al aangemeld voor deze activiteit.",
                    "Opgelet", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            bool success = userActivityController.AanmeldenVoorActiviteit(_ingelogdeGebruikerId, selectedActivityId);

            if (success)
            {
                MessageBox.Show("Je bent succesvol aangemeld voor deze activiteit!",
                    "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Er ging iets mis bij het aanmelden.",
                    "Fout", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnMijnActiviteiten_Click(object sender, EventArgs e)
        {
            lvActivities.Items.Clear();
            lvActivities.Columns.Clear();

            lvActivities.Columns.Add("Titel", 200);
            lvActivities.Columns.Add("Omschrijving", 250);
            lvActivities.Columns.Add("Locatie", 200);
            lvActivities.Columns.Add("Startdatum", 200);
            lvActivities.Columns.Add("Einddatum", 200);

            lvActivities.FullRowSelect = true;
            lvActivities.HideSelection = false;
            lvActivities.View = System.Windows.Forms.View.Details;

            // Haal enkel activiteiten van deze gebruiker op
            List<ActivitiesModel> mijnActiviteiten = userActivityController.GetMijnActiviteiten(_ingelogdeGebruikerId);

            if (mijnActiviteiten.Count == 0)
            {
                MessageBox.Show("Je bent nog niet aangemeld voor activiteiten.",
                    "Geen activiteiten", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            foreach (var activity in mijnActiviteiten)
            {
                ListViewItem item = new ListViewItem(activity.Title);
                item.SubItems.Add(activity.Description);
                item.SubItems.Add(activity.Location);
                item.SubItems.Add(activity.StartTime.ToString("yyyy-MM-dd HH:mm"));
                item.SubItems.Add(activity.EndTime.ToString("yyyy-MM-dd HH:mm"));
                item.Tag = activity.ActivityId;
                lvActivities.Items.Add(item);
            }
        }


    }
}
