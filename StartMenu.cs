using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace TheFinalChess
{
    public partial class StartMenu : Form
    {
        string connectionString = "Server=KAITO\\KAITO;Database=ChessGameDB;Trusted_Connection=True;";

        public StartMenu()
        {
            InitializeComponent();
        }

        private void btnLoadGame_Click(object sender, EventArgs e)
        {
            Form1 gameForm = new Form1();  // Standardmäßig wird das Schachbrett geladen
            gameForm.LoadGame();           // Lade das gespeicherte Spiel
            gameForm.Show();               // Zeige das Schachbrett an

            this.Hide();
        }

        private void btnNewGame_Click(object sender, EventArgs e)
        {
            // Erstelle und öffne ein neues Spiel-Formular ohne das Startmenü zu übergeben
            Form1 gameForm = new Form1(); // Kein Parameter wird übergeben
            gameForm.Show(); // Das Hauptspiel-Formular wird angezeigt

            this.Hide(); // Verstecke das Startmenü-Formular
        }

        // Methode zum Laden des Spiels
        private void LoadGame()
        {
           
        }

        // Methode zum Setzen der Figur auf dem Button
        private void SetFigureOnBoard(string position, string figurName)
        {
            // Diese Methode benötigt die Referenz auf das Schachbrett (Form1), um auf die Buttons zuzugreifen
            Form1 gameForm = (Form1)Application.OpenForms["Form1"]; // Greift auf das Schachbrett-Formular zu
            gameForm.SetFigureOnBoard(position, figurName); // Setze die Figur auf dem Schachbrett
        }
    }
}
