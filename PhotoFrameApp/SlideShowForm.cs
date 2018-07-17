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

        private CancellationTokenSource tokenSource;
        private CancellationToken cancelToken;
        private SoundPlayer player = null;
        private string musicFile = "music.mp3";

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
                pictureBox_SelectedPhotos.ImageLocation = photos.ElementAt(photo_index).File.FilePath;
                timer_ChangePhoto.Interval = 3000;

                if (checkBox_AutoPlay.Checked)
                {
                    timer_ChangePhoto.Start();
                }

                if (checkBox_MusicPlay.Checked)
                {
                    // 音楽再生メソッドを呼び出す
                    PlayMusic();
                }

                timer_CloseForm.Interval = 600000;//Form画面終了時間　10分
                timer_CloseForm.Start();
            }
        }

        /// <summary>
        /// 音楽再生チェックボックス制御
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckPlayMusic(object sender, EventArgs e)
        {
            if (checkBox_MusicPlay.Checked)
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
            //再生されているときは止める
            if (player != null)
                StopMusic();

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

            pictureBox_SelectedPhotos.ImageLocation = photos.ElementAt(photo_index).File.FilePath;
        }

        /// <summary>
        /// 自動再生のON/OFF切り替え
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckAutoSlideShow(object sender, EventArgs e)
        {
            if (checkBox_AutoPlay.Checked)
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
            checkBox_AutoPlay.Checked = false;
            timer_ChangePhoto.Stop();

            photo_index++;

            if (photo_index >= photos.Count())
            {
                photo_index = 0;
            }

            pictureBox_SelectedPhotos.ImageLocation = photos.ElementAt(photo_index).File.FilePath;
        }

        /// <summary>
        /// 一つ前の画像に戻す(自動再生OFF)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonBackClick(object sender, EventArgs e)
        {
            checkBox_AutoPlay.Checked = false;
            timer_ChangePhoto.Stop();

            photo_index--;

            if (photo_index < 0)
            {
                photo_index = photos.Count() - 1;
            }

            pictureBox_SelectedPhotos.ImageLocation = photos.ElementAt(photo_index).File.FilePath;
        }

        // Form画面の終了
        private void TimerCloseFormTick(object sender, EventArgs e)
        {
            timer_CloseForm.Stop();
            this.Close();
        }
    }
}
