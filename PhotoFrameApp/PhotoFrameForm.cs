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
        private IKeywordRepository albumRepository;
        private IPhotoFileService photoFileService;
        private PhotoFrameApplication application;
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
            albumRepository = repositoryFactory.AlbumRepository;
            photoFileService = serviceFactory.PhotoFileService;
            application = new PhotoFrameApplication(albumRepository, photoRepository, photoFileService);
            searchedPhotos = new List<Photo>().AsEnumerable();


            // 全アルバム名を取得し、アルバム変更リストをセット
            IEnumerable<Keyword> allAlbums = albumRepository.Find((IQueryable<Keyword> albums) => albums);

            if (allAlbums != null)
            {
                foreach (Keyword album in allAlbums)
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
            // フォルダパスを引数にとって、コントロールに渡す
            this.searchedPhotos = application.SearchDirectory(folderPath);
            //this.searchedPhotos = await application.SearchDirectoryAsync(textBox_Search.Text);

            RenewPhotoListView();

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
                Photo photo = controller.ToggleFavorite(searchedPhotos.ElementAt(indexList.ElementAt(i)));
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
            string albumName, isFavorite;

            if (photo.Album != null)
            {
                albumName = photo.Album.Name;
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

                    if (photo.Album != null)
                    {
                        albumName = photo.Album.Name;
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

        
    }
}
