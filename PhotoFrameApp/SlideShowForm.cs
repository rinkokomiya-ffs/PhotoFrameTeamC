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
using Microsoft.SmallBasic.Library;

namespace PhotoFrameApp
{
    public partial class SlideShowForm : Form
    {
        IEnumerable<Photo> photos;
        int photo_index;

        public SlideShowForm()
        {
            InitializeComponent();
            Environment.Exit(1);
        }

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
        private void SlideShow_Load(object sender, EventArgs e)
        {
            if(photos.Count() > 0)
            {
                pictureBox_SelectedPhotos.ImageLocation = photos.ElementAt(photo_index).File.FilePath;
                timer_ChangePhoto.Interval = 3000;
                if (checkBox_AutoPlay.Checked)
                {
                    timer_ChangePhoto.Start();
                }
            }

        }

        /// <summary>
        /// 一定時間ごとに画像を切り替え
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_ChangePhoto_Tick(object sender, EventArgs e)
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
        private void checkBox_AutoPlay_CheckedChanged(object sender, EventArgs e)
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


        /// <summary>
        /// 音楽再生
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckPlayMusic(object sender, EventArgs e)
        {
            if (checkBox_MusicPlay.Checked)
            {
                Microsoft.SmallBasic.Library.Sound.Play("Music.mp3");
            }
        }
    }
}
