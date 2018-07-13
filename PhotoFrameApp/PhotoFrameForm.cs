using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PhotoFrame.Application;
using PhotoFrame.Domain.Model;
using PhotoFrame.Persistence;
using System.IO;

namespace PhotoFrameApp
{
    public partial class PhotoFrameForm : Form
    {
        private IPhotoRepository photoRepository;
        private IKeywordRepository keywordRepository;
        private IPhotoFileService photoFileService;
        private IEnumerable<Photo> searchedPhotos; // リストビュー上のフォトのリスト
        private Controller controller;

        public string folderPath { set; get; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public PhotoFrameForm()
        {
            InitializeComponent();

            // 各テストごとにデータベースファイルを削除
            if (System.IO.File.Exists("_Photo.csv"))
            {
                System.IO.File.Delete("_Photo.csv");
            }
            if (System.IO.File.Exists("_Album.csv"))
            {
                System.IO.File.Delete("_Album.csv");
            }



            // リポジトリ生成・初期化
            RepositoryFactory repositoryFactory = new RepositoryFactory(PhotoFrame.Persistence.Type.Csv);
            //RepositoryFactory repositoryFactory = new RepositoryFactory(PhotoFrame.Persistence.Type.EF);
            ServiceFactory serviceFactory = new ServiceFactory();
            photoRepository = repositoryFactory.PhotoRepository;
            keywordRepository = repositoryFactory.KeywordRepository;
            photoFileService = serviceFactory.PhotoFileService;
            searchedPhotos = new List<Photo>().AsEnumerable();


            // 全アルバム名を取得し、アルバム変更リストをセット
            // ここで直接Findを呼び出すのはまずいのでは？
            IEnumerable<Keyword> allKeywords = keywordRepository.Find((IQueryable<Keyword> keywords) => keywords);

            // InitializeKeywordList()を用意して、そこから全キーワードリストを取得する


            if (allKeywords != null)
            {
                foreach (Keyword album in allKeywords)
                {
                    comboBox_ChangeAlbum.Items.Add(album.Name);
                }
            }

        }

        /// <summary>
        /// フォルダ参照ボタンをクリックしたときのイベント
        /// ダイアログを開いてラベルにフォルダパスを表示する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonReferenceFolderClick(object sender, EventArgs e)
        {
            // ダイアログを開く
            // FolderBrowserDialogクラスのインスタンスを作成
            FolderBrowserDialog fbd = new FolderBrowserDialog
            {
                //上部に表示する説明テキストを指定する
                Description = "フォルダを指定してください。",

                //最初に選択するフォルダを指定する
                SelectedPath = @"C:\",
            };

            //ダイアログで決定ボタンを選択される
            if (fbd.ShowDialog(this) == DialogResult.OK)
            {
                // ラベルにフォルダパスを表示
                labelShowFolderPath.Text = fbd.SelectedPath;
                // フォルダパスを格納
                folderPath = fbd.SelectedPath;
            }
        }

        /// <summary>
        /// フォルダ名からフォトを検索
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonSearchFolderClick(object sender, EventArgs e)
        //private async void button_SearchAlbum_Click(object sender, EventArgs e)
        {
            //ラベルにフォルダが表示されていない場合の例外処理
            if (folderPath == null)
            {
                MessageBox.Show("フォルダ名が指定されていません","エラー" ,MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

            // フォルダパスを引数にとって、コントローラーに渡す
            else
            {
                this.searchedPhotos = controller.ExecuteSearchFolder(folderPath);
                //this.searchedPhotos = await application.SearchDirectoryAsync(textBox_Search.Text);

                RenewPhotoListView();
            }
        }

        /// <summary>
        /// 条件絞り込みフォームを開く
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonDetailSearchClick(object sender, EventArgs e)
        {
            if(CheckExistListviewPhotos())
            {
                var detailSearchForm = new DetailSearchForm();
                detailSearchForm.ShowDialog();
            }
        }

        /// <summary>
        /// キーワード新規作成
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private async void ButtonRegistKeyword(object sender, EventArgs e)
        private void ButtonRegistKeyword(object sender, EventArgs e)
        {
            string keyword = textBoxRegistKeyword.Text;
            var result = controller.ExecuteRegistKeyword(keyword);
            //var result = await application.CreateAlbumAsync(keyword);

            switch (result)
            {
                case 0:
                    comboBox_ChangeAlbum.Items.Add(keyword);
                    break;
                case 1:
                    MessageBox.Show("キーワードが未入力です");
                    break;
                case 2:
                    MessageBox.Show("既存のキーワードです");
                    break;
                default:
                    break;
            }

        }

        /// <summary>
        /// お気に入り切り替え
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private async void button_ToggleFavorite_Click(object sender, EventArgs e)
        private void ButtonToggleFavoriteClick(object sender, EventArgs e)
        {
            var indexList = GetListviewIndex();

            for (int i = 0; i < indexList.Count; i++)
            {
                Photo photo = controller.ExecuteToggleFavorite(searchedPhotos.ElementAt(indexList.ElementAt(i)));
                //Photo photo = await application.ToggleFavoriteAsync(searchedPhotos.ElementAt(indexList.ElementAt(i)));
                RenewPhotoListViewItem(indexList.ElementAt(i), photo);
            }

        }

        /// <summary>
        /// 選択中のフォトの所属キーワードを変更
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private async void ButtonChangeKeywordClick(object sender, EventArgs e)
        private void ButtonChangeKeywordClick(object sender, EventArgs e)
        {
            string newAlbumName = comboBox_ChangeAlbum.Text;
            var indexList = GetListviewIndex();

            for (int i = 0; i < indexList.Count; i++)
            {
                Photo photo = controller.ExecuteChangeKeyword(searchedPhotos.ElementAt(indexList.ElementAt(i)), newAlbumName);
                //Photo photo = await application.ChangeAlbumAsync(searchedPhotos.ElementAt(indexList.ElementAt(i)), newAlbumName);
                RenewPhotoListViewItem(indexList.ElementAt(i), photo);
            }

        }

        //ダブルクリックした写真情報をpictureboxに描写
        private void PhotoListPreviewDoubleClick(object sender, EventArgs e)
        {
            ListViewItem targetItem = (ListViewItem)sender;
            int index_number = listView_PhotoList.SelectedItems.IndexOf(targetItem);

            this.Controls.Remove(labelPictureBox);
            pictureBoxShowPicture.ImageLocation = searchedPhotos.ElementAt(index_number).File.FilePath;
        }



        /// <summary>
        /// リストビューをソートする順番を設定
        /// </summary>
        private int CheckSortList()
        {
            if(radioButtonOldNew.Checked)
            {
                return 1;
            }
            else if(radioButtonNewOld.Checked)
            {
                return 2;
            }
            else
            {
                return 0;
            }
        }



        /// <summary>
        /// 選択したリストビューのインデックス取得
        /// </summary>
        /// <returns></returns>
        private List<int> GetListviewIndex()
        {
            var indexList = new List<int>();
            for (int i = 0; i < listView_PhotoList.SelectedItems.Count; i++)
            {
                indexList.Add(listView_PhotoList.SelectedItems[i].Index);
            }

            return indexList;
        }

        /// <summary>
        /// リストビュー上のフォトのスライドショーを実行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonStartSlideShowClick(object sender, EventArgs e)
        {
            controller.ExecuteSortList(searchedPhotos, CheckSortList());
            if (this.searchedPhotos.Count() > 0)
            {
                var slideShowForm = new SlideShowForm(this.searchedPhotos);
                slideShowForm.ShowDialog();
            }

        }


        /// <summary>
        /// リストビュー1行分更新
        /// </summary>
        /// <param name="index"></param>
        /// <param name="photo"></param>
        private void RenewPhotoListViewItem(int index, Photo photo)
        {
            string albumName = "";
            string isFavorite = "";

            if (photo.Keyword != null)
            {
                albumName = photo.Keyword.Name;
            }
            else
            {
                albumName = "";
            }


            if (photo.IsFavorite)
            {
                isFavorite = "★";
            }
            else
            {
                isFavorite = "";
            }

            listView_PhotoList.Items[index].SubItems[0].Text = photo.File.FilePath;
            listView_PhotoList.Items[index].SubItems[1].Text = albumName;
            listView_PhotoList.Items[index].SubItems[2].Text = isFavorite;
        }

        /// <summary>
        /// リストビューの更新
        /// </summary>
        /// <param name="photos"></param>
        private void RenewPhotoListView()
        {
            listView_PhotoList.Items.Clear();

            if (this.searchedPhotos != null)
            {
                foreach (Photo photo in searchedPhotos)
                {
                    string albumName, isFavorite;

                    if (photo.Keyword != null)
                    {
                        albumName = photo.Keyword.Name;
                    }
                    else
                    {
                        albumName = "";
                    }


                    if (photo.IsFavorite)
                    {
                        isFavorite = "★";
                    }
                    else
                    {
                        isFavorite = "";
                    }

                    string[] item = { photo.File.FilePath, albumName, isFavorite };
                    listView_PhotoList.Items.Add(new ListViewItem(item));

                }
            }
        }

        /// <summary>
        /// リストビューに写真があるかどうか確認する
        /// </summary>
        private bool CheckExistListviewPhotos()
        {
            if (this.searchedPhotos.Count() == 0)
            {
                MessageBox.Show("リストビューに写真が存在しません。");
                return false;
            }
            else
            {
                return true;
            }
        }

       
    }
}
