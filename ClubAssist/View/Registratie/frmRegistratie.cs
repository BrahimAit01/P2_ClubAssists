using ClubAssist.Controller;
using ClubAssist.Model;
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ClubAssist.Pages
{
    public partial class Registratiescherm : Form
    {
        private readonly UserController userController = new UserController();

        public Registratiescherm()
        {
            InitializeComponent();

            button1.Click += button1_Click;           // "Registreren" knop
            btnRegistratie.Click += btnRegistratie_Click; // "Annuleren" knop
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string firstname = textBox1.Text.Trim();
            string lastname = textBox2.Text.Trim();
            string email = textBox3.Text.Trim();
            string phone = txtTelefoonnummer.Text.Trim();
            string username = textBox4.Text.Trim();
            string password = textBox5.Text.Trim();
            string confirmPassword = textBox6.Text.Trim();
            string role = comboBox1.SelectedItem?.ToString() ?? "Vrijwilliger";

            // Basisvalidatie lege velden
            if (string.IsNullOrEmpty(firstname) || string.IsNullOrEmpty(lastname) ||
                string.IsNullOrEmpty(email) || string.IsNullOrEmpty(username) ||
                string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPassword))
            {
                MessageBox.Show("Vul alle verplichte velden in.");
                return;
            }

            // Controleer wachtwoorden
            if (password != confirmPassword)
            {
                MessageBox.Show("Wachtwoorden komen niet overeen.");
                return;
            }

            // E-mail validatie
            if (!IsValidEmail(email))
            {
                MessageBox.Show("Vul een geldig e-mailadres in.");
                return;
            }

            // Telefoonnummer validatie
            if (!IsValidPhoneNumber(phone))
            {
                MessageBox.Show("Vul een geldig telefoonnummer in (alleen cijfers).");
                return;
            }

            // Maak nieuw user-object
            var user = new modelUser
            {
                Firstname = firstname,
                Lastname = lastname,
                Email = email,
                PhoneNumber = phone,
                Username = username,
                Password = password,
                Role = role
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
            this.Close();
        }

        private bool IsValidEmail(string email)
        {
            return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }

        private bool IsValidPhoneNumber(string phone)
        {
            return Regex.IsMatch(phone, @"^\d{10,15}$"); // 10-15 cijfers
        }

        private void Registratiescherm_Load(object sender, EventArgs e)
        {
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList; // niet typen, alleen selecteren
            comboBox1.Items.Clear();
            comboBox1.Items.Add("Vrijwilliger"); 
            comboBox1.SelectedIndex = 0; 
        }
    }
}
