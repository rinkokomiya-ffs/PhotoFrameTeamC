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
                var c = new Comparison<Photo>(Compare);
                photoList.ToList().Sort(Compare);
                return photoList.AsEnumerable();
            }
            else if (searchMethod == 2)
            {
                return photoList.AsEnumerable();
            }
            else
            {
                return null;
            }
        }

        private int Compare(Photo photo1, Photo photo2)
        {
            if (photo1.DateTime < photo2.DateTime)
            {
                return -1;
            }
            else
            {
                return 1;
            }
        }
    }
}
