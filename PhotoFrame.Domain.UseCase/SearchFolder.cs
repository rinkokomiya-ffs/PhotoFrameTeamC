using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using PhotoFrame.Domain.Model;

namespace PhotoFrame.Domain.UseCase
{
    public class SearchFolder
    {
        private readonly IPhotoRepository _photoRepository;
        private readonly IPhotoFileService _photoFileService;

        public SearchFolder(IPhotoRepository photoRepository, IPhotoFileService photoFileService)
        {
            _photoRepository = photoRepository;
            _photoFileService = photoFileService;
        }

        /// <summary>
        /// 指定したディレクトリ直下のフォトのリストを返す
        /// </summary>
        /// <param name="folderPath"></param>
        /// <returns></returns>
        public IEnumerable<Photo> Execute(string folderPath)
        {
            var files = _photoFileService.FindAllPhotoFilesFromDirectory(folderPath);
            var photosInFolder = new List<Photo>();

            if (files == null)
            {
                return null;
            }

            var photos = _photoRepository.Find(allPhoto => allPhoto);
            foreach (var file in files)
            {
                var searchedPhoto = photos.SingleOrDefault(photo => photo.File.FilePath == file.FilePath);
                var getDateTime = GetDateTime(file.FilePath);

                // 有効データでない場合(初期値と比較)
                if (getDateTime != null)
                {
                    // 既存のデータの場合
                    if (searchedPhoto != null)
                    {
                        photosInFolder.Add(searchedPhoto);
                    }
                    else
                    {
                        var dateTime = (DateTime)getDateTime;
                        var photo = Photo.CreateFromFile(file, dateTime);
                        photosInFolder.Add(photo);
                        _photoRepository.Store(photo);

                    }
                    
                }   
            }

            return photosInFolder;
        }

        /// <summary>
        /// 撮影日取得
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        private DateTime? GetDateTime(string filePath)
        {
            //読み込む

            var image = IsValidImage(filePath);
  
            // 有効データでない場合初期値を返す
            if(image == null)
            {
                return null;
            }

            //Exif情報を列挙する
            var exifItem = image.PropertyItems.SingleOrDefault(item => item.Id == 0x9003 && item.Type == 2);
            if(exifItem != null)
            {
                //文字列に変換する

                var dateString = Encoding.ASCII.GetString(exifItem.Value);
                dateString = dateString.Trim(new char[] {'\0'});

                //DateTimeに変換
                var date = DateTime.ParseExact(dateString, "yyyy:MM:dd HH:mm:ss", null);
                return date;
            }
            else
            {
                // 作成日時を取得する
                var date = System.IO.File.GetCreationTime(filePath);
                return date;
            }
                   
        }

        /// <summary>
        /// 有効データの抽出
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        private Image IsValidImage(string filePath)
        {
            try
            {
                System.IO.FileStream stream = System.IO.File.OpenRead(filePath);
                Image image = Image.FromStream(stream, false, false);
                return image;

            }
            catch
            { 
                return null;
            }
            
        }

    }
}
