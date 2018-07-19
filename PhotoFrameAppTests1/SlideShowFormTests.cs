using Microsoft.VisualStudio.TestTools.UnitTesting;
using PhotoFrame.Domain.Model;
using PhotoFrameApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace PhotoFrameApp.Tests
{
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
            dummyPhotoList = new List<Photo>();
            slideshowform = new SlideShowForm(dummyPhotoList);
            privateobject = new PrivateObject(slideshowform);
        }


        [TestMethod()]
        public void 音楽を再生する()
        {
            //slideshowform.PlayMusic();
            var playmusic = privateobject.Invoke("PlayMusic");
      //      Assert.AreSame(@"C:\\ミニシステム開発演習.ver2\\PhotoFrameTeamC\\PhotoFrameAppTests\\bin\\Debug\\music.wav", slideshowform.musicFile);
        }

        [TestMethod()]
        public void 音楽を停止する()
        {
            var playmusic = privateobject.Invoke("PlayMusic");

            System.Threading.Thread.Sleep(2000);

            var stopmusic = privateobject.Invoke("StopMusic");
        }
    }
 
}
