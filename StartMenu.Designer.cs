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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartMenu));
            btnNewGame = new Button();
            btnLoadGame = new Button();
            button1 = new Button();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // btnNewGame
            // 
            btnNewGame.BackColor = SystemColors.MenuHighlight;
            btnNewGame.Font = new Font("Arial Rounded MT Bold", 28.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnNewGame.ForeColor = SystemColors.ControlLightLight;
            btnNewGame.Location = new Point(12, 271);
            btnNewGame.Name = "btnNewGame";
            btnNewGame.Size = new Size(418, 124);
            btnNewGame.TabIndex = 0;
            btnNewGame.Text = "Partie starten";
            btnNewGame.UseVisualStyleBackColor = false;
            btnNewGame.Click += btnNewGame_Click;
            // 
            // btnLoadGame
            // 
            btnLoadGame.BackColor = SystemColors.ActiveCaption;
            btnLoadGame.Font = new Font("Arial Rounded MT Bold", 28.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnLoadGame.ForeColor = SystemColors.ControlLightLight;
            btnLoadGame.Location = new Point(12, 422);
            btnLoadGame.Name = "btnLoadGame";
            btnLoadGame.Size = new Size(418, 116);
            btnLoadGame.TabIndex = 1;
            btnLoadGame.Text = "Spiel Laden";
            btnLoadGame.UseVisualStyleBackColor = false;
            btnLoadGame.Click += btnLoadGame_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.Blue;
            button1.Font = new Font("Arial Rounded MT Bold", 28.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.ForeColor = SystemColors.ControlLightLight;
            button1.Location = new Point(12, 130);
            button1.Name = "button1";
            button1.Size = new Size(418, 110);
            button1.TabIndex = 2;
            button1.Text = "Zeit";
            button1.UseVisualStyleBackColor = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(101, 4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(256, 120);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // StartMenu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            ClientSize = new Size(443, 550);
            Controls.Add(pictureBox1);
            Controls.Add(button1);
            Controls.Add(btnLoadGame);
            Controls.Add(btnNewGame);
            Name = "StartMenu";
            Text = "StartMenu";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnNewGame;
        private Button btnLoadGame;
        private Button button1;
        private PictureBox pictureBox1;
    }
}