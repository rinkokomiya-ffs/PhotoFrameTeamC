using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoFrame.Domain.Model;

namespace PhotoFrame.Domain.UseCase
{
    class SortList
    {

        public SortList()
        {

        }

        /// <summary>
        /// ソート実行
        /// </summary>
        /// <param name="photoList"></param>
        /// <param name="searchMethod"0,1,2></param>
        /// <returns></returns>
        public IEnumerable<Photo> Execute(IEnumerable<Photo> photoList, int searchMethod)
        {
            
            if (searchMethod == 0)
            {
                return photoList;
            }
            else if (searchMethod == 1)
            {
                return photoList.OrderBy(photo => photo.DateTime);
            }
            else if (searchMethod == 2)
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
