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

        public IEnumerable<Photo> searchedPhotos { set; get; } // リストビュー上のフォトのリスト
        private Controller controller;
        
        // 定数
        // キーワード登録上限値
        private readonly int MAX_REGIST_KEYWORD = 50;
        // キーワード文字数上限値
        private readonly int MAX_KEYWORD_LENGTH = 20;

        public string folderPath { set; get; }
        public IEnumerable<Keyword> allKeywords { set; get; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public PhotoFrameForm()
        {
            InitializeComponent();

            // リポジトリ生成・初期化
            RepositoryFactory repositoryFactory = new RepositoryFactory(PhotoFrame.Persistence.Type.Csv);
            //RepositoryFactory repositoryFactory = new RepositoryFactory(PhotoFrame.Persistence.Type.EF);
            ServiceFactory serviceFactory = new ServiceFactory();
            photoRepository = repositoryFactory.PhotoRepository;
            keywordRepository = repositoryFactory.KeywordRepository;
            photoFileService = serviceFactory.PhotoFileService;
            searchedPhotos = new List<Photo>().AsEnumerable();
            controller = new Controller(keywordRepository, photoRepository, photoFileService);

            // 全アルバム名を取得し、アルバム変更リストをセット
            UpdateKeywordList();

        }

        /// <summary>
        /// 全キーワードを取得してコンボボックスにセットする
        /// </summary>
        private void UpdateKeywordList()
        {
            allKeywords = controller.ExecuteGetKeyword();
            if (allKeywords != null)
            {
                foreach (Keyword keyword in allKeywords)
                {
                    comboBoxChangeKeyword.Items.Add(keyword.Name);
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
            if (folderPath == null || folderPath == "")
            {
                MessageBox.Show("フォルダ名が指定されていません");
            }

            // フォルダパスを引数にとって、コントローラーに渡す
            else
            {
                this.searchedPhotos = controller.ExecuteSearchFolder(folderPath);
                //this.searchedPhotos = await application.SearchDirectoryAsync(textBox_Search.Text);

                RenewPhotoListView();
            }

            // フォルダパスを引数にとって、コントローラーに渡す
            if (controller.ExecuteSearchFolder(folderPath).Count() == 0)
            {
                MessageBox.Show("写真が存在しません");
            }
            else if (controller.ExecuteSearchFolder(folderPath) == null)
            {
                MessageBox.Show("フォルダが存在しません");
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
                var detailSearchForm = new DetailSearchForm(this, controller, allKeywords, searchedPhotos);
                detailSearchForm.ShowDialog();
            }
        }

        /// <summary>
        /// キーワード新規作成
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private async void ButtonRegistKeyword(object sender, EventArgs e)
        private void ButtonRegistKeywordClick(object sender, EventArgs e)
        {
            if(allKeywords.Count() > MAX_REGIST_KEYWORD)
            {
                MessageBox.Show("作成できるキーワード数の上限値に達しています");
            }
            
            else
            {
                string keyword = textBoxRegistKeyword.Text;
                if(keyword == "")
                {
                    MessageBox.Show("テキストボックスにキーワードが入力されていません");
                }
                else if(keyword.Length > MAX_KEYWORD_LENGTH)
                {
                    MessageBox.Show("作成できるキーワードの文字数は20字以内です");
                }
                else
                {
                    var result = controller.ExecuteRegistKeyword(keyword);
                    //var result = await application.CreateAlbumAsync(keyword);

                    switch (result)
                    {
                        case 0:

                            allKeywords = controller.ExecuteGetKeyword();
                            comboBoxChangeKeyword.Items.Add(keyword);                          
                          

                            break;
                        case 1:
                            MessageBox.Show("既存のキーワードです");
                            break;
                        default:
                            break;
                    }
                }
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
            if(CheckExistListviewPhotos())
            {
                var indexList = GetListviewIndex();
            
                if(indexList.Count() == 0)
                {
                    MessageBox.Show("写真が選択されていません");
                }
                else
                {
                    for (int i = 0; i < indexList.Count; i++)
                    {
                        Photo photo = controller.ExecuteToggleFavorite(searchedPhotos.ElementAt(indexList.ElementAt(i)));
                        //Photo photo = await application.ToggleFavoriteAsync(searchedPhotos.ElementAt(indexList.ElementAt(i)));
                        RenewPhotoListViewItem(indexList.ElementAt(i), photo);
                    }
                }
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
            if(allKeywords.Count() == 0)
            {
                MessageBox.Show("キーワードが作成されていません");
            }
            if(CheckExistListviewPhotos())
            {
                string newKeywordName = comboBoxChangeKeyword.Text;
                var indexList = GetListviewIndex();
                
                if(indexList.Count() == 0)
                {
                    MessageBox.Show("写真が選択されていません");
                }
                else
                {
                    for (int i = 0; i < indexList.Count; i++)
                    {
                        Photo photo = controller.ExecuteChangeKeyword(searchedPhotos.ElementAt(indexList.ElementAt(i)), newKeywordName);
                        //Photo photo = await application.ChangeAlbumAsync(searchedPhotos.ElementAt(indexList.ElementAt(i)), newAlbumName);
                        RenewPhotoListViewItem(indexList.ElementAt(i), photo);
                    }
                }
            }
        }

        /// <summary>
        /// リストビューをダブルクリックしてプレビュー表示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PhotoListPreviewDoubleClick(object sender, EventArgs e)
        {
            if (CheckExistListviewPhotos())
            {
                try
                {
                    int indexNumber = listViewPhotoList.SelectedItems[0].Index;

                    labelPictureBox.Visible = false;
                    FileStream fs = System.IO.File.OpenRead(searchedPhotos.ElementAt(indexNumber).File.FilePath);
                    Image img = Image.FromStream(fs, false, false); // 検証なし
                    pictureBoxShowPicture.Image = img;
                }
                catch (ArgumentException)
                {
                    MessageBox.Show("ファイルが壊れています");
                }
                catch (FileNotFoundException)
                {
                    MessageBox.Show("ファイルが存在しません");
                }
            }
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
            for (int i = 0; i < listViewPhotoList.SelectedItems.Count; i++)
            {
                indexList.Add(listViewPhotoList.SelectedItems[i].Index);
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
            if(CheckExistListviewPhotos())
            {
                // ソートしたリストを渡す
                IEnumerable<Photo> targetSlideshowPhotos = controller.ExecuteSortList(searchedPhotos, CheckSortList());
                var slideShowForm = new SlideShowForm(targetSlideshowPhotos);
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
            string keyword = "";
            string isFavorite = "";
            string datetime = "";

            if (photo.Keyword != null)
            {
                keyword = photo.Keyword.Name;
            }
            else
            {
                keyword = "";
            }


            if (photo.IsFavorite)
            {
                isFavorite = "★";
            }
            else
            {
                isFavorite = "";
            }

            datetime = photo.DateTime.ToShortDateString();

            listViewPhotoList.Items[index].SubItems[0].Text = photo.File.FilePath;
            listViewPhotoList.Items[index].SubItems[1].Text = keyword;
            listViewPhotoList.Items[index].SubItems[2].Text = isFavorite;
            listViewPhotoList.Items[index].SubItems[3].Text = datetime;

        }

        /// <summary>
        /// リストビューの更新
        /// </summary>
        /// <param name="photos"></param>
        public void RenewPhotoListView()
        {
            listViewPhotoList.Items.Clear();

            if (this.searchedPhotos != null)
            {
                foreach (Photo photo in searchedPhotos)
                {
                    string keyword, isFavorite, datetime;

                    if (photo.Keyword != null)
                    {
                        keyword = photo.Keyword.Name;
                    }
                    else
                    {
                        keyword = "";
                    }


                    if (photo.IsFavorite)
                    {
                        isFavorite = "★";
                    }
                    else
                    {
                        isFavorite = "";
                    }

                    datetime = photo.DateTime.ToShortDateString();

                    string[] item = { photo.File.FilePath, keyword, isFavorite, datetime };
                    listViewPhotoList.Items.Add(new ListViewItem(item));

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
