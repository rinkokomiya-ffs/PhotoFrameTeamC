using PhotoFrame.Domain.Model;
using PhotoFrame.Domain.UseCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoFrame.Application
{
    /// <summary>
    /// PhotoFrameのUIの指示にしたがってドメインのユースケースを起動する
    /// </summary>
    // TODO: 仮実装
    public class PhotoFrameApplication
    {
        // ユースケースのインスタンス
        private readonly RegistKeyword registKeyword;
        private readonly DetailSearch detailSearch;
        private readonly SearchFolder searchFolder;
        private readonly ToggleFavorite toggleFavorite;
        private readonly ChangeKeyword changeKeyword;
        private readonly GetKeywordList getKeywordList;

        public PhotoFrameApplication(IKeywordRepository albumRepository, IPhotoRepository photoRepository, IPhotoFileService photoFileService)
        {
            this.registKeyword = new RegistKeyword(albumRepository);
            this.detailSearch = new DetailSearch(photoRepository);
            this.searchFolder = new SearchFolder(photoRepository, photoFileService);
            this.toggleFavorite = new ToggleFavorite(photoRepository);
            this.changeKeyword = new ChangeKeyword(albumRepository, photoRepository);
        }

        public int RegistKeyword(string keyword)
        {
            return registKeyword.Execute(keyword);
        }

        public IEnumerable<Photo> DetailSearch(IEnumerable<Photo> photoList, string keyword, string isFavorite, DateTime firstData, DateTime lastData)
        {
            return detailSearch.Execute(photoList, keyword, isFavorite, firstData, lastData);
        }

        public IEnumerable<Photo> SearchFolder(string directoryName)
        {
            return searchFolder.Execute(directoryName);
        }

        public Photo ToggleFavorite(Photo photo)
        {
            return toggleFavorite.Execute(photo);
        }
     
        public Photo ChangeKeyword(Photo photo, string keyword)
        {
            return changeKeyword.Execute(photo, keyword);
        }

        public IEnumerable<Keyword> GetKeyword()
        {
            return getKeywordList.Execute();
        }

        // ここより下は非同期用のユースケースの呼び出しメソッド
        //public async Task<int> CreateAlbumAsync(string albumName)
        //{
        //    var judgement = await createAlbum.ExecuteAsync(albumName);
        //    return judgement;
        //}

        //public async Task<IEnumerable<Photo>> SearchDirectoryAsync(string directoryName)
        //{ 
        //    var retPhotos = await searchDirectory.ExecuteAsync(directoryName);
        //    return retPhotos;
        //}

        //public async Task<IEnumerable<Photo>> SearchAlbumAsync(string albumName)
        //{
        //    var retPhotos = await searchAlbum.ExecuteAsync(albumName);
        //    return retPhotos;
        //}

        //public async Task<Photo> ToggleFavoriteAsync(Photo photo)
        //{
        //    var retPhoto = await toggleFavorite.ExecuteAsync(photo);
        //    return retPhoto;
        //}

        //public async Task<Photo> ChangeAlbumAsync(Photo photo, string newAlbumName)
        //{
        //    var retPhoto = await changeAlbum.ExecuteAsync(photo, newAlbumName);
        //    return retPhoto;

        //}
    }
}
