﻿using System;
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

                if (searchedPhoto != null)
                {
                    photosInFolder.Add(searchedPhoto);
                }
                else
                {
                    var photo = Photo.CreateFromFile(file, GetDateTime(file.FilePath));
                    photosInFolder.Add(photo);
                    _photoRepository.Store(photo);

                }
            }

            return photosInFolder;
        }

        /// <summary>
        /// 非同期処理
        /// </summary>
        /// <param name="directoryName"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Photo>> ExecuteAsync(string folderPath)
        {
            var files = _photoFileService.FindAllPhotoFilesFromDirectory(folderPath);
            var photosInFolder = new List<Photo>();

            if (files == null)
            {
                return null;
            }

            var photos = _photoRepository.Find(allPhoto => allPhoto);
            var photosInDirectory = await Task.Run(() =>
            {
                var photosList = new List<Photo>();
                foreach (var file in files)
                {
                    var searchedPhoto = photos.SingleOrDefault(photo => photo.File.FilePath == file.FilePath);

                    if (searchedPhoto != null)
                    {
                        photosInFolder.Add(searchedPhoto);
                    }
                    else
                    {
                        var photo = Photo.CreateFromFile(file, GetDateTime(file.FilePath));
                        photosInFolder.Add(photo);
                        _photoRepository.Store(photo);

                    }
                }

                return photosList;
            });

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
            System.IO.FileStream stream = System.IO.File.OpenRead(filePath);
            Image bmp = Image.FromStream(stream, false, false);
            //var bmp = new System.Drawing.Bitmap(filePath);
            //Exif情報を列挙する
            var exifItem = bmp.PropertyItems.SingleOrDefault(item => item.Id == 0x9003 && item.Type == 2);
            if(exifItem != null)
            {
                //文字列に変換する
                var val = Encoding.ASCII.GetString(exifItem.Value);
                val = val.Trim(new char[] {'\0'});
                //DateTimeに変換
                var date = DateTime.ParseExact(val, "yyyy:MM:dd HH:mm:ss", null);
                return date;
            }
            else
            {
                // 作成日時を取得する
                var date = System.IO.File.GetCreationTime(filePath);
                return date;
            }
                   
        }

    }
}
