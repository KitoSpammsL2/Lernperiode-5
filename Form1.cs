using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using Newtonsoft.Json;


namespace TheFinalChess
{
    public partial class Form1 : Form
    {
        private Button selectedButton = null;
        private Image whitePawnImage, blackPawnImage;
        private Image whiteRookImage, blackRookImage;
        private Image whiteKnightImage, blackKnightImage;
        private Image whiteBishopImage, blackBishopImage;
        private Image whiteQueenImage, blackQueenImage;
        private Image whiteKingImage, blackKingImage;

        string connectionString = "Server=KAITO\\KAITO;Database=ChessGameDB;Trusted_Connection=True;";


        public Form1()
        {
            InitializeComponent();


            whitePawnImage = LoadTransparentImage(@"C:\Users\kaito\source\repos\TheFinalChess\TheFinalChess\Resources\pawn-white-chess-piece-11532856224alv1lwm9ml.png");
            blackPawnImage = LoadTransparentImage(@"C:\Users\kaito\source\repos\TheFinalChess\TheFinalChess\Resources\awn-chess-piece-pawn-chess-piece-transparent-11563391176oxnhiiocwr.png");
            whiteRookImage = LoadTransparentImage(@"C:\Users\kaito\source\repos\TheFinalChess\TheFinalChess\Resources\rook-white-chess-piece-11532860352fgkrs0cewb.png");
            blackRookImage = LoadTransparentImage(@"C:\Users\kaito\source\repos\TheFinalChess\TheFinalChess\Resources\rook-black-chess-piece-11532860333ghjtvpbqyh.png");
            whiteKnightImage = LoadTransparentImage(@"C:\Users\kaito\source\repos\TheFinalChess\TheFinalChess\Resources\free-png-knight-white-chess-piece-png-images-transparent-white-chess-piece-knight-115629430673uazsbdfwl.png");
            blackKnightImage = LoadTransparentImage(@"C:\Users\kaito\source\repos\TheFinalChess\TheFinalChess\Resources\knight-chess-piece-single-chess-pieces-transparent-11563052385g1ueawbhff.png");
            whiteBishopImage = LoadTransparentImage(@"C:\Users\kaito\source\repos\TheFinalChess\TheFinalChess\Resources\bishop-white-chess-piece-11532847677hc6caq6osp.png");
            blackBishopImage = LoadTransparentImage(@"C:\Users\kaito\source\repos\TheFinalChess\TheFinalChess\Resources\bishop-black-chess-piece-11532847664y1lgfdc9mj.png");
            whiteQueenImage = LoadTransparentImage(@"C:\Users\kaito\source\repos\TheFinalChess\TheFinalChess\Resources\queen-white-chess-piece-1153286020237xtfzok6y.png");
            blackQueenImage = LoadTransparentImage(@"C:\Users\kaito\source\repos\TheFinalChess\TheFinalChess\Resources\queen-black-chess-piece-11532856322hwnpzklmal.png");
            whiteKingImage = LoadTransparentImage(@"C:\Users\kaito\source\repos\TheFinalChess\TheFinalChess\Resources\king-white-chess-piece-11532856134uuwp9qlozn.png");
            blackKingImage = LoadTransparentImage(@"C:\Users\kaito\source\repos\TheFinalChess\TheFinalChess\Resources\king-black-chess-piece-115328561199vb1bvbiin.png");


            PlacePawns();
            PlaceRooks();
            PlaceKnights();
            PlaceBishops();
            PlaceQueens();
            PlaceKings();



            foreach (Control control in this.Controls)
            {
                if (control is Button button)
                {
                    button.Click += Button_Click;
                }
            }
        }

        private Image LoadTransparentImage(string path)
        {
            Image img = Image.FromFile(path);
            Bitmap bmp = new Bitmap(img);
            bmp.MakeTransparent(Color.White);
            return bmp;
        }


        private void SetButtonImage(Button btn, Image img)
        {
            btn.Image = img;
            btn.FlatStyle = FlatStyle.Flat;
            btn.BackColor = Color.Transparent;
            btn.FlatAppearance.BorderSize = 0;
        }

