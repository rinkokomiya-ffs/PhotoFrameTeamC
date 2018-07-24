using PhotoFrame.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.SqlServer;


namespace PhotoFrame.Persistence.EF
{
    /// <summary>
    /// <see cref="IPhotoRepository">の実装クラス
    /// </summary>
    class PhotoRepository : IPhotoRepository
    {
        private SqlProviderServices _sqlProviderServices;
        private IKeywordRepository keywordRepository;

        public PhotoRepository(IKeywordRepository keywordRepository, SqlProviderServices sqlProviderServices)
        {
            this.keywordRepository = keywordRepository;
            _sqlProviderServices = sqlProviderServices;
        }

        public bool Exists(Photo entity)
        {
            // TODO: DBプログラミング講座で実装
            throw new NotImplementedException();
        }

        public bool ExistsBy(string id)
        {
            // TODO: DBプログラミング講座で実装
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public IEnumerable<Photo> Find(Func<IQueryable<Photo>, IQueryable<Photo>> query)
            => query(FindAll());

        public Photo Find(Func<IQueryable<Photo>, Photo> query)
            => query(FindAll());

        public Photo FindBy(string id)
        {
            // TODO: DBプログラミング講座で実装
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public Photo Store(Photo entity)
        {
            // TODO: DBプログラミング講座で実装
            var photo = PhotoToTable(entity);

            using (var photoFrameEntity = new PhotoFrameTeamCEntities())
            {
                // トランザクション作成
                using (var transaction = photoFrameEntity.Database.BeginTransaction())
                {
                    try
                    {
                        var searchedPhoto = photoFrameEntity.m_Photo.SingleOrDefault(p => p.Id == photo.Id);

                        if (searchedPhoto == null)
                        {
                            photoFrameEntity.m_Photo.Add(photo);
                        }
                        else
                        {
                            searchedPhoto.FilePath = photo.FilePath;
                            searchedPhoto.DateTime = photo.DateTime;
                            searchedPhoto.IsFavorite = photo.IsFavorite;
                            searchedPhoto.KeywordId = photo.KeywordId;
                        }
                        photoFrameEntity.SaveChanges();
                        transaction.Commit();
                        return entity;

                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        /// <summary>
        ///  DBのデータをすべて取得
        /// </summary>
        /// <returns></returns>
        private IQueryable<Photo> FindAll()
        {
            var m_photos = new List<m_Photo>();

            // KeywordのFindAllでDBへアクセスするため、 一度DBのデータを格納して接続切る
            using (var photoFrameEntity = new PhotoFrameTeamCEntities())
            {
                m_photos = photoFrameEntity.m_Photo.ToList();
            }

            // DBのテーブルデータからPhotoオブジェクトへ変換メソッドTableToPhotoの呼び出し
            // ここでKeywordのFindAllでDBへアクセスがある
            var photos = m_photos.Select(p => TableToPhoto(p));
            return photos.AsQueryable();
           
        }

        /// <summary>
        /// DBのテーブルデータからPhotoオブジェクトへ変換
        /// </summary>
        /// <param name="m_Photo"></param>
        /// <returns></returns>
        private Photo TableToPhoto(m_Photo m_photo)
        {
            var file = new File(m_photo.FilePath);
            var keyword = keywordRepository.Find(allKeyword => allKeyword.FirstOrDefault(p => p.Id == m_photo.KeywordId.ToString()));

            if (keyword == null)
            {
                return new Photo(m_photo.Id.ToString(), file, m_photo.DateTime, m_photo.IsFavorite);
            }
            else
            {
                return new Photo(m_photo.Id.ToString(), file, m_photo.DateTime, m_photo.IsFavorite, m_photo.KeywordId.ToString(), keyword);

            }
        }

        /// <summary>
        /// 逆変換
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        private m_Photo PhotoToTable(Photo photo)
        {
            var m_photo = new m_Photo();
            m_photo.Id = Guid.Parse(photo.Id);
            m_photo.FilePath = photo.File.FilePath;
            m_photo.DateTime = photo.DateTime;
            m_photo.IsFavorite = photo.IsFavorite;
            if (photo.KeywordId != null) m_photo.KeywordId = Guid.Parse(photo.KeywordId);

            return m_photo;
        }

        public void StoreIfNotExists(IEnumerable<Photo> photos)
        {
            // TODO: DBプログラミング講座で実装
            throw new NotImplementedException();
        }
    }
}
