using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoFrame.Domain.Model;

namespace PhotoFrame.Domain.UseCase
{
    public class ChangeKeyword
    {

        private readonly IKeywordRepository keywordRepository;
        private readonly IPhotoRepository photoRepository;

        public ChangeKeyword(IKeywordRepository keywordRepository, IPhotoRepository photoRepository)
        {
            this.keywordRepository = keywordRepository;
            this.photoRepository = photoRepository;
        }

        /// <summary>
        /// 引数のフォトの所属アルバムを変更する
        /// ※参照渡しなので返り値を保存しなくても書き換わる
        /// </summary>
        /// <param name="photo"></param>
        /// <param name="newAlbumName"></param>
        /// <returns></returns>
        public Photo Execute(Photo photo, string keywordName)
        {
           
            Func<IQueryable<Keyword>, Keyword> query = allKeywords => allKeywords.FirstOrDefault(keyword => keyword.Name == keywordName);

            var result = keywordRepository.Find(query);
            if (result != null)
            {
                photo.IsAssignedTo(result);
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
        //public async Task<Photo> ExecuteAsync(Photo photo, string newAlbumName)
        //{
        //    Func<IQueryable<Keyword>, Keyword> query = allAlbums => allAlbums.FirstOrDefault(a => a.Name == newAlbumName);

        //    var newAlbum = keywordRepository.Find(query);

        //    if (newAlbum != null)
        //    {
        //        photo.IsAssignedTo(newAlbum);
        //    }

        //    await Task.Run(() =>
        //    {
        //        photoRepository.Store(photo);
        //    });

        //    return photo;
        //}
    }
}
