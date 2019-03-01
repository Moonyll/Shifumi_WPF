using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Globalization;

namespace Shifumi
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Déclaration des variables
        private bool choice_clicked = false;
        int index;
        double a;
        string[] shifumi = new string[] { "Pierre", "Feuille", "Ciseaux" }; // Tableau Pierre Feuille Ciseaux
        double wins, loss, deuce, games = 0; // Victoires, égalités, jeux
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Choice(object sender, RoutedEventArgs e)
        {
            Button button_choice = (Button)sender;

            //int index = System.Windows.Controls.Grid.GetColumn(button_choice); // Récupère l'index de la colonne du button choisi
            string choix = $"{button_choice.Content}";
            index = Array.IndexOf(shifumi, choix);

            joueur.Text = $"{"Le Joueur a choisi : "}{choix}";
            choice_clicked = true;

        }
        private void Play(object sender, RoutedEventArgs e)
        {
            if (choice_clicked == false)
            {
                MessageBox.Show("Merci de choisir entre Pierre, Feuille ou Ciseaux !");
            }
            else
            {

                Random random_number = new Random();
                int random_choice = random_number.Next(0, 3);
                var combine = index.ToString() + random_choice.ToString();
                int new_index = index;
                if (games != 0)
                {
                    a = Math.Round((wins / games) * 100, 2);
                }

                Button button_play = (Button)sender;

                ordinateur.Text = $"{"L'ordinateur a choisi : "}{shifumi[random_choice]}";
                if (combine == "02" || combine == "10" || combine == "21")
                {
                    wins++;
                    games++;
                    // Résultats   
                    resultat.Text = $"{shifumi[new_index]}{" Versus "}{shifumi[random_choice]}{"\n"}{" Gagné ! "}{"\n"}{" Victoires : "}{wins}{"\n"}{ " Défaites : "}{loss}{"\n"}{ " Egalités : "}{deuce}{"\n"}{" Nb Jeux : "}{games}";
                    pourcentage.Text = $"{"Pourcentage de victoire : "}{a}{" %"}";
                }
                else if (combine == "20" || combine == "01" || combine == "12")
                {
                    loss++;
                    games++;
                    // Résultats    
                    resultat.Text = $"{shifumi[new_index]}{" Versus "}{shifumi[random_choice]}{"\n"}{" Perdu... "}{"\n"}{"Victoires : "}{wins}{"\n"}{ " Défaites : "}{loss}{"\n"}{ " Egalités : "}{deuce}{"\n"}{" Nb Jeux : "}{games}";
                    pourcentage.Text = $"{"Pourcentage de victoire : "}{a}{" %"}";
                }
                else
                {
                    deuce++;
                    games++;
                    // Résultats     
                    resultat.Text = $"{shifumi[new_index]}{" Versus "}{shifumi[random_choice]}{"\n"}{" Egalité... "}{"\n"}{" Victoires : "}{wins}{"\n"}{ " Défaites : "}{loss}{"\n"}{ " Egalités : "}{deuce}{"\n"}{" Nb Jeux : "}{games}";
                    pourcentage.Text = $"{"Pourcentage de victoire : "}{a}{" %"}";
                }

            }
        }
    }
}
