using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;
using System.Windows;
using System.Windows.Controls;
using Zamestnanci.Data;
using ZamestnanciManagement.Model;
using System.Text.RegularExpressions;
using System;

namespace Zamestnanci
{
    public partial class MainWindow : Window
    {
        public List<Zamestnanec> Zamestnanci {  get; private set; }
        public MainWindow()
        {
            InitializeComponent();

        }
        public static bool IsValidEmail(string email)
        {
            return Regex.Match(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$ |^$", RegexOptions.IgnorePatternWhitespace).Success;
        }
        public static bool IsPhoneNumber(string number)
        {
            return Regex.Match(number, @"^(^[1-9]\d{8}$)+$ |^$", RegexOptions.IgnorePatternWhitespace).Success;
        }

        public void Create()
        {
            using (var context = new ZamestnaciContext())
            {
                var prijmeni = tbPrijmeni?.Text;
                var jmeno = tbJmeno?.Text;
                var telefon = tbTelefon.Text;
                var email = tbEmail.Text;

                if (prijmeni.IsNullOrEmpty() || jmeno.IsNullOrEmpty())
                {
                    MessageBox.Show("Příjmení nebo Jméno nemůže být prázdné");
                    
                }
                if (!IsValidEmail(email))
                {
                    MessageBox.Show("Email neni ve spravnem formatu.");
                }
                if (!IsPhoneNumber(telefon))
                {
                    MessageBox.Show("Telefoní číslo není ve správném formátu.");
                }
            else {
                    context.Zamestnanci.Add(new Zamestnanec() { Prijmeni = prijmeni, Jmeno = jmeno, Email = email, Telefon = telefon });
                    context.SaveChanges();
                }
        }
            
        }
           private void Read()
        {
            using (var context = new ZamestnaciContext())
            {
                Zamestnanci = context.Zamestnanci.ToList();
                //binding to ListView
                ZemestnanciList.ItemsSource = Zamestnanci;
            }
        }
        private void Update()
        {
            using (var context = new ZamestnaciContext())
            {
                Zamestnanec selectedZamestnanec = ZemestnanciList.SelectedItem as Zamestnanec;

                var prijmeni = tbPrijmeni.Text;
                var jmeno = tbJmeno.Text;
                var telefon = tbTelefon.Text;
                var email = tbEmail.Text;

                if (prijmeni.IsNullOrEmpty() || jmeno.IsNullOrEmpty())
                {
                    MessageBox.Show("Příjmení nebo Jméno nemůže být prázdné");

                }
                
                if (!IsValidEmail(email))
                {
                    MessageBox.Show("Email neni ve spravnem formatu.");
                }
                if (!IsPhoneNumber(telefon))
                {
                    MessageBox.Show("Telefoní číslo není ve správném formátu.");
                }

                else
                {
                    Zamestnanec zamestnanec =
                        context.Zamestnanci.Find(selectedZamestnanec.Id);
                    zamestnanec.Prijmeni = prijmeni;
                    zamestnanec.Jmeno = jmeno;
                zamestnanec.Email = email;
                    zamestnanec.Telefon = telefon;
                    context.SaveChanges();
                }
            }
        }




        private void ButtonUlozit_Click(object sender, RoutedEventArgs e)
        {
            Create();
        }

        private void ButtonOpravit_Click(object sender, RoutedEventArgs e)
        {
            Update();
        }

        private void ButtonZobrazit_Click(object sender, RoutedEventArgs e)
        {
            Read();
        }
    }
}