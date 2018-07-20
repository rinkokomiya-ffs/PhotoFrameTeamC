using PhotoFrame.Application;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PhotoFrame.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoFrame.Domain.UseCase;
using PhotoFrame.Persistence.Repositories;
using PhotoFrame.Persistence;
using System.Globalization;
namespace PhotoFrame.Application.Tests
{
    [TestClass()]
    public class PhotoFrameApplicationTests
    {
        private static IPhotoRepository photoRepository;
        private static IKeywordRepository keywordRepository;
        private static IPhotoFileService photoFileService;
        private static PhotoFrameApplication photoFrameApplication;

        [TestInitialize]
        public void SetUp()
        {

            // リポジトリ生成
            ServiceFactory serviceFactory = new ServiceFactory();
            var repos = new RepositoryFactory(Persistence.Type.EF);
            photoRepository = repos.PhotoRepository;
            keywordRepository = repos.KeywordRepository;
            photoFileService = serviceFactory.PhotoFileService;

            photoFrameApplication = new PhotoFrameApplication(keywordRepository, photoRepository, photoFileService);

        }

        [TestMethod()]
        [DataRow("album1", 1)]
        [DataRow("album2", 0)]
        public void RegistKeywordTest(string in_keyword, int except)
        {
            // 初期データ
            var keyword = Keyword.Create("album1");
            keywordRepository.Store(keyword);

            // テスト処理
            var result = photoFrameApplication.RegistKeyword(in_keyword);
            Assert.AreEqual(except, result);
        }

        [TestMethod()]
        public void SearchFolderTest()
        {
            // テスト処理
            //Assert.AreEqual(3, photoFrameApplication.SearchFolder(@"C:\test1").Count());
            var sw = new System.Diagnostics.Stopwatch();
            sw.Start();
            Assert.AreEqual(472, photoFrameApplication.SearchFolder(@"\\Cfs-05-bk\home7\12810467\My Documents\My Pictures\Album2").Count());
            sw.Stop();
            
            TimeSpan ts = sw.Elapsed;
        
           

            //Assert.AreEqual(null, photoFrameApplication.SearchFolder(@"C:\test3"));

        }

        [TestMethod()]
        [DataRow(false, true)]
        [DataRow(true, false)]
        public void ToggleFavoriteTest(bool before, bool after)
        {
            // 初期データ
            var photo = new Photo(Guid.NewGuid().ToString(), new File("dummy.bmp"), DateTime.Now, before);
            photoRepository.Store(photo);

            // テスト処理
            var result = photoFrameApplication.ToggleFavorite(photo);
            Assert.AreEqual(after, result.IsFavorite);

        }

        [TestMethod()]
        [DataRow(300)]
        public void GetKeywordListTest(int except)
        {
            // 初期データ
            for (int i = 0; i < except; i++)
            {
                string name = "album" + i;
                keywordRepository.Store(Keyword.Create(name));
            }

            // テスト処理
            var result = photoFrameApplication.GetKeywordList();
            Assert.AreEqual(except, result.Count());
        }

        [TestMethod()]
        public void ChangeKeywordTest_Keyword()
        {
            // 初期データ
            var keyword1 = Keyword.Create("album1");
            var keyword2 = Keyword.Create("album2");
            keywordRepository.Store(keyword1);
            keywordRepository.Store(keyword2);

            var photo = Photo.CreateFromFile(new File("dummy.bmp"), DateTime.Now);
            photo.IsAssignedTo(keyword1);

            // テスト処理
            Assert.AreEqual("album1", photoFrameApplication.ChangeKeyword(photo, "album1").Keyword.Name);
            photo = Photo.CreateFromFile(new File("dummy.bmp"), DateTime.Now);
            photo.IsAssignedTo(keyword1);

            Assert.AreEqual("album2", photoFrameApplication.ChangeKeyword(photo, "album2").Keyword.Name);
            photo = Photo.CreateFromFile(new File("dummy.bmp"), DateTime.Now);
            photo.IsAssignedTo(keyword1);

            Assert.AreEqual(null, photoFrameApplication.ChangeKeyword(photo, "設定解除").Keyword);

            Assert.AreEqual("album1", photoFrameApplication.ChangeKeyword(photo, "album1").Keyword.Name);
            photo = Photo.CreateFromFile(new File("dummy.bmp"), DateTime.Now);

            Assert.AreEqual("album2", photoFrameApplication.ChangeKeyword(photo, "album2").Keyword.Name);
        }

