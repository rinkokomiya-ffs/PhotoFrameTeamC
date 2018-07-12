using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoFrame.Domain.Model
{
    public class Photo : IEntity
    {
        public string Id { get; private set; }

        /// <summary>
        /// ファイル実体
        /// </summary>
        public File File { get; private set; }

        /// <summary>
        /// お気に入りかどうか
        /// </summary>
        public bool IsFavorite { get; private set; }

        /// <summary>
        /// 所属アルバム
        /// </summary>
        public virtual Keyword Keyword { get; private set; }

        /// <summary>
        /// 所属アルバムID
        /// </summary>
        public string KeywordId { get; set; }

        /// <summary>
        /// 撮影日
        /// </summary>
        public DateTime DateTime { get; set; }

        public Photo(string photoId, File file, DateTime date, bool isFavorite = false, string keywordId = null, Keyword keyword= null)
        {
            Id = photoId;
            File = file;
            DateTime = date;
            IsFavorite = isFavorite;
            KeywordId = keywordId;
            Keyword = keyword;
        }

        public static Photo CreateFromFile(File file, DateTime data)
        {
            if (!file.IsPhoto)
            {
                throw new ArgumentException("The specified file is not a photo.");
            }
            return new Photo(Guid.NewGuid().ToString(), file, data);
        }

        private Photo() { }

        public void IsAssignedTo(Keyword keyword)
        {
            Keyword = keyword;
            KeywordId = keyword.Id;
        }

        public void MarkAsFavorite()
        {
            IsFavorite = true;
        }

        public void MarkAsUnFavorite()
        {
            IsFavorite = false;
        }

        public override bool Equals(object obj)
        {
            if ((object)this == obj) return true;
            if (obj == null || GetType() != obj.GetType()) return false;
            return Id == ((Photo)obj).Id;
        }

        public override int GetHashCode() => Id.GetHashCode();

        public static bool operator ==(Photo photo1, Photo photo2)
        {
            if (ReferenceEquals(photo1, photo2)) return true;
            if ((object)photo1 == null || (object)photo2 == null) return false;
            return photo1.Equals(photo2);
        }

        public static bool operator !=(Photo photo1, Photo photo2) => !(photo1 == photo2);
    }
}
