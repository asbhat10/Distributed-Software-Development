namespace WindowsFormsApplication1
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
            this.urlText = new System.Windows.Forms.TextBox();
            this.goButton = new System.Windows.Forms.Button();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.encryptText = new System.Windows.Forms.TextBox();
            this.encryptButton = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.decryptButton = new System.Windows.Forms.Button();
            this.DecryptText = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.DecryptedString = new System.Windows.Forms.Label();
            this.encryptedText = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.CompanyText = new System.Windows.Forms.TextBox();
            this.GetQuotesButton = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.QuoteInfoText = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // urlText
            // 
            this.urlText.Location = new System.Drawing.Point(7, 3);
            this.urlText.Name = "urlText";
            this.urlText.Size = new System.Drawing.Size(1079, 20);
            this.urlText.TabIndex = 6;
            this.urlText.Text = " http://";
            // 
            // goButton
            // 
            this.goButton.Location = new System.Drawing.Point(1093, 3);
            this.goButton.Name = "goButton";
            this.goButton.Size = new System.Drawing.Size(59, 23);
            this.goButton.TabIndex = 7;
            this.goButton.Text = "Go!";
            this.goButton.UseVisualStyleBackColor = true;
            this.goButton.Click += new System.EventHandler(this.goButton_Click);
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(11, 30);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(1265, 581);
            this.webBrowser1.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(38, 458);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Encryption Service";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 488);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Text to be Encrypted";
            // 
            // encryptText
            // 
            this.encryptText.Location = new System.Drawing.Point(167, 488);
            this.encryptText.Name = "encryptText";
            this.encryptText.Size = new System.Drawing.Size(172, 20);
            this.encryptText.TabIndex = 13;
            // 
            // encryptButton
            // 
            this.encryptButton.Location = new System.Drawing.Point(358, 488);
            this.encryptButton.Name = "encryptButton";
            this.encryptButton.Size = new System.Drawing.Size(75, 23);
            this.encryptButton.TabIndex = 14;
            this.encryptButton.Text = "Encrypt";
            this.encryptButton.UseVisualStyleBackColor = true;
            this.encryptButton.Click += new System.EventHandler(this.encryptButton_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(43, 516);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Encrypted String: ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(44, 570);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(92, 13);
            this.label7.TabIndex = 20;
            this.label7.Text = "Decrypted String: ";
            // 
            // decryptButton
            // 
            this.decryptButton.Location = new System.Drawing.Point(358, 541);
            this.decryptButton.Name = "decryptButton";
            this.decryptButton.Size = new System.Drawing.Size(75, 23);
            this.decryptButton.TabIndex = 19;
            this.decryptButton.Text = "Decrypt";
            this.decryptButton.UseVisualStyleBackColor = true;
            this.decryptButton.Click += new System.EventHandler(this.decryptButton_Click);
            // 
            // DecryptText
            // 
            this.DecryptText.Location = new System.Drawing.Point(167, 543);
            this.DecryptText.Name = "DecryptText";
            this.DecryptText.Size = new System.Drawing.Size(172, 20);
            this.DecryptText.TabIndex = 18;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(28, 546);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(107, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Text to be Decrypted";
            // 
            // DecryptedString
            // 
            this.DecryptedString.AutoSize = true;
            this.DecryptedString.Location = new System.Drawing.Point(167, 570);
            this.DecryptedString.Name = "DecryptedString";
            this.DecryptedString.Size = new System.Drawing.Size(52, 13);
            this.DecryptedString.TabIndex = 21;
            this.DecryptedString.Text = "Print here";
            // 
            // encryptedText
            // 
            this.encryptedText.AutoSize = true;
            this.encryptedText.Location = new System.Drawing.Point(167, 516);
            this.encryptedText.Name = "encryptedText";
            this.encryptedText.Size = new System.Drawing.Size(52, 13);
            this.encryptedText.TabIndex = 22;
            this.encryptedText.Text = "Print here";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(525, 458);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(108, 13);
            this.label9.TabIndex = 23;
            this.label9.Text = "Stock Quote function";
            // 
            // CompanyText
            // 
            this.CompanyText.Location = new System.Drawing.Point(655, 481);
            this.CompanyText.Name = "CompanyText";
            this.CompanyText.Size = new System.Drawing.Size(168, 20);
            this.CompanyText.TabIndex = 24;
            // 
            // GetQuotesButton
            // 
            this.GetQuotesButton.Location = new System.Drawing.Point(843, 478);
            this.GetQuotesButton.Name = "GetQuotesButton";
            this.GetQuotesButton.Size = new System.Drawing.Size(75, 23);
            this.GetQuotesButton.TabIndex = 25;
            this.GetQuotesButton.Text = "Go!";
            this.GetQuotesButton.UseVisualStyleBackColor = true;
            this.GetQuotesButton.Click += new System.EventHandler(this.GetQuotesButton_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(592, 481);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(57, 13);
            this.label10.TabIndex = 26;
            this.label10.Text = "Company: ";
            // 
            // QuoteInfoText
            // 
            this.QuoteInfoText.AutoSize = true;
            this.QuoteInfoText.Location = new System.Drawing.Point(652, 520);
            this.QuoteInfoText.Name = "QuoteInfoText";
            this.QuoteInfoText.Size = new System.Drawing.Size(54, 13);
            this.QuoteInfoText.TabIndex = 27;
            this.QuoteInfoText.Text = "Print Here";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(591, 520);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(63, 13);
            this.label11.TabIndex = 28;
            this.label11.Text = "Quote Info: ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 623);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.QuoteInfoText);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.GetQuotesButton);
            this.Controls.Add(this.CompanyText);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.encryptedText);
            this.Controls.Add(this.DecryptedString);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.decryptButton);
            this.Controls.Add(this.DecryptText);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.encryptButton);
            this.Controls.Add(this.encryptText);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.goButton);
            this.Controls.Add(this.urlText);
            this.Name = "Form1";
            this.Text = "Abhishek\'s Browser";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox urlText;
        private System.Windows.Forms.Button goButton;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox encryptText;
        private System.Windows.Forms.Button encryptButton;
        private System.Windows.Forms.Label label6;

        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button decryptButton;
        private System.Windows.Forms.TextBox DecryptText;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label DecryptedString;
        private System.Windows.Forms.Label encryptedText;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox CompanyText;
        private System.Windows.Forms.Button GetQuotesButton;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label QuoteInfoText;
        private System.Windows.Forms.Label label11;
    }
}

