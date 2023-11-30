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
        // vielleicht noch lustige Anworten überlegen..
        private readonly string[] answers = { "Ja", "Nein", "Vielleicht", "Frag später nochmal", "Wahrscheinlich nicht", "Auf jeden Fall!" };

        public MainWindow()
        {
            InitializeComponent();
        }

        //TODO: Methode erstellen die auch auf Enter-Taste reagiert
        private void Image_Click(object sender, MouseButtonEventArgs e)
        {
            // Benutzerfrage erhalten
            string userQuestion = txt_UserEingabe.Text;

            // Prüfen d. gültigen Frageingabe
            if (string.IsNullOrWhiteSpace(userQuestion) || userQuestion.ToLower() == "Frage eingeben!")
            {
                // Wenn keine gültige Frage eingegeben wurde, zeige Hinweis an
                outputLabel.Content = "Bitte eine gültige Frage eingeben!";
            }
            else
            {
                // random Antwort
                Random random = new Random();
                int index = random.Next(answers.Length);
                string answer = answers[index];

                // Antwort im outputLabel
                outputLabel.Content = $"Frage: {userQuestion}\nAntwort: {answer}";
            }
        }


        private void txt_UserEingabe_GotFocus(object sender, RoutedEventArgs e)
        {
            // Textbox leeren, wenn der Benutzer reinclickt
            txt_UserEingabe.Text = "";
        }
    }
}
