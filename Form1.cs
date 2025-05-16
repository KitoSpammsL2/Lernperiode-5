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

        private StartMenu startMenuForm;

        public Form1()
        {
            InitializeComponent();


            startMenuForm = new StartMenu();

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
                    if (IsEnemyPiece(selectedButton, clickedButton))
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

        private bool IsEnemyPiece(Button from, Button to)
        {
            if (from.Tag == null || to.Tag == null) return false;

            string fromPiece = from.Tag.ToString(); // z. B. "white_King"
            string toPiece = to.Tag.ToString();     // z. B. "black_Pawn"

            // Farbe extrahieren (vor dem "_")
            string fromColor = fromPiece.Split('_')[0];
            string toColor = toPiece.Split('_')[0];

            return fromColor != toColor; // true, wenn gegnerische Farbe
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




        private void btnBackToMenu_Click_1(object sender, EventArgs e)
        {
            StartMenu menu = new StartMenu();
            menu.Show();
            this.Close();
        }



        private void BtnSave_Click(object sender, EventArgs e)
        {
            string connectionString = "Server=KAITO\\KAITO;Database=ChessGameDB;Trusted_Connection=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Bestehende Daten löschen
                SqlCommand deleteCommand = new SqlCommand("DELETE FROM ChessBoardState", connection);
                deleteCommand.ExecuteNonQuery();

                // Alle Buttons von A1 bis H8 durchgehen
                for (char col = 'A'; col <= 'H'; col++)
                {
                    for (int row = 1; row <= 8; row++)
                    {
                        string feldname = $"btn{col}{row}";
                        Control[] controls = this.Controls.Find(feldname, true);

                        if (controls.Length > 0 && controls[0] is Button button)
                        {
                            string inhalt = button.Tag?.ToString() ?? "";


                            SqlCommand insertCommand = new SqlCommand("INSERT INTO ChessBoardState (Feld, Inhalt) VALUES (@Feld, @Inhalt)", connection);
                            insertCommand.Parameters.AddWithValue("@Feld", $"{col}{row}");
                            insertCommand.Parameters.AddWithValue("@Inhalt", inhalt);
                            insertCommand.ExecuteNonQuery();
                        }
                    }
                }

                MessageBox.Show("Spielstand erfolgreich gespeichert.");
            }
        }






        public void SetFigureOnBoard(string position, string figurName)
        {
            Button button = GetButtonByPosition(position);
            if (button != null)
            {
                string imagePath = $"path_to_images/{figurName}.png";
                button.BackgroundImage = Image.FromFile(imagePath);
                button.BackgroundImageLayout = ImageLayout.Stretch;
            }
        }


        public void LoadGame()
        {
            ClearBoard();

            string query = "SELECT Feld, Inhalt FROM ChessBoardState";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string field = reader["Feld"].ToString();
                    string content = reader["Inhalt"].ToString();

                    Button btn = Controls.Find("btn" + field, true).FirstOrDefault() as Button;
                    if (btn != null && !string.IsNullOrEmpty(content))
                    {
                        switch (content)
                        {
                            case "whitePawn":
                                btn.BackgroundImage = whitePawnImage;
                                break;
                            case "blackPawn":
                                btn.BackgroundImage = blackPawnImage;
                                break;
                            case "whiteRook":
                                btn.BackgroundImage = whiteRookImage;
                                break;
                            case "blackRook":
                                btn.BackgroundImage = blackRookImage;
                                break;
                            case "whiteKnight":
                                btn.BackgroundImage = whiteKnightImage;
                                break;
                            case "blackKnight":
                                btn.BackgroundImage = blackKnightImage;
                                break;
                            case "whiteBishop":
                                btn.BackgroundImage = whiteBishopImage;
                                break;
                            case "blackBishop":
                                btn.BackgroundImage = blackBishopImage;
                                break;
                            case "whiteQueen":
                                btn.BackgroundImage = whiteQueenImage;
                                break;
                            case "blackQueen":
                                btn.BackgroundImage = blackQueenImage;
                                break;
                            case "whiteKing":
                                btn.BackgroundImage = whiteKingImage;
                                break;
                            case "blackKing":
                                btn.BackgroundImage = blackKingImage;
                                break;
                            default:
                                btn.BackgroundImage = null;
                                break;
                        }

                        btn.BackgroundImageLayout = ImageLayout.Stretch;
                    }
                }
            }
        }





        private void ClearBoard()
        {
            for (char col = 'A'; col <= 'H'; col++)
            {
                for (int row = 1; row <= 8; row++)
                {
                    string feldname = $"btn{col}{row}";
                    Control[] controls = this.Controls.Find(feldname, true);

                    if (controls.Length > 0 && controls[0] is Button button)
                    {
                        button.BackgroundImage = null;
                        button.Tag = null;
                    }
                }
            }

        }


        private Button GetButtonByPosition(string position)
        {
            switch (position)
            {
                case "A1": return btnA1;
                case "A2": return btnA2;
                case "A3": return btnA3;
                case "A4": return btnA4;
                case "A5": return btnA5;
                case "A6": return btnA6;
                case "A7": return btnA7;
                case "A8": return btnA8;
                case "B1": return btnB1;
                case "B2": return btnB2;
                case "B3": return btnB3;
                case "B4": return btnB4;
                case "B5": return btnB5;
                case "B6": return btnB6;
                case "B7": return btnB7;
                case "B8": return btnB8;
                case "C1": return btnC1;
                case "C2": return btnC2;
                case "C3": return btnC3;
                case "C4": return btnC4;
                case "C5": return btnC5;
                case "C6": return btnC6;
                case "C7": return btnC7;
                case "C8": return btnC8;
                case "D1": return btnD1;
                case "D2": return btnD2;
                case "D3": return btnD3;
                case "D4": return btnD4;
                case "D5": return btnD5;
                case "D6": return btnD6;
                case "D7": return btnD7;
                case "D8": return btnD8;
                case "E1": return btnE1;
                case "E2": return btnE2;
                case "E3": return btnE3;
                case "E4": return btnE4;
                case "E5": return btnE5;
                case "E6": return btnE6;
                case "E7": return btnE7;
                case "E8": return btnE8;
                case "F1": return btnF1;
                case "F2": return btnF2;
                case "F3": return btnF3;
                case "F4": return btnF4;
                case "F5": return btnF5;
                case "F6": return btnF6;
                case "F7": return btnF7;
                case "F8": return btnF8;
                case "G1": return btnG1;
                case "G2": return btnG2;
                case "G3": return btnG3;
                case "G4": return btnG4;
                case "G5": return btnG5;
                case "G6": return btnG6;
                case "G7": return btnG7;
                case "G8": return btnG8;
                case "H1": return btnH1;
                case "H2": return btnH2;
                case "H3": return btnH3;
                case "H4": return btnH4;
                case "H5": return btnH5;
                case "H6": return btnH6;
                case "H7": return btnH7;
                case "H8": return btnH8;
                default: return null;
            }
        }

        private void Lösche_Click(object sender, EventArgs e)
        {
            ClearBoard();
        }


        private Button FindKing(string color)
        {
            foreach (Control control in this.Controls)
            {
                if (control is Button btn && btn.Tag != null && btn.Tag.ToString() == $"{color}King")
                {
                    return btn;
                }
            }
            return null;
        }

        private bool HasLegalMoves(string color)
        {
            foreach (Control control in this.Controls)
            {
                if (control is Button from && from.Tag != null && from.Tag.ToString().StartsWith(color))
                {
                    foreach (Control target in this.Controls)
                    {
                        if (target is Button to && from != to)
                        {
                            if (IsValidMove(from, to))
                            {
                                var tempImage = to.BackgroundImage;
                                var tempTag = to.Tag;

                                to.BackgroundImage = from.BackgroundImage;
                                to.Tag = from.Tag;
                                from.BackgroundImage = null;
                                from.Tag = null;

                                bool inCheck = IsKingInCheck(color);

                                from.BackgroundImage = to.BackgroundImage;
                                from.Tag = to.Tag;
                                to.BackgroundImage = tempImage;
                                to.Tag = tempTag;

                                if (!inCheck)
                                    return true;
                            }
                        }
                    }
                }
            }
            return false;
        }


        private bool IsCheckmate()
        {
            string enemyKingTag = currentPlayer == "white" ? "blackKing" : "whiteKing";

            foreach (Control control in this.Controls)
            {
                if (control is Button btn && btn.Tag != null && btn.Tag.ToString() == enemyKingTag)
                {
                    return false;
                }
            }

            return true; 
        }







        private bool IsValidMove(Button from, Button to)
        {
            if (from.Tag == null) return false;
            string piece = from.Tag.ToString();

            if (to.Tag != null && !IsEnemyPiece(from, to)) return false;

            if (piece.Contains("King")) return IsValidKingMove(from, to);


            return false;
        }


        private bool IsKingInCheck(string currentPlayerColor)
        {
            Button kingButton = null;

            // 1. König finden
            foreach (Button btn in GetAllBoardButtons())
            {
                if (btn.BackgroundImage != null &&
                    btn.Tag != null &&
                    btn.Tag.ToString() == currentPlayerColor + "_King")
                {
                    kingButton = btn;
                    break;
                }
            }

            if (kingButton == null)
                return false;

            foreach (Button btn in GetAllBoardButtons())
            {
                if (btn.BackgroundImage != null &&
                    btn.Tag != null &&
                    btn.Tag.ToString().StartsWith(OpponentColor(currentPlayerColor)))
                {
                    if (IsValidMove(btn, kingButton))
                    {
                        return true;
                    }
                }
            }

            return false;
        }


        private string OpponentColor(string color)
        {
            return color == "White" ? "Black" : "White";
        }


        private bool HasAnyValidMove(string currentPlayerColor)
        {
            foreach (Button from in GetAllBoardButtons())
            {
                if (from.BackgroundImage != null &&
                    from.Tag != null &&
                    from.Tag.ToString().StartsWith(currentPlayerColor))
                {
                    foreach (Button to in GetAllBoardButtons())
                    {
                        if (from != to && IsValidMove(from, to))
                        {
                            // Zug testen
                            Image savedImageTo = to.BackgroundImage;
                            object savedTagTo = to.Tag;

                            to.BackgroundImage = from.BackgroundImage;
                            to.Tag = from.Tag;
                            from.BackgroundImage = null;
                            from.Tag = null;

                            bool kingInCheck = IsKingInCheck(currentPlayerColor);

                            // Rückgängig machen
                            from.BackgroundImage = to.BackgroundImage;
                            from.Tag = to.Tag;
                            to.BackgroundImage = savedImageTo;
                            to.Tag = savedTagTo;

                            if (!kingInCheck)
                                return true;
                        }
                    }
                }
            }

            return false;
        }


        private List<Button> GetAllBoardButtons()
        {
            List<Button> buttons = new List<Button>();

            foreach (Control control in this.Controls)
            {
                if (control is Button btn && btn.Name.StartsWith("btn"))
                {
                    buttons.Add(btn);
                }
            }

            return buttons;
        }



        private void DisableBoard()
        {
            foreach (Button btn in GetAllBoardButtons())
            {
                btn.Enabled = false;
            }
        }


    }

    public class FigurenPosition
    {
        public string Position { get; set; }
        public string Figur { get; set; }
    }


}