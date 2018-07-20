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

        private readonly IKeywordRepository _keywordRepository;
        private readonly IPhotoRepository _photoRepository;

        public ChangeKeyword(IKeywordRepository keywordRepository, IPhotoRepository photoRepository)
        {
            _keywordRepository = keywordRepository;
            _photoRepository = photoRepository;
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

            if(keywordName == "設定解除")
            {
                photo.IsAssignedTo(null);
                _photoRepository.Store(photo);
            }
            else
            {
                var result = _keywordRepository.Find(keywords => keywords.SingleOrDefault(keyword => keyword.Name == keywordName));
                if (result != null)
                {
                    photo.IsAssignedTo(result);
                    _photoRepository.Store(photo);
                }
            }
           
            return photo;
        }

    }
}
