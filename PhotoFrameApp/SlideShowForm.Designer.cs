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
            this.buttonShowNextPicture = new System.Windows.Forms.Button();
            this.buttonShowPrevPicture = new System.Windows.Forms.Button();
            this.checkBoxAutoSlideShow = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkBoxPlayMusic = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSelectedPhotos)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer_ChangePhoto
            // 
            this.timer_ChangePhoto.Tick += new System.EventHandler(this.TimerChangePhotoTick);
            // 
            // pictureBoxSelectedPhotos
            // 
            this.pictureBoxSelectedPhotos.Location = new System.Drawing.Point(59, 13);
            this.pictureBoxSelectedPhotos.Name = "pictureBoxSelectedPhotos";
            this.pictureBoxSelectedPhotos.Size = new System.Drawing.Size(625, 337);
            this.pictureBoxSelectedPhotos.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxSelectedPhotos.TabIndex = 1;
            this.pictureBoxSelectedPhotos.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.buttonShowNextPicture);
            this.panel2.Controls.Add(this.buttonShowPrevPicture);
            this.panel2.Location = new System.Drawing.Point(219, 368);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(296, 54);
            this.panel2.TabIndex = 7;
            // 
            // buttonShowNextPicture
            // 
            this.buttonShowNextPicture.Font = new System.Drawing.Font("HGP創英角ｺﾞｼｯｸUB", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonShowNextPicture.Location = new System.Drawing.Point(229, 3);
            this.buttonShowNextPicture.Name = "buttonShowNextPicture";
            this.buttonShowNextPicture.Size = new System.Drawing.Size(64, 45);
            this.buttonShowNextPicture.TabIndex = 8;
            this.buttonShowNextPicture.Text = "▶";
            this.buttonShowNextPicture.UseVisualStyleBackColor = true;
            this.buttonShowNextPicture.Click += new System.EventHandler(this.ButtonNextClick);
            // 
            // buttonShowPrevPicture
            // 
            this.buttonShowPrevPicture.Font = new System.Drawing.Font("HGP創英角ｺﾞｼｯｸUB", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonShowPrevPicture.Location = new System.Drawing.Point(3, 3);
            this.buttonShowPrevPicture.Name = "buttonShowPrevPicture";
            this.buttonShowPrevPicture.Size = new System.Drawing.Size(63, 45);
            this.buttonShowPrevPicture.TabIndex = 7;
            this.buttonShowPrevPicture.Text = "◀";
            this.buttonShowPrevPicture.UseVisualStyleBackColor = true;
            this.buttonShowPrevPicture.Click += new System.EventHandler(this.ButtonBackClick);
            // 
            // checkBoxAutoSlideShow
            // 
            this.checkBoxAutoSlideShow.AutoSize = true;
            this.checkBoxAutoSlideShow.Checked = true;
            this.checkBoxAutoSlideShow.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxAutoSlideShow.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.checkBoxAutoSlideShow.Location = new System.Drawing.Point(26, 372);
            this.checkBoxAutoSlideShow.Name = "checkBoxAutoSlideShow";
            this.checkBoxAutoSlideShow.Size = new System.Drawing.Size(104, 23);
            this.checkBoxAutoSlideShow.TabIndex = 9;
            this.checkBoxAutoSlideShow.Text = "自動再生";
            this.checkBoxAutoSlideShow.UseVisualStyleBackColor = true;
            this.checkBoxAutoSlideShow.CheckedChanged += new System.EventHandler(this.CheckAutoSlideShow);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.checkBoxPlayMusic);
            this.panel1.Controls.Add(this.checkBoxAutoSlideShow);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.pictureBoxSelectedPhotos);
            this.panel1.Location = new System.Drawing.Point(31, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(739, 436);
            this.panel1.TabIndex = 4;
            // 
            // checkBoxPlayMusic
            // 
            this.checkBoxPlayMusic.AutoSize = true;
            this.checkBoxPlayMusic.Checked = true;
            this.checkBoxPlayMusic.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxPlayMusic.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.checkBoxPlayMusic.Location = new System.Drawing.Point(26, 401);
            this.checkBoxPlayMusic.Name = "checkBoxPlayMusic";
            this.checkBoxPlayMusic.Size = new System.Drawing.Size(104, 23);
            this.checkBoxPlayMusic.TabIndex = 10;
            this.checkBoxPlayMusic.Text = "音楽再生";
            this.checkBoxPlayMusic.UseVisualStyleBackColor = true;
            this.checkBoxPlayMusic.CheckedChanged += new System.EventHandler(this.CheckPlayMusic);
            // 
            // SlideShowForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Name = "SlideShowForm";
            this.Text = "SlideShow";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SlideShowForm_FormClosing);
            this.Load += new System.EventHandler(this.SlideShowLoad);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSelectedPhotos)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timer_ChangePhoto;
        private System.Windows.Forms.PictureBox pictureBoxSelectedPhotos;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button buttonShowNextPicture;
        private System.Windows.Forms.Button buttonShowPrevPicture;
        private System.Windows.Forms.CheckBox checkBoxAutoSlideShow;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox checkBoxPlayMusic;
    }
}