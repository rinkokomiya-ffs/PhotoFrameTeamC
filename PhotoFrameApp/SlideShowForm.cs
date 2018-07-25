using System;
using System.IO;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using PhotoFrame.Domain.Model;
using System.Media;

namespace PhotoFrameApp
{
    public partial class SlideShowForm : Form
    {
        private IEnumerable<Photo> photos;
        private int photo_index;

        private SoundPlayer player = null;
        private string musicFile;

        public SlideShowForm(IEnumerable<Photo> photos)
        {
            InitializeComponent();
            this.photos = photos;
            this.photo_index = 0;
        }

        /// <summary>
        /// スライドショー画面の初期設定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SlideShowLoad(object sender, EventArgs e)
        {
            if (photos.Count() > 0)
            {
                System.IO.FileStream fs = System.IO.File.OpenRead(photos.ElementAt(photo_index).File.FilePath);
                Image img = Image.FromStream(fs, false, false);
                pictureBoxSelectedPhotos.Image = img;

                timer_ChangePhoto.Interval = 3000;

                if (checkBoxAutoSlideShow.Checked)
                {
                    timer_ChangePhoto.Start();
                }

                if (checkBoxPlayMusic.Checked)
                {
                    // 音楽再生メソッドを呼び出す
                    PlayMusic();
                }
            }
        }

        /// <summary>
        /// 音楽再生チェックボックス制御
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckPlayMusic(object sender, EventArgs e)
        {
            if (checkBoxPlayMusic.Checked)
            {
                PlayMusic();
            }

            else
            {
                StopMusic();
            }
        }

        /// <summary>
        /// 音楽再生
        /// </summary>
        private void PlayMusic()
        {
            //読み込む
            player = new SoundPlayer(musicFile);

            //ループ再生
            player.PlayLooping();
        }

        /// <summary>
        /// 音楽停止
        /// </summary>
        private void StopMusic()
        {
            if (player != null)
            {
                player.Stop();
                player.Dispose();
                player = null;
            }
        }

        /// <summary>
        /// 一定時間ごとに画像を切り替え
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimerChangePhotoTick(object sender, EventArgs e)
        {
            photo_index++;

            if (photo_index >= photos.Count())
            {
                photo_index = 0;
            }

            System.IO.FileStream fs = System.IO.File.OpenRead(photos.ElementAt(photo_index).File.FilePath);
            Image img = Image.FromStream(fs, true, true);
            pictureBoxSelectedPhotos.Image = img;

        }

        /// <summary>
        /// 自動再生のON/OFF切り替え
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckAutoSlideShow(object sender, EventArgs e)
        {
            if (checkBoxAutoSlideShow.Checked)
            {
                timer_ChangePhoto.Start();
            }
            else
            {
                timer_ChangePhoto.Stop();
            }
        }

        /// <summary>
        /// 次の画像に切り替える(自動再生OFF)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonNextClick(object sender, EventArgs e)
        {
            checkBoxAutoSlideShow.Checked = false;
            timer_ChangePhoto.Stop();

            photo_index++;

            if (photo_index >= photos.Count())
            {
                photo_index = 0;
            }

            System.IO.FileStream fs = System.IO.File.OpenRead(photos.ElementAt(photo_index).File.FilePath);
            Image img = Image.FromStream(fs, false, false);
            pictureBoxSelectedPhotos.Image = img;
        }

        /// <summary>
        /// 一つ前の画像に戻す(自動再生OFF)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonBackClick(object sender, EventArgs e)
        {
            checkBoxAutoSlideShow.Checked = false;
            timer_ChangePhoto.Stop();

            photo_index--;

            if (photo_index < 0)
            {
                photo_index = photos.Count() - 1;
            }

            System.IO.FileStream fs = System.IO.File.OpenRead(photos.ElementAt(photo_index).File.FilePath);
            Image img = Image.FromStream(fs, false, false);
            pictureBoxSelectedPhotos.Image = img;
        }


        private void SlideShowForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.StopMusic();
        }

        private void ButtonSearchMusicFileClick(object sender, EventArgs e)
        {
            // ダイアログを開く
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Filter = "(*.wav) | *.wav";

            //ダイアログで決定ボタンを選択される
            if (ofd.ShowDialog(this) == DialogResult.OK)
            {
                // ラベルに音楽ファイルパスを表示
                labelShowMusicFilePath.Text = Path.GetFileName(ofd.FileName);

                // パスを格納
                musicFile = ofd.FileName;

                // 再生する
                checkBoxPlayMusic.Enabled = true;
                checkBoxPlayMusic.Checked = true;
                checkBoxAutoSlideShow.Checked = true;
                PlayMusic();
            }
        }


    }
}
