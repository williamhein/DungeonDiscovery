namespace DungeonDiscovery
{
    partial class frmDiscover
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
            this.components = new System.ComponentModel.Container();
            this.pnlCreate = new System.Windows.Forms.Panel();
            this.pnlControlsCreate = new System.Windows.Forms.Panel();
            this.btnNewCreate = new System.Windows.Forms.Button();
            this.gpbBrush = new System.Windows.Forms.GroupBox();
            this.rdbStrokeCreate = new System.Windows.Forms.RadioButton();
            this.rdbRectCreate = new System.Windows.Forms.RadioButton();
            this.nudDialCreate = new System.Windows.Forms.NumericUpDown();
            this.btnOpenCreate = new System.Windows.Forms.Button();
            this.btnSaveCreate = new System.Windows.Forms.Button();
            this.gpbType = new System.Windows.Forms.GroupBox();
            this.rdbStartCreate = new System.Windows.Forms.RadioButton();
            this.rdbDoorCreate = new System.Windows.Forms.RadioButton();
            this.rdbEraseCreate = new System.Windows.Forms.RadioButton();
            this.rdbRoomCreate = new System.Windows.Forms.RadioButton();
            this.ptbCreate = new System.Windows.Forms.PictureBox();
            this.pnlDiscover = new System.Windows.Forms.Panel();
            this.btnOpenDiscover = new System.Windows.Forms.Button();
            this.ptbDiscover = new System.Windows.Forms.PictureBox();
            this.ofdOpenCreate = new System.Windows.Forms.OpenFileDialog();
            this.sfdSaveCreate = new System.Windows.Forms.SaveFileDialog();
            this.ofdNewCreate = new System.Windows.Forms.OpenFileDialog();
            this.tmrStrokeCreate = new System.Windows.Forms.Timer(this.components);
            this.ofdOpenPNGCreate = new System.Windows.Forms.OpenFileDialog();
            this.ofdOpenPNGDiscover = new System.Windows.Forms.OpenFileDialog();
            this.ofdOpenDiscover = new System.Windows.Forms.OpenFileDialog();
            this.tmrAnimationDiscover = new System.Windows.Forms.Timer(this.components);
            this.pnlCreate.SuspendLayout();
            this.pnlControlsCreate.SuspendLayout();
            this.gpbBrush.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDialCreate)).BeginInit();
            this.gpbType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbCreate)).BeginInit();
            this.pnlDiscover.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbDiscover)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlCreate
            // 
            this.pnlCreate.BackColor = System.Drawing.Color.Gainsboro;
            this.pnlCreate.Controls.Add(this.pnlControlsCreate);
            this.pnlCreate.Controls.Add(this.ptbCreate);
            this.pnlCreate.Location = new System.Drawing.Point(3, 6);
            this.pnlCreate.Margin = new System.Windows.Forms.Padding(4);
            this.pnlCreate.Name = "pnlCreate";
            this.pnlCreate.Size = new System.Drawing.Size(884, 577);
            this.pnlCreate.TabIndex = 0;
            // 
            // pnlControlsCreate
            // 
            this.pnlControlsCreate.Controls.Add(this.btnNewCreate);
            this.pnlControlsCreate.Controls.Add(this.gpbBrush);
            this.pnlControlsCreate.Controls.Add(this.btnOpenCreate);
            this.pnlControlsCreate.Controls.Add(this.btnSaveCreate);
            this.pnlControlsCreate.Controls.Add(this.gpbType);
            this.pnlControlsCreate.Location = new System.Drawing.Point(11, 7);
            this.pnlControlsCreate.Margin = new System.Windows.Forms.Padding(4);
            this.pnlControlsCreate.Name = "pnlControlsCreate";
            this.pnlControlsCreate.Size = new System.Drawing.Size(915, 60);
            this.pnlControlsCreate.TabIndex = 3;
            // 
            // btnNewCreate
            // 
            this.btnNewCreate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewCreate.Location = new System.Drawing.Point(181, 14);
            this.btnNewCreate.Margin = new System.Windows.Forms.Padding(4);
            this.btnNewCreate.Name = "btnNewCreate";
            this.btnNewCreate.Size = new System.Drawing.Size(81, 34);
            this.btnNewCreate.TabIndex = 3;
            this.btnNewCreate.Text = "New";
            this.btnNewCreate.UseVisualStyleBackColor = true;
            this.btnNewCreate.Click += new System.EventHandler(this.BtnNewCreate_Click);
            // 
            // gpbBrush
            // 
            this.gpbBrush.Controls.Add(this.rdbStrokeCreate);
            this.gpbBrush.Controls.Add(this.rdbRectCreate);
            this.gpbBrush.Controls.Add(this.nudDialCreate);
            this.gpbBrush.Location = new System.Drawing.Point(271, 2);
            this.gpbBrush.Margin = new System.Windows.Forms.Padding(4);
            this.gpbBrush.Name = "gpbBrush";
            this.gpbBrush.Padding = new System.Windows.Forms.Padding(4);
            this.gpbBrush.Size = new System.Drawing.Size(281, 57);
            this.gpbBrush.TabIndex = 4;
            this.gpbBrush.TabStop = false;
            this.gpbBrush.Text = "Brush";
            // 
            // rdbStrokeCreate
            // 
            this.rdbStrokeCreate.AutoSize = true;
            this.rdbStrokeCreate.Location = new System.Drawing.Point(127, 23);
            this.rdbStrokeCreate.Margin = new System.Windows.Forms.Padding(4);
            this.rdbStrokeCreate.Name = "rdbStrokeCreate";
            this.rdbStrokeCreate.Size = new System.Drawing.Size(67, 20);
            this.rdbStrokeCreate.TabIndex = 2;
            this.rdbStrokeCreate.Text = "Stroke";
            this.rdbStrokeCreate.UseVisualStyleBackColor = true;
            // 
            // rdbRectCreate
            // 
            this.rdbRectCreate.AutoSize = true;
            this.rdbRectCreate.Checked = true;
            this.rdbRectCreate.Location = new System.Drawing.Point(8, 23);
            this.rdbRectCreate.Margin = new System.Windows.Forms.Padding(4);
            this.rdbRectCreate.Name = "rdbRectCreate";
            this.rdbRectCreate.Size = new System.Drawing.Size(90, 20);
            this.rdbRectCreate.TabIndex = 1;
            this.rdbRectCreate.TabStop = true;
            this.rdbRectCreate.Text = "Rectangle";
            this.rdbRectCreate.UseVisualStyleBackColor = true;
            // 
            // nudDialCreate
            // 
            this.nudDialCreate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudDialCreate.Location = new System.Drawing.Point(209, 17);
            this.nudDialCreate.Margin = new System.Windows.Forms.Padding(4);
            this.nudDialCreate.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudDialCreate.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudDialCreate.Name = "nudDialCreate";
            this.nudDialCreate.Size = new System.Drawing.Size(72, 30);
            this.nudDialCreate.TabIndex = 0;
            this.nudDialCreate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudDialCreate.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
            // 
            // btnOpenCreate
            // 
            this.btnOpenCreate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenCreate.Location = new System.Drawing.Point(4, 14);
            this.btnOpenCreate.Margin = new System.Windows.Forms.Padding(4);
            this.btnOpenCreate.Name = "btnOpenCreate";
            this.btnOpenCreate.Size = new System.Drawing.Size(81, 34);
            this.btnOpenCreate.TabIndex = 1;
            this.btnOpenCreate.Text = "Open";
            this.btnOpenCreate.UseVisualStyleBackColor = true;
            this.btnOpenCreate.Click += new System.EventHandler(this.btnOpenCreate_Click);
            // 
            // btnSaveCreate
            // 
            this.btnSaveCreate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveCreate.Location = new System.Drawing.Point(93, 14);
            this.btnSaveCreate.Margin = new System.Windows.Forms.Padding(4);
            this.btnSaveCreate.Name = "btnSaveCreate";
            this.btnSaveCreate.Size = new System.Drawing.Size(81, 34);
            this.btnSaveCreate.TabIndex = 2;
            this.btnSaveCreate.Text = "Save";
            this.btnSaveCreate.UseVisualStyleBackColor = true;
            this.btnSaveCreate.Click += new System.EventHandler(this.btnSaveCreate_Click);
            // 
            // gpbType
            // 
            this.gpbType.Controls.Add(this.rdbStartCreate);
            this.gpbType.Controls.Add(this.rdbDoorCreate);
            this.gpbType.Controls.Add(this.rdbEraseCreate);
            this.gpbType.Controls.Add(this.rdbRoomCreate);
            this.gpbType.Location = new System.Drawing.Point(553, 2);
            this.gpbType.Margin = new System.Windows.Forms.Padding(4);
            this.gpbType.Name = "gpbType";
            this.gpbType.Padding = new System.Windows.Forms.Padding(4);
            this.gpbType.Size = new System.Drawing.Size(365, 57);
            this.gpbType.TabIndex = 3;
            this.gpbType.TabStop = false;
            this.gpbType.Text = "Type";
            // 
            // rdbStartCreate
            // 
            this.rdbStartCreate.AutoSize = true;
            this.rdbStartCreate.Location = new System.Drawing.Point(229, 22);
            this.rdbStartCreate.Margin = new System.Windows.Forms.Padding(4);
            this.rdbStartCreate.Name = "rdbStartCreate";
            this.rdbStartCreate.Size = new System.Drawing.Size(102, 20);
            this.rdbStartCreate.TabIndex = 3;
            this.rdbStartCreate.Text = "Start Rooms";
            this.rdbStartCreate.UseVisualStyleBackColor = true;
            // 
            // rdbDoorCreate
            // 
            this.rdbDoorCreate.AutoSize = true;
            this.rdbDoorCreate.Location = new System.Drawing.Point(8, 22);
            this.rdbDoorCreate.Margin = new System.Windows.Forms.Padding(4);
            this.rdbDoorCreate.Name = "rdbDoorCreate";
            this.rdbDoorCreate.Size = new System.Drawing.Size(65, 20);
            this.rdbDoorCreate.TabIndex = 0;
            this.rdbDoorCreate.Text = "Doors";
            this.rdbDoorCreate.UseVisualStyleBackColor = true;
            // 
            // rdbEraseCreate
            // 
            this.rdbEraseCreate.AutoSize = true;
            this.rdbEraseCreate.Location = new System.Drawing.Point(164, 22);
            this.rdbEraseCreate.Margin = new System.Windows.Forms.Padding(4);
            this.rdbEraseCreate.Name = "rdbEraseCreate";
            this.rdbEraseCreate.Size = new System.Drawing.Size(64, 20);
            this.rdbEraseCreate.TabIndex = 2;
            this.rdbEraseCreate.Text = "Erase";
            this.rdbEraseCreate.UseVisualStyleBackColor = true;
            // 
            // rdbRoomCreate
            // 
            this.rdbRoomCreate.AutoSize = true;
            this.rdbRoomCreate.Checked = true;
            this.rdbRoomCreate.Location = new System.Drawing.Point(83, 22);
            this.rdbRoomCreate.Margin = new System.Windows.Forms.Padding(4);
            this.rdbRoomCreate.Name = "rdbRoomCreate";
            this.rdbRoomCreate.Size = new System.Drawing.Size(72, 20);
            this.rdbRoomCreate.TabIndex = 1;
            this.rdbRoomCreate.TabStop = true;
            this.rdbRoomCreate.Text = "Rooms";
            this.rdbRoomCreate.UseVisualStyleBackColor = true;
            // 
            // ptbCreate
            // 
            this.ptbCreate.BackColor = System.Drawing.Color.GhostWhite;
            this.ptbCreate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ptbCreate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ptbCreate.Cursor = System.Windows.Forms.Cursors.Cross;
            this.ptbCreate.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ptbCreate.Location = new System.Drawing.Point(0, 72);
            this.ptbCreate.Margin = new System.Windows.Forms.Padding(4);
            this.ptbCreate.Name = "ptbCreate";
            this.ptbCreate.Size = new System.Drawing.Size(884, 505);
            this.ptbCreate.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptbCreate.TabIndex = 0;
            this.ptbCreate.TabStop = false;
            this.ptbCreate.Click += new System.EventHandler(this.ptbCreate_Click);
            // 
            // pnlDiscover
            // 
            this.pnlDiscover.BackColor = System.Drawing.Color.Gainsboro;
            this.pnlDiscover.Controls.Add(this.btnOpenDiscover);
            this.pnlDiscover.Controls.Add(this.ptbDiscover);
            this.pnlDiscover.Location = new System.Drawing.Point(935, 6);
            this.pnlDiscover.Margin = new System.Windows.Forms.Padding(4);
            this.pnlDiscover.Name = "pnlDiscover";
            this.pnlDiscover.Size = new System.Drawing.Size(560, 578);
            this.pnlDiscover.TabIndex = 1;
            // 
            // btnOpenDiscover
            // 
            this.btnOpenDiscover.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenDiscover.Location = new System.Drawing.Point(4, 20);
            this.btnOpenDiscover.Margin = new System.Windows.Forms.Padding(4);
            this.btnOpenDiscover.Name = "btnOpenDiscover";
            this.btnOpenDiscover.Size = new System.Drawing.Size(81, 34);
            this.btnOpenDiscover.TabIndex = 4;
            this.btnOpenDiscover.Text = "Open";
            this.btnOpenDiscover.UseVisualStyleBackColor = true;
            this.btnOpenDiscover.Click += new System.EventHandler(this.btnOpenDiscover_Click);
            // 
            // ptbDiscover
            // 
            this.ptbDiscover.BackColor = System.Drawing.Color.GhostWhite;
            this.ptbDiscover.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ptbDiscover.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ptbDiscover.Location = new System.Drawing.Point(4, 71);
            this.ptbDiscover.Margin = new System.Windows.Forms.Padding(4);
            this.ptbDiscover.Name = "ptbDiscover";
            this.ptbDiscover.Size = new System.Drawing.Size(519, 483);
            this.ptbDiscover.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptbDiscover.TabIndex = 0;
            this.ptbDiscover.TabStop = false;
            // 
            // ofdOpenCreate
            // 
            this.ofdOpenCreate.Filter = "DD Files (*.ddf)|*.ddf";
            this.ofdOpenCreate.Title = "Open DDF File";
            // 
            // sfdSaveCreate
            // 
            this.sfdSaveCreate.DefaultExt = "ddf";
            this.sfdSaveCreate.Filter = "DD Files (*.ddf)|*.ddf";
            this.sfdSaveCreate.Title = "Save DDF File";
            // 
            // ofdNewCreate
            // 
            this.ofdNewCreate.Filter = "PNGs|*.png|WebP|*.webp";
            this.ofdNewCreate.Title = "Select New PNG File";
            // 
            // tmrStrokeCreate
            // 
            this.tmrStrokeCreate.Interval = 50;
            this.tmrStrokeCreate.Tick += new System.EventHandler(this.TmrStrokeCreate_Tick);
            // 
            // ofdOpenPNGCreate
            // 
            this.ofdOpenPNGCreate.Filter = "PNGs|*.png|WebP|*.webp";
            this.ofdOpenPNGCreate.Title = "Open Associated PNG File";
            this.ofdOpenPNGCreate.FileOk += new System.ComponentModel.CancelEventHandler(this.ofdOpenPNGCreate_FileOk);
            // 
            // ofdOpenPNGDiscover
            // 
            this.ofdOpenPNGDiscover.Filter = "PNGs|*.png";
            this.ofdOpenPNGDiscover.Title = "Open Associated PNG File";
            // 
            // ofdOpenDiscover
            // 
            this.ofdOpenDiscover.Filter = "DD Files (*.ddf)|*.ddf";
            this.ofdOpenDiscover.Title = "Open DDF File";
            // 
            // tmrAnimationDiscover
            // 
            this.tmrAnimationDiscover.Interval = 50;
            this.tmrAnimationDiscover.Tick += new System.EventHandler(this.tmrAnimationDiscover_Tick);
            // 
            // frmDiscover
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1503, 841);
            this.Controls.Add(this.pnlDiscover);
            this.Controls.Add(this.pnlCreate);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmDiscover";
            this.Load += new System.EventHandler(this.FrmDiscover_Load);
            this.pnlCreate.ResumeLayout(false);
            this.pnlControlsCreate.ResumeLayout(false);
            this.gpbBrush.ResumeLayout(false);
            this.gpbBrush.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDialCreate)).EndInit();
            this.gpbType.ResumeLayout(false);
            this.gpbType.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbCreate)).EndInit();
            this.pnlDiscover.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ptbDiscover)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlCreate;
        private System.Windows.Forms.PictureBox ptbCreate;
        private System.Windows.Forms.Panel pnlDiscover;
        private System.Windows.Forms.PictureBox ptbDiscover;
        private System.Windows.Forms.Button btnSaveCreate;
        private System.Windows.Forms.Button btnOpenCreate;
        private System.Windows.Forms.Panel pnlControlsCreate;
        private System.Windows.Forms.Button btnNewCreate;
        private System.Windows.Forms.RadioButton rdbEraseCreate;
        private System.Windows.Forms.RadioButton rdbRoomCreate;
        private System.Windows.Forms.RadioButton rdbDoorCreate;
        private System.Windows.Forms.OpenFileDialog ofdOpenCreate;
        private System.Windows.Forms.SaveFileDialog sfdSaveCreate;
        private System.Windows.Forms.OpenFileDialog ofdNewCreate;
        private System.Windows.Forms.GroupBox gpbBrush;
        private System.Windows.Forms.GroupBox gpbType;
        private System.Windows.Forms.RadioButton rdbStrokeCreate;
        private System.Windows.Forms.RadioButton rdbRectCreate;
        private System.Windows.Forms.NumericUpDown nudDialCreate;
        private System.Windows.Forms.Timer tmrStrokeCreate;
        private System.Windows.Forms.OpenFileDialog ofdOpenPNGCreate;
        private System.Windows.Forms.OpenFileDialog ofdOpenPNGDiscover;
        private System.Windows.Forms.OpenFileDialog ofdOpenDiscover;
        private System.Windows.Forms.RadioButton rdbStartCreate;
        private System.Windows.Forms.Button btnOpenDiscover;
        private System.Windows.Forms.Timer tmrAnimationDiscover;
    }
}

