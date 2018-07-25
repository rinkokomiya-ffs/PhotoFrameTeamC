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
            this.buttonShowNextPicture = new System.Windows.Forms.Button();
            this.buttonShowPrevPicture = new System.Windows.Forms.Button();
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
            this.pictureBoxSelectedPhotos.Size = new System.Drawing.Size(1051, 433);
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
            this.splitContainer1.Size = new System.Drawing.Size(1051, 590);
            this.splitContainer1.SplitterDistance = 433;
            this.splitContainer1.TabIndex = 5;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.74025F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 77.25975F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel1, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1051, 153);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.53412F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.49318F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.49318F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.49318F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.49318F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.49318F));
            this.tableLayoutPanel1.Controls.Add(this.buttonShowPrevPicture, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonShowNextPicture, 3, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(242, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 27.11864F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 49.71751F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 23.16384F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(806, 147);
            this.tableLayoutPanel1.TabIndex = 13;
            // 
            // buttonShowNextPicture
            // 
            this.buttonShowNextPicture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonShowNextPicture.Font = new System.Drawing.Font("HGP創英角ｺﾞｼｯｸUB", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonShowNextPicture.Location = new System.Drawing.Point(361, 42);
            this.buttonShowNextPicture.Name = "buttonShowNextPicture";
            this.buttonShowNextPicture.Size = new System.Drawing.Size(143, 67);
            this.buttonShowNextPicture.TabIndex = 8;
            this.buttonShowNextPicture.Text = "▶";
            this.buttonShowNextPicture.UseVisualStyleBackColor = true;
            this.buttonShowNextPicture.Click += new System.EventHandler(this.ButtonNextClick);
            // 
            // buttonShowPrevPicture
            // 
            this.buttonShowPrevPicture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonShowPrevPicture.Font = new System.Drawing.Font("HGP創英角ｺﾞｼｯｸUB", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonShowPrevPicture.Location = new System.Drawing.Point(63, 42);
            this.buttonShowPrevPicture.Name = "buttonShowPrevPicture";
            this.buttonShowPrevPicture.Size = new System.Drawing.Size(143, 67);
            this.buttonShowPrevPicture.TabIndex = 7;
            this.buttonShowPrevPicture.Text = "◀";
            this.buttonShowPrevPicture.UseVisualStyleBackColor = true;
            this.buttonShowPrevPicture.Click += new System.EventHandler(this.ButtonBackClick);
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
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 21.49589F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19.32606F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45.50977F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.909409F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(233, 147);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // checkBoxAutoSlideShow
            // 
            this.checkBoxAutoSlideShow.AutoSize = true;
            this.checkBoxAutoSlideShow.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.checkBoxAutoSlideShow.Location = new System.Drawing.Point(36, 12);
            this.checkBoxAutoSlideShow.Name = "checkBoxAutoSlideShow";
            this.checkBoxAutoSlideShow.Size = new System.Drawing.Size(104, 23);
            this.checkBoxAutoSlideShow.TabIndex = 9;
            this.checkBoxAutoSlideShow.Text = "自動再生";
            this.checkBoxAutoSlideShow.UseVisualStyleBackColor = true;
            this.checkBoxAutoSlideShow.CheckedChanged += new System.EventHandler(this.CheckAutoSlideShow);
            // 
            // checkBoxPlayMusic
            // 
            this.checkBoxPlayMusic.AutoSize = true;
            this.checkBoxPlayMusic.Enabled = false;
            this.checkBoxPlayMusic.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.checkBoxPlayMusic.Location = new System.Drawing.Point(36, 43);
            this.checkBoxPlayMusic.Name = "checkBoxPlayMusic";
            this.checkBoxPlayMusic.Size = new System.Drawing.Size(104, 22);
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
            this.tableLayoutPanel5.Location = new System.Drawing.Point(36, 71);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 2;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(185, 60);
            this.tableLayoutPanel5.TabIndex = 13;
            // 
            // labelShowMusicFilePath
            // 
            this.labelShowMusicFilePath.AutoSize = true;
            this.labelShowMusicFilePath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelShowMusicFilePath.Location = new System.Drawing.Point(3, 30);
            this.labelShowMusicFilePath.Name = "labelShowMusicFilePath";
            this.labelShowMusicFilePath.Size = new System.Drawing.Size(179, 30);
            this.labelShowMusicFilePath.TabIndex = 12;
            this.labelShowMusicFilePath.Text = "指定した音楽ファイル(.wav)名が　　表示されます";
            this.labelShowMusicFilePath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ButtonReferenceMusicFile
            // 
            this.ButtonReferenceMusicFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonReferenceMusicFile.Location = new System.Drawing.Point(3, 3);
            this.ButtonReferenceMusicFile.Name = "ButtonReferenceMusicFile";
            this.ButtonReferenceMusicFile.Size = new System.Drawing.Size(179, 24);
            this.ButtonReferenceMusicFile.TabIndex = 11;
            this.ButtonReferenceMusicFile.Text = "音楽ファイル参照";
            this.ButtonReferenceMusicFile.UseVisualStyleBackColor = true;
            this.ButtonReferenceMusicFile.Click += new System.EventHandler(this.ButtonSearchMusicFileClick);
            // 
            // SlideShowForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1051, 590);
            this.Controls.Add(this.splitContainer1);
            this.Name = "SlideShowForm";
            this.Text = "SlideShow";
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