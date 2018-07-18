using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PhotoFrameApp;
using System.Media;
using PhotoFrame.Domain.Model;

namespace PhotoFrameApp.Tests
{
    //音楽が再生されるかどうかのテスト

    [TestClass()]
    public class SlideShowFormTests
    {
        private PhotoFrameForm photoframeform;
        private SlideShowForm slideshowform;
        private PrivateObject privateobject;
        private SoundPlayer player = null;

        private List<Photo> dummyPhotoList;


        [TestInitialize]
        public void SetUp()
        {
            privateobject = new PrivateObject(photoframeform);
            slideshowform = new SlideShowForm(dummyPhotoList);
        }


        [TestMethod()]
        public void 音楽を再生する()
        {
            var playmusic = privateobject.Invoke("PlayMusic");
            Assert.AreEqual("music.wav", slideshowform.musicFile);
        }
    }
}