        [TestMethod()]
        [DataRow(0)]
        [DataRow(1)]
        [DataRow(2)]
        public void SortListTest(int sortMethod)
        {
            DateTime dt1 = new DateTime(2008, 3, 14);
            DateTime dt2 = new DateTime(2008, 3, 15);
            DateTime dt3 = new DateTime(2008, 3, 16);

            var photo1 = Photo.CreateFromFile(new File("dummy1.bmp"), dt1);
            var photo2 = Photo.CreateFromFile(new File("dummy2.bmp"), dt2);
            var photo3 = Photo.CreateFromFile(new File("dummy3.bmp"), dt3);

            List<Photo> photoList = new List<Photo>();
            photoList.Add(photo1);
            photoList.Add(photo2);
            photoList.Add(photo3);

            // テスト処理
            var result = photoFrameApplication.SortList(photoList.AsEnumerable(), sortMethod);

            if (sortMethod == 0)
            {
                bool flag = photoList.SequenceEqual(result);
                Assert.IsTrue(flag);
            }

            if (sortMethod == 1)
            {
                var ordered = photoList.OrderBy(photo => photo.DateTime);
                bool flag = ordered.SequenceEqual(result);
                Assert.IsTrue(flag);
            }

            if (sortMethod == 2)
            {
                var ordered = photoList.OrderByDescending(photo => photo.DateTime);
                bool flag = ordered.SequenceEqual(result);
                Assert.IsTrue(flag);
            }

        }

        [TestMethod()]
        [DataRow("TRUE", null, null, null, false, true, true)]
        [DataRow("FALSE", null, null, null, true, false, false)]
        [DataRow(null, null, null, null, true, true, true)]
        [DataRow(null, "album1", null, null, true, false, false)]
        [DataRow(null, "album2", null, null, false, true, false)]
        [DataRow(null, "album3", null, null, false, false, false)]
        [DataRow(null, null, "2008:03:14" , "2008:03:16", true, true, true)]
        [DataRow(null, null, "2008:03:14", "2008:03:15", true, true, false)]
        [DataRow(null, null, "2008:03:14", "2008:03:14", true, false, false)]
        [DataRow(null, null, "2008:03:13", "2008:03:13", false, false, false)]
        [DataRow(null, null, "2008:03:17", "2008:03:17", false, false, false)]
        [DataRow(null, null, "", "2008:03:16", true, true, true)]
        [DataRow(null, "album1", "2008:03:15", "2008:03:15", false, false, false)]
        [DataRow("TRUE", null, "2008:03:14", "2008:03:16", false, true, true)]
        [DataRow("FALSE", "album1", null, null, true, false, false)]
        [DataRow("TRUE", "album2", "2008:03:15", "2008:03:17", false, true, false)]
        public void DetailSearchTest(string isFavorite, string keyword, string firstData, string lastData, bool flag1, bool flag2, bool flag3)
        {
            // 初期データ
            DateTime dt1 = new DateTime(2008, 3, 14);
            DateTime dt2 = new DateTime(2008, 3, 15);
            DateTime dt3 = new DateTime(2008, 3, 16);

            var keyword1 = Keyword.Create("album1");
            var keyword2 = Keyword.Create("album2");

            keywordRepository.Store(keyword1);
            keywordRepository.Store(keyword2);

            var photo1 = new Photo(Guid.NewGuid().ToString(), new File("dummy1.bmp"), dt1, false, keyword1.Id, keyword1);
            var photo2 = new Photo(Guid.NewGuid().ToString(), new File("dummy2.bmp"), dt2, true, keyword2.Id, keyword2);
            var photo3 = new Photo(Guid.NewGuid().ToString(), new File("dummy3.bmp"), dt3, true);

            List<Photo> photoList = new List<Photo>();
            photoList.Add(photo1);
            photoList.Add(photo2);
            photoList.Add(photo3);

            CultureInfo ci = CultureInfo.CurrentCulture;
            DateTimeStyles dts = DateTimeStyles.None;

            DateTime Date;
            DateTime? firstDate = null;
            DateTime? lastDate = null;


            if (DateTime.TryParseExact(firstData, "yyyy:MM:dd", ci, dts, out Date))
            {
                firstDate = Date;
            }
            
            if (DateTime.TryParseExact(lastData, "yyyy:MM:dd", ci, dts, out Date))
            {
                lastDate = Date;
            }

            bool[] searched = { flag1, flag2, flag3 };

            // テスト処理
            var tmp = new List<Photo>(photoList);
            var result = photoFrameApplication.DetailSearch(tmp, keyword, isFavorite, firstDate, lastDate);

            for(int i = 0; i < photoList.Count; i++ )
            {
                if (searched[i])
                {  
                    Assert.IsTrue(result.Contains(photoList[i]));
                }
                else
                {
                    Assert.IsFalse(result.Contains(photoList[i]));
                }
            }
           
        }
    }


}