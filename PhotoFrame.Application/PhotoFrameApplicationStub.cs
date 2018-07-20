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

            var photo = new Photo("f7e5586d-9c75-435c-a462-59fd3d50a154", new File("Chrysanthemum.jpg"), new DateTime(1993, 05, 15, 15, 00, 00));
            var photo2 = new Photo("f26ddb0b-3718-47f0-984e-8c99872c3077", new File("test.jpeg"), new DateTime(1993, 06, 15, 15, 00, 00));
            dummyPhotoList.Add(photo);
            dummyPhotoList.Add(photo2);


            var keyword1 = new Keyword("f7e5586d-9c75-435c-a462-59fd3d50a154", "Keyword");
            var keyword2 = new Keyword("f26ddb0b-3718-47f0-984e-8c99872c3077", "Keyword2");
            //var keyword3 = new Keyword("f7e5586d-9c75-435c-a462-59fd3d50a154", "Keyword");
            //var keyword4 = new Keyword("f26ddb0b-3718-47f0-984e-8c99872c3077", "Keyword2");
            //var keyword5 = new Keyword("f7e5586d-9c75-435c-a462-59fd3d50a154", "Keyword");
            //var keyword6 = new Keyword("f26ddb0b-3718-47f0-984e-8c99872c3077", "Keyword2");
            //var keyword7 = new Keyword("f7e5586d-9c75-435c-a462-59fd3d50a154", "Keyword");
            //var keyword8 = new Keyword("f26ddb0b-3718-47f0-984e-8c99872c3077", "Keyword2");
            //var keyword9 = new Keyword("f7e5586d-9c75-435c-a462-59fd3d50a154", "Keyword");
            //var keyword10 = new Keyword("f7e5586d-9c75-435c-a462-59fd3d50a154", "Keyword");
            //var keyword11 = new Keyword("f7e5586d-9c75-435c-a462-59fd3d50a154", "Keyword");
            //var keyword12 = new Keyword("f7e5586d-9c75-435c-a462-59fd3d50a154", "Keyword");
            //var keyword13 = new Keyword("f7e5586d-9c75-435c-a462-59fd3d50a154", "Keyword");
            //var keyword14 = new Keyword("f7e5586d-9c75-435c-a462-59fd3d50a154", "Keyword");
            //var keyword15 = new Keyword("f7e5586d-9c75-435c-a462-59fd3d50a154", "Keyword");
            //var keyword16 = new Keyword("f7e5586d-9c75-435c-a462-59fd3d50a154", "Keyword");
            //var keyword17 = new Keyword("f7e5586d-9c75-435c-a462-59fd3d50a154", "Keyword");
            //var keyword18 = new Keyword("f7e5586d-9c75-435c-a462-59fd3d50a154", "Keyword");
            //var keyword19 = new Keyword("f26ddb0b-3718-47f0-984e-8c99872c3077", "Keyword2");
            //var keyword20 = new Keyword("f26ddb0b-3718-47f0-984e-8c99872c3077", "Keyword2");
            //var keyword21 = new Keyword("f26ddb0b-3718-47f0-984e-8c99872c3077", "Keyword2");
            //var keyword22 = new Keyword("f26ddb0b-3718-47f0-984e-8c99872c3077", "Keyword2");
            //var keyword23 = new Keyword("f26ddb0b-3718-47f0-984e-8c99872c3077", "Keyword2");
            //var keyword24 = new Keyword("f26ddb0b-3718-47f0-984e-8c99872c3077", "Keyword2");
            //var keyword25 = new Keyword("f26ddb0b-3718-47f0-984e-8c99872c3077", "Keyword2");
            //var keyword26 = new Keyword("f26ddb0b-3718-47f0-984e-8c99872c3077", "Keyword2");
            //var keyword27 = new Keyword("f26ddb0b-3718-47f0-984e-8c99872c3077", "Keyword2");
            //var keyword28 = new Keyword("f26ddb0b-3718-47f0-984e-8c99872c3077", "Keyword2");
            //var keyword29 = new Keyword("f26ddb0b-3718-47f0-984e-8c99872c3077", "Keyword2");
            //var keyword30 = new Keyword("f26ddb0b-3718-47f0-984e-8c99872c3077", "Keyword2");
            //var keyword31 = new Keyword("f7e5586d-9c75-435c-a462-59fd3d50a154", "Keyword");
            //var keyword32 = new Keyword("f7e5586d-9c75-435c-a462-59fd3d50a154", "Keyword");
            //var keyword33 = new Keyword("f7e5586d-9c75-435c-a462-59fd3d50a154", "Keyword");
            //var keyword34 = new Keyword("f7e5586d-9c75-435c-a462-59fd3d50a154", "Keyword");
            //var keyword35 = new Keyword("f7e5586d-9c75-435c-a462-59fd3d50a154", "Keyword");
            //var keyword36 = new Keyword("f7e5586d-9c75-435c-a462-59fd3d50a154", "Keyword");
            //var keyword37 = new Keyword("f7e5586d-9c75-435c-a462-59fd3d50a154", "Keyword");
            //var keyword38 = new Keyword("f7e5586d-9c75-435c-a462-59fd3d50a154", "Keyword");
            //var keyword39 = new Keyword("f26ddb0b-3718-47f0-984e-8c99872c3077", "Keyword2");
            //var keyword40 = new Keyword("f26ddb0b-3718-47f0-984e-8c99872c3077", "Keyword2");
            //var keyword41 = new Keyword("f26ddb0b-3718-47f0-984e-8c99872c3077", "Keyword2");
            //var keyword42 = new Keyword("f26ddb0b-3718-47f0-984e-8c99872c3077", "Keyword2");
            //var keyword43 = new Keyword("f26ddb0b-3718-47f0-984e-8c99872c3077", "Keyword2");
            //var keyword44 = new Keyword("f26ddb0b-3718-47f0-984e-8c99872c3077", "Keyword2");
            //var keyword45 = new Keyword("f26ddb0b-3718-47f0-984e-8c99872c3077", "Keyword2");
            //var keyword46 = new Keyword("f26ddb0b-3718-47f0-984e-8c99872c3077", "Keyword2");
            //var keyword47 = new Keyword("f26ddb0b-3718-47f0-984e-8c99872c3077", "Keyword2");
            //var keyword48 = new Keyword("f26ddb0b-3718-47f0-984e-8c99872c3077", "Keyword2");
            //var keyword49 = new Keyword("f26ddb0b-3718-47f0-984e-8c99872c3077", "Keyword2");


            dummyKeywordList.Add(keyword1);
            dummyKeywordList.Add(keyword2);
            //dummyKeywordList.Add(keyword3);
            //dummyKeywordList.Add(keyword4);
            //dummyKeywordList.Add(keyword5);
            //dummyKeywordList.Add(keyword6);
            //dummyKeywordList.Add(keyword7);
            //dummyKeywordList.Add(keyword8);
            //dummyKeywordList.Add(keyword9);
            //dummyKeywordList.Add(keyword10);
            //dummyKeywordList.Add(keyword11);
            //dummyKeywordList.Add(keyword12);
            //dummyKeywordList.Add(keyword13);
            //dummyKeywordList.Add(keyword14);
            //dummyKeywordList.Add(keyword15);
            //dummyKeywordList.Add(keyword16);
            //dummyKeywordList.Add(keyword17);
            //dummyKeywordList.Add(keyword18);
            //dummyKeywordList.Add(keyword19);
            //dummyKeywordList.Add(keyword20);
            //dummyKeywordList.Add(keyword21);
            //dummyKeywordList.Add(keyword22);
            //dummyKeywordList.Add(keyword23);
            //dummyKeywordList.Add(keyword24);
            //dummyKeywordList.Add(keyword25);
            //dummyKeywordList.Add(keyword26);
            //dummyKeywordList.Add(keyword27);
            //dummyKeywordList.Add(keyword28);
            //dummyKeywordList.Add(keyword29);
            //dummyKeywordList.Add(keyword30);
            //dummyKeywordList.Add(keyword31);
            //dummyKeywordList.Add(keyword32);
            //dummyKeywordList.Add(keyword33);
            //dummyKeywordList.Add(keyword34);
            //dummyKeywordList.Add(keyword35);
            //dummyKeywordList.Add(keyword36);
            //dummyKeywordList.Add(keyword37);
            //dummyKeywordList.Add(keyword38);
            //dummyKeywordList.Add(keyword39);
            //dummyKeywordList.Add(keyword40);
            //dummyKeywordList.Add(keyword41);
            //dummyKeywordList.Add(keyword42);
            //dummyKeywordList.Add(keyword43);
            //dummyKeywordList.Add(keyword44);
            //dummyKeywordList.Add(keyword45);
            //dummyKeywordList.Add(keyword46);
            //dummyKeywordList.Add(keyword47);
            //dummyKeywordList.Add(keyword48);
            //dummyKeywordList.Add(keyword49);
        }

        public int RegistKeyword(string keyword)
        {
            Console.WriteLine("Application.RegistKeywordは呼び出されました");

            var keyword_test = keyword;
            if(keyword_test == "Keyword")
            {
                return 1;
            }
            else if(keyword_test == "Keyword2")
            {
                return 1;
            }
            else
            {
                dummyKeywordList.Add(Keyword.Create(keyword));
                return 0;

            }
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
            var photo3 = new Photo("f7e5586d-9c75-435c-a462-59fd3d50a154", new File("Chrysanthemum.jpg"), new DateTime(1993, 05, 15, 15, 00, 00), true);

            return photo3;
        }

        public Photo ChangeKeyword(Photo photo, string keyword)
        {
            var keyword_test = keyword;
            Keyword keywords = Keyword.Create(keyword);
            var photo3 = new Photo("f7e5586d-9c75-435c-a462-59fd3d50a154", new File("Chrysanthemum.jpg"), new DateTime(1993, 05, 15, 15, 00, 00),false, keywords.Id, keywords);

            Console.WriteLine("Application.ChangeKeywordは呼び出されました");
            return photo3;
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
            //return null;
        }
    }
}
