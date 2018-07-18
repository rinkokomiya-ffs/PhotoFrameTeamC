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



        [TestMethod]
        public void アプリ起動時にキーワードがなければ空を返す()
        {

            var expectResult = new List<Keyword>();

            var result = keywordRepository.Find(allKeyword => allKeyword);

            List<Keyword> actualResult = new List<Keyword>();

            foreach (var re in result)
            {
                actualResult.Add(re);
            }

            CollectionAssert.AreEqual(expectResult, actualResult);

        }



        
        [TestMethod]
        public void キーワードを新規登録できること()
        {
            var firstKeyword = Keyword.Create("firstKeyword");
            var secondKeyword = Keyword.Create("secondKeyword");

            keywordRepository.Store(firstKeyword);
            keywordRepository.Store(secondKeyword);

        } // KeywordRepository.storeのテスト完了



       
        [TestMethod]
        public void アプリ起動時にキーワードをすべて取得できること()
        {
            
            var result = keywordRepository.Find(allKeyword => allKeyword);
            List<Keyword> actualResult = new List<Keyword>();

            foreach (var re in result)
            {
                actualResult.Add(re);
            }
            
            Assert.AreNotEqual(null, actualResult);

        } // 1番目と3番目のテストで KeywordRepository.Find(Func<IQueryable<Keyword>, IQueryable<Keyword>> query)のテスト完了



       
        [TestMethod]
        public void キーワード新規作成時にそのキーワードがDB上に存在する場合キーワードを返す()
        {
            var keyword = Keyword.Create("firstKeyword");

            var result = keywordRepository.Find(allKeyword => allKeyword.FirstOrDefault(k => k.Name == keyword.Name));
            Assert.AreNotEqual(null, result);

        } 




        [TestMethod]
        public void キーワード新規作成時にそのキーワードがDB上に存在しない場合nullを返す()
        {
            var newkeyword = Keyword.Create("newKeyword");

            var result = keywordRepository.Find(allKeyword => allKeyword.FirstOrDefault(k => k.Name == newkeyword.Name));
            Assert.AreEqual(null, result);
        } //4番目のテストと5番目のテストでKeywordRepository.Find(Func<IQueryable<Keyword>, Keyword> query)のテスト完了





        [TestMethod]
        public void SQL型からKeyword型に変換できること()
        {

        }

        [TestMethod]
        public void Keyword型からSQL型に変換できること()
        {

        }




        [TestMethod]
        public void 写真を追加できること()
        {
            var firstPhoto = Photo.CreateFromFile(new File("dummy.bmp"), new DateTime(1993, 05, 15, 15, 00, 00));
            var secondPhoto = Photo.CreateFromFile(new File("dummy.bmp"), new DateTime(1993, 05, 15, 15, 00, 00));

            photoRepository.Store(firstPhoto);
            photoRepository.Store(secondPhoto);
        }


        [TestMethod]
        public void 写真を検索できること()
        {
            var result = photoRepository.Find(allphoto => allphoto);
            Assert.AreNotEqual(null, result);
        }


        [TestMethod]
        public void 検索した結果写真がないときはnullを返すこと()
        {
            var result = photoRepository.Find(allphoto => allphoto);
            Assert.AreEqual(null, result);
        }

    //    photos => photos.SingleOrDefault(photo => photo.File.FilePath == file.FilePath)

        [TestMethod]
        public void フォルダ検索時に受け取った写真がDB内に存在するときにその写真を全て検索できること()
        {
            var photo = Photo.CreateFromFile(new File("dummy.bmp"), new DateTime(1993, 05, 15, 15, 00, 00));

            photoRepository.Store(photo);
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




        //[TestMethod]
        //public void キーワードを新規登録できること()
        //{
        //    var keyword = Keyword.Create("addKeyword");
        //    keywordRepository.Store(keyword);

        //    var result = keywordRepository.Find(allKeyword => allKeyword.FirstOrDefault(k => k.Id == keyword.Id));
        //    Assert.AreEqual(keyword, result);
        //}

        //[TestMethod]
        //public void アプリ起動時にキーワードをすべて取得できること()
        //{
        //    var firstKeyword = Keyword.Create("firstKeyword");
        //    var secondKeyword = Keyword.Create("secondKeyword");
        //    keywordRepository.Store(firstKeyword);
        //    keywordRepository.Store(secondKeyword);

        //    var expectResult = new List<Keyword>();
        //    expectResult.Add(firstKeyword);
        //    expectResult.Add(secondKeyword);

        //    var result = keywordRepository.Find(allKeyword => allKeyword);
        //    List<Keyword> actualResult = new List<Keyword>();

        //    foreach (var re in result)
        //    {
        //        actualResult.Add(re);
        //    }

        //    CollectionAssert.AreEqual(expectResult, actualResult);

        //}


    }
}
