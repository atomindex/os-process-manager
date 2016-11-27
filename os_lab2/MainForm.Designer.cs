namespace os_lab2 {
    partial class MainForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.btnStart = new System.Windows.Forms.Button();
            this.pbFCFS = new System.Windows.Forms.PictureBox();
            this.pnlSide = new System.Windows.Forms.Panel();
            this.pnlInfoWrapper = new System.Windows.Forms.Panel();
            this.pnlInfo = new System.Windows.Forms.Panel();
            this.btnLoadFile = new System.Windows.Forms.Button();
            this.lblSpeedLarger = new System.Windows.Forms.Label();
            this.lblSpeedLess = new System.Windows.Forms.Label();
            this.lblSpeed = new System.Windows.Forms.Label();
            this.tbSpeed = new System.Windows.Forms.TrackBar();
            this.tlpViews = new System.Windows.Forms.TableLayoutPanel();
            this.pbRR = new System.Windows.Forms.PictureBox();
            this.pbCA = new System.Windows.Forms.PictureBox();
            this.pnlConsole = new System.Windows.Forms.Panel();
            this.rtbConsole = new System.Windows.Forms.RichTextBox();
            this.ofd = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pbFCFS)).BeginInit();
            this.pnlSide.SuspendLayout();
            this.pnlInfoWrapper.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbSpeed)).BeginInit();
            this.tlpViews.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbRR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCA)).BeginInit();
            this.pnlConsole.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Enabled = false;
            this.btnStart.Location = new System.Drawing.Point(10, 50);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(190, 30);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "Запустить";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // pbFCFS
            // 
            this.pbFCFS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbFCFS.Location = new System.Drawing.Point(10, 10);
            this.pbFCFS.Margin = new System.Windows.Forms.Padding(10, 10, 6, 7);
            this.pbFCFS.Name = "pbFCFS";
            this.pbFCFS.Size = new System.Drawing.Size(379, 263);
            this.pbFCFS.TabIndex = 2;
            this.pbFCFS.TabStop = false;
            this.pbFCFS.Click += new System.EventHandler(this.view_Click);
            // 
            // pnlSide
            // 
            this.pnlSide.Controls.Add(this.pnlInfoWrapper);
            this.pnlSide.Controls.Add(this.btnLoadFile);
            this.pnlSide.Controls.Add(this.lblSpeedLarger);
            this.pnlSide.Controls.Add(this.lblSpeedLess);
            this.pnlSide.Controls.Add(this.lblSpeed);
            this.pnlSide.Controls.Add(this.tbSpeed);
            this.pnlSide.Controls.Add(this.btnStart);
            this.pnlSide.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSide.Location = new System.Drawing.Point(0, 0);
            this.pnlSide.Name = "pnlSide";
            this.pnlSide.Padding = new System.Windows.Forms.Padding(10);
            this.pnlSide.Size = new System.Drawing.Size(210, 561);
            this.pnlSide.TabIndex = 4;
            // 
            // pnlInfoWrapper
            // 
            this.pnlInfoWrapper.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pnlInfoWrapper.Controls.Add(this.pnlInfo);
            this.pnlInfoWrapper.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlInfoWrapper.Location = new System.Drawing.Point(10, 365);
            this.pnlInfoWrapper.Name = "pnlInfoWrapper";
            this.pnlInfoWrapper.Padding = new System.Windows.Forms.Padding(1);
            this.pnlInfoWrapper.Size = new System.Drawing.Size(190, 186);
            this.pnlInfoWrapper.TabIndex = 7;
            // 
            // pnlInfo
            // 
            this.pnlInfo.BackColor = System.Drawing.Color.White;
            this.pnlInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlInfo.Location = new System.Drawing.Point(1, 1);
            this.pnlInfo.Name = "pnlInfo";
            this.pnlInfo.Size = new System.Drawing.Size(188, 184);
            this.pnlInfo.TabIndex = 0;
            this.pnlInfo.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlInfo_Paint);
            // 
            // btnLoadFile
            // 
            this.btnLoadFile.Location = new System.Drawing.Point(10, 10);
            this.btnLoadFile.Name = "btnLoadFile";
            this.btnLoadFile.Size = new System.Drawing.Size(190, 30);
            this.btnLoadFile.TabIndex = 6;
            this.btnLoadFile.Text = "Загрузить файл";
            this.btnLoadFile.UseVisualStyleBackColor = true;
            this.btnLoadFile.Click += new System.EventHandler(this.btnLoadFile_Click);
            // 
            // lblSpeedLarger
            // 
            this.lblSpeedLarger.AutoSize = true;
            this.lblSpeedLarger.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblSpeedLarger.Location = new System.Drawing.Point(156, 156);
            this.lblSpeedLarger.Name = "lblSpeedLarger";
            this.lblSpeedLarger.Size = new System.Drawing.Size(44, 13);
            this.lblSpeedLarger.TabIndex = 5;
            this.lblSpeedLarger.Text = "больше";
            // 
            // lblSpeedLess
            // 
            this.lblSpeedLess.AutoSize = true;
            this.lblSpeedLess.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblSpeedLess.Location = new System.Drawing.Point(10, 156);
            this.lblSpeedLess.Name = "lblSpeedLess";
            this.lblSpeedLess.Size = new System.Drawing.Size(45, 13);
            this.lblSpeedLess.TabIndex = 4;
            this.lblSpeedLess.Text = "меньше";
            // 
            // lblSpeed
            // 
            this.lblSpeed.AutoSize = true;
            this.lblSpeed.Location = new System.Drawing.Point(10, 105);
            this.lblSpeed.Name = "lblSpeed";
            this.lblSpeed.Size = new System.Drawing.Size(55, 13);
            this.lblSpeed.TabIndex = 3;
            this.lblSpeed.Text = "Скорость";
            // 
            // tbSpeed
            // 
            this.tbSpeed.Enabled = false;
            this.tbSpeed.Location = new System.Drawing.Point(10, 118);
            this.tbSpeed.Minimum = -10;
            this.tbSpeed.Name = "tbSpeed";
            this.tbSpeed.Size = new System.Drawing.Size(190, 45);
            this.tbSpeed.TabIndex = 2;
            this.tbSpeed.Scroll += new System.EventHandler(this.tbSpeed_Scroll);
            // 
            // tlpViews
            // 
            this.tlpViews.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tlpViews.ColumnCount = 2;
            this.tlpViews.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpViews.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpViews.Controls.Add(this.pbFCFS, 0, 0);
            this.tlpViews.Controls.Add(this.pbRR, 1, 0);
            this.tlpViews.Controls.Add(this.pbCA, 0, 1);
            this.tlpViews.Controls.Add(this.pnlConsole, 1, 1);
            this.tlpViews.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpViews.Location = new System.Drawing.Point(210, 0);
            this.tlpViews.Name = "tlpViews";
            this.tlpViews.RowCount = 2;
            this.tlpViews.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpViews.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpViews.Size = new System.Drawing.Size(790, 561);
            this.tlpViews.TabIndex = 5;
            // 
            // pbRR
            // 
            this.pbRR.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbRR.Location = new System.Drawing.Point(401, 10);
            this.pbRR.Margin = new System.Windows.Forms.Padding(6, 10, 10, 7);
            this.pbRR.Name = "pbRR";
            this.pbRR.Size = new System.Drawing.Size(379, 263);
            this.pbRR.TabIndex = 3;
            this.pbRR.TabStop = false;
            this.pbRR.Click += new System.EventHandler(this.view_Click);
            // 
            // pbCA
            // 
            this.pbCA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbCA.Location = new System.Drawing.Point(10, 287);
            this.pbCA.Margin = new System.Windows.Forms.Padding(10, 7, 6, 10);
            this.pbCA.Name = "pbCA";
            this.pbCA.Size = new System.Drawing.Size(379, 264);
            this.pbCA.TabIndex = 4;
            this.pbCA.TabStop = false;
            this.pbCA.Click += new System.EventHandler(this.view_Click);
            // 
            // pnlConsole
            // 
            this.pnlConsole.BackColor = System.Drawing.SystemColors.Control;
            this.pnlConsole.Controls.Add(this.rtbConsole);
            this.pnlConsole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlConsole.Location = new System.Drawing.Point(401, 287);
            this.pnlConsole.Margin = new System.Windows.Forms.Padding(6, 7, 10, 10);
            this.pnlConsole.Name = "pnlConsole";
            this.pnlConsole.Padding = new System.Windows.Forms.Padding(5);
            this.pnlConsole.Size = new System.Drawing.Size(379, 264);
            this.pnlConsole.TabIndex = 5;
            this.pnlConsole.Visible = false;
            // 
            // rtbConsole
            // 
            this.rtbConsole.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbConsole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbConsole.Location = new System.Drawing.Point(5, 5);
            this.rtbConsole.Name = "rtbConsole";
            this.rtbConsole.ReadOnly = true;
            this.rtbConsole.Size = new System.Drawing.Size(369, 254);
            this.rtbConsole.TabIndex = 1;
            this.rtbConsole.Text = "";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 561);
            this.Controls.Add(this.tlpViews);
            this.Controls.Add(this.pnlSide);
            this.Name = "MainForm";
            this.Text = "Егоров Евгений. ПРО-406сз. ОС. Лабораторная работа 2";
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pbFCFS)).EndInit();
            this.pnlSide.ResumeLayout(false);
            this.pnlSide.PerformLayout();
            this.pnlInfoWrapper.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tbSpeed)).EndInit();
            this.tlpViews.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbRR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCA)).EndInit();
            this.pnlConsole.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.PictureBox pbFCFS;
        private System.Windows.Forms.Panel pnlSide;
        private System.Windows.Forms.TableLayoutPanel tlpViews;
        private System.Windows.Forms.PictureBox pbRR;
        private System.Windows.Forms.PictureBox pbCA;
        private System.Windows.Forms.Panel pnlConsole;
        private System.Windows.Forms.RichTextBox rtbConsole;
        private System.Windows.Forms.TrackBar tbSpeed;
        private System.Windows.Forms.Label lblSpeed;
        private System.Windows.Forms.Label lblSpeedLarger;
        private System.Windows.Forms.Label lblSpeedLess;
        private System.Windows.Forms.Button btnLoadFile;
        private System.Windows.Forms.OpenFileDialog ofd;
        private System.Windows.Forms.Panel pnlInfoWrapper;
        private System.Windows.Forms.Panel pnlInfo;
    }
}

