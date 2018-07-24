using System.Collections.Generic;
using System.Linq;
using PhotoFrame.Domain.Model;

namespace PhotoFrame.Domain.UseCase
{
    public class SortList
    {
        public SortList() { }

        /// <summary>
        /// ソート実行
        /// </summary>
        /// <param name="photoList"></param>
        /// <param name="sortMethod"0,1,2></param>
        /// <returns></returns>
        public IEnumerable<Photo> Execute(IEnumerable<Photo> photoList, int sortMethod)
        {
            if (sortMethod == 0)
            {
                return photoList;
            }
            else if (sortMethod == 1)
            {
                return photoList.OrderBy(photo => photo.DateTime);
            }
            else if (sortMethod == 2)
            {
                return photoList.OrderByDescending(photo => photo.DateTime);
            }
            else
            {
                return null;
            }
        }
    }
}
