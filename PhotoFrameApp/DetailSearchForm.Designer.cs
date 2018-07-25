namespace PhotoFrameApp
{
    partial class DetailSearchForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.checkBoxKeyword = new System.Windows.Forms.CheckBox();
            this.checkBoxFavorite = new System.Windows.Forms.CheckBox();
            this.checkBoxDateTime = new System.Windows.Forms.CheckBox();
            this.comboBoxSelectKeyword = new System.Windows.Forms.ComboBox();
            this.radioButtonFavoriteTrue = new System.Windows.Forms.RadioButton();
            this.radioButtonFavoriteFalse = new System.Windows.Forms.RadioButton();
            this.dateTimePickerFirstDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePickerLastDate = new System.Windows.Forms.DateTimePicker();
            this.ButtonFinishDecide = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("メイリオ", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(29, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "絞り込み条件";
            // 
            // checkBoxKeyword
            // 
            this.checkBoxKeyword.AutoSize = true;
            this.checkBoxKeyword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBoxKeyword.Location = new System.Drawing.Point(42, 90);
            this.checkBoxKeyword.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.checkBoxKeyword.Name = "checkBoxKeyword";
            this.checkBoxKeyword.Size = new System.Drawing.Size(84, 22);
            this.checkBoxKeyword.TabIndex = 1;
            this.checkBoxKeyword.Text = "キーワード";
            this.checkBoxKeyword.UseVisualStyleBackColor = true;
            // 
            // checkBoxFavorite
            // 
            this.checkBoxFavorite.AutoSize = true;
            this.checkBoxFavorite.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBoxFavorite.Location = new System.Drawing.Point(42, 160);
            this.checkBoxFavorite.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.checkBoxFavorite.Name = "checkBoxFavorite";
            this.checkBoxFavorite.Size = new System.Drawing.Size(84, 22);
            this.checkBoxFavorite.TabIndex = 2;
            this.checkBoxFavorite.Text = "お気に入り";
            this.checkBoxFavorite.UseVisualStyleBackColor = true;
            // 
            // checkBoxDateTime
            // 
            this.checkBoxDateTime.AutoSize = true;
            this.checkBoxDateTime.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBoxDateTime.Location = new System.Drawing.Point(42, 230);
            this.checkBoxDateTime.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.checkBoxDateTime.Name = "checkBoxDateTime";
            this.checkBoxDateTime.Size = new System.Drawing.Size(60, 22);
            this.checkBoxDateTime.TabIndex = 3;
            this.checkBoxDateTime.Text = "撮影日";
            this.checkBoxDateTime.UseVisualStyleBackColor = true;
            // 
            // comboBoxSelectKeyword
            // 
            this.comboBoxSelectKeyword.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSelectKeyword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxSelectKeyword.FormattingEnabled = true;
            this.comboBoxSelectKeyword.Location = new System.Drawing.Point(157, 87);
            this.comboBoxSelectKeyword.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboBoxSelectKeyword.Name = "comboBoxSelectKeyword";
            this.comboBoxSelectKeyword.Size = new System.Drawing.Size(315, 26);
            this.comboBoxSelectKeyword.TabIndex = 4;
            // 
            // radioButtonFavoriteTrue
            // 
            this.radioButtonFavoriteTrue.AutoSize = true;
            this.radioButtonFavoriteTrue.Checked = true;
            this.radioButtonFavoriteTrue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioButtonFavoriteTrue.Location = new System.Drawing.Point(157, 159);
            this.radioButtonFavoriteTrue.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radioButtonFavoriteTrue.Name = "radioButtonFavoriteTrue";
            this.radioButtonFavoriteTrue.Size = new System.Drawing.Size(49, 22);
            this.radioButtonFavoriteTrue.TabIndex = 5;
            this.radioButtonFavoriteTrue.TabStop = true;
            this.radioButtonFavoriteTrue.Text = "あり";
            this.radioButtonFavoriteTrue.UseVisualStyleBackColor = true;
            // 
            // radioButtonFavoriteFalse
            // 
            this.radioButtonFavoriteFalse.AutoSize = true;
            this.radioButtonFavoriteFalse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioButtonFavoriteFalse.Location = new System.Drawing.Point(288, 159);
            this.radioButtonFavoriteFalse.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radioButtonFavoriteFalse.Name = "radioButtonFavoriteFalse";
            this.radioButtonFavoriteFalse.Size = new System.Drawing.Size(49, 22);
            this.radioButtonFavoriteFalse.TabIndex = 6;
            this.radioButtonFavoriteFalse.Text = "なし";
            this.radioButtonFavoriteFalse.UseVisualStyleBackColor = true;
            // 
            // dateTimePickerFirstDate
            // 
            this.dateTimePickerFirstDate.Location = new System.Drawing.Point(157, 230);
            this.dateTimePickerFirstDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dateTimePickerFirstDate.Name = "dateTimePickerFirstDate";
            this.dateTimePickerFirstDate.Size = new System.Drawing.Size(140, 25);
            this.dateTimePickerFirstDate.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(306, 236);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 18);
            this.label2.TabIndex = 8;
            this.label2.Text = "～";
            // 
            // dateTimePickerLastDate
            // 
            this.dateTimePickerLastDate.Location = new System.Drawing.Point(332, 230);
            this.dateTimePickerLastDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dateTimePickerLastDate.Name = "dateTimePickerLastDate";
            this.dateTimePickerLastDate.Size = new System.Drawing.Size(140, 25);
            this.dateTimePickerLastDate.TabIndex = 9;
            // 
            // ButtonFinishDecide
            // 
            this.ButtonFinishDecide.BackColor = System.Drawing.Color.White;
            this.ButtonFinishDecide.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonFinishDecide.Location = new System.Drawing.Point(211, 288);
            this.ButtonFinishDecide.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ButtonFinishDecide.Name = "ButtonFinishDecide";
            this.ButtonFinishDecide.Size = new System.Drawing.Size(87, 34);
            this.ButtonFinishDecide.TabIndex = 10;
            this.ButtonFinishDecide.Text = "決定";
            this.ButtonFinishDecide.UseVisualStyleBackColor = false;
            this.ButtonFinishDecide.Click += new System.EventHandler(this.ButtonFinishDecideClick);
            // 
            // DetailSearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Moccasin;
            this.ClientSize = new System.Drawing.Size(524, 352);
            this.Controls.Add(this.ButtonFinishDecide);
            this.Controls.Add(this.dateTimePickerLastDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dateTimePickerFirstDate);
            this.Controls.Add(this.radioButtonFavoriteFalse);
            this.Controls.Add(this.radioButtonFavoriteTrue);
            this.Controls.Add(this.comboBoxSelectKeyword);
            this.Controls.Add(this.checkBoxDateTime);
            this.Controls.Add(this.checkBoxFavorite);
            this.Controls.Add(this.checkBoxKeyword);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximumSize = new System.Drawing.Size(540, 390);
            this.Name = "DetailSearchForm";
            this.Text = "DetailSearchForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBoxKeyword;
        private System.Windows.Forms.CheckBox checkBoxFavorite;
        private System.Windows.Forms.CheckBox checkBoxDateTime;
        private System.Windows.Forms.ComboBox comboBoxSelectKeyword;
        private System.Windows.Forms.RadioButton radioButtonFavoriteTrue;
        private System.Windows.Forms.RadioButton radioButtonFavoriteFalse;
        private System.Windows.Forms.DateTimePicker dateTimePickerFirstDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePickerLastDate;
        private System.Windows.Forms.Button ButtonFinishDecide;
    }
}