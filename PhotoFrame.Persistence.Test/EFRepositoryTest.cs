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



        [TestMethod] //テスト2　DBを全てDeleteしてテストを行う
        public void アプリ起動時にキーワードがなければ空を返す()
        {
            
            var result = keywordRepository.Find(allKeyword => allKeyword);
            Assert.AreEqual(0, result.Count());

        }



        
        [TestMethod] //テスト5
        public void キーワードを新規登録できること()
        {
            var firstKeyword = Keyword.Create("firstKeyword");
            var secondKeyword = Keyword.Create("secondKeyword");

            keywordRepository.Store(firstKeyword);
            keywordRepository.Store(secondKeyword);

        } // KeywordRepository.storeのテスト完了



       
        [TestMethod] // テスト1
        public void アプリ起動時にキーワードをすべて取得できること()
        {
            
            var result = keywordRepository.Find(allKeyword => allKeyword);
        
            
            Assert.AreEqual(1, result.Count());

        } // 1番目と3番目のテストで KeywordRepository.Find(Func<IQueryable<Keyword>, IQueryable<Keyword>> query)のテスト完了



       
        [TestMethod] //テスト3
        public void DB上に存在する同じ名前のキーワードを作成する場合DB上のそのキーワードを返す()
        {
            var keyword = Keyword.Create("海");

            var result = keywordRepository.Find(allKeyword => allKeyword.FirstOrDefault(k => k.Name == keyword.Name));
            Assert.AreEqual(keyword.Name, result.Name);

        } 




        [TestMethod] //テスト4
        public void キーワード新規作成時にそのキーワードがDB上に存在しない場合nullを返す()
        {
            var newkeyword = Keyword.Create("newKeyword");

            var result = keywordRepository.Find(allKeyword => allKeyword.FirstOrDefault(k => k.Name == newkeyword.Name));
            Assert.AreEqual(null, result);
        } //4番目のテストと5番目のテストでKeywordRepository.Find(Func<IQueryable<Keyword>, Keyword> query)のテスト完了





      


        [TestMethod]//テスト8
        public void 写真を追加できること()
        {
            var firstPhoto = Photo.CreateFromFile(new File("dummy1.bmp"), new DateTime(1993, 05, 15, 15, 00, 00));
            var secondPhoto = Photo.CreateFromFile(new File("dummy2.bmp"), new DateTime(2018, 07, 18, 15, 00, 00));

            photoRepository.Store(firstPhoto);
            photoRepository.Store(secondPhoto);
        }


        [TestMethod] //テスト6

        public void 写真を検索できること()
        {
            var result = photoRepository.Find(allphoto => allphoto);
            Assert.AreEqual(4, result.Count());
        }


        //DB内の写真を一度Deleteとして行う。テスト後Deleteした項目を再追加する
        [TestMethod] //テスト7
        public void 検索した結果写真がないときは空を返すこと()
        {
            var result = photoRepository.Find(allphoto => allphoto);
            Assert.AreEqual(0, result.Count());
        }


        

        [TestMethod] //テスト9
        public void 既存の写真にキーワードを追加できること()
        {
            var keyword = Keyword.Create("haveKeyword");
            keywordRepository.Store(keyword);

            var haveKeyword = photoRepository.Find(allphoto => allphoto.FirstOrDefault(p => p.File.FilePath == "AddKeyword.bmp"));

            haveKeyword.IsAssignedTo(keyword);
            photoRepository.Store(haveKeyword);
           
        }

        [TestMethod] //テスト10
        public void 写真のキーワードを更新できること()
        {
            var keyword = Keyword.Create("newKeyword");
            keywordRepository.Store(keyword);

            var changedKeyword = photoRepository.Find(allphoto => allphoto.FirstOrDefault(p => p.File.FilePath == "ChangeKeyword.bmp"));

            changedKeyword.IsAssignedTo(keyword);
            photoRepository.Store(changedKeyword);
        }


        [TestMethod] //テスト11
        public void 写真のお気に入り情報を追加更新できること()
        {
            var changeFavorite = photoRepository.Find(allphoto => allphoto.FirstOrDefault(p => p.File.FilePath == "ChangeFavorite.bmp"));
            
            changeFavorite.MarkAsFavorite();
            photoRepository.Store(changeFavorite);

        }

        [TestMethod] //テスト12
        public void 写真のお気に入り情報を取り消し更新できること()
        {
            var changeFavorite = photoRepository.Find(allphoto => allphoto.FirstOrDefault(p => p.File.FilePath == "ChangeFavorite.bmp"));

            changeFavorite.MarkAsUnFavorite();
            photoRepository.Store(changeFavorite);

        }

    }
}
