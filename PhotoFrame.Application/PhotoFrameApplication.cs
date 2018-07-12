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
        private readonly CreateKeyword createAlbum;
        private readonly SearchAlbums searchAlbum;
        private readonly SearchDirectory searchDirectory;
        private readonly ToggleFavorite toggleFavorite;
        private readonly ChangeKeyword changeAlbum;

        public PhotoFrameApplication(IKeywordRepository albumRepository, IPhotoRepository photoRepository, IPhotoFileService photoFileService)
        {
            this.createAlbum = new CreateKeyword(albumRepository);
            this.searchAlbum = new SearchAlbums(photoRepository);
            this.searchDirectory = new SearchDirectory(photoRepository, photoFileService);
            this.toggleFavorite = new ToggleFavorite(photoRepository);
            this.changeAlbum = new ChangeKeyword(albumRepository, photoRepository);
        }

        public int CreateAlbum(string albumName)
        {
            return createAlbum.Execute(albumName);
        }

        public IEnumerable<Photo> SearchAlbum(string albumName)
        {
            return searchAlbum.Execute(albumName);
        }

        public IEnumerable<Photo> SearchDirectory(string directoryName)
        {
            return searchDirectory.Execute(directoryName);
        }

        public Photo ToggleFavorite(Photo photo)
        {
            return toggleFavorite.Execute(photo);
        }
     
        public Photo ChangeAlbum(Photo photo, string newAlbumName)
        {
            return changeAlbum.Execute(photo, newAlbumName);
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
