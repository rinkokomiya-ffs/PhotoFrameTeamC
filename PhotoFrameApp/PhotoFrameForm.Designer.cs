namespace PhotoFrameApp
{
    partial class PhotoFrameForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonReferenceFolder = new System.Windows.Forms.Button();
            this.buttonSearchKeyword = new System.Windows.Forms.Button();
            this.labelShowFolderPath = new System.Windows.Forms.Label();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.labelPictureBox = new System.Windows.Forms.Label();
            this.pictureBoxShowPicture = new System.Windows.Forms.PictureBox();
            this.listViewPhotoList = new System.Windows.Forms.ListView();
            this.columnHeader_PhotoPath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_Keyword = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_Favorite = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_Date = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBoxRegistKeyword = new System.Windows.Forms.TextBox();
            this.labelKeywordName = new System.Windows.Forms.Label();
            this.buttonCreateKeyword = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.radioButtonNewOld = new System.Windows.Forms.RadioButton();
            this.radioButtonOldNew = new System.Windows.Forms.RadioButton();
            this.radioButtonDefault = new System.Windows.Forms.RadioButton();
            this.buttonSlideShow = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.ButtonDetailSearch = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.labelKeyword = new System.Windows.Forms.Label();
            this.labelFavorite = new System.Windows.Forms.Label();
            this.comboBoxChangeKeyword = new System.Windows.Forms.ComboBox();
            this.buttonChangeKeyword = new System.Windows.Forms.Button();
            this.buttonToggleFavorite = new System.Windows.Forms.Button();
            this.pictureBoxProcessing = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxShowPicture)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProcessing)).BeginInit();
            this.SuspendLayout();
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
            this.splitContainer1.Panel1.AccessibleRole = System.Windows.Forms.AccessibleRole.IpAddress;
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(990, 572);
            this.splitContainer1.SplitterDistance = 97;
            this.splitContainer1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonReferenceFolder);
            this.groupBox1.Controls.Add(this.buttonSearchKeyword);
            this.groupBox1.Controls.Add(this.labelShowFolderPath);
            this.groupBox1.Location = new System.Drawing.Point(33, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(686, 75);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "1. フォルダから写真一覧を表示";
            // 
            // buttonReferenceFolder
            // 
            this.buttonReferenceFolder.Location = new System.Drawing.Point(6, 18);
            this.buttonReferenceFolder.Name = "buttonReferenceFolder";
            this.buttonReferenceFolder.Size = new System.Drawing.Size(75, 23);
            this.buttonReferenceFolder.TabIndex = 3;
            this.buttonReferenceFolder.Text = "フォルダ参照";
            this.buttonReferenceFolder.UseVisualStyleBackColor = true;
            this.buttonReferenceFolder.Click += new System.EventHandler(this.ButtonReferenceFolderClick);
            // 
            // buttonSearchKeyword
            // 
            this.buttonSearchKeyword.Location = new System.Drawing.Point(5, 46);
            this.buttonSearchKeyword.Name = "buttonSearchKeyword";
            this.buttonSearchKeyword.Size = new System.Drawing.Size(77, 23);
            this.buttonSearchKeyword.TabIndex = 1;
            this.buttonSearchKeyword.Text = "検索";
            this.buttonSearchKeyword.UseVisualStyleBackColor = true;
            this.buttonSearchKeyword.Click += new System.EventHandler(this.ButtonSearchFolderClick);
            // 
            // labelShowFolderPath
            // 
            this.labelShowFolderPath.AutoSize = true;
            this.labelShowFolderPath.Location = new System.Drawing.Point(87, 23);
            this.labelShowFolderPath.Name = "labelShowFolderPath";
            this.labelShowFolderPath.Size = new System.Drawing.Size(198, 12);
            this.labelShowFolderPath.TabIndex = 4;
            this.labelShowFolderPath.Text = "指定したフォルダパスがここに表示されます";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.pictureBoxProcessing);
            this.splitContainer2.Panel1.Controls.Add(this.labelPictureBox);
            this.splitContainer2.Panel1.Controls.Add(this.pictureBoxShowPicture);
            this.splitContainer2.Panel1.Controls.Add(this.listViewPhotoList);
            this.splitContainer2.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.groupBox4);
            this.splitContainer2.Panel2.Controls.Add(this.groupBox3);
            this.splitContainer2.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer2.Size = new System.Drawing.Size(990, 471);
            this.splitContainer2.SplitterDistance = 361;
            this.splitContainer2.TabIndex = 0;
            // 
            // labelPictureBox
            // 
            this.labelPictureBox.AutoSize = true;
            this.labelPictureBox.Location = new System.Drawing.Point(712, 163);
            this.labelPictureBox.Name = "labelPictureBox";
            this.labelPictureBox.Size = new System.Drawing.Size(126, 12);
            this.labelPictureBox.TabIndex = 2;
            this.labelPictureBox.Text = "写真がここに表示されます";
            // 
            // pictureBoxShowPicture
            // 
            this.pictureBoxShowPicture.Location = new System.Drawing.Point(581, 3);
            this.pictureBoxShowPicture.Name = "pictureBoxShowPicture";
            this.pictureBoxShowPicture.Size = new System.Drawing.Size(397, 342);
            this.pictureBoxShowPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxShowPicture.TabIndex = 1;
            this.pictureBoxShowPicture.TabStop = false;
            // 
            // listViewPhotoList
            // 
            this.listViewPhotoList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader_PhotoPath,
            this.columnHeader_Keyword,
            this.columnHeader_Favorite,
            this.columnHeader_Date});
            this.listViewPhotoList.FullRowSelect = true;
            this.listViewPhotoList.Location = new System.Drawing.Point(33, 0);
            this.listViewPhotoList.Name = "listViewPhotoList";
            this.listViewPhotoList.Size = new System.Drawing.Size(530, 311);
            this.listViewPhotoList.TabIndex = 0;
            this.listViewPhotoList.UseCompatibleStateImageBehavior = false;
            this.listViewPhotoList.View = System.Windows.Forms.View.Details;
            this.listViewPhotoList.DoubleClick += new System.EventHandler(this.PhotoListPreviewDoubleClick);
            // 
            // columnHeader_PhotoPath
            // 
            this.columnHeader_PhotoPath.Text = "ファイルパス";
            this.columnHeader_PhotoPath.Width = 204;
            // 
            // columnHeader_Keyword
            // 
            this.columnHeader_Keyword.Text = "キーワード";
            this.columnHeader_Keyword.Width = 165;
            // 
            // columnHeader_Favorite
            // 
            this.columnHeader_Favorite.Text = "お気に入り";
            this.columnHeader_Favorite.Width = 63;
            // 
            // columnHeader_Date
            // 
            this.columnHeader_Date.Text = "撮影日";
            this.columnHeader_Date.Width = 85;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBoxRegistKeyword);
            this.panel1.Controls.Add(this.labelKeywordName);
            this.panel1.Controls.Add(this.buttonCreateKeyword);
            this.panel1.Location = new System.Drawing.Point(33, 317);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(512, 31);
            this.panel1.TabIndex = 0;
            // 
            // textBoxRegistKeyword
            // 
            this.textBoxRegistKeyword.Location = new System.Drawing.Point(123, 7);
            this.textBoxRegistKeyword.Name = "textBoxRegistKeyword";
            this.textBoxRegistKeyword.Size = new System.Drawing.Size(284, 19);
            this.textBoxRegistKeyword.TabIndex = 0;
            // 
            // labelKeywordName
            // 
            this.labelKeywordName.AutoSize = true;
            this.labelKeywordName.Location = new System.Drawing.Point(16, 8);
            this.labelKeywordName.Name = "labelKeywordName";
            this.labelKeywordName.Size = new System.Drawing.Size(101, 12);
            this.labelKeywordName.TabIndex = 1;
            this.labelKeywordName.Text = "キーワード新規作成";
            // 
            // buttonCreateKeyword
            // 
            this.buttonCreateKeyword.Location = new System.Drawing.Point(413, 5);
            this.buttonCreateKeyword.Name = "buttonCreateKeyword";
            this.buttonCreateKeyword.Size = new System.Drawing.Size(86, 23);
            this.buttonCreateKeyword.TabIndex = 1;
            this.buttonCreateKeyword.Text = "作成";
            this.buttonCreateKeyword.UseVisualStyleBackColor = true;
            this.buttonCreateKeyword.Click += new System.EventHandler(this.ButtonRegistKeywordClick);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.radioButtonNewOld);
            this.groupBox4.Controls.Add(this.radioButtonOldNew);
            this.groupBox4.Controls.Add(this.radioButtonDefault);
            this.groupBox4.Controls.Add(this.buttonSlideShow);
            this.groupBox4.Location = new System.Drawing.Point(643, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(251, 80);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "4. スライドショー再生順";
            // 
            // radioButtonNewOld
            // 
            this.radioButtonNewOld.AutoSize = true;
            this.radioButtonNewOld.Location = new System.Drawing.Point(24, 55);
            this.radioButtonNewOld.Name = "radioButtonNewOld";
            this.radioButtonNewOld.Size = new System.Drawing.Size(83, 16);
            this.radioButtonNewOld.TabIndex = 2;
            this.radioButtonNewOld.Text = "撮影日降順";
            this.radioButtonNewOld.UseVisualStyleBackColor = true;
            // 
            // radioButtonOldNew
            // 
            this.radioButtonOldNew.AutoSize = true;
            this.radioButtonOldNew.Location = new System.Drawing.Point(24, 37);
            this.radioButtonOldNew.Name = "radioButtonOldNew";
            this.radioButtonOldNew.Size = new System.Drawing.Size(83, 16);
            this.radioButtonOldNew.TabIndex = 1;
            this.radioButtonOldNew.Text = "撮影日昇順";
            this.radioButtonOldNew.UseVisualStyleBackColor = true;
            // 
            // radioButtonDefault
            // 
            this.radioButtonDefault.AutoSize = true;
            this.radioButtonDefault.Checked = true;
            this.radioButtonDefault.Location = new System.Drawing.Point(24, 19);
            this.radioButtonDefault.Name = "radioButtonDefault";
            this.radioButtonDefault.Size = new System.Drawing.Size(59, 16);
            this.radioButtonDefault.TabIndex = 0;
            this.radioButtonDefault.TabStop = true;
            this.radioButtonDefault.Text = "表示順";
            this.radioButtonDefault.UseVisualStyleBackColor = true;
            // 
            // buttonSlideShow
            // 
            this.buttonSlideShow.Location = new System.Drawing.Point(123, 34);
            this.buttonSlideShow.Name = "buttonSlideShow";
            this.buttonSlideShow.Size = new System.Drawing.Size(103, 23);
            this.buttonSlideShow.TabIndex = 2;
            this.buttonSlideShow.Text = "スライドショー開始";
            this.buttonSlideShow.UseVisualStyleBackColor = true;
            this.buttonSlideShow.Click += new System.EventHandler(this.ButtonStartSlideShowClick);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.ButtonDetailSearch);
            this.groupBox3.Location = new System.Drawing.Point(411, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(212, 80);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "3. 検索条件";
            // 
            // ButtonDetailSearch
            // 
            this.ButtonDetailSearch.Location = new System.Drawing.Point(55, 26);
            this.ButtonDetailSearch.Name = "ButtonDetailSearch";
            this.ButtonDetailSearch.Size = new System.Drawing.Size(97, 23);
            this.ButtonDetailSearch.TabIndex = 3;
            this.ButtonDetailSearch.Text = "条件設定";
            this.ButtonDetailSearch.UseVisualStyleBackColor = true;
            this.ButtonDetailSearch.Click += new System.EventHandler(this.ButtonDetailSearchClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.labelKeyword);
            this.groupBox2.Controls.Add(this.labelFavorite);
            this.groupBox2.Controls.Add(this.comboBoxChangeKeyword);
            this.groupBox2.Controls.Add(this.buttonChangeKeyword);
            this.groupBox2.Controls.Add(this.buttonToggleFavorite);
            this.groupBox2.Location = new System.Drawing.Point(33, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(360, 80);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "2. 選択した写真に対する操作";
            // 
            // labelKeyword
            // 
            this.labelKeyword.AutoSize = true;
            this.labelKeyword.Location = new System.Drawing.Point(9, 21);
            this.labelKeyword.Name = "labelKeyword";
            this.labelKeyword.Size = new System.Drawing.Size(53, 12);
            this.labelKeyword.TabIndex = 3;
            this.labelKeyword.Text = "キーワード";
            // 
            // labelFavorite
            // 
            this.labelFavorite.AutoSize = true;
            this.labelFavorite.Location = new System.Drawing.Point(9, 46);
            this.labelFavorite.Name = "labelFavorite";
            this.labelFavorite.Size = new System.Drawing.Size(56, 12);
            this.labelFavorite.TabIndex = 2;
            this.labelFavorite.Text = "お気に入り";
            // 
            // comboBoxChangeKeyword
            // 
            this.comboBoxChangeKeyword.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxChangeKeyword.FormattingEnabled = true;
            this.comboBoxChangeKeyword.Location = new System.Drawing.Point(71, 18);
            this.comboBoxChangeKeyword.Name = "comboBoxChangeKeyword";
            this.comboBoxChangeKeyword.Size = new System.Drawing.Size(190, 20);
            this.comboBoxChangeKeyword.TabIndex = 0;
            // 
            // buttonChangeKeyword
            // 
            this.buttonChangeKeyword.Location = new System.Drawing.Point(267, 16);
            this.buttonChangeKeyword.Name = "buttonChangeKeyword";
            this.buttonChangeKeyword.Size = new System.Drawing.Size(70, 23);
            this.buttonChangeKeyword.TabIndex = 1;
            this.buttonChangeKeyword.Text = "設定";
            this.buttonChangeKeyword.UseVisualStyleBackColor = true;
            this.buttonChangeKeyword.Click += new System.EventHandler(this.ButtonChangeKeywordClick);
            // 
            // buttonToggleFavorite
            // 
            this.buttonToggleFavorite.Location = new System.Drawing.Point(71, 41);
            this.buttonToggleFavorite.Name = "buttonToggleFavorite";
            this.buttonToggleFavorite.Size = new System.Drawing.Size(89, 23);
            this.buttonToggleFavorite.TabIndex = 1;
            this.buttonToggleFavorite.Text = "切替";
            this.buttonToggleFavorite.UseVisualStyleBackColor = true;
            this.buttonToggleFavorite.Click += new System.EventHandler(this.ButtonToggleFavoriteClick);
            // 
            // pictureBoxProcessing
            // 
            this.pictureBoxProcessing.Location = new System.Drawing.Point(33, 0);
            this.pictureBoxProcessing.Name = "pictureBoxProcessing";
            this.pictureBoxProcessing.Size = new System.Drawing.Size(530, 311);
            this.pictureBoxProcessing.TabIndex = 3;
            this.pictureBoxProcessing.TabStop = false;
            this.pictureBoxProcessing.Visible = false;
            // 
            // PhotoFrameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(990, 572);
            this.Controls.Add(this.splitContainer1);
            this.Name = "PhotoFrameForm";
            this.Text = "Emograph～マイストーリーは突然に～";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxShowPicture)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProcessing)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button buttonCreateKeyword;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ListView listViewPhotoList;
        private System.Windows.Forms.ColumnHeader columnHeader_PhotoPath;
        private System.Windows.Forms.ColumnHeader columnHeader_Keyword;
        private System.Windows.Forms.ColumnHeader columnHeader_Favorite;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonSearchKeyword;
        private System.Windows.Forms.TextBox textBoxRegistKeyword;
        private System.Windows.Forms.Label labelKeywordName;
        private System.Windows.Forms.Button buttonSlideShow;
        private System.Windows.Forms.Button buttonReferenceFolder;
        private System.Windows.Forms.Label labelShowFolderPath;
        private System.Windows.Forms.Button ButtonDetailSearch;
        private System.Windows.Forms.ComboBox comboBoxChangeKeyword;
        private System.Windows.Forms.Button buttonChangeKeyword;
        private System.Windows.Forms.Button buttonToggleFavorite;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pictureBoxShowPicture;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton radioButtonNewOld;
        private System.Windows.Forms.RadioButton radioButtonOldNew;
        private System.Windows.Forms.RadioButton radioButtonDefault;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label labelKeyword;
        private System.Windows.Forms.Label labelFavorite;
        private System.Windows.Forms.ColumnHeader columnHeader_Date;
        private System.Windows.Forms.Label labelPictureBox;
        private System.Windows.Forms.PictureBox pictureBoxProcessing;
    }
}

