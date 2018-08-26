namespace WindowsFormsApp4
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
            this.txtHTML = new System.Windows.Forms.RichTextBox();
            this.radioRotoGrinders = new System.Windows.Forms.RadioButton();
            this.radioNumberFire = new System.Windows.Forms.RadioButton();
            this.sbtButton = new System.Windows.Forms.Button();
            this.btnPrintPlayers = new System.Windows.Forms.Button();
            this.btnClearScreen = new System.Windows.Forms.Button();
            this.btnRunStats = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtHTML
            // 
            this.txtHTML.Location = new System.Drawing.Point(13, 13);
            this.txtHTML.Name = "txtHTML";
            this.txtHTML.Size = new System.Drawing.Size(832, 264);
            this.txtHTML.TabIndex = 0;
            this.txtHTML.Text = "";
            // 
            // radioRotoGrinders
            // 
            this.radioRotoGrinders.AutoSize = true;
            this.radioRotoGrinders.Location = new System.Drawing.Point(13, 296);
            this.radioRotoGrinders.Name = "radioRotoGrinders";
            this.radioRotoGrinders.Size = new System.Drawing.Size(130, 24);
            this.radioRotoGrinders.TabIndex = 1;
            this.radioRotoGrinders.TabStop = true;
            this.radioRotoGrinders.Text = "RotoGrinders";
            this.radioRotoGrinders.UseVisualStyleBackColor = true;
            this.radioRotoGrinders.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioNumberFire
            // 
            this.radioNumberFire.AutoSize = true;
            this.radioNumberFire.Location = new System.Drawing.Point(13, 327);
            this.radioNumberFire.Name = "radioNumberFire";
            this.radioNumberFire.Size = new System.Drawing.Size(117, 24);
            this.radioNumberFire.TabIndex = 2;
            this.radioNumberFire.TabStop = true;
            this.radioNumberFire.Text = "NumberFire";
            this.radioNumberFire.UseVisualStyleBackColor = true;
            // 
            // sbtButton
            // 
            this.sbtButton.Location = new System.Drawing.Point(13, 358);
            this.sbtButton.Name = "sbtButton";
            this.sbtButton.Size = new System.Drawing.Size(130, 48);
            this.sbtButton.TabIndex = 3;
            this.sbtButton.Text = "Submit";
            this.sbtButton.UseVisualStyleBackColor = true;
            this.sbtButton.Click += new System.EventHandler(this.sbtButton_Click);
            // 
            // btnPrintPlayers
            // 
            this.btnPrintPlayers.Location = new System.Drawing.Point(178, 358);
            this.btnPrintPlayers.Name = "btnPrintPlayers";
            this.btnPrintPlayers.Size = new System.Drawing.Size(128, 48);
            this.btnPrintPlayers.TabIndex = 4;
            this.btnPrintPlayers.Text = "Print Players";
            this.btnPrintPlayers.UseVisualStyleBackColor = true;
            this.btnPrintPlayers.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnClearScreen
            // 
            this.btnClearScreen.Location = new System.Drawing.Point(349, 358);
            this.btnClearScreen.Name = "btnClearScreen";
            this.btnClearScreen.Size = new System.Drawing.Size(151, 48);
            this.btnClearScreen.TabIndex = 5;
            this.btnClearScreen.Text = "Clear Screen";
            this.btnClearScreen.UseVisualStyleBackColor = true;
            this.btnClearScreen.Click += new System.EventHandler(this.btnClearScreen_Click);
            // 
            // btnRunStats
            // 
            this.btnRunStats.Location = new System.Drawing.Point(544, 358);
            this.btnRunStats.Name = "btnRunStats";
            this.btnRunStats.Size = new System.Drawing.Size(137, 48);
            this.btnRunStats.TabIndex = 6;
            this.btnRunStats.Text = "Run Stats";
            this.btnRunStats.UseVisualStyleBackColor = true;
            this.btnRunStats.Click += new System.EventHandler(this.btnRunStats_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1151, 459);
            this.Controls.Add(this.btnRunStats);
            this.Controls.Add(this.btnClearScreen);
            this.Controls.Add(this.btnPrintPlayers);
            this.Controls.Add(this.sbtButton);
            this.Controls.Add(this.radioNumberFire);
            this.Controls.Add(this.radioRotoGrinders);
            this.Controls.Add(this.txtHTML);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox txtHTML;
        private System.Windows.Forms.RadioButton radioRotoGrinders;
        private System.Windows.Forms.RadioButton radioNumberFire;
        private System.Windows.Forms.Button sbtButton;
        private System.Windows.Forms.Button btnPrintPlayers;
        private System.Windows.Forms.Button btnClearScreen;
        private System.Windows.Forms.Button btnRunStats;
    }
}

