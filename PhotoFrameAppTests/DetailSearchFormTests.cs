using Microsoft.VisualStudio.TestTools.UnitTesting;
using PhotoFrame.Domain.Model;
using PhotoFrameApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoFrameApp.Tests
{
    [TestClass()]
    public class DetailSearchFormTests
    {
        private static IPhotoRepository photoRepository;
        private static IKeywordRepository keywordRepository;
        private static IPhotoFileService photoFileService;

        private PhotoFrameForm photoFrameForm;
        private Controller controller;
        private PrivateObject privateObject;

        private List<Photo> dummyPhotoList;

        [TestMethod()]
        public void GetDateTimeTest()
        {
            Assert.Fail();
        }
    }
}