using ClubAssist.Controller;
using ClubAssist.Model;
using ClubAssist.Pages;
using ClubAssist.View.Organisator;

namespace ClubAssist
{
    public partial class Startpagina : Form
    {
        private readonly UserController userController = new UserController();

        public Startpagina()
        {
            InitializeComponent();
        }

        private void btnRegistratie_Click_1(object sender, EventArgs e)
        {
            Registratiescherm registratiescherm = new Registratiescherm();
            registratiescherm.ShowDialog();
        }

        private void btnInloggen_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            // 1?? Validatie
            if (!ValidateInput(username, password))
                return;

            // 2?? Authenticatie
            var user = AuthenticateUser(username, password);

            if (user == null)
                return;

            // 3?? Login afhandelen
            HandleLogin(user);
        }


        private bool ValidateInput(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vul een gebruikersnaam en wachtwoord in.",
                    "Foutmelding", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private modelUser AuthenticateUser(string username, string password)
        {
            bool isValid = userController.VerifyLogin(username, password);

            if (!isValid)
            {
                MessageBox.Show("Verkeerde gebruikersnaam of wachtwoord!",
                    "Foutmelding", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            modelUser user = userController.GetUserByUsername(username);

            if (user == null)
            {
                MessageBox.Show("Kon gebruikersgegevens niet ophalen.",
                    "Foutmelding", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            return user;
        }

        private void HandleLogin(modelUser user)
        {
            MessageBox.Show($"Welkom {user.Firstname}!", "Succesvol ingelogd",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (user.Role.Equals("Vrijwilliger", StringComparison.OrdinalIgnoreCase))
            {
                frmActiviteitenschermVrijwilliger vrijwilligerScherm =
                    new frmActiviteitenschermVrijwilliger(user.Id, user.Firstname);
                vrijwilligerScherm.ShowDialog();
            }
            else if (user.Role.Equals("Organisator", StringComparison.OrdinalIgnoreCase))
            {
                frmActiviteitenschermOrganisator organisatorScherm = new frmActiviteitenschermOrganisator(user.Id, user.Firstname);
                organisatorScherm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Onbekende gebruikersrol.",
                    "Foutmelding", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void Startpagina_Load(object sender, EventArgs e)
        {
        }

    }
}
