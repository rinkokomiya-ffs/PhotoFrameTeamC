using PhotoFrame.Domain.Model;
using PhotoFrame.Domain.UseCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoFrame.Application
{
    /// <summary>
    /// PhotoFrameのUIの指示にしたがってドメインのユースケースを起動する
    /// </summary>
    // TODO: 仮実装
    public class PhotoFrameApplication
    {
        // ユースケースのインスタンス
        private readonly RegistKeyword _registKeyword;
        private readonly DetailSearch _detailSearch;
        private readonly SearchFolder _searchFolder;
        private readonly ToggleFavorite _toggleFavorite;
        private readonly ChangeKeyword _changeKeyword;
        private readonly SortList _sortList;
        private readonly GetKeywordList _getKeywordList;

        public PhotoFrameApplication(IKeywordRepository keywordRepository, IPhotoRepository photoRepository, IPhotoFileService photoFileService)
        {
            _registKeyword = new RegistKeyword(keywordRepository);
            _detailSearch = new DetailSearch();
            _searchFolder = new SearchFolder(photoRepository, photoFileService);
            _toggleFavorite = new ToggleFavorite(photoRepository);
            _sortList = new SortList();
            _changeKeyword = new ChangeKeyword(keywordRepository, photoRepository);
            _getKeywordList = new GetKeywordList(keywordRepository);
        }

        public int RegistKeyword(string keyword)
        {
            return _registKeyword.Execute(keyword);
        }

        public IEnumerable<Photo> DetailSearch(IEnumerable<Photo> photoList, string keyword, string isFavorite, DateTime? firstData, DateTime? lastData)
        {
            return _detailSearch.Execute(photoList, keyword, isFavorite, firstData, lastData);
        }

        public IEnumerable<Photo> SearchFolder(string directoryName)
        {
            return _searchFolder.Execute(directoryName);
        }

        public Photo ToggleFavorite(Photo photo)
        {
            return _toggleFavorite.Execute(photo);
        }
     
        public Photo ChangeKeyword(Photo photo, string keyword)
        {
            return _changeKeyword.Execute(photo, keyword);
        }

        public IEnumerable<Photo> SortList(IEnumerable<Photo> photoList, int sortMethod)
        {
            return _sortList.Execute(photoList, sortMethod);
        }

        public IEnumerable<Keyword> GetKeywordList()
        {
            return _getKeywordList.Execute();
        }

        public async Task<IEnumerable<Photo>> SearchFolderAsync(string directoryName)
        {
            var retPhotos = await _searchFolder.ExecuteAsync(directoryName);
            return retPhotos;
        }

    }
}
