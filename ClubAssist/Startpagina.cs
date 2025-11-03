using ClubAssist.Controller;
using ClubAssist.Pages;
using System;
using System.Windows.Forms;

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
            string inputUsername = txtUsername.Text.Trim();
            string inputPassword = txtPassword.Text.Trim();

            bool isValid = userController.VerifyLogin(inputUsername, inputPassword);

            if (isValid)
            {
                MessageBox.Show("Succesvol ingelogd!");

                // Hier kun je kiezen welke scherm je opent
                frmActiviteitenschermVrijwilliger vrijwilligerscherm = new frmActiviteitenschermVrijwilliger();
                vrijwilligerscherm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Verkeerde gebruikersnaam of wachtwoord!", "Foutmelding", MessageBoxButtons.OK);
            }
        }
        private void Startpagina_Load(object sender, EventArgs e)
        {
        }

        private void btnTESTORGANISATOR_Click(object sender, EventArgs e)
        {
            ClubAssist.View.Organisator.frmActiviteitenschermOrganisator organisatorscherm = new View.Organisator.frmActiviteitenschermOrganisator();
            organisatorscherm.ShowDialog();
        }
    }
}
