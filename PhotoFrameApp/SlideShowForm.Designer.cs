namespace PhotoFrameApp
{
    partial class SlideShowForm
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
            this.timer_ChangePhoto = new System.Windows.Forms.Timer(this.components);
            this.pictureBoxSelectedPhotos = new System.Windows.Forms.PictureBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonShowPrevPicture = new System.Windows.Forms.Button();
            this.buttonShowNextPicture = new System.Windows.Forms.Button();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.checkBoxAutoSlideShow = new System.Windows.Forms.CheckBox();
            this.checkBoxPlayMusic = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.labelShowMusicFilePath = new System.Windows.Forms.Label();
            this.ButtonReferenceMusicFile = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSelectedPhotos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer_ChangePhoto
            // 
            this.timer_ChangePhoto.Tick += new System.EventHandler(this.TimerChangePhotoTick);
            // 
            // pictureBoxSelectedPhotos
            // 
            this.pictureBoxSelectedPhotos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxSelectedPhotos.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxSelectedPhotos.Name = "pictureBoxSelectedPhotos";
            this.pictureBoxSelectedPhotos.Size = new System.Drawing.Size(1025, 469);
            this.pictureBoxSelectedPhotos.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxSelectedPhotos.TabIndex = 1;
            this.pictureBoxSelectedPhotos.TabStop = false;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.pictureBoxSelectedPhotos);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel2);
            this.splitContainer1.Size = new System.Drawing.Size(1025, 641);
            this.splitContainer1.SplitterDistance = 469;
            this.splitContainer1.TabIndex = 5;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.78306F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 72.21693F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel1, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1025, 168);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.938776F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.14286F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.87075F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.27891F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 41.63265F));
            this.tableLayoutPanel1.Controls.Add(this.buttonShowPrevPicture, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonShowNextPicture, 3, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(287, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 27.11864F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 49.71751F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 23.16384F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(735, 162);
            this.tableLayoutPanel1.TabIndex = 13;
            // 
            // buttonShowPrevPicture
            // 
            this.buttonShowPrevPicture.BackColor = System.Drawing.Color.Linen;
            this.buttonShowPrevPicture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonShowPrevPicture.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonShowPrevPicture.Font = new System.Drawing.Font("HGP創英角ｺﾞｼｯｸUB", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonShowPrevPicture.Location = new System.Drawing.Point(54, 46);
            this.buttonShowPrevPicture.Name = "buttonShowPrevPicture";
            this.buttonShowPrevPicture.Size = new System.Drawing.Size(120, 74);
            this.buttonShowPrevPicture.TabIndex = 7;
            this.buttonShowPrevPicture.Text = "◀";
            this.buttonShowPrevPicture.UseVisualStyleBackColor = false;
            this.buttonShowPrevPicture.Click += new System.EventHandler(this.ButtonBackClick);
            // 
            // buttonShowNextPicture
            // 
            this.buttonShowNextPicture.BackColor = System.Drawing.Color.Linen;
            this.buttonShowNextPicture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonShowNextPicture.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonShowNextPicture.Font = new System.Drawing.Font("HGP創英角ｺﾞｼｯｸUB", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonShowNextPicture.Location = new System.Drawing.Point(304, 46);
            this.buttonShowNextPicture.Name = "buttonShowNextPicture";
            this.buttonShowNextPicture.Size = new System.Drawing.Size(121, 74);
            this.buttonShowNextPicture.TabIndex = 8;
            this.buttonShowNextPicture.Text = "▶";
            this.buttonShowNextPicture.UseVisualStyleBackColor = false;
            this.buttonShowNextPicture.Click += new System.EventHandler(this.ButtonNextClick);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.59227F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 85.40773F));
            this.tableLayoutPanel3.Controls.Add(this.checkBoxAutoSlideShow, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.checkBoxPlayMusic, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel5, 1, 3);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 5;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.758874F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.91892F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.94595F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 49.35897F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.128205F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(278, 162);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // checkBoxAutoSlideShow
            // 
            this.checkBoxAutoSlideShow.AutoSize = true;
            this.checkBoxAutoSlideShow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBoxAutoSlideShow.Font = new System.Drawing.Font("メイリオ", 11F);
            this.checkBoxAutoSlideShow.Location = new System.Drawing.Point(43, 13);
            this.checkBoxAutoSlideShow.Name = "checkBoxAutoSlideShow";
            this.checkBoxAutoSlideShow.Size = new System.Drawing.Size(86, 24);
            this.checkBoxAutoSlideShow.TabIndex = 9;
            this.checkBoxAutoSlideShow.Text = "自動再生";
            this.checkBoxAutoSlideShow.UseVisualStyleBackColor = true;
            this.checkBoxAutoSlideShow.CheckedChanged += new System.EventHandler(this.CheckAutoSlideShow);
            // 
            // checkBoxPlayMusic
            // 
            this.checkBoxPlayMusic.AutoSize = true;
            this.checkBoxPlayMusic.Enabled = false;
            this.checkBoxPlayMusic.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBoxPlayMusic.Font = new System.Drawing.Font("メイリオ", 11F);
            this.checkBoxPlayMusic.Location = new System.Drawing.Point(43, 43);
            this.checkBoxPlayMusic.Name = "checkBoxPlayMusic";
            this.checkBoxPlayMusic.Size = new System.Drawing.Size(86, 27);
            this.checkBoxPlayMusic.TabIndex = 10;
            this.checkBoxPlayMusic.Text = "音楽再生";
            this.checkBoxPlayMusic.UseVisualStyleBackColor = true;
            this.checkBoxPlayMusic.CheckedChanged += new System.EventHandler(this.CheckPlayMusic);
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Controls.Add(this.labelShowMusicFilePath, 0, 1);
            this.tableLayoutPanel5.Controls.Add(this.ButtonReferenceMusicFile, 0, 0);
            this.tableLayoutPanel5.Location = new System.Drawing.Point(43, 76);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 2;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(232, 73);
            this.tableLayoutPanel5.TabIndex = 13;
            // 
            // labelShowMusicFilePath
            // 
            this.labelShowMusicFilePath.AutoSize = true;
            this.labelShowMusicFilePath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelShowMusicFilePath.Font = new System.Drawing.Font("メイリオ", 8.5F);
            this.labelShowMusicFilePath.Location = new System.Drawing.Point(3, 36);
            this.labelShowMusicFilePath.Name = "labelShowMusicFilePath";
            this.labelShowMusicFilePath.Size = new System.Drawing.Size(226, 37);
            this.labelShowMusicFilePath.TabIndex = 12;
            this.labelShowMusicFilePath.Text = "指定した音楽ファイル(.wav)名が          表示されます";
            this.labelShowMusicFilePath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ButtonReferenceMusicFile
            // 
            this.ButtonReferenceMusicFile.BackColor = System.Drawing.Color.White;
            this.ButtonReferenceMusicFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonReferenceMusicFile.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ButtonReferenceMusicFile.Location = new System.Drawing.Point(3, 3);
            this.ButtonReferenceMusicFile.Name = "ButtonReferenceMusicFile";
            this.ButtonReferenceMusicFile.Size = new System.Drawing.Size(191, 30);
            this.ButtonReferenceMusicFile.TabIndex = 11;
            this.ButtonReferenceMusicFile.Text = "音楽ファイル参照";
            this.ButtonReferenceMusicFile.UseVisualStyleBackColor = false;
            this.ButtonReferenceMusicFile.Click += new System.EventHandler(this.ButtonSearchMusicFileClick);
            // 
            // SlideShowForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Moccasin;
            this.ClientSize = new System.Drawing.Size(1025, 641);
            this.Controls.Add(this.splitContainer1);
            this.Name = "SlideShowForm";
            this.Text = "スライドショー画面";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SlideShowForm_FormClosing);
            this.Load += new System.EventHandler(this.SlideShowLoad);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSelectedPhotos)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timer_ChangePhoto;
        private System.Windows.Forms.PictureBox pictureBoxSelectedPhotos;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button buttonShowNextPicture;
        private System.Windows.Forms.Button buttonShowPrevPicture;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.CheckBox checkBoxAutoSlideShow;
        private System.Windows.Forms.CheckBox checkBoxPlayMusic;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Label labelShowMusicFilePath;
        private System.Windows.Forms.Button ButtonReferenceMusicFile;
    }
}