namespace Gestao_Produtividade_Industrial
{
    partial class frmSensorsDataCollection
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSensorsDataCollection));
            progressBar = new ProgressBar();
            btnUpdateSensors = new Button();
            tbxProductionGoodPieces = new TextBox();
            groupBox1 = new GroupBox();
            label1 = new Label();
            label5 = new Label();
            label4 = new Label();
            tbxProductionDefectivePieces = new TextBox();
            tbxProductionPieces = new TextBox();
            label3 = new Label();
            groupBox3 = new GroupBox();
            tbxStatusLed4 = new TextBox();
            lbInformationInterface = new Label();
            cbxSelectMachine = new ComboBox();
            tbxStatusLed1 = new TextBox();
            tbxStatusLed3 = new TextBox();
            tbxStatusLed2 = new TextBox();
            picImgMachine = new PictureBox();
            btnOn = new Button();
            btnOff = new Button();
            btnIdle = new Button();
            btnEmergencyStop = new Button();
            btnConfig = new Button();
            groupBox4 = new GroupBox();
            lbStatus = new Label();
            tbxStopTime = new TextBox();
            label6 = new Label();
            tbxOperationTime = new TextBox();
            label2 = new Label();
            tbxSpeedMachine = new TextBox();
            label7 = new Label();
            btnIncreaseSpeed = new Button();
            btnDecreaseSpeed = new Button();
            btnViewStatistics = new Button();
            groupBox1.SuspendLayout();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picImgMachine).BeginInit();
            groupBox4.SuspendLayout();
            SuspendLayout();
            // 
            // progressBar
            // 
            progressBar.Location = new Point(0, 605);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(938, 12);
            progressBar.Step = 100;
            progressBar.Style = ProgressBarStyle.Marquee;
            progressBar.TabIndex = 0;
            // 
            // btnUpdateSensors
            // 
            btnUpdateSensors.BackColor = SystemColors.Highlight;
            btnUpdateSensors.Font = new Font("Microsoft JhengHei UI", 15.75F, FontStyle.Bold);
            btnUpdateSensors.ForeColor = SystemColors.Window;
            btnUpdateSensors.Image = Properties.Resources.atualize;
            btnUpdateSensors.ImageAlign = ContentAlignment.MiddleLeft;
            btnUpdateSensors.Location = new Point(741, 511);
            btnUpdateSensors.Name = "btnUpdateSensors";
            btnUpdateSensors.Size = new Size(181, 77);
            btnUpdateSensors.TabIndex = 1;
            btnUpdateSensors.Text = "        ATUALIZE \r\n        SENSORES";
            btnUpdateSensors.UseVisualStyleBackColor = false;
            btnUpdateSensors.Click += btnUpdateSensors_Click;
            // 
            // tbxProductionGoodPieces
            // 
            tbxProductionGoodPieces.BackColor = SystemColors.InactiveBorder;
            tbxProductionGoodPieces.BorderStyle = BorderStyle.FixedSingle;
            tbxProductionGoodPieces.Font = new Font("Microsoft JhengHei UI", 21.75F);
            tbxProductionGoodPieces.ForeColor = SystemColors.HotTrack;
            tbxProductionGoodPieces.Location = new Point(17, 141);
            tbxProductionGoodPieces.Name = "tbxProductionGoodPieces";
            tbxProductionGoodPieces.ReadOnly = true;
            tbxProductionGoodPieces.Size = new Size(264, 44);
            tbxProductionGoodPieces.TabIndex = 2;
            tbxProductionGoodPieces.TextAlign = HorizontalAlignment.Center;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(tbxProductionDefectivePieces);
            groupBox1.Controls.Add(tbxProductionPieces);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(tbxProductionGoodPieces);
            groupBox1.Font = new Font("Microsoft JhengHei UI", 14.25F, FontStyle.Bold);
            groupBox1.ForeColor = SystemColors.Window;
            groupBox1.Location = new Point(23, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(306, 278);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "Coleta de dados Sensorizadas";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft JhengHei UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(8, 21);
            label1.Name = "label1";
            label1.Size = new Size(102, 14);
            label1.TabIndex = 8;
            label1.Text = "quantidade/peças";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft JhengHei UI", 12.75F, FontStyle.Bold);
            label5.ForeColor = SystemColors.ActiveCaption;
            label5.Location = new Point(17, 195);
            label5.Name = "label5";
            label5.Size = new Size(169, 22);
            label5.TabIndex = 7;
            label5.Text = "PEÇAS REFUGADAS";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft JhengHei UI", 12.75F, FontStyle.Bold);
            label4.ForeColor = SystemColors.ActiveCaption;
            label4.Location = new Point(17, 116);
            label4.Name = "label4";
            label4.Size = new Size(114, 22);
            label4.TabIndex = 5;
            label4.Text = "PEÇAS BOAS";
            // 
            // tbxProductionDefectivePieces
            // 
            tbxProductionDefectivePieces.BackColor = SystemColors.InactiveBorder;
            tbxProductionDefectivePieces.BorderStyle = BorderStyle.FixedSingle;
            tbxProductionDefectivePieces.Font = new Font("Microsoft JhengHei UI", 21.75F);
            tbxProductionDefectivePieces.ForeColor = SystemColors.HotTrack;
            tbxProductionDefectivePieces.Location = new Point(17, 220);
            tbxProductionDefectivePieces.Name = "tbxProductionDefectivePieces";
            tbxProductionDefectivePieces.ReadOnly = true;
            tbxProductionDefectivePieces.Size = new Size(264, 44);
            tbxProductionDefectivePieces.TabIndex = 6;
            tbxProductionDefectivePieces.TextAlign = HorizontalAlignment.Center;
            // 
            // tbxProductionPieces
            // 
            tbxProductionPieces.BackColor = SystemColors.InactiveBorder;
            tbxProductionPieces.BorderStyle = BorderStyle.FixedSingle;
            tbxProductionPieces.Font = new Font("Microsoft JhengHei UI", 21.75F);
            tbxProductionPieces.ForeColor = SystemColors.HotTrack;
            tbxProductionPieces.Location = new Point(17, 66);
            tbxProductionPieces.Name = "tbxProductionPieces";
            tbxProductionPieces.ReadOnly = true;
            tbxProductionPieces.Size = new Size(264, 44);
            tbxProductionPieces.TabIndex = 4;
            tbxProductionPieces.TextAlign = HorizontalAlignment.Center;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft JhengHei UI", 12.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.ActiveCaption;
            label3.Location = new Point(17, 41);
            label3.Name = "label3";
            label3.Size = new Size(109, 22);
            label3.TabIndex = 3;
            label3.Text = "PRODUÇÃO";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(tbxStatusLed4);
            groupBox3.Controls.Add(lbInformationInterface);
            groupBox3.Controls.Add(cbxSelectMachine);
            groupBox3.Controls.Add(tbxStatusLed1);
            groupBox3.Controls.Add(tbxStatusLed3);
            groupBox3.Controls.Add(tbxStatusLed2);
            groupBox3.Font = new Font("Microsoft JhengHei UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox3.ForeColor = SystemColors.Window;
            groupBox3.Location = new Point(483, 19);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(252, 163);
            groupBox3.TabIndex = 9;
            groupBox3.TabStop = false;
            groupBox3.Text = "Recurso Produtivo";
            // 
            // tbxStatusLed4
            // 
            tbxStatusLed4.BackColor = SystemColors.Window;
            tbxStatusLed4.BorderStyle = BorderStyle.FixedSingle;
            tbxStatusLed4.Location = new Point(182, 82);
            tbxStatusLed4.Multiline = true;
            tbxStatusLed4.Name = "tbxStatusLed4";
            tbxStatusLed4.ReadOnly = true;
            tbxStatusLed4.Size = new Size(50, 34);
            tbxStatusLed4.TabIndex = 20;
            // 
            // lbInformationInterface
            // 
            lbInformationInterface.AutoSize = true;
            lbInformationInterface.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbInformationInterface.ForeColor = SystemColors.Window;
            lbInformationInterface.Location = new Point(36, 128);
            lbInformationInterface.Name = "lbInformationInterface";
            lbInformationInterface.Size = new Size(113, 20);
            lbInformationInterface.TabIndex = 19;
            lbInformationInterface.Text = "&&information";
            // 
            // cbxSelectMachine
            // 
            cbxSelectMachine.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxSelectMachine.FlatStyle = FlatStyle.Flat;
            cbxSelectMachine.Font = new Font("Microsoft JhengHei UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            cbxSelectMachine.ForeColor = SystemColors.Highlight;
            cbxSelectMachine.FormattingEnabled = true;
            cbxSelectMachine.Location = new Point(20, 37);
            cbxSelectMachine.Name = "cbxSelectMachine";
            cbxSelectMachine.Size = new Size(212, 34);
            cbxSelectMachine.TabIndex = 14;
            cbxSelectMachine.SelectedIndexChanged += cbxSelectMachine_SelectedIndexChanged;
            // 
            // tbxStatusLed1
            // 
            tbxStatusLed1.BackColor = SystemColors.Window;
            tbxStatusLed1.BorderStyle = BorderStyle.FixedSingle;
            tbxStatusLed1.Location = new Point(20, 82);
            tbxStatusLed1.Multiline = true;
            tbxStatusLed1.Name = "tbxStatusLed1";
            tbxStatusLed1.ReadOnly = true;
            tbxStatusLed1.Size = new Size(50, 34);
            tbxStatusLed1.TabIndex = 13;
            // 
            // tbxStatusLed3
            // 
            tbxStatusLed3.BackColor = SystemColors.Window;
            tbxStatusLed3.BorderStyle = BorderStyle.FixedSingle;
            tbxStatusLed3.Location = new Point(128, 82);
            tbxStatusLed3.Multiline = true;
            tbxStatusLed3.Name = "tbxStatusLed3";
            tbxStatusLed3.ReadOnly = true;
            tbxStatusLed3.Size = new Size(50, 34);
            tbxStatusLed3.TabIndex = 11;
            // 
            // tbxStatusLed2
            // 
            tbxStatusLed2.BackColor = SystemColors.Window;
            tbxStatusLed2.BorderStyle = BorderStyle.FixedSingle;
            tbxStatusLed2.Location = new Point(74, 82);
            tbxStatusLed2.Multiline = true;
            tbxStatusLed2.Name = "tbxStatusLed2";
            tbxStatusLed2.ReadOnly = true;
            tbxStatusLed2.Size = new Size(50, 34);
            tbxStatusLed2.TabIndex = 12;
            // 
            // picImgMachine
            // 
            picImgMachine.BackgroundImageLayout = ImageLayout.Zoom;
            picImgMachine.Location = new Point(741, 29);
            picImgMachine.Name = "picImgMachine";
            picImgMachine.Size = new Size(181, 153);
            picImgMachine.TabIndex = 10;
            picImgMachine.TabStop = false;
            // 
            // btnOn
            // 
            btnOn.BackColor = SystemColors.Highlight;
            btnOn.Font = new Font("Microsoft JhengHei UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnOn.ForeColor = SystemColors.Window;
            btnOn.Image = Properties.Resources.statusOperacional1;
            btnOn.ImageAlign = ContentAlignment.MiddleLeft;
            btnOn.Location = new Point(520, 242);
            btnOn.Name = "btnOn";
            btnOn.Size = new Size(200, 77);
            btnOn.TabIndex = 11;
            btnOn.Text = "      LIGAR";
            btnOn.UseVisualStyleBackColor = false;
            btnOn.Click += btnOn_Click;
            // 
            // btnOff
            // 
            btnOff.BackColor = SystemColors.Highlight;
            btnOff.Font = new Font("Microsoft JhengHei UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnOff.ForeColor = SystemColors.Window;
            btnOff.Image = Properties.Resources.statusParada;
            btnOff.ImageAlign = ContentAlignment.MiddleLeft;
            btnOff.Location = new Point(723, 242);
            btnOff.Name = "btnOff";
            btnOff.Size = new Size(200, 77);
            btnOff.TabIndex = 12;
            btnOff.Text = "         DESLIGAR";
            btnOff.UseVisualStyleBackColor = false;
            btnOff.Click += btnOff_Click;
            // 
            // btnIdle
            // 
            btnIdle.BackColor = SystemColors.Highlight;
            btnIdle.BackgroundImageLayout = ImageLayout.None;
            btnIdle.Font = new Font("Microsoft JhengHei UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnIdle.ForeColor = SystemColors.Window;
            btnIdle.Image = Properties.Resources.statusOcioso2;
            btnIdle.ImageAlign = ContentAlignment.MiddleLeft;
            btnIdle.Location = new Point(520, 325);
            btnIdle.Name = "btnIdle";
            btnIdle.Size = new Size(200, 77);
            btnIdle.TabIndex = 13;
            btnIdle.Text = "      OCIOSO";
            btnIdle.UseVisualStyleBackColor = false;
            btnIdle.Click += btnIdle_Click;
            // 
            // btnEmergencyStop
            // 
            btnEmergencyStop.BackColor = SystemColors.Highlight;
            btnEmergencyStop.Font = new Font("Microsoft JhengHei UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEmergencyStop.ForeColor = SystemColors.Window;
            btnEmergencyStop.Image = Properties.Resources.statusParadaEmergencia;
            btnEmergencyStop.ImageAlign = ContentAlignment.MiddleLeft;
            btnEmergencyStop.Location = new Point(723, 325);
            btnEmergencyStop.Name = "btnEmergencyStop";
            btnEmergencyStop.Size = new Size(200, 77);
            btnEmergencyStop.TabIndex = 14;
            btnEmergencyStop.Text = "       PARADA DE \r\n       EMERGÊNCIA";
            btnEmergencyStop.UseVisualStyleBackColor = false;
            btnEmergencyStop.Click += btnEmergencyStop_Click;
            // 
            // btnConfig
            // 
            btnConfig.BackColor = SystemColors.Highlight;
            btnConfig.Font = new Font("Microsoft JhengHei UI", 15.75F, FontStyle.Bold);
            btnConfig.ForeColor = SystemColors.Window;
            btnConfig.Image = Properties.Resources.config;
            btnConfig.ImageAlign = ContentAlignment.MiddleLeft;
            btnConfig.Location = new Point(557, 511);
            btnConfig.Name = "btnConfig";
            btnConfig.Size = new Size(181, 77);
            btnConfig.TabIndex = 15;
            btnConfig.Text = "      CONFIG";
            btnConfig.UseVisualStyleBackColor = false;
            btnConfig.Click += btnConfig_Click;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(lbStatus);
            groupBox4.Controls.Add(tbxStopTime);
            groupBox4.Controls.Add(label6);
            groupBox4.Controls.Add(tbxOperationTime);
            groupBox4.Controls.Add(label2);
            groupBox4.Controls.Add(tbxSpeedMachine);
            groupBox4.Controls.Add(label7);
            groupBox4.Font = new Font("Microsoft JhengHei UI", 14.25F, FontStyle.Bold);
            groupBox4.ForeColor = SystemColors.Window;
            groupBox4.Location = new Point(23, 297);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(306, 291);
            groupBox4.TabIndex = 8;
            groupBox4.TabStop = false;
            groupBox4.Text = "Monitores";
            // 
            // lbStatus
            // 
            lbStatus.AutoSize = true;
            lbStatus.Font = new Font("Microsoft JhengHei UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbStatus.Location = new Point(184, 46);
            lbStatus.Name = "lbStatus";
            lbStatus.Size = new Size(48, 14);
            lbStatus.TabIndex = 9;
            lbStatus.Text = "&&status";
            // 
            // tbxStopTime
            // 
            tbxStopTime.BackColor = SystemColors.InactiveBorder;
            tbxStopTime.BorderStyle = BorderStyle.FixedSingle;
            tbxStopTime.Font = new Font("Microsoft JhengHei UI", 21.75F);
            tbxStopTime.ForeColor = SystemColors.HotTrack;
            tbxStopTime.Location = new Point(17, 224);
            tbxStopTime.Name = "tbxStopTime";
            tbxStopTime.ReadOnly = true;
            tbxStopTime.Size = new Size(264, 44);
            tbxStopTime.TabIndex = 8;
            tbxStopTime.TextAlign = HorizontalAlignment.Center;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft JhengHei UI", 12.75F, FontStyle.Bold);
            label6.ForeColor = SystemColors.ActiveCaption;
            label6.Location = new Point(17, 199);
            label6.Name = "label6";
            label6.Size = new Size(176, 22);
            label6.TabIndex = 7;
            label6.Text = "TEMPO EM PARADA";
            // 
            // tbxOperationTime
            // 
            tbxOperationTime.BackColor = SystemColors.InactiveBorder;
            tbxOperationTime.BorderStyle = BorderStyle.FixedSingle;
            tbxOperationTime.Font = new Font("Microsoft JhengHei UI", 21.75F);
            tbxOperationTime.ForeColor = SystemColors.HotTrack;
            tbxOperationTime.Location = new Point(17, 147);
            tbxOperationTime.Name = "tbxOperationTime";
            tbxOperationTime.ReadOnly = true;
            tbxOperationTime.Size = new Size(264, 44);
            tbxOperationTime.TabIndex = 6;
            tbxOperationTime.TextAlign = HorizontalAlignment.Center;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft JhengHei UI", 12.75F, FontStyle.Bold);
            label2.ForeColor = SystemColors.ActiveCaption;
            label2.Location = new Point(17, 122);
            label2.Name = "label2";
            label2.Size = new Size(199, 22);
            label2.TabIndex = 5;
            label2.Text = "TEMPO EM OPERAÇÃO";
            // 
            // tbxSpeedMachine
            // 
            tbxSpeedMachine.BackColor = SystemColors.InactiveBorder;
            tbxSpeedMachine.BorderStyle = BorderStyle.FixedSingle;
            tbxSpeedMachine.Font = new Font("Microsoft JhengHei UI", 21.75F);
            tbxSpeedMachine.ForeColor = SystemColors.HotTrack;
            tbxSpeedMachine.Location = new Point(17, 67);
            tbxSpeedMachine.Name = "tbxSpeedMachine";
            tbxSpeedMachine.ReadOnly = true;
            tbxSpeedMachine.Size = new Size(264, 44);
            tbxSpeedMachine.TabIndex = 4;
            tbxSpeedMachine.TextAlign = HorizontalAlignment.Center;
            tbxSpeedMachine.TextChanged += tbxSpeedMachine_TextChanged;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Microsoft JhengHei UI", 12.75F, FontStyle.Bold);
            label7.ForeColor = SystemColors.ActiveCaption;
            label7.Location = new Point(17, 42);
            label7.Name = "label7";
            label7.Size = new Size(170, 22);
            label7.TabIndex = 3;
            label7.Text = "VELOCIDADE NÍVEL";
            // 
            // btnIncreaseSpeed
            // 
            btnIncreaseSpeed.BackColor = SystemColors.Highlight;
            btnIncreaseSpeed.BackgroundImage = Properties.Resources.aumentar;
            btnIncreaseSpeed.BackgroundImageLayout = ImageLayout.Zoom;
            btnIncreaseSpeed.Font = new Font("Microsoft JhengHei UI", 15.75F, FontStyle.Bold);
            btnIncreaseSpeed.ForeColor = SystemColors.Window;
            btnIncreaseSpeed.ImageAlign = ContentAlignment.MiddleLeft;
            btnIncreaseSpeed.Location = new Point(332, 334);
            btnIncreaseSpeed.Name = "btnIncreaseSpeed";
            btnIncreaseSpeed.Size = new Size(50, 50);
            btnIncreaseSpeed.TabIndex = 16;
            btnIncreaseSpeed.UseVisualStyleBackColor = false;
            btnIncreaseSpeed.Click += btnIncreaseSpeed_Click;
            // 
            // btnDecreaseSpeed
            // 
            btnDecreaseSpeed.BackColor = SystemColors.Highlight;
            btnDecreaseSpeed.BackgroundImage = Properties.Resources.diminuir;
            btnDecreaseSpeed.BackgroundImageLayout = ImageLayout.Zoom;
            btnDecreaseSpeed.Font = new Font("Microsoft JhengHei UI", 15.75F, FontStyle.Bold);
            btnDecreaseSpeed.ForeColor = SystemColors.Window;
            btnDecreaseSpeed.ImageAlign = ContentAlignment.MiddleLeft;
            btnDecreaseSpeed.Location = new Point(332, 383);
            btnDecreaseSpeed.Name = "btnDecreaseSpeed";
            btnDecreaseSpeed.Size = new Size(50, 50);
            btnDecreaseSpeed.TabIndex = 17;
            btnDecreaseSpeed.UseVisualStyleBackColor = false;
            btnDecreaseSpeed.Click += btnDecreaseSpeed_Click;
            // 
            // btnViewStatistics
            // 
            btnViewStatistics.BackColor = SystemColors.Highlight;
            btnViewStatistics.Font = new Font("Microsoft JhengHei UI", 15.75F, FontStyle.Bold);
            btnViewStatistics.ForeColor = SystemColors.Window;
            btnViewStatistics.Image = Properties.Resources.estatistica;
            btnViewStatistics.ImageAlign = ContentAlignment.MiddleLeft;
            btnViewStatistics.Location = new Point(370, 511);
            btnViewStatistics.Name = "btnViewStatistics";
            btnViewStatistics.Size = new Size(181, 77);
            btnViewStatistics.TabIndex = 18;
            btnViewStatistics.Text = "      ESTATISTICA";
            btnViewStatistics.UseVisualStyleBackColor = false;
            btnViewStatistics.Click += btnViewStatistics_Click;
            // 
            // frmSensorsDataCollection
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.HotTrack;
            ClientSize = new Size(934, 611);
            Controls.Add(btnViewStatistics);
            Controls.Add(btnDecreaseSpeed);
            Controls.Add(btnIncreaseSpeed);
            Controls.Add(groupBox4);
            Controls.Add(btnConfig);
            Controls.Add(btnEmergencyStop);
            Controls.Add(btnIdle);
            Controls.Add(btnOff);
            Controls.Add(btnOn);
            Controls.Add(picImgMachine);
            Controls.Add(groupBox3);
            Controls.Add(groupBox1);
            Controls.Add(btnUpdateSensors);
            Controls.Add(progressBar);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "frmSensorsDataCollection";
            StartPosition = FormStartPosition.CenterScreen;
            Load += frmSensorsDataCollection_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picImgMachine).EndInit();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private ProgressBar progressBar;
        private Button btnUpdateSensors;
        private TextBox tbxProductionGoodPieces;
        private GroupBox groupBox1;
        private TextBox tbxProductionPieces;
        private Label label3;
        private Label label4;
        private TextBox tbxProductionDefectivePieces;
        private Label label5;
        private GroupBox groupBox3;
        private PictureBox picImgMachine;
        private TextBox tbxStatusLed3;
        private TextBox tbxStatusLed2;
        private TextBox tbxStatusLed1;
        private ComboBox cbxSelectMachine;
        private Button btnOn;
        private Button btnOff;
        private Button btnIdle;
        private Button btnEmergencyStop;
        private Button btnConfig;
        private GroupBox groupBox4;
        private TextBox tbxSpeedMachine;
        private Label label7;
        private TextBox tbxOperationTime;
        private Label label2;
        private TextBox tbxStopTime;
        private Label label6;
        private Button btnIncreaseSpeed;
        private Button btnDecreaseSpeed;
        private Button btnViewStatistics;
        private Label lbInformationInterface;
        private TextBox tbxStatusLed4;
        private Label label1;
        private Label lbStatus;
    }
}