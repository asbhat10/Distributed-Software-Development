namespace TemperatureApplication
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
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.convertedLabel = new System.Windows.Forms.Label();
            this.CelToFah = new System.Windows.Forms.Button();
            this.FahToCelsius = new System.Windows.Forms.Button();
            this.temptextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(162, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Temperature Conversion Service";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Converted Temperature: ";
            // 
            // convertedLabel
            // 
            this.convertedLabel.AutoSize = true;
            this.convertedLabel.Location = new System.Drawing.Point(137, 113);
            this.convertedLabel.Name = "convertedLabel";
            this.convertedLabel.Size = new System.Drawing.Size(163, 13);
            this.convertedLabel.TabIndex = 15;
            this.convertedLabel.Text = "Print Converted temperature here";
            // 
            // CelToFah
            // 
            this.CelToFah.Location = new System.Drawing.Point(137, 70);
            this.CelToFah.Name = "CelToFah";
            this.CelToFah.Size = new System.Drawing.Size(124, 30);
            this.CelToFah.TabIndex = 14;
            this.CelToFah.Text = "Convert to Fahrenheit";
            this.CelToFah.UseVisualStyleBackColor = true;
            this.CelToFah.Click += new System.EventHandler(this.CelToFah_Click);
            // 
            // FahToCelsius
            // 
            this.FahToCelsius.Location = new System.Drawing.Point(1, 70);
            this.FahToCelsius.Name = "FahToCelsius";
            this.FahToCelsius.Size = new System.Drawing.Size(130, 30);
            this.FahToCelsius.TabIndex = 13;
            this.FahToCelsius.Text = "Convert to Celsius";
            this.FahToCelsius.UseVisualStyleBackColor = true;
            this.FahToCelsius.Click += new System.EventHandler(this.FahToCelsius_Click_1);
            // 
            // temptextBox
            // 
            this.temptextBox.Location = new System.Drawing.Point(132, 38);
            this.temptextBox.Name = "temptextBox";
            this.temptextBox.Size = new System.Drawing.Size(119, 20);
            this.temptextBox.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Enter Temperature";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(387, 282);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.convertedLabel);
            this.Controls.Add(this.CelToFah);
            this.Controls.Add(this.FahToCelsius);
            this.Controls.Add(this.temptextBox);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label convertedLabel;
        private System.Windows.Forms.Button CelToFah;
        private System.Windows.Forms.Button FahToCelsius;
        private System.Windows.Forms.TextBox temptextBox;
        private System.Windows.Forms.Label label1;
    }
}

