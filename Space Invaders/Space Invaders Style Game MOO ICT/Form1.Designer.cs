namespace Space_Invaders_Style_Game_MOO_ICT
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.txtScore = new System.Windows.Forms.Label();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.LivesTracker = new System.Windows.Forms.Label();
            this.player = new System.Windows.Forms.PictureBox();
            this.gamedone = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.player)).BeginInit();
            this.SuspendLayout();
            // 
            // txtScore
            // 
            this.txtScore.AutoSize = true;
            this.txtScore.Font = new System.Drawing.Font("OCR A Extended", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtScore.ForeColor = System.Drawing.Color.White;
            this.txtScore.Location = new System.Drawing.Point(12, 19);
            this.txtScore.Name = "txtScore";
            this.txtScore.Size = new System.Drawing.Size(165, 20);
            this.txtScore.TabIndex = 0;
            this.txtScore.Text = "Invaders : 50";
            // 
            // gameTimer
            // 
            this.gameTimer.Interval = 20;
            this.gameTimer.Tick += new System.EventHandler(this.mainGameTimerEvent);
            // 
            // LivesTracker
            // 
            this.LivesTracker.AutoSize = true;
            this.LivesTracker.Font = new System.Drawing.Font("OCR A Extended", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LivesTracker.ForeColor = System.Drawing.Color.White;
            this.LivesTracker.Location = new System.Drawing.Point(607, 19);
            this.LivesTracker.Name = "LivesTracker";
            this.LivesTracker.Size = new System.Drawing.Size(105, 20);
            this.LivesTracker.TabIndex = 2;
            this.LivesTracker.Text = "Lives: 5";
            this.LivesTracker.Click += new System.EventHandler(this.label1_Click);
            // 
            // player
            // 
            this.player.Image = global::Space_Invaders_Style_Game_MOO_ICT.Properties.Resources.spaceship2;
            this.player.Location = new System.Drawing.Point(328, 482);
            this.player.Name = "player";
            this.player.Size = new System.Drawing.Size(61, 61);
            this.player.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.player.TabIndex = 1;
            this.player.TabStop = false;
            this.player.Click += new System.EventHandler(this.player_Click);
            // 
            // gamedone
            // 
            this.gamedone.AutoSize = true;
            this.gamedone.Font = new System.Drawing.Font("OCR A Extended", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gamedone.ForeColor = System.Drawing.Color.Red;
            this.gamedone.Location = new System.Drawing.Point(255, 215);
            this.gamedone.Name = "gamedone";
            this.gamedone.Size = new System.Drawing.Size(0, 37);
            this.gamedone.TabIndex = 3;
            this.gamedone.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(734, 561);
            this.Controls.Add(this.LivesTracker);
            this.Controls.Add(this.player);
            this.Controls.Add(this.txtScore);
            this.Controls.Add(this.gamedone);
            this.Name = "Form1";
            this.Text = "Space Invaders Style Game MOO ICT";
            ((System.ComponentModel.ISupportInitialize)(this.player)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label txtScore;
        private System.Windows.Forms.PictureBox player;
        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.Label LivesTracker;
        private System.Windows.Forms.Label gamedone;
    }
}

