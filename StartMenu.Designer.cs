namespace TheFinalChess
{
    partial class StartMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnNewGame = new Button();
            btnLoadGame = new Button();
            SuspendLayout();
            // 
            // btnNewGame
            // 
            btnNewGame.Location = new Point(94, 141);
            btnNewGame.Name = "btnNewGame";
            btnNewGame.Size = new Size(203, 132);
            btnNewGame.TabIndex = 0;
            btnNewGame.Text = "Neues Spiel";
            btnNewGame.UseVisualStyleBackColor = true;
            btnNewGame.Click += btnNewGame_Click;
            // 
            // btnLoadGame
            // 
            btnLoadGame.Location = new Point(438, 143);
            btnLoadGame.Name = "btnLoadGame";
            btnLoadGame.Size = new Size(175, 130);
            btnLoadGame.TabIndex = 1;
            btnLoadGame.Text = "Spiel Laden";
            btnLoadGame.UseVisualStyleBackColor = true;
            btnLoadGame.Click += btnLoadGame_Click;
            // 
            // StartMenu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 450);
            Controls.Add(btnLoadGame);
            Controls.Add(btnNewGame);
            Name = "StartMenu";
            Text = "StartMenu";
            ResumeLayout(false);
        }

        #endregion

        private Button btnNewGame;
        private Button btnLoadGame;
    }
}