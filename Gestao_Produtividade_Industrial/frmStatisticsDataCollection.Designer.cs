namespace Gestao_Produtividade_Industrial
{
    partial class frmStatisticsDataCollection
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStatisticsDataCollection));
            btnUpdateStatistics = new Button();
            chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            label1 = new Label();
            lbProductionQuantity = new Label();
            lbOperationTime = new Label();
            label3 = new Label();
            label5 = new Label();
            lbStopTime = new Label();
            btnExit = new Button();
            ((System.ComponentModel.ISupportInitialize)chart1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chart2).BeginInit();
            SuspendLayout();
            // 
            // btnUpdateStatistics
            // 
            btnUpdateStatistics.BackColor = SystemColors.Window;
            btnUpdateStatistics.Font = new Font("Microsoft JhengHei UI", 15.75F, FontStyle.Bold);
            btnUpdateStatistics.ForeColor = SystemColors.Window;
            btnUpdateStatistics.Image = Properties.Resources.atualize;
            btnUpdateStatistics.ImageAlign = ContentAlignment.MiddleLeft;
            btnUpdateStatistics.Location = new Point(913, 638);
            btnUpdateStatistics.Name = "btnUpdateStatistics";
            btnUpdateStatistics.Size = new Size(58, 54);
            btnUpdateStatistics.TabIndex = 7;
            btnUpdateStatistics.UseVisualStyleBackColor = false;
            btnUpdateStatistics.Click += btnUpdateStatistics_Click;
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            chart1.Legends.Add(legend1);
            chart1.Location = new Point(-17, -5);
            chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            chart1.Series.Add(series1);
            chart1.Size = new Size(717, 640);
            chart1.TabIndex = 8;
            chart1.Text = "chart1";
            // 
            // chart2
            // 
            chartArea2.Name = "ChartArea1";
            chart2.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            chart2.Legends.Add(legend2);
            chart2.Location = new Point(462, -4);
            chart2.Name = "chart2";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            chart2.Series.Add(series2);
            chart2.Size = new Size(628, 639);
            chart2.TabIndex = 9;
            chart2.Text = "chart2";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.HotTrack;
            label1.Font = new Font("Microsoft JhengHei UI", 15.75F, FontStyle.Bold);
            label1.ForeColor = SystemColors.Window;
            label1.Location = new Point(166, 656);
            label1.Name = "label1";
            label1.Size = new Size(199, 26);
            label1.TabIndex = 10;
            label1.Text = "Total Sensorizado:";
            // 
            // lbProductionQuantity
            // 
            lbProductionQuantity.AutoSize = true;
            lbProductionQuantity.BackColor = SystemColors.HotTrack;
            lbProductionQuantity.Font = new Font("Microsoft JhengHei UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbProductionQuantity.ForeColor = SystemColors.Window;
            lbProductionQuantity.Location = new Point(360, 657);
            lbProductionQuantity.Name = "lbProductionQuantity";
            lbProductionQuantity.Size = new Size(79, 26);
            lbProductionQuantity.TabIndex = 11;
            lbProductionQuantity.Text = "&&qtde";
            // 
            // lbOperationTime
            // 
            lbOperationTime.AutoSize = true;
            lbOperationTime.BackColor = SystemColors.HotTrack;
            lbOperationTime.Font = new Font("Microsoft JhengHei UI", 15.75F, FontStyle.Bold);
            lbOperationTime.ForeColor = SystemColors.Window;
            lbOperationTime.Location = new Point(709, 641);
            lbOperationTime.Name = "lbOperationTime";
            lbOperationTime.Size = new Size(108, 26);
            lbOperationTime.TabIndex = 13;
            lbOperationTime.Text = "&&timeOp";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = SystemColors.HotTrack;
            label3.Font = new Font("Microsoft JhengHei UI", 15.75F, FontStyle.Bold);
            label3.ForeColor = SystemColors.Window;
            label3.Location = new Point(482, 640);
            label3.Name = "label3";
            label3.Size = new Size(231, 26);
            label3.TabIndex = 12;
            label3.Text = "Tempo em Operação:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = SystemColors.HotTrack;
            label5.Font = new Font("Microsoft JhengHei UI", 15.75F, FontStyle.Bold);
            label5.ForeColor = SystemColors.Window;
            label5.Location = new Point(483, 669);
            label5.Name = "label5";
            label5.Size = new Size(196, 26);
            label5.TabIndex = 15;
            label5.Text = "Tempo de Parada:";
            // 
            // lbStopTime
            // 
            lbStopTime.AutoSize = true;
            lbStopTime.BackColor = SystemColors.HotTrack;
            lbStopTime.Font = new Font("Microsoft JhengHei UI", 15.75F, FontStyle.Bold);
            lbStopTime.ForeColor = SystemColors.Window;
            lbStopTime.Location = new Point(674, 670);
            lbStopTime.Name = "lbStopTime";
            lbStopTime.Size = new Size(125, 26);
            lbStopTime.TabIndex = 16;
            lbStopTime.Text = "&&timeStop";
            // 
            // btnExit
            // 
            btnExit.BackColor = SystemColors.Window;
            btnExit.Font = new Font("Microsoft JhengHei UI", 15.75F, FontStyle.Bold);
            btnExit.ForeColor = SystemColors.Window;
            btnExit.Image = Properties.Resources.sair;
            btnExit.ImageAlign = ContentAlignment.MiddleLeft;
            btnExit.Location = new Point(981, 638);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(58, 54);
            btnExit.TabIndex = 17;
            btnExit.UseVisualStyleBackColor = false;
            btnExit.Click += btnExit_Click;
            // 
            // frmStatisticsDataCollection
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.HotTrack;
            ClientSize = new Size(1047, 703);
            Controls.Add(chart2);
            Controls.Add(chart1);
            Controls.Add(btnExit);
            Controls.Add(lbStopTime);
            Controls.Add(label5);
            Controls.Add(lbOperationTime);
            Controls.Add(label3);
            Controls.Add(lbProductionQuantity);
            Controls.Add(label1);
            Controls.Add(btnUpdateStatistics);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmStatisticsDataCollection";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Estatisticas Coleta de dados Produção";
            Load += frmStatisticsDataCollection_Load;
            ((System.ComponentModel.ISupportInitialize)chart1).EndInit();
            ((System.ComponentModel.ISupportInitialize)chart2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        public Button btnUpdateStatistics;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private Label label1;
        private Label lbProductionQuantity;
        private Label lbOperationTime;
        private Label label3;
        private Label label5;
        private Label lbStopTime;
        public Button btnExit;
    }
}