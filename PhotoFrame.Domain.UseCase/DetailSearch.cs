using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoFrame.Domain.Model;

namespace PhotoFrame.Domain.UseCase
{
    public class DetailSearch
    {
        public DetailSearch(){}

        /// <summary>
        /// 指定した名前のアルバムに属するフォトのリストを返す
        /// </summary>
        /// <param name="albumName"></param>
        /// <returns></returns>
        public IEnumerable<Photo> Execute(IEnumerable<Photo> photoList, string keyword, string isFavorite, DateTime? firstData, DateTime? lastData)
        {
            if(keyword != null)
            {
                photoList = photoList.Where(photo => photo.Keyword != null && photo.Keyword.Name == keyword);
            }

            if(isFavorite != null)
            {
                photoList = photoList.Where(photo => photo.IsFavorite == Convert.ToBoolean(isFavorite));
            }

            if(firstData != null && lastData != null)
            {
                photoList = photoList.Where(photo => photo.DateTime >= firstData && photo.DateTime <= lastData);
            }
            return photoList;
        }

    }
}
