using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PhotoFrame.Domain.Model;
using PhotoFrame.Application;

namespace PhotoFrameApp
{
    public class Controller
    {
        // アプリケーションのインスタンス
        private readonly PhotoFrameApplication application;

        public Controller(IKeywordRepository keywordRepository, IPhotoRepository photoRepository, IPhotoFileService photoFileService)
        {
            this.application = new PhotoFrameApplication(keywordRepository, photoRepository, photoFileService);
        }

        public IEnumerable<Keyword> ExecuteGetKeyword()
        {
            return application.GetKeywordList();
        }

        public int ExecuteRegistKeyword(string keyword)
        {
            return application.RegistKeyword(keyword);
        }

        public IEnumerable<Photo> ExecuteSearchFolder(string folderPath)
        {
            return application.SearchFolder(folderPath);
        }

        public Photo ExecuteToggleFavorite(Photo photo)
        {
            return application.ToggleFavorite(photo);
        }

        public Photo ExecuteChangeKeyword(Photo photo, string keyword)
        {
            return application.ChangeKeyword(photo, keyword);
        }

        public IEnumerable<Photo> ExecuteSortList(IEnumerable<Photo> photoList, int sortMethod)
        {
            return application.SortList(photoList, sortMethod);
        }

        public IEnumerable<Photo> ExecuteDetailSearch(IEnumerable<Photo> photoList, string keyword, string isFavorite, DateTime? firstDate, DateTime? lastDate)
        {
            return application.DetailSearch(photoList, keyword, isFavorite, firstDate, lastDate);
        }

        public async Task<IEnumerable<Photo>> ExecuteSearchFolderAsync(string directoryName)
        {
            var retPhotos = await Task.Run(() =>
            {
                var photos = application.SearchFolder(directoryName);
                return photos;
            });
            return retPhotos;
        }
    }
}
