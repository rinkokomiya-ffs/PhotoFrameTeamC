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
        private readonly IPhotoRepository photoRepository;
        private readonly IPhotoFileService photoFileService;

        public SearchFolder(IPhotoRepository photoRepository, IPhotoFileService photoFileService)
        {
            this.photoRepository = photoRepository;
            this.photoFileService = photoFileService;
        }

        /// <summary>
        /// 指定したディレクトリ直下のフォトのリストを返す
        /// </summary>
        /// <param name="directoryName"></param>
        /// <returns></returns>
        public IEnumerable<Photo> Execute(string directoryName)
        {
            var files = photoFileService.FindAllPhotoFilesFromDirectory(directoryName);
            var photosInDirectory = new List<Photo>();

            foreach (var file in files)
            {
                Func<IQueryable<Photo>, Photo> query = allPhotos => allPhotos.SingleOrDefault(a => a.File.FilePath == file.FilePath);
               
                var hitPhoto = photoRepository.Find(query);

                if (hitPhoto != null)
                {
                    photosInDirectory.Add(hitPhoto);
                }
                else
                {
                    Photo photo = Photo.CreateFromFile(file, GetDateTime(file.FilePath));
                    photosInDirectory.Add(photo);
                    photoRepository.Store(photo);


                }
            }

            return photosInDirectory;
        }

        /// <summary>
        /// 撮影日取得
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        private DateTime GetDateTime(string filePath)
        {
            //読み込む
            Bitmap bmp = new System.Drawing.Bitmap(filePath);
            //Exif情報を列挙する
            var exifItem = bmp.PropertyItems.SingleOrDefault(item => item.Id == 0x9003 && item.Type == 2);
            if(exifItem != null)
            {
                //文字列に変換する
                string val = Encoding.ASCII.GetString(exifItem.Value);
                val = val.Trim(new char[] {'\0'});
                //DateTimeに変換
                DateTime date = DateTime.ParseExact(val, "yyyy:MM:dd HH:mm:ss", null);
                return date;
            }
            else
            {
                // 作成日時を取得する
                DateTime date = System.IO.File.GetCreationTime(filePath);
                return date;
            }
           
                
        }

        /// <summary>
        /// 非同期処理
        /// </summary>
        /// <param name="directoryName"></param>
        /// <returns></returns>
        //public async Task<IEnumerable<Photo>> ExecuteAsync(string directoryName)
        //{
        //    var files = photoFileService.FindAllPhotoFilesFromDirectory(directoryName);
        //    var photosInDirectory = await Task.Run(() =>
        //    {
        //        var photosList = new List<Photo>();
        //        foreach (var file in files)
        //        {
        //            Func<IQueryable<Photo>, Photo> query = allPhotos => allPhotos.FirstOrDefault(a => a.File.FilePath == file.FilePath);

        //            var hitPhoto = photoRepository.Find(query);

        //            if (hitPhoto != null)
        //            {
        //                photosList.Add(hitPhoto);
        //            }
        //            else
        //            {
        //                photosList.Add(Photo.CreateFromFile(file));
        //            }
        //        }

        //        return photosList;
        //    });
            
        //    return photosInDirectory;
        //}
    }
}
