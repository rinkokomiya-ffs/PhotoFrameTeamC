using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoFrame.Domain.Model;

namespace PhotoFrame.Domain.UseCase
{
    public class SearchAlbums
    {

        private readonly IPhotoRepository photoRepository;

        public SearchAlbums(IPhotoRepository repository)
        {
            this.photoRepository = repository;
        }

        /// <summary>
        /// 指定した名前のアルバムに属するフォトのリストを返す
        /// </summary>
        /// <param name="albumName"></param>
        /// <returns></returns>
        public IEnumerable<Photo> Execute(string albumName)
        {
            return photoRepository.Find(photos => (from p in photos where p.Album.Name == albumName select p).ToList().AsQueryable());
        }

        /// <summary>
        /// 非同期処理用
        /// </summary>
        /// <param name="albumName"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Photo>> ExecuteAsync(string albumName)
        {
            var searchedPhotos = await Task.Run(() =>
            {
                // アルバムが割り当てられていない写真とアルバム名が一致していない写真を取り除く
                return photoRepository.Find(photos => photos.Where(p => p.Album != null && p.Album.Name == albumName));

            });

            return searchedPhotos.AsEnumerable();
        }
    }
}
