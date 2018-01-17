namespace OpenShop_GA
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
            this.nJobsLabel = new System.Windows.Forms.Label();
            this.nMachineLabel = new System.Windows.Forms.Label();
            this.NIter = new System.Windows.Forms.TextBox();
            this.DimPop = new System.Windows.Forms.TextBox();
            this.nCrossover = new System.Windows.Forms.TextBox();
            this.MutProb = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SelFile = new System.Windows.Forms.Button();
            this.calc = new System.Windows.Forms.Button();
            this.resultList = new System.Windows.Forms.ListBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // nJobsLabel
            // 
            this.nJobsLabel.AutoSize = true;
            this.nJobsLabel.Location = new System.Drawing.Point(424, 9);
            this.nJobsLabel.Name = "nJobsLabel";
            this.nJobsLabel.Size = new System.Drawing.Size(69, 13);
            this.nJobsLabel.TabIndex = 0;
            this.nJobsLabel.Text = "Numero Jobs";
            // 
            // nMachineLabel
            // 
            this.nMachineLabel.AutoSize = true;
            this.nMachineLabel.Location = new System.Drawing.Point(617, 9);
            this.nMachineLabel.Name = "nMachineLabel";
            this.nMachineLabel.Size = new System.Drawing.Size(93, 13);
            this.nMachineLabel.TabIndex = 1;
            this.nMachineLabel.Text = "Numero Machines";
            // 
            // NIter
            // 
            this.NIter.Location = new System.Drawing.Point(25, 60);
            this.NIter.Name = "NIter";
            this.NIter.Size = new System.Drawing.Size(100, 20);
            this.NIter.TabIndex = 4;
            this.NIter.TextChanged += new System.EventHandler(this.NIter_TextChanged);
            this.NIter.Leave += new System.EventHandler(this.NIter_Leave);
            // 
            // DimPop
            // 
            this.DimPop.Location = new System.Drawing.Point(194, 60);
            this.DimPop.Name = "DimPop";
            this.DimPop.Size = new System.Drawing.Size(100, 20);
            this.DimPop.TabIndex = 5;
            this.DimPop.TextChanged += new System.EventHandler(this.DimPop_TextChanged);
            this.DimPop.Leave += new System.EventHandler(this.DimPop_Leave);
            // 
            // nCrossover
            // 
            this.nCrossover.Location = new System.Drawing.Point(25, 132);
            this.nCrossover.Name = "nCrossover";
            this.nCrossover.Size = new System.Drawing.Size(100, 20);
            this.nCrossover.TabIndex = 6;
            this.nCrossover.TextChanged += new System.EventHandler(this.nCrossover_TextChanged);
            this.nCrossover.Leave += new System.EventHandler(this.nCrossover_Leave);
            // 
            // MutProb
            // 
            this.MutProb.Location = new System.Drawing.Point(194, 132);
            this.MutProb.Name = "MutProb";
            this.MutProb.Size = new System.Drawing.Size(100, 20);
            this.MutProb.TabIndex = 7;
            this.MutProb.TextChanged += new System.EventHandler(this.MutProb_TextChanged);
            this.MutProb.Leave += new System.EventHandler(this.MutProb_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Numero iterazioni";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(141, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Numero figli per generazione";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(186, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Dimensione Popolazione";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(186, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Probabilità di mutazione";
            // 
            // SelFile
            // 
            this.SelFile.Location = new System.Drawing.Point(32, 255);
            this.SelFile.Name = "SelFile";
            this.SelFile.Size = new System.Drawing.Size(88, 23);
            this.SelFile.TabIndex = 12;
            this.SelFile.Text = "CaricaFile";
            this.SelFile.UseVisualStyleBackColor = true;
            this.SelFile.Click += new System.EventHandler(this.SelFile_Click);
            // 
            // calc
            // 
            this.calc.Enabled = false;
            this.calc.Location = new System.Drawing.Point(226, 255);
            this.calc.Name = "calc";
            this.calc.Size = new System.Drawing.Size(75, 23);
            this.calc.TabIndex = 13;
            this.calc.Text = "Calcola";
            this.calc.UseVisualStyleBackColor = true;
            this.calc.Click += new System.EventHandler(this.calc_Click);
            // 
            // resultList
            // 
            this.resultList.FormattingEnabled = true;
            this.resultList.Location = new System.Drawing.Point(345, 46);
            this.resultList.Name = "resultList";
            this.resultList.Size = new System.Drawing.Size(442, 316);
            this.resultList.TabIndex = 17;
            this.resultList.Visible = false;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DimPop);
            this.groupBox1.Controls.Add(this.NIter);
            this.groupBox1.Controls.Add(this.nCrossover);
            this.groupBox1.Controls.Add(this.MutProb);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 46);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(315, 167);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Inserire dati per il problema";
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(410, 25);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 19;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox2
            // 
            this.textBox2.Enabled = false;
            this.textBox2.Location = new System.Drawing.Point(620, 25);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 20;
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 417);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.resultList);
            this.Controls.Add(this.calc);
            this.Controls.Add(this.SelFile);
            this.Controls.Add(this.nMachineLabel);
            this.Controls.Add(this.nJobsLabel);
            this.Name = "Form1";
            this.Text = "GA";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label nJobsLabel;
        private System.Windows.Forms.Label nMachineLabel;
        private System.Windows.Forms.TextBox NIter;
        private System.Windows.Forms.TextBox DimPop;
        private System.Windows.Forms.TextBox nCrossover;
        private System.Windows.Forms.TextBox MutProb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button SelFile;
        private System.Windows.Forms.Button calc;
        private System.Windows.Forms.ListBox resultList;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
    }
}

