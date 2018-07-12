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
            this.panel3 = new System.Windows.Forms.Panel();
            this.labelShowFolderPath = new System.Windows.Forms.Label();
            this.buttonReferenceFolder = new System.Windows.Forms.Button();
            this.buttonSearchAlbum = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBoxRegistKeyword = new System.Windows.Forms.TextBox();
            this.labelKeywordName = new System.Windows.Forms.Label();
            this.buttonCreateKeyword = new System.Windows.Forms.Button();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.listView_PhotoList = new System.Windows.Forms.ListView();
            this.columnHeader_PhotoPath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_AlbumName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_Favorite = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ButtonDetailSearch = new System.Windows.Forms.Button();
            this.button_SlideShow = new System.Windows.Forms.Button();
            this.button_ChangeAlbum = new System.Windows.Forms.Button();
            this.button_ToggleFavorite = new System.Windows.Forms.Button();
            this.comboBox_ChangeAlbum = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.panel3);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(990, 546);
            this.splitContainer1.SplitterDistance = 69;
            this.splitContainer1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.labelShowFolderPath);
            this.panel3.Controls.Add(this.buttonReferenceFolder);
            this.panel3.Controls.Add(this.buttonSearchAlbum);
            this.panel3.Location = new System.Drawing.Point(33, 7);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(530, 53);
            this.panel3.TabIndex = 2;
            // 
            // labelShowFolderPath
            // 
            this.labelShowFolderPath.AutoSize = true;
            this.labelShowFolderPath.Location = new System.Drawing.Point(86, 8);
            this.labelShowFolderPath.Name = "labelShowFolderPath";
            this.labelShowFolderPath.Size = new System.Drawing.Size(198, 12);
            this.labelShowFolderPath.TabIndex = 4;
            this.labelShowFolderPath.Text = "指定したフォルダパスがここに表示されます";
            // 
            // buttonReferenceFolder
            // 
            this.buttonReferenceFolder.Location = new System.Drawing.Point(5, 3);
            this.buttonReferenceFolder.Name = "buttonReferenceFolder";
            this.buttonReferenceFolder.Size = new System.Drawing.Size(75, 23);
            this.buttonReferenceFolder.TabIndex = 3;
            this.buttonReferenceFolder.Text = "参照";
            this.buttonReferenceFolder.UseVisualStyleBackColor = true;
            this.buttonReferenceFolder.Click += new System.EventHandler(this.ButtonReferenceFolderClick);
            // 
            // buttonSearchAlbum
            // 
            this.buttonSearchAlbum.Location = new System.Drawing.Point(3, 30);
            this.buttonSearchAlbum.Name = "buttonSearchAlbum";
            this.buttonSearchAlbum.Size = new System.Drawing.Size(77, 23);
            this.buttonSearchAlbum.TabIndex = 1;
            this.buttonSearchAlbum.Text = "検索";
            this.buttonSearchAlbum.UseVisualStyleBackColor = true;
            this.buttonSearchAlbum.Click += new System.EventHandler(this.ButtonSearchFolderClick);
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
            this.buttonCreateKeyword.Click += new System.EventHandler(this.ButtonRegistKeyword);
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
            this.splitContainer2.Panel1.Controls.Add(this.listView_PhotoList);
            this.splitContainer2.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.comboBox_ChangeAlbum);
            this.splitContainer2.Panel2.Controls.Add(this.ButtonDetailSearch);
            this.splitContainer2.Panel2.Controls.Add(this.button_ChangeAlbum);
            this.splitContainer2.Panel2.Controls.Add(this.button_ToggleFavorite);
            this.splitContainer2.Panel2.Controls.Add(this.button_SlideShow);
            this.splitContainer2.Size = new System.Drawing.Size(990, 473);
            this.splitContainer2.SplitterDistance = 351;
            this.splitContainer2.TabIndex = 0;
            // 
            // listView_PhotoList
            // 
            this.listView_PhotoList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader_PhotoPath,
            this.columnHeader_AlbumName,
            this.columnHeader_Favorite});
            this.listView_PhotoList.FullRowSelect = true;
            this.listView_PhotoList.Location = new System.Drawing.Point(33, 0);
            this.listView_PhotoList.Name = "listView_PhotoList";
            this.listView_PhotoList.Size = new System.Drawing.Size(530, 311);
            this.listView_PhotoList.TabIndex = 0;
            this.listView_PhotoList.UseCompatibleStateImageBehavior = false;
            this.listView_PhotoList.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader_PhotoPath
            // 
            this.columnHeader_PhotoPath.Text = "ファイルパス";
            this.columnHeader_PhotoPath.Width = 294;
            // 
            // columnHeader_AlbumName
            // 
            this.columnHeader_AlbumName.Text = "アルバム名";
            this.columnHeader_AlbumName.Width = 140;
            // 
            // columnHeader_Favorite
            // 
            this.columnHeader_Favorite.Text = "お気に入り";
            this.columnHeader_Favorite.Width = 85;
            // 
            // ButtonDetailSearch
            // 
            this.ButtonDetailSearch.Location = new System.Drawing.Point(343, 43);
            this.ButtonDetailSearch.Name = "ButtonDetailSearch";
            this.ButtonDetailSearch.Size = new System.Drawing.Size(97, 23);
            this.ButtonDetailSearch.TabIndex = 3;
            this.ButtonDetailSearch.Text = "条件絞り込み";
            this.ButtonDetailSearch.UseVisualStyleBackColor = true;
            this.ButtonDetailSearch.Click += new System.EventHandler(this.ButtonDetailSearchClick);
            // 
            // button_SlideShow
            // 
            this.button_SlideShow.Location = new System.Drawing.Point(456, 43);
            this.button_SlideShow.Name = "button_SlideShow";
            this.button_SlideShow.Size = new System.Drawing.Size(89, 23);
            this.button_SlideShow.TabIndex = 2;
            this.button_SlideShow.Text = "スライドショー";
            this.button_SlideShow.UseVisualStyleBackColor = true;
            this.button_SlideShow.Click += new System.EventHandler(this.ButtonStartSlideShowClick);
            // 
            // button_ChangeAlbum
            // 
            this.button_ChangeAlbum.Location = new System.Drawing.Point(259, 30);
            this.button_ChangeAlbum.Name = "button_ChangeAlbum";
            this.button_ChangeAlbum.Size = new System.Drawing.Size(70, 23);
            this.button_ChangeAlbum.TabIndex = 1;
            this.button_ChangeAlbum.Text = "設定";
            this.button_ChangeAlbum.UseVisualStyleBackColor = true;
            this.button_ChangeAlbum.Click += new System.EventHandler(this.ButtonChangeKeywordClick);
            // 
            // button_ToggleFavorite
            // 
            this.button_ToggleFavorite.Location = new System.Drawing.Point(51, 58);
            this.button_ToggleFavorite.Name = "button_ToggleFavorite";
            this.button_ToggleFavorite.Size = new System.Drawing.Size(89, 23);
            this.button_ToggleFavorite.TabIndex = 1;
            this.button_ToggleFavorite.Text = "切替";
            this.button_ToggleFavorite.UseVisualStyleBackColor = true;
            this.button_ToggleFavorite.Click += new System.EventHandler(this.ButtonToggleFavoriteClick);
            // 
            // comboBox_ChangeAlbum
            // 
            this.comboBox_ChangeAlbum.FormattingEnabled = true;
            this.comboBox_ChangeAlbum.Location = new System.Drawing.Point(51, 32);
            this.comboBox_ChangeAlbum.Name = "comboBox_ChangeAlbum";
            this.comboBox_ChangeAlbum.Size = new System.Drawing.Size(190, 20);
            this.comboBox_ChangeAlbum.TabIndex = 0;
            // 
            // PhotoFrameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(990, 546);
            this.Controls.Add(this.splitContainer1);
            this.Name = "PhotoFrameForm";
            this.Text = "Form1";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button buttonCreateKeyword;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ListView listView_PhotoList;
        private System.Windows.Forms.ColumnHeader columnHeader_PhotoPath;
        private System.Windows.Forms.ColumnHeader columnHeader_AlbumName;
        private System.Windows.Forms.ColumnHeader columnHeader_Favorite;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonSearchAlbum;
        private System.Windows.Forms.TextBox textBoxRegistKeyword;
        private System.Windows.Forms.Label labelKeywordName;
        private System.Windows.Forms.Button button_SlideShow;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button buttonReferenceFolder;
        private System.Windows.Forms.Label labelShowFolderPath;
        private System.Windows.Forms.Button ButtonDetailSearch;
        private System.Windows.Forms.ComboBox comboBox_ChangeAlbum;
        private System.Windows.Forms.Button button_ChangeAlbum;
        private System.Windows.Forms.Button button_ToggleFavorite;
    }
}