        private void SetPictureBoxImage(PictureBox pb, Image img)
        {
            pb.Image = img;
            pb.SizeMode = PictureBoxSizeMode.StretchImage;
            pb.BackColor = Color.Transparent;
        }

        private void PlaceKnights()
        {
            string[] whiteKnightPositions = { "btnB1", "btnG1" };
            string[] blackKnightPositions = { "btnB8", "btnG8" };

            foreach (string pos in whiteKnightPositions)
                PlacePiece(pos, whiteKnightImage, "whiteKnight");

            foreach (string pos in blackKnightPositions)
                PlacePiece(pos, blackKnightImage, "blackKnight");
        }
        private void PlaceQueens()
        {
            PlacePiece("btnD1", whiteQueenImage, "whiteQueen");
            PlacePiece("btnD8", blackQueenImage, "blackQueen");
        }

        private void PlaceKings()
        {
            PlacePiece("btnE1", whiteKingImage, "whiteKing");
            PlacePiece("btnE8", blackKingImage, "blackKing");
        }

        private void PlacePiece(string position, Image image, string tag)
        {
            Button btn = this.Controls.Find(position, true)[0] as Button;
            btn.BackgroundImage = image;
            btn.Tag = tag;
            btn.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void PlacePawns()
        {
            char[] columns = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H' };

            foreach (char col in columns)
            {
                string whiteButtonName = $"btn{col}2";
                string blackButtonName = $"btn{col}7";

                Button whiteBtn = this.Controls.Find(whiteButtonName, true)[0] as Button;
                Button blackBtn = this.Controls.Find(blackButtonName, true)[0] as Button;

                whiteBtn.BackgroundImage = whitePawnImage;
                whiteBtn.Tag = "whitePawn";
                whiteBtn.BackgroundImageLayout = ImageLayout.Stretch;

                blackBtn.BackgroundImage = blackPawnImage;
                blackBtn.Tag = "blackPawn";
                blackBtn.BackgroundImageLayout = ImageLayout.Stretch;
            }
        }

        private void PlaceRooks()
        {
            string[] whiteRookPositions = { "btnA1", "btnH1" };
            string[] blackRookPositions = { "btnA8", "btnH8" };

            foreach (string pos in whiteRookPositions)
            {
                Button btn = this.Controls.Find(pos, true)[0] as Button;
                btn.BackgroundImage = whiteRookImage;
                btn.Tag = "whiteRook";
                btn.BackgroundImageLayout = ImageLayout.Stretch;
            }

            foreach (string pos in blackRookPositions)
            {
                Button btn = this.Controls.Find(pos, true)[0] as Button;
                btn.BackgroundImage = blackRookImage;
                btn.Tag = "blackRook";
                btn.BackgroundImageLayout = ImageLayout.Stretch;
            }
        }


        private void PlaceBishops()
        {
            string[] whiteBishopPositions = { "btnC1", "btnF1" };
            string[] blackBishopPositions = { "btnC8", "btnF8" };


            foreach (string pos in whiteBishopPositions)
            {
                Button btn = this.Controls.Find(pos, true)[0] as Button;
                btn.BackgroundImage = whiteBishopImage;
                btn.Tag = "whiteBishop";
                btn.BackgroundImageLayout = ImageLayout.Stretch;
            }


            foreach (string pos in blackBishopPositions)
            {
                Button btn = this.Controls.Find(pos, true)[0] as Button;
                btn.BackgroundImage = blackBishopImage;
                btn.Tag = "blackBishop";
                btn.BackgroundImageLayout = ImageLayout.Stretch;
            }
        }


        private string currentPlayer = "white";

        private void Button_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;

            if (clickedButton.BackgroundImage != null)
            {
                if (selectedButton == null)
                {
                    if (IsCorrectPlayer(clickedButton))
                    {
                        selectedButton = clickedButton;
                    }
                    else
                    {
                        MessageBox.Show("Es ist nicht deine Runde!");
                    }
                }
                else
                {
                    if (IsEnemyPiece(clickedButton))
                    {
                        MovePiece(selectedButton, clickedButton);
                        SwitchPlayer();
                        selectedButton = null;
                    }
                    else
                    {
                        if (IsCorrectPlayer(clickedButton))
                        {
                            selectedButton = clickedButton;
                        }
                    }
                }
            }
            else if (selectedButton != null)
            {
                MovePiece(selectedButton, clickedButton);
                SwitchPlayer();
                selectedButton = null;
            }
        }

