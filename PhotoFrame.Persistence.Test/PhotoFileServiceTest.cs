using Microsoft.VisualStudio.TestTools.UnitTesting;
using PhotoFrame.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoFrame.Persistence.Test
{
    [TestClass]
    public class PhotoFileServiceTest
    {
        private IPhotoFileService service;

        [TestInitialize]
        public void SetUp()
        {
            service = new ServiceFactory().PhotoFileService;
        }

        [TestMethod] //テスト14
        public void 指定されたフォルダの画像データのみを全て取得できること()
        {
            // テストデータをどう与えるかなどはお任せします
            var result = service.FindAllPhotoFilesFromDirectory(@"\\CFS-01\HOME0\12810470\Desktop\ミニシステム開発\TestPicture");

            string[] test = {@"\\CFS-01\HOME0\12810470\Desktop\ミニシステム開発\TestPicture\Penguins.jpg", @"\\CFS-01\HOME0\12810470\Desktop\ミニシステム開発\TestPicture\Koala.jpg" };

            int i = 0;

            foreach(Domain.Model.File file in result)
            {
                Assert.AreEqual(file.FilePath, test[i]);
                i++;
            }
        }

        [TestMethod] //テスト15
        public void ネストを含む指定されたフォルダの画像データのみを全て取得できること()
        {
            // テストデータをどう与えるかなどはお任せします
            var result = service.FindAllPhotoFilesFromDirectory(@"\\CFS-01\HOME0\12810470\Desktop\ミニシステム開発\TestNestPicture");

            string[] test = { @"\\CFS-01\HOME0\12810470\Desktop\ミニシステム開発\TestNestPicture\Koala.jpg", @"\\CFS-01\HOME0\12810470\Desktop\ミニシステム開発\TestNestPicture\Penguins.jpg"
, @"\\CFS-01\HOME0\12810470\Desktop\ミニシステム開発\TestNestPicture\TestPicture\Lighthouse.jpg",@"\\CFS-01\HOME0\12810470\Desktop\ミニシステム開発\TestNestPicture\TestPicture\Tulips.jpg" }; 

            int i = 0;

            foreach (Domain.Model.File file in result)
            {
                Assert.AreEqual(file.FilePath, test[i]);
                i++;
            }
        }


        [TestMethod] //テスト13
        public void 画像データを含まないディレクトリを受け取った場合空を返すこと()
        {
            // テストデータをどう与えるかなどはお任せします
            var result = service.FindAllPhotoFilesFromDirectory(@"\\CFS-01\HOME0\12810470\Desktop\ミニシステム開発\TestDummyPicture");
            
            Assert.AreEqual(0, result.Count());
        }

        
    }
}
