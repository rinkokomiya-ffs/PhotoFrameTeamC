using Microsoft.VisualStudio.TestTools.UnitTesting;
using PhotoFrame.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;


namespace PhotoFrame.Persistence.Test
{
    [TestClass]
    public class EFRepositoryTest
    {
        private static IPhotoRepository photoRepository;
        private static IKeywordRepository keywordRepository;

        private TransactionScope scope;

        [ClassInitialize]
        public static void SetUpTestCase(TestContext context)
        {
            // リポジトリ生成
            var repos = new RepositoryFactory(Type.EF);
            photoRepository = repos.PhotoRepository;
            keywordRepository = repos.KeywordRepository;

            // テスト用データベースが存在していない場合は作りにいくが、
            // Transaction中ではテーブルを作成できないため、ここで作成させる
            //photoRepository.FindBy("dummy");
            //keywordRepository.FindBy("dummy");
        }

        [TestInitialize]
        public void SetUp()
        {
            scope = new TransactionScope();
        }

        [TestCleanup]
        public void TearDown()
        {
            scope.Dispose();
        }

        [TestMethod]
        public void 写真を追加できること()
        {
            var photo = Photo.CreateFromFile(new File("dummy.bmp"), new DateTime(1993,05,15,15,00,00));

            photoRepository.Store(photo);

            //var result = photoRepository.FindBy(photo.Id);
            var result = photoRepository.Find(allPhoto => allPhoto.FirstOrDefault(p => p.Id == photo.Id));
            Assert.AreNotEqual(null, result);
        }

        //[TestMethod]
        //public void 重複した写真は追加されないこと()
        //{
        //    var photo = Photo.CreateFromFile(new File("dummy.bmp"), new DateTime(1993,05,15,15,00,00));
        //    photoRepository.Store(photo);

        //    var same_photo = Photo.CreateFromFile(new File("dummy.bmp"), new DateTime(1993, 05, 15, 15, 00, 00));
        //    photoRepository.Store(same_photo);
        

        //}


        [TestMethod]
        public void 写真のお気に入りを更新できること()
        {
            var photo = Photo.CreateFromFile(new File("dummy.bmp"), new DateTime(1993, 05, 15, 15, 00, 00));

            photoRepository.Store(photo);

            photo.MarkAsFavorite();
            photoRepository.Store(photo);

            // var result = photoRepository.FindBy(photo.Id);
            var result = photoRepository.Find(allPhoto => allPhoto.FirstOrDefault(p => p.Id == photo.Id));
            Assert.AreEqual(true, result.IsFavorite);
        }

        [TestMethod]
        public void 既存の写真にキーワードを追加できること()
        {
            var keyword = Keyword.Create("Keyword1");
            keywordRepository.Store(keyword);
            var photo = Photo.CreateFromFile(new File("dummy.bmp"), new DateTime(1993, 05, 15, 15, 00, 00));

            photoRepository.Store(photo);

            photo.IsAssignedTo(keyword);
            photoRepository.Store(photo);

            //var result = photoRepository.FindBy(photo.Id);
            var result = photoRepository.Find(allPhoto => allPhoto.FirstOrDefault(p => p.Keyword.Name == photo.Keyword.Name));
            Assert.AreEqual(photo.Keyword.Name, result.Keyword.Name);
        }

        [TestMethod]
        public void 写真のキーワードを更新できること()
        {
            var old_keyword = Keyword.Create("old_keyword");
            keywordRepository.Store(old_keyword);
            var new_keyword = Keyword.Create("new_keyword");
            keywordRepository.Store(new_keyword);


            var photo = Photo.CreateFromFile(new File("dummy.bmp"), new DateTime(1993, 05, 15, 15, 00, 00));

            photo.IsAssignedTo(old_keyword);
            photoRepository.Store(photo);


            photo.IsAssignedTo(new_keyword);
            photoRepository.Store(photo);


            var result = photoRepository.Find(allPhoto => allPhoto.FirstOrDefault(p => p.Id == photo.Id));
            Assert.AreEqual(new_keyword.Name, result.Keyword.Name);

        }

        [TestMethod]
        public void キーワードを追加できること()
        {
            var keyword = Keyword.Create("addKeyword");
            keywordRepository.Store(keyword);

            var result = keywordRepository.Find(allKeyword => allKeyword.FirstOrDefault(k => k.Id == keyword.Id));
            Assert.AreEqual(keyword.Id, result.Id);
        }

    }
}
