﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoFrame.Domain.Model;
using PhotoFrame.Application;

namespace PhotoFrameApp
{
    public class Controller
    {
        // アプリケーションのインスタンス
        private readonly PhotoFrameApplication application;

        private IPhotoRepository photoRepository;
        private IKeywordRepository albumRepository;
        private IPhotoFileService photoFileService;

        public Controller(IKeywordRepository keywordRepository, IPhotoRepository photoRepository, IPhotoFileService photoFileService)
        {
            this.application = new PhotoFrameApplication(keywordRepository, photoRepository, photoFileService);
        }

        public int ExecuteRegistKeyword(string keyword)
        {
            return application.RegistKeyword(keyword);
        }

        public IEnumerable<Photo> ExecuteSearchFolder(string folderPath)
        {
            return application.SearchFolder(folderPath);
        }

        public IEnumerable<Photo> SearchDirectory(string directoryName)
        {
            return searchDirectory.Execute(directoryName);
        }

        public Photo ToggleFavorite(Photo photo)
        {
            return toggleFavorite.Execute(photo);
        }

        public Photo ExecuteChangeKeyword(Photo photo, string newAlbumName)
        {
            return application.ChangeKeyword(photo, newAlbumName);
        }

        // ここより下は非同期用のユースケースの呼び出しメソッド
        public async Task<int> CreateAlbumAsync(string albumName)
        {
            var judgement = await createAlbum.ExecuteAsync(albumName);
            return judgement;
        }

        public async Task<IEnumerable<Photo>> SearchDirectoryAsync(string directoryName)
        {
            var retPhotos = await searchDirectory.ExecuteAsync(directoryName);
            return retPhotos;
        }

        public async Task<IEnumerable<Photo>> SearchAlbumAsync(string albumName)
        {
            var retPhotos = await searchAlbum.ExecuteAsync(albumName);
            return retPhotos;
        }

        public async Task<Photo> ToggleFavoriteAsync(Photo photo)
        {
            var retPhoto = await toggleFavorite.ExecuteAsync(photo);
            return retPhoto;
        }

        public async Task<Photo> ChangeAlbumAsync(Photo photo, string newAlbumName)
        {
            var retPhoto = await changeAlbum.ExecuteAsync(photo, newAlbumName);
            return retPhoto;

        }
    }
}
