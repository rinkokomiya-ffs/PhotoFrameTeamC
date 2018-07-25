using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
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
        private Controller controller;

        // フォルダパス
        private string folderPath;
        // リストビュー上のフォトのリスト
        public IEnumerable<Photo> searchedPhotos { set; get; }
        // キーワードリスト
        public IEnumerable<Keyword> allKeywords { set; get; }
        
        // 定数
        // キーワード登録上限値
        private readonly int MAX_REGIST_KEYWORD = 50;
        // 写真登録上限値
        private readonly int MAX_REGIST_IMAGE = 100;
        // キーワード文字数上限値
        private readonly int MAX_KEYWORD_LENGTH = 20;

        public PhotoFrameForm()
        {
            InitializeComponent();

            // リポジトリ生成・初期化
            RepositoryFactory repositoryFactory = new RepositoryFactory(PhotoFrame.Persistence.Type.EF);
            ServiceFactory serviceFactory = new ServiceFactory();
            photoRepository = repositoryFactory.PhotoRepository;
            keywordRepository = repositoryFactory.KeywordRepository;
            photoFileService = serviceFactory.PhotoFileService;
            controller = new Controller(keywordRepository, photoRepository, photoFileService);
            searchedPhotos = new List<Photo>().AsEnumerable();
            // キーワード解除用文字列の登録
            comboBoxChangeKeyword.Items.Add("設定解除");

            // 全アルバム名を取得し、アルバム変更リストをセット
            UpdateKeywordList();

            comboBoxChangeKeyword.SelectedIndex = 0;
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

            // 読み込み中画面のロード
            pictureBoxProcessing.Image = new Bitmap("loading.jpg");
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
        private async void ButtonSearchFolderClick(object sender, EventArgs e)
        {
            //ラベルにフォルダが表示されていない場合の例外処理
            if (folderPath == null || folderPath == "")
            {
                MessageBox.Show("フォルダ名が指定されていません");
            }
            else
            {
                //　表示されている写真をリセット
                if (pictureBoxShowPicture.Image != null) pictureBoxShowPicture.Image = null;

                // 読み込み中画面表示
                pictureBoxProcessing.Visible = true;

                // 写真情報読み込み
                searchedPhotos = await controller.ExecuteSearchFolderAsync(folderPath);

                // 読み込み中画面非表示
                pictureBoxProcessing.Visible = false;

                // フォルダパスを引数にとって、コントローラーに渡す
                if (searchedPhotos == null)
                {
                    MessageBox.Show("フォルダが存在しません");
                }
                else if (searchedPhotos.Count() == 0)
                {
                    MessageBox.Show("写真が存在しません");
                }
                else
                {
                    RenewPhotoListView();

                    // 上限枚数に達した場合
                    if (this.searchedPhotos.Count() >= MAX_REGIST_IMAGE)
                    {
                        MessageBox.Show("表示上限枚数100枚に達しました\nこれ以上は表示できません");
                    }
                }
            }
        }

        /// <summary>
        /// 条件絞り込みフォームを開く
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonDetailSearchClick(object sender, EventArgs e)
        {
            if (CheckExistListviewPhotos())
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
            if (allKeywords.Count() >= MAX_REGIST_KEYWORD)
            {
                MessageBox.Show("作成できるキーワード数の上限値に達しています");
            }

            else
            {
                string keyword = textBoxRegistKeyword.Text;
                if (keyword == "")
                {
                    MessageBox.Show("テキストボックスにキーワードが入力されていません");
                }
                else if (keyword.Length > MAX_KEYWORD_LENGTH)
                {
                    MessageBox.Show("作成できるキーワードの文字数は20字以内です");
                }
                else
                {
                    var result = controller.ExecuteRegistKeyword(keyword);

                    switch (result)
                    {
                        case 0:
                            allKeywords = controller.ExecuteGetKeyword();
                            comboBoxChangeKeyword.Items.Add(keyword);
                            break;
                        case 1:
                            MessageBox.Show("そのキーワードはすでに作成されています");
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
        private void ButtonToggleFavoriteClick(object sender, EventArgs e)
        {
            if (CheckExistListviewPhotos())
            {
                var indexList = GetListviewIndex();

                if (indexList.Count() == 0)
                {
                    MessageBox.Show("写真が選択されていません");
                }
                else
                {
                    for (int i = 0; i < indexList.Count; i++)
                    {
                        Photo photo = controller.ExecuteToggleFavorite(searchedPhotos.ElementAt(indexList.ElementAt(i)));
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
        private void ButtonChangeKeywordClick(object sender, EventArgs e)
        {
            if (allKeywords.Count() == 0)
            {
                MessageBox.Show("キーワードが作成されていません");
            }
            if (CheckExistListviewPhotos())
            {
                string newKeywordName = null;

                if (comboBoxChangeKeyword.Text != "設定解除")
                {
                    newKeywordName = comboBoxChangeKeyword.Text;
                }

                var indexList = GetListviewIndex();

                if (indexList.Count() == 0)
                {
                    MessageBox.Show("写真が選択されていません");
                }
                else
                {
                    for (int i = 0; i < indexList.Count; i++)
                    {
                        Photo photo = controller.ExecuteChangeKeyword(searchedPhotos.ElementAt(indexList.ElementAt(i)), newKeywordName);
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
                    Image img = Image.FromStream(fs, false, false);
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
            if (radioButtonOldNew.Checked)
            {
                return 1;
            }
            else if (radioButtonNewOld.Checked)
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

            listViewPhotoList.SelectedItems.Clear();

            return indexList;
        }

        /// <summary>
        /// リストビュー上のフォトのスライドショーを実行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonStartSlideShowClick(object sender, EventArgs e)
        {
            if (CheckExistListviewPhotos())
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
