using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PhotoFrame.Domain.Model;


namespace PhotoFrameApp
{
    public partial class DetailSearchForm : Form
    {
        private readonly Controller controller;
        public IEnumerable<Photo> photoList { get; set; }
        private DateTime oldDate;
        private DateTime newDate;

        public DetailSearchForm(IEnumerable<Keyword> allKeywords, IEnumerable<Photo> photoList)
        {
            InitializeComponent();

            // キーワードを選択できるようにコンボボックスに表示する
            if (allKeywords != null)
            {
                foreach (Keyword keyword in allKeywords)
                {
                    comboBoxSelectKeyword.Items.Add(keyword.Name);
                }
            }

            // 初期状態で表示する撮影日を設定する
            GetDateTime();
            dateTimePickerFirstDate.Value = oldDate;
            dateTimePickerLastDate.Value = newDate;
        }

        private void GetDateTime()
        {
            for(int i =0; i < photoList.Count(); i++)
            {
                if(photoList.DateTime 
            }
        }

        /// <summary>
        /// 決定ボタンクリック時のイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonFinishDecideClick(object sender, EventArgs e)
        {
            CheckParameter();
            this.Close();
        }

        /// <summary>
        /// 決定ボタンクリック時の絞り込み条件を取得してコントローラに送る
        /// </summary>
        private void CheckParameter()
        {
            string keyword = null;
            string isFavorite = null;
            DateTime? firstDate = null;
            DateTime? lastDate = null;

            // 各条件のチェックボックスが選択されているかどうか確認する
            // キーワード
            if (checkBoxKeyword.Checked)
            {
                // もし空文字が選択されていたら検索しない
                if (comboBoxSelectKeyword.Text == "")
                {
                    keyword = null;
                }
                else
                {
                    keyword = comboBoxSelectKeyword.Text;
                }
            }

            // お気に入り
            if (checkBoxFavorite.Checked)
            {
                if (radioButtonFavoriteFalse.Checked)
                {
                    isFavorite = "false";
                }
                else
                {
                    isFavorite = "true";
                }
            }

            // 撮影日
            if (checkBoxDateTime.Checked)
            {
                firstDate = dateTimePickerFirstDate.Value;
                lastDate = dateTimePickerLastDate.Value;
            }

            // コントローラに投げる
            controller.ExecuteDetailSearch(photoList, keyword, isFavorite, firstDate, lastDate);
        }
    }
}
