using ClubAssist.Controller;
using ClubAssist.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace ClubAssist.Pages
{
    public partial class frmActiviteitenschermVrijwilliger : Form
    {
        private ActivitiesController activiteitenController;

        public frmActiviteitenschermVrijwilliger()
        {
            InitializeComponent();
            activiteitenController = new ActivitiesController();
        }

        private void frmActiviteitenscherm_Load(object sender, EventArgs e)
        {
            // Voeg kolommen toe aan de ListView
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

            // Haal de activiteiten op via de controller
            List<ActivitiesModel> activities = activiteitenController.Read();

            // Voeg elke activiteit toe aan de ListView
            foreach (var activity in activities)
            {
                // Maak een nieuw ListViewItem voor de activiteit
                ListViewItem item = new ListViewItem(activity.Title);
                item.SubItems.Add(activity.Description);
                item.SubItems.Add(activity.Location);
                item.SubItems.Add(activity.StartTime.ToString("yyyy-MM-dd HH:mm"));
                item.SubItems.Add(activity.EndTime.ToString("yyyy-MM-dd HH:mm"));
                item.SubItems.Add(activity.NeededVolunteers.ToString());
                item.SubItems.Add(activity.CurrentVolunteers.ToString());
                item.SubItems.Add(activity.CreatedBy.ToString());

                // Voeg het item toe aan de ListView
                lvActivities.Items.Add(item);
            }
        }
    }
}
