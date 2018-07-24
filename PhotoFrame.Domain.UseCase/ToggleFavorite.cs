using PhotoFrame.Domain.Model;

namespace PhotoFrame.Domain.UseCase
{
    public class ToggleFavorite
    {
        private readonly IPhotoRepository _photoRepository;

        public ToggleFavorite(IPhotoRepository photoRepository)
        {
            _photoRepository = photoRepository;
        }

        /// <summary>
        /// 引数で渡したフォトのお気に入りON/OFFを切り替えて返す
        /// ※参照渡しなので返り値を保存しなくても書き換わる
        /// </summary>
        /// <param name="photo"></param>
        /// <returns></returns>
        public Photo Execute(Photo photo)
        {
            if (photo.IsFavorite)
            {
                photo.MarkAsUnFavorite();
            }
            else
            {
                photo.MarkAsFavorite();
            }

            _photoRepository.Store(photo);

            return photo;
        }
    }
}