        private bool IsEnemyPiece(Button button)
        {
            if (button.Tag == null || selectedButton == null) return false;

            string selectedTag = selectedButton.Tag.ToString();
            string clickedTag = button.Tag.ToString();

            return (selectedTag.Contains("white") && clickedTag.Contains("black")) ||
                   (selectedTag.Contains("black") && clickedTag.Contains("white"));
        }



        private bool IsCorrectPlayer(Button button)
        {

            if (currentPlayer == "white" && button.Tag.ToString().Contains("white"))
            {
                return true;
            }
            if (currentPlayer == "black" && button.Tag.ToString().Contains("black"))
            {
                return true;
            }
            return false;
        }

        private void SwitchPlayer()
        {

            currentPlayer = currentPlayer == "white" ? "black" : "white";
        }

        private void MovePiece(Button from, Button to)
        {
            string fromTag = from.Tag?.ToString();
            string toTag = to.Tag?.ToString();

            if (fromTag.Contains("Pawn") && IsValidPawnMove(from, to) ||
                fromTag.Contains("Rook") && IsValidRookMove(from, to) ||
                fromTag.Contains("Bishop") && IsValidBishopMove(from, to) ||
                fromTag.Contains("Knight") && IsValidKnightMove(from, to) ||
                fromTag.Contains("Queen") && IsValidQueenMove(from, to) ||
                fromTag.Contains("King") && IsValidKingMove(from, to))
            {
                if (toTag != null && toTag.Contains("King"))
                {
                    MessageBox.Show($"{currentPlayer} gewinnt! Spiel vorbei.");
                    Application.Exit();
                }
                MoveFigure(from, to);
            }
        }

        private bool IsValidKingMove(Button from, Button to)
        {
            string fromName = from.Name;
            string toName = to.Name;

            int colFrom = fromName[3] - 'A';
            int rowFrom = int.Parse(fromName[4].ToString());
            int colTo = toName[3] - 'A';
            int rowTo = int.Parse(toName[4].ToString());

            return Math.Abs(colFrom - colTo) <= 1 && Math.Abs(rowFrom - rowTo) <= 1;
        }
        private bool IsValidQueenMove(Button from, Button to)
        {
            return IsValidRookMove(from, to) || IsValidBishopMove(from, to);
        }

        private bool IsValidPawnMove(Button from, Button to)
        {
            string fromName = from.Name;
            string toName = to.Name;

            int colFrom = fromName[3] - 'A';
            int rowFrom = int.Parse(fromName[4].ToString());
            int colTo = toName[3] - 'A';
            int rowTo = int.Parse(toName[4].ToString());

            string pawnColor = from.Tag.ToString();
            bool isCapture = to.BackgroundImage != null;


            if (pawnColor == "whitePawn")
            {
                if (colFrom == colTo && !isCapture)
                {
                    if (rowFrom == 2 && rowTo == 4)
                    {
                        return true;
                    }
                    else if (rowTo == rowFrom + 1)
                    {
                        return true;
                    }
                }
                else if (isCapture && Math.Abs(colFrom - colTo) == 1 && rowTo == rowFrom + 1)
                {

                    if (to.Tag != null && !to.Tag.ToString().Contains("white"))
                    {

                        to.BackgroundImage = null;
                        to.Tag = null;
                        return true;
                    }
                }
            }

            else if (pawnColor == "blackPawn")
            {
                if (colFrom == colTo && !isCapture)
                {
                    if (rowFrom == 7 && rowTo == 5)
                    {
                        return true;
                    }
                    else if (rowTo == rowFrom - 1)
                    {
                        return true;
                    }
                }
                else if (isCapture && Math.Abs(colFrom - colTo) == 1 && rowTo == rowFrom - 1)
                {

                    if (to.Tag != null && !to.Tag.ToString().Contains("black"))
                    {

                        to.BackgroundImage = null;
                        to.Tag = null;
                        return true;
                    }
                }
            }

            return false;
        }

