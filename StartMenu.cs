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
        string connectionString = "Server=localhost\\SQLEXPRESS;Database=ChessGameDB;Trusted_Connection=True;";

        public StartMenu()
        {
            InitializeComponent();
        }



        private void btnLoadGame_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Ladefunktion kommt später.");
        }

        private void btnNewGame_Click(object sender, EventArgs e)
        {
            Form1 gameForm = new Form1();
            gameForm.Show();
            this.Hide();
        }
    }
}
