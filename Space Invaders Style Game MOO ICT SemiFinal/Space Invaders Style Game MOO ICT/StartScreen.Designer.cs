namespace Space_Invaders_Style_Game_MOO_ICT
{
    partial class StartScreen
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.startupmenuTimer = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Desktop;
            this.button1.Font = new System.Drawing.Font("OCR A Extended", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.button1.Location = new System.Drawing.Point(280, 211);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(167, 45);
            this.button1.TabIndex = 0;
            this.button1.Text = "Easy";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.loadEasy);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.Desktop;
            this.button2.Font = new System.Drawing.Font("OCR A Extended", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.DodgerBlue;
            this.button2.Location = new System.Drawing.Point(280, 295);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(167, 44);
            this.button2.TabIndex = 1;
            this.button2.Text = "Medium";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.loadMedium);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.Desktop;
            this.button3.Font = new System.Drawing.Font("OCR A Extended", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.Red;
            this.button3.Location = new System.Drawing.Point(280, 377);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(167, 44);
            this.button3.TabIndex = 2;
            this.button3.Text = "Hard";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.loadHard);
            // 
            // startupmenuTimer
            // 
            this.startupmenuTimer.Interval = 20;
            this.startupmenuTimer.Tick += new System.EventHandler(this.startupMenuTimer);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("OCR A Extended", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label1.Location = new System.Drawing.Point(82, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(574, 66);
            this.label1.TabIndex = 3;
            this.label1.Text = "Space Invaders";
            // 
            // StartScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(734, 561);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "StartScreen";
            this.Text = "StartScreen";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Timer startupmenuTimer;
        private System.Windows.Forms.Label label1;
    }
}