using ClubAssist.Pages;
using ClubAssist.View.Organisator;

namespace ClubAssist
{
    public partial class Startpagina : Form
    {
        string username = "Brahim";
        string password = "Brahim";

        public Startpagina()
        {
            InitializeComponent();
        }

        public void Startpagina_Load(object sender, EventArgs e)
        {

        }

        private void btnRegistratie_Click_1(object sender, EventArgs e)
        {
            // Object gemaakt van form Registratiescherm
            Registratiescherm registratiescherm = new Registratiescherm();
            // Openen van het registratiescherm formulier
            registratiescherm.ShowDialog();
        }

        private void btnInloggen_Click(object sender, EventArgs e)
        {
            string inputUsername = txtUsername.Text;
            string inputPassword = txtPassword.Text;

            if (inputUsername == username && inputPassword == password)
            {
                frmActiviteitenschermVrijwilliger vrijwilligerscherm = new frmActiviteitenschermVrijwilliger();
                vrijwilligerscherm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Verkeerde invoer, probeer het opnieuw!", "Foutmelding", MessageBoxButtons.OK);
            }
        }

        private void btnTESTORGANISATOR_Click(object sender, EventArgs e)
        {
            ClubAssist.View.Organisator.frmActiviteitenschermOrganisator organisatorscherm = new View.Organisator.frmActiviteitenschermOrganisator();
            organisatorscherm.ShowDialog();
        }

        private void btnOrganisatortest_Click(object sender, EventArgs e)
        {
            frmActiviteitenschermOrganisator organisatortest = new frmActiviteitenschermOrganisator();

            organisatortest.ShowDialog();
        }
    }
}