        private bool IsValidKnightMove(Button from, Button to)
        {
            string fromName = from.Name;
            string toName = to.Name;

            int colFrom = fromName[3] - 'A';
            int rowFrom = int.Parse(fromName[4].ToString());
            int colTo = toName[3] - 'A';
            int rowTo = int.Parse(toName[4].ToString());

            int colDiff = Math.Abs(colFrom - colTo);
            int rowDiff = Math.Abs(rowFrom - rowTo);

            return (colDiff == 2 && rowDiff == 1) || (colDiff == 1 && rowDiff == 2);
        }

        private bool IsValidRookMove(Button from, Button to)
        {
            if (!IsPathClear(from, to)) return false;

            string fromName = from.Name;
            string toName = to.Name;
            int colFrom = fromName[3] - 'A';
            int rowFrom = int.Parse(fromName[4].ToString());
            int colTo = toName[3] - 'A';
            int rowTo = int.Parse(toName[4].ToString());

            return colFrom == colTo || rowFrom == rowTo;
        }
        private bool IsValidBishopMove(Button from, Button to)
        {
            if (!IsPathClear(from, to)) return false;

            string fromName = from.Name;
            string toName = to.Name;
            int colFrom = fromName[3] - 'A';
            int rowFrom = int.Parse(fromName[4].ToString());
            int colTo = toName[3] - 'A';
            int rowTo = int.Parse(toName[4].ToString());

            return Math.Abs(colFrom - colTo) == Math.Abs(rowFrom - rowTo);
        }
        private bool IsPathClear(Button from, Button to)
        {
            string fromName = from.Name;
            string toName = to.Name;
            int colFrom = fromName[3] - 'A';
            int rowFrom = int.Parse(fromName[4].ToString());
            int colTo = toName[3] - 'A';
            int rowTo = int.Parse(toName[4].ToString());

            int colStep = colFrom == colTo ? 0 : (colTo > colFrom ? 1 : -1);
            int rowStep = rowFrom == rowTo ? 0 : (rowTo > rowFrom ? 1 : -1);

            int col = colFrom + colStep;
            int row = rowFrom + rowStep;

            while (col != colTo || row != rowTo)
            {
                string position = $"btn{(char)('A' + col)}{row}";
                Button btn = this.Controls.Find(position, true).FirstOrDefault() as Button;
                if (btn != null && btn.BackgroundImage != null)
                {
                    return false;
                }
                col += colStep;
                row += rowStep;
            }
            return true;
        }

        private void MoveFigure(Button from, Button to)
        {
            to.BackgroundImage = from.BackgroundImage;
            to.BackgroundImageLayout = ImageLayout.Stretch;
            to.Tag = from.Tag;
            from.BackgroundImage = null;
            from.Tag = null;
        }

        private void btnBackToMenu_Click(object sender, EventArgs e)
        {
            StartMenu menu = new StartMenu();
            menu.Show();
            this.Close();
        }



        private void btnSave_Click(object sender, EventArgs e)
        {
            List<FigurenPosition> positionen = new List<FigurenPosition>();

            foreach (Control c in this.Controls)
            {
                if (c is Button btn && btn.Name.StartsWith("btn"))
                {
                    string position = btn.Name.Substring(3); // z.B. "A1"
                    string figur = btn.Tag?.ToString(); // z.B. "whitePawn", "blackKing", etc.

                    if (!string.IsNullOrWhiteSpace(figur))
                    {
                        positionen.Add(new FigurenPosition
                        {
                            Position = position,
                            Figur = figur
                        });
                    }
                }
            }

            string json = JsonConvert.SerializeObject(positionen);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO Savegames (Spielstand) VALUES (@json)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@json", json);
                    command.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Spiel erfolgreich gespeichert.");
        }
        private void SaveGame(string gameState)
        {
            string connectionString = "Server=KAITO/KAITO;Database=ChessGameDB;Trusted_Connection=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "INSERT INTO GameStates (GameState) VALUES (@GameState)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@GameState", gameState);
                    command.ExecuteNonQuery();
                }
            }
        }


    }

    public class FigurenPosition
    {
        public string Position { get; set; }
        public string Figur { get; set; }
    }


}