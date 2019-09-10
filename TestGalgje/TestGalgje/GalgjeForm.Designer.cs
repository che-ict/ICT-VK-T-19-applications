namespace TestGalgje
{
    partial class GalgjeForm
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
            this.Kies = new System.Windows.Forms.Button();
            this.TeKiezenWoord = new System.Windows.Forms.Label();
            this.LetterInvoer = new System.Windows.Forms.TextBox();
            this.DeGalg = new System.Windows.Forms.TextBox();
            this.NieuwPotjeButton = new System.Windows.Forms.Button();
            this.ValidatieMelding = new System.Windows.Forms.Label();
            this.GoedeLetters = new System.Windows.Forms.Label();
            this.FouteLetters = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Kies
            // 
            this.Kies.Location = new System.Drawing.Point(226, 141);
            this.Kies.Name = "Kies";
            this.Kies.Size = new System.Drawing.Size(61, 41);
            this.Kies.TabIndex = 0;
            this.Kies.Text = "Kies";
            this.Kies.UseVisualStyleBackColor = true;
            this.Kies.Click += new System.EventHandler(this.Kies_Click);
            // 
            // TeKiezenWoord
            // 
            this.TeKiezenWoord.AutoSize = true;
            this.TeKiezenWoord.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.TeKiezenWoord.Location = new System.Drawing.Point(184, 12);
            this.TeKiezenWoord.Name = "TeKiezenWoord";
            this.TeKiezenWoord.Size = new System.Drawing.Size(0, 36);
            this.TeKiezenWoord.TabIndex = 1;
            // 
            // LetterInvoer
            // 
            this.LetterInvoer.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.LetterInvoer.Location = new System.Drawing.Point(187, 141);
            this.LetterInvoer.MaxLength = 1;
            this.LetterInvoer.Name = "LetterInvoer";
            this.LetterInvoer.Size = new System.Drawing.Size(33, 41);
            this.LetterInvoer.TabIndex = 3;
            // 
            // DeGalg
            // 
            this.DeGalg.Font = new System.Drawing.Font("Courier New", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeGalg.Location = new System.Drawing.Point(12, 12);
            this.DeGalg.Multiline = true;
            this.DeGalg.Name = "DeGalg";
            this.DeGalg.Size = new System.Drawing.Size(138, 170);
            this.DeGalg.TabIndex = 4;
            // 
            // NieuwPotjeButton
            // 
            this.NieuwPotjeButton.Location = new System.Drawing.Point(12, 244);
            this.NieuwPotjeButton.Name = "NieuwPotjeButton";
            this.NieuwPotjeButton.Size = new System.Drawing.Size(153, 38);
            this.NieuwPotjeButton.TabIndex = 5;
            this.NieuwPotjeButton.Text = "Herstart";
            this.NieuwPotjeButton.UseVisualStyleBackColor = true;
            this.NieuwPotjeButton.Click += new System.EventHandler(this.NieuwPotjeButton_Click);
            // 
            // ValidatieMelding
            // 
            this.ValidatieMelding.AutoSize = true;
            this.ValidatieMelding.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.ValidatieMelding.ForeColor = System.Drawing.Color.Red;
            this.ValidatieMelding.Location = new System.Drawing.Point(12, 199);
            this.ValidatieMelding.Name = "ValidatieMelding";
            this.ValidatieMelding.Size = new System.Drawing.Size(0, 18);
            this.ValidatieMelding.TabIndex = 6;
            // 
            // GoedeLetters
            // 
            this.GoedeLetters.AutoSize = true;
            this.GoedeLetters.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.GoedeLetters.Location = new System.Drawing.Point(182, 61);
            this.GoedeLetters.Name = "GoedeLetters";
            this.GoedeLetters.Size = new System.Drawing.Size(0, 25);
            this.GoedeLetters.TabIndex = 7;
            // 
            // FouteLetters
            // 
            this.FouteLetters.AutoSize = true;
            this.FouteLetters.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.FouteLetters.ForeColor = System.Drawing.Color.Red;
            this.FouteLetters.Location = new System.Drawing.Point(340, 61);
            this.FouteLetters.Name = "FouteLetters";
            this.FouteLetters.Size = new System.Drawing.Size(0, 25);
            this.FouteLetters.TabIndex = 8;
            // 
            // GalgjeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(599, 295);
            this.Controls.Add(this.FouteLetters);
            this.Controls.Add(this.GoedeLetters);
            this.Controls.Add(this.ValidatieMelding);
            this.Controls.Add(this.NieuwPotjeButton);
            this.Controls.Add(this.DeGalg);
            this.Controls.Add(this.LetterInvoer);
            this.Controls.Add(this.TeKiezenWoord);
            this.Controls.Add(this.Kies);
            this.Name = "GalgjeForm";
            this.Text = "Galgje the game";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Kies;
        private System.Windows.Forms.Label TeKiezenWoord;
        private System.Windows.Forms.TextBox LetterInvoer;
        private System.Windows.Forms.TextBox DeGalg;
        private System.Windows.Forms.Button NieuwPotjeButton;
        private System.Windows.Forms.Label ValidatieMelding;
        private System.Windows.Forms.Label GoedeLetters;
        private System.Windows.Forms.Label FouteLetters;
    }
}

