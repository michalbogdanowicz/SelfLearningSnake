namespace GraphicalRepr
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnGenerateGame = new System.Windows.Forms.Button();
            this.btnNextStep = new System.Windows.Forms.Button();
            this.btnAutomatic = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblAlive = new System.Windows.Forms.Label();
            this.lblMovements = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblSankesWhoAte = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblGeneration = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblMeanDistanceOfGeneration = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblMeanDistanceOfGeneration);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.lblGeneration);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.lblSankesWhoAte);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.lblMovements);
            this.panel2.Controls.Add(this.lblAlive);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.btnAutomatic);
            this.panel2.Controls.Add(this.btnNextStep);
            this.panel2.Controls.Add(this.btnGenerateGame);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(998, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(416, 608);
            this.panel2.TabIndex = 1;
            // 
            // btnGenerateGame
            // 
            this.btnGenerateGame.Location = new System.Drawing.Point(74, 39);
            this.btnGenerateGame.Name = "btnGenerateGame";
            this.btnGenerateGame.Size = new System.Drawing.Size(271, 23);
            this.btnGenerateGame.TabIndex = 2;
            this.btnGenerateGame.Text = "Generate Random World";
            this.btnGenerateGame.UseVisualStyleBackColor = true;
            this.btnGenerateGame.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnNextStep
            // 
            this.btnNextStep.Location = new System.Drawing.Point(222, 288);
            this.btnNextStep.Name = "btnNextStep";
            this.btnNextStep.Size = new System.Drawing.Size(123, 23);
            this.btnNextStep.TabIndex = 3;
            this.btnNextStep.Text = "Next STEP";
            this.btnNextStep.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // btnAutomatic
            // 
            this.btnAutomatic.Location = new System.Drawing.Point(222, 344);
            this.btnAutomatic.Name = "btnAutomatic";
            this.btnAutomatic.Size = new System.Drawing.Size(123, 23);
            this.btnAutomatic.TabIndex = 4;
            this.btnAutomatic.Text = "Automatic";
            this.btnAutomatic.UseVisualStyleBackColor = true;
            this.btnAutomatic.Click += new System.EventHandler(this.button2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(970, 608);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(74, 99);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(271, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Generate Fixed World";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(56, 353);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "alive";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 385);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Movements";
            // 
            // lblAlive
            // 
            this.lblAlive.AutoSize = true;
            this.lblAlive.Location = new System.Drawing.Point(140, 353);
            this.lblAlive.Name = "lblAlive";
            this.lblAlive.Size = new System.Drawing.Size(13, 13);
            this.lblAlive.TabIndex = 8;
            this.lblAlive.Text = "0";
            // 
            // lblMovements
            // 
            this.lblMovements.AutoSize = true;
            this.lblMovements.Location = new System.Drawing.Point(140, 385);
            this.lblMovements.Name = "lblMovements";
            this.lblMovements.Size = new System.Drawing.Size(13, 13);
            this.lblMovements.TabIndex = 9;
            this.lblMovements.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 417);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Sankes who ate";
            // 
            // lblSankesWhoAte
            // 
            this.lblSankesWhoAte.AutoSize = true;
            this.lblSankesWhoAte.Location = new System.Drawing.Point(140, 417);
            this.lblSankesWhoAte.Name = "lblSankesWhoAte";
            this.lblSankesWhoAte.Size = new System.Drawing.Size(13, 13);
            this.lblSankesWhoAte.TabIndex = 11;
            this.lblSankesWhoAte.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(38, 314);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Generation";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // lblGeneration
            // 
            this.lblGeneration.AutoSize = true;
            this.lblGeneration.Location = new System.Drawing.Point(140, 314);
            this.lblGeneration.Name = "lblGeneration";
            this.lblGeneration.Size = new System.Drawing.Size(13, 13);
            this.lblGeneration.TabIndex = 13;
            this.lblGeneration.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 460);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(146, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Mean distance Of Generation";
            // 
            // lblMeanDistanceOfGeneration
            // 
            this.lblMeanDistanceOfGeneration.AutoSize = true;
            this.lblMeanDistanceOfGeneration.Location = new System.Drawing.Point(177, 460);
            this.lblMeanDistanceOfGeneration.Name = "lblMeanDistanceOfGeneration";
            this.lblMeanDistanceOfGeneration.Size = new System.Drawing.Size(13, 13);
            this.lblMeanDistanceOfGeneration.TabIndex = 15;
            this.lblMeanDistanceOfGeneration.Text = "0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1414, 608);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnGenerateGame;
        private System.Windows.Forms.Button btnNextStep;
        private System.Windows.Forms.Button btnAutomatic;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblMovements;
        private System.Windows.Forms.Label lblAlive;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblSankesWhoAte;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblGeneration;
        private System.Windows.Forms.Label lblMeanDistanceOfGeneration;
        private System.Windows.Forms.Label label5;
    }
}

