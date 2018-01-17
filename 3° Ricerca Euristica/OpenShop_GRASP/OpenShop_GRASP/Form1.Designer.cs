namespace OpenShop_GRASP
{
    partial class Form1
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.nMachineLabel = new System.Windows.Forms.Label();
            this.nJobsLabel = new System.Windows.Forms.Label();
            this.resultList = new System.Windows.Forms.ListBox();
            this.calc = new System.Windows.Forms.Button();
            this.SelFile = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.NIter = new System.Windows.Forms.TextBox();
            this.Greediness = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // nMachineLabel
            // 
            this.nMachineLabel.AutoSize = true;
            this.nMachineLabel.Location = new System.Drawing.Point(382, 118);
            this.nMachineLabel.Name = "nMachineLabel";
            this.nMachineLabel.Size = new System.Drawing.Size(93, 13);
            this.nMachineLabel.TabIndex = 5;
            this.nMachineLabel.Text = "Numero Machines";
            // 
            // nJobsLabel
            // 
            this.nJobsLabel.AutoSize = true;
            this.nJobsLabel.Location = new System.Drawing.Point(216, 118);
            this.nJobsLabel.Name = "nJobsLabel";
            this.nJobsLabel.Size = new System.Drawing.Size(69, 13);
            this.nJobsLabel.TabIndex = 4;
            this.nJobsLabel.Text = "Numero Jobs";
            // 
            // resultList
            // 
            this.resultList.FormattingEnabled = true;
            this.resultList.Location = new System.Drawing.Point(36, 160);
            this.resultList.Name = "resultList";
            this.resultList.Size = new System.Drawing.Size(621, 134);
            this.resultList.TabIndex = 20;
            this.resultList.Visible = false;
            // 
            // calc
            // 
            this.calc.Enabled = false;
            this.calc.Location = new System.Drawing.Point(326, 66);
            this.calc.Name = "calc";
            this.calc.Size = new System.Drawing.Size(88, 23);
            this.calc.TabIndex = 19;
            this.calc.Text = "Calcola";
            this.calc.UseVisualStyleBackColor = true;
            this.calc.Click += new System.EventHandler(this.calc_Click);
            // 
            // SelFile
            // 
            this.SelFile.Location = new System.Drawing.Point(326, 19);
            this.SelFile.Name = "SelFile";
            this.SelFile.Size = new System.Drawing.Size(88, 23);
            this.SelFile.TabIndex = 18;
            this.SelFile.Text = "CaricaFile";
            this.SelFile.UseVisualStyleBackColor = true;
            this.SelFile.Click += new System.EventHandler(this.SelFile_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Valore di greediness";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Numero Iterazioni";
            // 
            // NIter
            // 
            this.NIter.Location = new System.Drawing.Point(40, 31);
            this.NIter.Name = "NIter";
            this.NIter.Size = new System.Drawing.Size(100, 20);
            this.NIter.TabIndex = 23;
            this.NIter.TextChanged += new System.EventHandler(this.NIter_TextChanged);
            this.NIter.Leave += new System.EventHandler(this.NIter_Leave);
            // 
            // Greediness
            // 
            this.Greediness.Location = new System.Drawing.Point(40, 69);
            this.Greediness.Name = "Greediness";
            this.Greediness.Size = new System.Drawing.Size(100, 20);
            this.Greediness.TabIndex = 24;
            this.Greediness.TextChanged += new System.EventHandler(this.Greediness_TextChanged);
            this.Greediness.Leave += new System.EventHandler(this.Greediness_Leave);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.HideSelection = false;
            this.textBox1.Location = new System.Drawing.Point(219, 134);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 25;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox2
            // 
            this.textBox2.Enabled = false;
            this.textBox2.HideSelection = false;
            this.textBox2.Location = new System.Drawing.Point(385, 134);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 26;
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.calc);
            this.groupBox1.Controls.Add(this.SelFile);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.Greediness);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.NIter);
            this.groupBox1.Location = new System.Drawing.Point(150, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(440, 103);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dati input";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(716, 328);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.resultList);
            this.Controls.Add(this.nMachineLabel);
            this.Controls.Add(this.nJobsLabel);
            this.Name = "Form1";
            this.Text = "GRASP";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label nMachineLabel;
        private System.Windows.Forms.Label nJobsLabel;
        private System.Windows.Forms.ListBox resultList;
        private System.Windows.Forms.Button calc;
        private System.Windows.Forms.Button SelFile;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox NIter;
        private System.Windows.Forms.TextBox Greediness;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

