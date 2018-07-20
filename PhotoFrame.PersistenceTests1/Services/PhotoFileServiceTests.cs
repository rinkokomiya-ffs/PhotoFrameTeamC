
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PhotoFrame.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace PhotoFrame.Persistence.Tests
{
    [TestClass()]
    public class PhotoFileServiceTests
    {
        private static IPhotoRepository photoRepository;
        private static IKeywordRepository keywordRepository;


        [ClassInitialize]
        public static void SetUpTestCase(TestContext context)
        {
            // リポジトリ生成
            var repos = new RepositoryFactory(Type.EF);
            photoRepository = repos.PhotoRepository;
            keywordRepository = repos.KeywordRepository;

        }

        private IPhotoFileService service;

        [TestInitialize]
        public void SetUp()
        {
            service = new ServiceFactory().PhotoFileService;
        }


        [TestMethod]
        public void 指定されたフォルダの画像データのみを全て取得できること()
        {
            // テストデータをどう与えるかなどはお任せします
            var result = service.FindAllPhotoFilesFromDirectory(@"\\CFS-01\HOME0\12810470\Desktop\ミニシステム開発\TestPicture");

            string[] test = { @"\\CFS-01\HOME0\12810470\Desktop\ミニシステム開発\TestPicture\Penguins.jpg", @"\\CFS-01\HOME0\12810470\Desktop\ミニシステム開発\TestPicture\Koala.jpg" };

            int i = 0;

            foreach (Domain.Model.File file in result)
            {
                Assert.AreEqual(file.FilePath, test[i]);
                i++;
            }
        }

        [TestMethod]
        public void 非機能800枚の写真を格納できる()
        {
            // テストデータをどう与えるかなどはお任せします
            var result = service.FindAllPhotoFilesFromDirectory(@"\\CFS-01\HOME0\12810470\Desktop\ミニシステム開発\HikinouTestPicture");
            var photosInFolder = new List<Photo>();


            foreach (Domain.Model.File file in result)
            {
                var photo = Photo.CreateFromFile(file, DateTime.Now);
               // photosInFolder.Add(photo);
                photosInFolder.Add(photoRepository.Store(photo));
            }

            Assert.AreEqual(800, photosInFolder.Count());
        }



        [TestMethod] 
        public void 画像データを含まないディレクトリを受け取った場合空を返すこと()
        {
            var result = service.FindAllPhotoFilesFromDirectory(@"\\CFS-01\HOME0\12810470\Desktop\ミニシステム開発\TestDummyPicture");

            Assert.AreEqual(0, result.Count());
        }

    }
}