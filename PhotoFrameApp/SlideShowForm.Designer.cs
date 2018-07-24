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
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonShowPrevPicture = new System.Windows.Forms.Button();
            this.buttonShowNextPicture = new System.Windows.Forms.Button();
            this.checkBoxAutoSlideShow = new System.Windows.Forms.CheckBox();
            this.checkBoxPlayMusic = new System.Windows.Forms.CheckBox();
            this.ButtonReferenceMusicFile = new System.Windows.Forms.Button();
            this.labelShowMusicFilePath = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSelectedPhotos)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
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
            this.pictureBoxSelectedPhotos.Size = new System.Drawing.Size(764, 375);
            this.pictureBoxSelectedPhotos.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxSelectedPhotos.TabIndex = 1;
            this.pictureBoxSelectedPhotos.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.labelShowMusicFilePath);
            this.panel2.Controls.Add(this.checkBoxPlayMusic);
            this.panel2.Controls.Add(this.buttonShowNextPicture);
            this.panel2.Controls.Add(this.checkBoxAutoSlideShow);
            this.panel2.Controls.Add(this.ButtonReferenceMusicFile);
            this.panel2.Controls.Add(this.buttonShowPrevPicture);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(764, 138);
            this.panel2.TabIndex = 7;
            // 
            // buttonShowPrevPicture
            // 
            this.buttonShowPrevPicture.Font = new System.Drawing.Font("HGP創英角ｺﾞｼｯｸUB", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonShowPrevPicture.Location = new System.Drawing.Point(226, 15);
            this.buttonShowPrevPicture.Name = "buttonShowPrevPicture";
            this.buttonShowPrevPicture.Size = new System.Drawing.Size(65, 45);
            this.buttonShowPrevPicture.TabIndex = 7;
            this.buttonShowPrevPicture.Text = "◀";
            this.buttonShowPrevPicture.UseVisualStyleBackColor = true;
            this.buttonShowPrevPicture.Click += new System.EventHandler(this.ButtonBackClick);
            // 
            // buttonShowNextPicture
            // 
            this.buttonShowNextPicture.Font = new System.Drawing.Font("HGP創英角ｺﾞｼｯｸUB", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonShowNextPicture.Location = new System.Drawing.Point(452, 15);
            this.buttonShowNextPicture.Name = "buttonShowNextPicture";
            this.buttonShowNextPicture.Size = new System.Drawing.Size(66, 45);
            this.buttonShowNextPicture.TabIndex = 8;
            this.buttonShowNextPicture.Text = "▶";
            this.buttonShowNextPicture.UseVisualStyleBackColor = true;
            this.buttonShowNextPicture.Click += new System.EventHandler(this.ButtonNextClick);
            // 
            // checkBoxAutoSlideShow
            // 
            this.checkBoxAutoSlideShow.AutoSize = true;
            this.checkBoxAutoSlideShow.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.checkBoxAutoSlideShow.Location = new System.Drawing.Point(24, 20);
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
            this.checkBoxPlayMusic.Location = new System.Drawing.Point(24, 49);
            this.checkBoxPlayMusic.Name = "checkBoxPlayMusic";
            this.checkBoxPlayMusic.Size = new System.Drawing.Size(104, 23);
            this.checkBoxPlayMusic.TabIndex = 10;
            this.checkBoxPlayMusic.Text = "音楽再生";
            this.checkBoxPlayMusic.UseVisualStyleBackColor = true;
            this.checkBoxPlayMusic.CheckedChanged += new System.EventHandler(this.CheckPlayMusic);
            // 
            // ButtonReferenceMusicFile
            // 
            this.ButtonReferenceMusicFile.Location = new System.Drawing.Point(24, 87);
            this.ButtonReferenceMusicFile.Name = "ButtonReferenceMusicFile";
            this.ButtonReferenceMusicFile.Size = new System.Drawing.Size(121, 23);
            this.ButtonReferenceMusicFile.TabIndex = 11;
            this.ButtonReferenceMusicFile.Text = "音楽ファイル参照";
            this.ButtonReferenceMusicFile.UseVisualStyleBackColor = true;
            this.ButtonReferenceMusicFile.Click += new System.EventHandler(this.ButtonSearchMusicFile_Click);
            // 
            // labelShowMusicFilePath
            // 
            this.labelShowMusicFilePath.AutoSize = true;
            this.labelShowMusicFilePath.Location = new System.Drawing.Point(154, 92);
            this.labelShowMusicFilePath.Name = "labelShowMusicFilePath";
            this.labelShowMusicFilePath.Size = new System.Drawing.Size(251, 12);
            this.labelShowMusicFilePath.TabIndex = 12;
            this.labelShowMusicFilePath.Text = "指定した音楽ファイル(.wav)パスがここに表示されます";
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
            this.splitContainer1.Panel2.Controls.Add(this.panel2);
            this.splitContainer1.Size = new System.Drawing.Size(764, 517);
            this.splitContainer1.SplitterDistance = 375;
            this.splitContainer1.TabIndex = 5;
            // 
            // SlideShowForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(764, 517);
            this.Controls.Add(this.splitContainer1);
            this.Name = "SlideShowForm";
            this.Text = "SlideShow";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SlideShowForm_FormClosing);
            this.Load += new System.EventHandler(this.SlideShowLoad);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSelectedPhotos)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timer_ChangePhoto;
        private System.Windows.Forms.CheckBox checkBoxPlayMusic;
        private System.Windows.Forms.PictureBox pictureBoxSelectedPhotos;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button buttonShowNextPicture;
        private System.Windows.Forms.Button buttonShowPrevPicture;
        private System.Windows.Forms.CheckBox checkBoxAutoSlideShow;
        private System.Windows.Forms.Label labelShowMusicFilePath;
        private System.Windows.Forms.Button ButtonReferenceMusicFile;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}