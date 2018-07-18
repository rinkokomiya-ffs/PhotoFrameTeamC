using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoFrame.Domain.Model;


namespace PhotoFrame.Application
{
    public class PhotoFrameApplicationStub
    {
        // ダミー用のフィールド
        public List<Photo> dummyPhotoList { set; get; }
        public List<Keyword> dummyKeywordList { set; get; }

        public PhotoFrameApplicationStub(IKeywordRepository keywordRepository, IPhotoRepository photoRepository, IPhotoFileService photoFileService)
        {
            // ダミーに格納する
            dummyPhotoList = new List<Photo>();
            dummyKeywordList = new List<Keyword>();

            var photo = new Photo("f7e5586d-9c75-435c-a462-59fd3d50a154", new File("dummy.bmp"), new DateTime(1993, 05, 15, 15, 00, 00));
            var photo2 = new Photo("f26ddb0b-3718-47f0-984e-8c99872c3077", new File("dummy2.bmp"), new DateTime(1993, 05, 15, 15, 00, 00));
            dummyPhotoList.Add(photo);
            dummyPhotoList.Add(photo2);

            var keyword = new Keyword("f7e5586d-9c75-435c-a462-59fd3d50a154", "Keyword");
            var keyword2 = new Keyword("f26ddb0b-3718-47f0-984e-8c99872c3077", "Keyword2");
            dummyKeywordList.Add(keyword);
            dummyKeywordList.Add(keyword2);
        }

        public int RegistKeyword(string keyword)
        {
            var keyword_test = keyword;
            Console.WriteLine("Application.RegistKeywordは呼び出されました");
            return 0;
        }

        public IEnumerable<Photo> DetailSearch(IEnumerable<Photo> photoList, string keyword, string isFavorite, DateTime? firstData, DateTime? lastData)
        {
            var keyword_test = keyword;
            var isFavorite_test = isFavorite;
            var firstDate_test = firstData;
            var lastDate_test = lastData;
            Console.WriteLine("Application.DetailSearchは呼び出されました");
            return photoList;
        }

        public IEnumerable<Photo> SearchFolder(string directoryName)
        {
            var directoryName_test = directoryName;
            Console.WriteLine("Application.SearchFolderは呼び出されました");
            return dummyPhotoList;
        }

        public Photo ToggleFavorite(Photo photo)
        {
            Console.WriteLine("Application.ToggleFavoriteは呼び出されました");
            return photo;
        }

        public Photo ChangeKeyword(Photo photo, string keyword)
        {
            var keyword_test = keyword;

            Console.WriteLine("Application.ChangeKeywordは呼び出されました");
            return photo;
        }

        public IEnumerable<Photo> SortList(IEnumerable<Photo> photoList, int sortMethod)
        {
            var sortMethod_test = sortMethod;
            Console.WriteLine("Application.SortListは呼び出されました");
            return photoList;
        }

        public IEnumerable<Keyword> GetKeywordList()
        {
            Console.WriteLine("Application.GetKeywordListは呼び出されました");
            return dummyKeywordList;
        }
    }
}
