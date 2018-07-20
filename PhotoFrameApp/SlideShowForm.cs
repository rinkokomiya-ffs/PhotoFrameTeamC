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
using PhotoFrame.Domain;
using PhotoFrame.Domain.Model;
using PhotoFrame.Domain.UseCase;
using PhotoFrame.Persistence;
using PhotoFrame.Persistence.Csv;
using System.Media;
using System.Threading;

namespace PhotoFrameApp
{
    public partial class SlideShowForm : Form
    {
        IEnumerable<Photo> photos;
        int photo_index;

        private SoundPlayer player = null;
        private string musicFile = "music.wav";

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="photos"></param>
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
            if(photos.Count() > 0)
            {
                System.IO.FileStream fs = System.IO.File.OpenRead(photos.ElementAt(photo_index).File.FilePath);
                Image img = Image.FromStream(fs, false, false); // 検証なし
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
            //非同期再生する
            //player.Play();
     
            //ループ再生される
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

            if(photo_index >= photos.Count())
            {
                photo_index = 0;
            }

            System.IO.FileStream fs = System.IO.File.OpenRead(photos.ElementAt(photo_index).File.FilePath);
            Image img = Image.FromStream(fs, true, true); // 検証なし
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
            Image img = Image.FromStream(fs, false, false); // 検証なし
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
            Image img = Image.FromStream(fs, false, false); // 検証なし
            pictureBoxSelectedPhotos.Image = img;
           
        }

       
        private void SlideShowForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.StopMusic();
        }
    }
}
