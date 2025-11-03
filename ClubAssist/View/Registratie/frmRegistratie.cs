using ClubAssist.Controller;
using ClubAssist.Model;
using System;
using System.Windows.Forms;

namespace ClubAssist.Pages
{
    public partial class Registratiescherm : Form
    {
        private readonly UserController userController = new UserController();

        public Registratiescherm()
        {
            InitializeComponent();

            // Eventhandlers koppelen aan knoppen
            button1.Click += button1_Click;           // "Registreren" knop
            btnRegistratie.Click += btnRegistratie_Click; // "Annuleren" knop
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Controleer wachtwoorden
            if (textBox5.Text != textBox6.Text)
            {
                MessageBox.Show("Wachtwoorden komen niet overeen.");
                return;
            }

            // Maak nieuw user-object
            var user = new modelUser
            {
                Firstname = textBox1.Text.Trim(),
                Lastname = textBox2.Text.Trim(),
                Email = textBox3.Text.Trim(),
                Username = textBox4.Text.Trim(),
                Password = textBox5.Text.Trim(), // eventueel later gehasht
                Role = comboBox1.SelectedItem?.ToString() ?? "Vrijwilliger"
            };

            bool success = userController.RegisterUser(user);

            if (success)
            {
                MessageBox.Show("Gebruiker succesvol geregistreerd!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Er is iets misgegaan bij de registratie.");
            }
        }

        private void btnRegistratie_Click(object sender, EventArgs e)
        {
            // Sluit formulier zonder opslaan
            this.Close();
        }

        private void Registratiescherm_Load(object sender, EventArgs e)
        {
            // Eventueel iets doen bij het laden
        }
    }
}
