using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoFrame.Domain.Model;

namespace PhotoFrame.Domain.UseCase
{
    public class ChangeAlbum
    {

        private readonly IAlbumRepository albumRepository;
        private readonly IPhotoRepository photoRepository;

        public ChangeAlbum(IAlbumRepository albumRepository, IPhotoRepository photoRepository)
        {
            this.albumRepository = albumRepository;
            this.photoRepository = photoRepository;
        }

        /// <summary>
        /// 引数のフォトの所属アルバムを変更する
        /// ※参照渡しなので返り値を保存しなくても書き換わる
        /// </summary>
        /// <param name="photo"></param>
        /// <param name="newAlbumName"></param>
        /// <returns></returns>
        public Photo Execute(Photo photo, string newAlbumName)
        {
           
            Func<IQueryable<Album>, Album> query = allAlbums => allAlbums.FirstOrDefault(a => a.Name == newAlbumName);

            // 毎回Findを呼び出すのは非効率
            // Find・Storeメソッド自体に見直しも必要
            var newAlbum = albumRepository.Find(query);

            if (newAlbum != null)
            {
                photo.IsAssignedTo(newAlbum);
            }

            photoRepository.Store(photo);
           
            return photo;
        }

        /// <summary>
        /// 非同期用Excute()
        /// </summary>
        /// <param name="photo"></param>
        /// <param name="newAlbumName"></param>
        /// <returns></returns>
        public async Task<Photo> ExecuteAsync(Photo photo, string newAlbumName)
        {
            Func<IQueryable<Album>, Album> query = allAlbums => allAlbums.FirstOrDefault(a => a.Name == newAlbumName);

            var newAlbum = albumRepository.Find(query);

            if (newAlbum != null)
            {
                photo.IsAssignedTo(newAlbum);
            }

            await Task.Run(() =>
            {
                photoRepository.Store(photo);
            });

            return photo;
        }
    }
}
