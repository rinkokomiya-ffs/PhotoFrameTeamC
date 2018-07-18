using Microsoft.VisualStudio.TestTools.UnitTesting;
using PhotoFrame.Domain.Model;
using PhotoFrame.Persistence;
using PhotoFrameApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PhotoFrameApp.Tests
{
    /// <summary>
    /// コントローラがアプリケーションを正しく呼び出しているかどうかのテスト
    /// </summary>
    [TestClass()]
    public class ControllerTests
    {
        private static IPhotoRepository photoRepository;
        private static IKeywordRepository keywordRepository;
        private static IPhotoFileService photoFileService;

        private Controller controller;

        private List<Photo> dummyPhotoList;
        private List<Keyword> dummyKeywordList;

        [ClassInitialize]
        public static void SetUpTestCase(TestContext context)
        {
            // リポジトリ生成
            var repos = new RepositoryFactory(PhotoFrame.Persistence.Type.EF);
            photoRepository = repos.PhotoRepository;
            keywordRepository = repos.KeywordRepository;
            ServiceFactory serviceFactory = new ServiceFactory();
            photoFileService = serviceFactory.PhotoFileService;
        }

        [TestInitialize]
        public void SetUp()
        {
            controller = new Controller(keywordRepository, photoRepository, photoFileService);

            // ダミーデータ作成
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

        [TestMethod()]
        public void ExecuteGetKeywordTest()
        {
            Assert.IsTrue(dummyKeywordList.SequenceEqual(controller.ExecuteGetKeyword()));
        }

        [TestMethod()]
        public void ExecuteGetKeywordTest_null()
        {
            Assert.AreEqual(null, controller.ExecuteGetKeyword());
        }

        [TestMethod()]
        public void ExecuteRegistKeywordTest()
        {
            string keyword = "keyword";
            Assert.AreEqual(0, controller.ExecuteRegistKeyword(keyword));
        }

        [TestMethod()]
        public void ExecuteSearchFolderTest()
        {
            string folderPath = "test\\test";
            Assert.IsTrue(dummyPhotoList.SequenceEqual(controller.ExecuteSearchFolder(folderPath)));
        }

        [TestMethod()]
        public void ExecuteToggleFavoriteTest()
        {
            var photo = Photo.CreateFromFile(new File("dummy.bmp"), new DateTime(1993, 05, 15, 15, 00, 00));
            Assert.AreEqual(photo, controller.ExecuteToggleFavorite(photo));
        }

        [TestMethod()]
        public void ExecuteChangeKeywordTest()
        {
            var photo = Photo.CreateFromFile(new File("dummy.bmp"), new DateTime(1993, 05, 15, 15, 00, 00));
            string keyword = "keyword";
            Assert.AreEqual(photo, controller.ExecuteChangeKeyword(photo, keyword));
        }

        [TestMethod()]
        public void ExecuteSortListTest()
        {
            int sortMethod = 0;
            Assert.IsTrue(dummyPhotoList.SequenceEqual(controller.ExecuteSortList(dummyPhotoList,sortMethod)));
        }

        [TestMethod()]
        public void ExecuteDetailSearchTest()
        {
            string keyword = "keyword";
            string isFavorite = "true";
            DateTime? firstDate = new DateTime(1993, 05, 15, 15, 00, 00);
            DateTime? lastDate = new DateTime(1993, 05, 15, 15, 00, 00);
            Assert.IsTrue(dummyPhotoList.SequenceEqual(controller.ExecuteDetailSearch(dummyPhotoList, keyword, isFavorite, firstDate, lastDate)));

        }
    }
}