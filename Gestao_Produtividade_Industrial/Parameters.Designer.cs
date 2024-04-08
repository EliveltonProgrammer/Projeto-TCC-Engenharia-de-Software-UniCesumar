namespace Gestao_Produtividade_Industrial
{
    partial class Parameters
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Parameters));
            groupBox2 = new GroupBox();
            label1 = new Label();
            numColetaPulsos = new NumericUpDown();
            btnUpdateParameters = new Button();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numColetaPulsos).BeginInit();
            SuspendLayout();
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(numColetaPulsos);
            groupBox2.Font = new Font("Microsoft JhengHei UI", 14.25F, FontStyle.Bold);
            groupBox2.ForeColor = SystemColors.Window;
            groupBox2.Location = new Point(46, 56);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(386, 75);
            groupBox2.TabIndex = 5;
            groupBox2.TabStop = false;
            groupBox2.Text = "Configurações de Coleta";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft JhengHei UI", 12.75F, FontStyle.Bold);
            label1.ForeColor = SystemColors.ActiveCaption;
            label1.Location = new Point(5, 39);
            label1.Name = "label1";
            label1.Size = new Size(323, 22);
            label1.TabIndex = 1;
            label1.Text = "Fator quantidade (por Pulsos Sensor):";
            // 
            // numColetaPulsos
            // 
            numColetaPulsos.BorderStyle = BorderStyle.FixedSingle;
            numColetaPulsos.Location = new Point(330, 35);
            numColetaPulsos.Name = "numColetaPulsos";
            numColetaPulsos.Size = new Size(45, 32);
            numColetaPulsos.TabIndex = 0;
            numColetaPulsos.TextAlign = HorizontalAlignment.Center;
            // 
            // btnUpdateParameters
            // 
            btnUpdateParameters.BackColor = SystemColors.Highlight;
            btnUpdateParameters.Font = new Font("Microsoft JhengHei UI", 15.75F, FontStyle.Bold);
            btnUpdateParameters.ForeColor = SystemColors.Window;
            btnUpdateParameters.Image = Properties.Resources.atualize;
            btnUpdateParameters.ImageAlign = ContentAlignment.MiddleLeft;
            btnUpdateParameters.Location = new Point(290, 150);
            btnUpdateParameters.Name = "btnUpdateParameters";
            btnUpdateParameters.Size = new Size(181, 77);
            btnUpdateParameters.TabIndex = 6;
            btnUpdateParameters.Text = "        ATUALIZE";
            btnUpdateParameters.UseVisualStyleBackColor = false;
            btnUpdateParameters.Click += btnUpdateParameters_Click;
            // 
            // Parameters
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.HotTrack;
            ClientSize = new Size(473, 229);
            Controls.Add(btnUpdateParameters);
            Controls.Add(groupBox2);
            Font = new Font("Microsoft JhengHei UI", 9F, FontStyle.Bold);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Parameters";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Parâmetros de Configuração";
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numColetaPulsos).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox2;
        private Label label1;
        private NumericUpDown numColetaPulsos;
        private Button btnUpdateParameters;
    }
}