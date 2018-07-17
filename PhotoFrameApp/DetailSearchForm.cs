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
        PhotoFrameForm mainForm;
        private readonly Controller controller;
        public IEnumerable<Photo> photoList { get; set; }
        private DateTime oldDate;
        private DateTime newDate;

        public DetailSearchForm(PhotoFrameForm mainForm, IEnumerable<Keyword> allKeywords, IEnumerable<Photo> photoList)
        {
            this.mainForm = mainForm;
            InitializeComponent();
            
            

            // キーワードを選択できるようにコンボボックスに表示する
            if (allKeywords != null)
            {
                foreach (Keyword keyword in allKeywords)
                {
                    comboBoxSelectKeyword.Items.Add(keyword.Name);
                }
                comboBoxSelectKeyword.SelectedIndex = 0;

            }

            // 初期状態で表示する撮影日を設定する
            GetDateTime();
            dateTimePickerFirstDate.Value = oldDate;
            dateTimePickerLastDate.Value = newDate;
        }

        private void GetDateTime()
        {
            int compareValue = 0;
            bool isOldDate = false;
            bool isNewDate = false;
            for (int i = 0; i < photoList.Count()-1; i++)
            {
                compareValue = photoList.ElementAt(i).DateTime.CompareTo(photoList.ElementAt(i + 1).DateTime);
                if (compareValue < 0)
                {
                    oldDate = photoList.ElementAt(i).DateTime;
                    isOldDate = true;
                }
                if (compareValue > 0)
                {
                    newDate = photoList.ElementAt(i).DateTime;
                    isNewDate = true;
                }
            }

            // 比較失敗時はリストの最初のものを取得
            if (isOldDate == false)
            {
                oldDate = photoList.ElementAt(0).DateTime;
            }
            if (isNewDate == false)
            {
                newDate = photoList.ElementAt(0).DateTime;
            }
        }

        /// <summary>
        /// 決定ボタンクリック時のイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonFinishDecideClick(object sender, EventArgs e)
        {
            var searchResultPhotos = CheckParameter();
            // 絞り込み結果がなかった場合
            if (searchResultPhotos.Count() == 0)
            {
                MessageBox.Show("条件にあう写真は存在しません");
            }
            // 結果があった場合
            else
            {
                mainForm.searchedPhotos = CheckParameter();
                mainForm.RenewPhotoListView();
                this.Close();
            }
        }

        /// <summary>
        /// 決定ボタンクリック時の絞り込み条件を取得してコントローラに送る
        /// </summary>
        private IEnumerable<Photo> CheckParameter()
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
            return controller.ExecuteDetailSearch(photoList, keyword, isFavorite, firstDate, lastDate);
        }
    }
}
