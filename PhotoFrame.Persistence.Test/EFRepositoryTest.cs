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
            
            var result = keywordRepository.Find(allKeyword => allKeyword);
            Assert.AreEqual(0, result.Count());

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
            var keyword = Keyword.Create("海");

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
            var firstPhoto = Photo.CreateFromFile(new File("dummy1.bmp"), new DateTime(1993, 05, 15, 15, 00, 00));
            var secondPhoto = Photo.CreateFromFile(new File("dummy2.bmp"), new DateTime(2018, 07, 18, 15, 00, 00));

            photoRepository.Store(firstPhoto);
            photoRepository.Store(secondPhoto);
        }


        [TestMethod]
        public void 写真を検索できること()
        {
            var result = photoRepository.Find(allphoto => allphoto);
            Assert.AreNotEqual(null, result);
        }


        //DB内の写真を一度デリーとして行う
        [TestMethod]
        public void 検索した結果写真がないときは空を返すこと()
        {
            var result = photoRepository.Find(allphoto => allphoto);
            Assert.AreEqual(0, result.Count());
        }


        

        [TestMethod] //完了
        public void 既存の写真にキーワードを追加できること()
        {
            var keyword = Keyword.Create("haveKeyword");
            keywordRepository.Store(keyword);

            var haveKeyword = photoRepository.Find(allphoto => allphoto.FirstOrDefault(p => p.File.FilePath == "AddKeyword.bmp"));

            haveKeyword.IsAssignedTo(keyword);
            photoRepository.Store(haveKeyword);
           
        }

        [TestMethod] //他のメソッドを使うが完了
        public void 写真のキーワードを更新できること()
        {
            var keyword = Keyword.Create("newKeyword");
            keywordRepository.Store(keyword);

            var changedKeyword = photoRepository.Find(allphoto => allphoto.FirstOrDefault(p => p.File.FilePath == "AddKeyword.bmp"));

            changedKeyword.IsAssignedTo(keyword);
            photoRepository.Store(changedKeyword);
        }


        [TestMethod]
        public void 写真のお気に入りを更新できること()
        {
            var changeFavorite = photoRepository.Find(allphoto => allphoto.FirstOrDefault(p => p.File.FilePath == "ChangeFavorite.bmp"));
            
            changeFavorite.MarkAsFavorite();
            photoRepository.Store(changeFavorite);

        }
       



        //[TestMethod]
        //public void 重複した写真は追加されないこと()
        //{
        //    var photo = Photo.CreateFromFile(new File("dummy.bmp"), new DateTime(1993,05,15,15,00,00));
        //    photoRepository.Store(photo);

        //    var same_photo = Photo.CreateFromFile(new File("dummy.bmp"), new DateTime(1993, 05, 15, 15, 00, 00));
        //    photoRepository.Store(same_photo);
        

        //}







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
