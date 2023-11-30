using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System;
using System.Windows;
using System.Windows.Input;

namespace Mentalo_Magic8Ball_
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly string[] answers = { "Ja", "Nein", "Vielleicht", "Frag später nochmal", "Wahrscheinlich nicht", "Auf jeden Fall" };

        public MainWindow()
        {
            InitializeComponent();
        }

        //TODO: Methode erstellen die auch auf Enter-Taste reagiert
        private void Image_Click(object sender, MouseButtonEventArgs e)
        {
            // Benutzerfrage erhalten
            string userQuestion = txt_UserEingabe.Text;

            // Überprüfen, ob eine gültige Frage eingegeben wurde
            if (string.IsNullOrWhiteSpace(userQuestion) || userQuestion.ToLower() == "frage eingeben!")
            {
                // Wenn keine gültige Frage eingegeben wurde, zeige einen Hinweis an
                outputLabel.Content = "Bitte eine gültige Frage eingeben!";
            }
            else
            {
                // Zufällige Antwort auswählen
                Random random = new Random();
                int index = random.Next(answers.Length);
                string answer = answers[index];

                // Antwort anzeigen
                outputLabel.Content = $"Frage: {userQuestion}\nAntwort: {answer}";
            }
        }


        private void txt_UserEingabe_GotFocus(object sender, RoutedEventArgs e)
        {
            // Textbox leeren, wenn der Benutzer den Fokus erhält
            txt_UserEingabe.Text = "";
        }
    }
}
