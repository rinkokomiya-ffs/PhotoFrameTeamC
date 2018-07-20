
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PhotoFrame.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;



namespace PhotoFrame.Persistence.EF.Tests
{
    [TestClass()]
    public class PhotoRepositoryTests
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

        //private TransactionScope scope;

        //[TestInitialize]
        //public void SetUp()
        //{
        //    scope = new TransactionScope();
        //}

        //[TestCleanup]
        //public void TearDown()
        //{
        //    scope.Dispose();
        //}


        [TestMethod()] //DBにキーワードを登録しておく
        [DataRow("newKeyword", 0)]
        [DataRow("existKeyword", 1)]
        public void キーワードを新規登録できること(string registKeyword, int except)
        {
            var newKeyword = Keyword.Create(registKeyword);

            var result = keywordRepository.Find(keywords => keywords.SingleOrDefault(keyword => keyword.Name == newKeyword.Name));
            int testResult;

            if (result == null)
            {
                keywordRepository.Store(newKeyword);
                testResult = 0;

            }
            else
            {
                testResult = 1;
            }
            Assert.AreEqual(except,testResult);
        }
        

        [TestMethod()] 
        public void 写真の情報を更新できること()
        {

            var testPhoto = photoRepository.Find(photos => photos.SingleOrDefault(photo => photo.File.FilePath == "testPhoto.bmp"));
            var returnPhoto = photoRepository.Store(testPhoto);

            Assert.AreEqual(testPhoto, returnPhoto);
        }





        [TestMethod()]
        public void 一つのキーワードに対して百枚の写真を割り当てられること()
        {
            var testKeyword = keywordRepository.Find(keywords => keywords.SingleOrDefault(keyword => keyword.Name == "夏"));


   
            var result = service.FindAllPhotoFilesFromDirectory(@"\\CFS-01\HOME0\12810470\Desktop\ミニシステム開発\HikinouKeywordTestPicture");
            var photosInFolder = new List<Photo>();


            foreach (Domain.Model.File file in result)
            {
                var photo = Photo.CreateFromFile(file, DateTime.Now);
                photo.IsAssignedTo(testKeyword);
                
                photosInFolder.Add(photoRepository.Store(photo));
                Assert.AreEqual(testKeyword, photo.Keyword);
            }

        }



        [TestMethod()] //DBにキーワードを3つ登録しておく
        public void 起動時にDB内の全キーワードを取得できること()
        {
            var returnKeyword = keywordRepository.Find(keywords => keywords);

            Assert.AreEqual(3, returnKeyword.Count());
        }



        [TestMethod()] //DBにキーワードを全て消しておく
        public void 起動時にキーワードがDBに登録されていない場合は空のリストを返すこと()
        {
            var returnKeyword = keywordRepository.Find(keywords => keywords);

            Assert.AreEqual(0, returnKeyword.Count());
        }
        
    }
    
}