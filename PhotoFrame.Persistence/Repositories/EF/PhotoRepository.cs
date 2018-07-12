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
        private IKeywordRepository albumRepository;

        public PhotoRepository(IKeywordRepository albumRepository, SqlProviderServices sqlProviderServices)
        {
            this.albumRepository = albumRepository;
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
            var photo = AlbumToTable(entity);

            using (var photoFrameEntity = new PhotoFrameDBEntities())
            {
                // トランザクション作成
                using (var transaction = photoFrameEntity.Database.BeginTransaction())
                {
                    try
                    {
                        var searchedPhoto = photoFrameEntity.M_PHOTO.SingleOrDefault(p => p.Id == photo.Id);

                        if (searchedPhoto == null)
                        {
                            photoFrameEntity.M_PHOTO.Add(photo);
                        }
                        else
                        {
                            searchedPhoto.FilePath = photo.FilePath;
                            searchedPhoto.IsFavorite = photo.IsFavorite;
                            searchedPhoto.AlbumId = photo.AlbumId;
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
            var m_photos = new List<M_PHOTO>();

            // AlbumのFindAllでDBへアクセスするため、 一度DBのデータを格納して接続切る
            using (var photoFrameEntity = new PhotoFrameDBEntities())
            {
                m_photos = photoFrameEntity.M_PHOTO.ToList();
            }

            // DBのテーブルデータからPhotoオブジェクトへ変換メソッドTableToPhotoの呼び出し
            // ここでAlbumのFindAllでDBへアクセスがある
            var photos = m_photos.Select(p => TableToPhoto(p));
            return photos.AsQueryable();
           
        }

        /// <summary>
        /// DBのテーブルデータからPhotoオブジェクトへ変換
        /// </summary>
        /// <param name="m_album"></param>
        /// <returns></returns>
        private Photo TableToPhoto(M_PHOTO m_photo)
        {
            var file = new File(m_photo.FilePath);
            var album = albumRepository.Find(allAlbum => allAlbum.FirstOrDefault(p => p.Id == m_photo.AlbumId.ToString()));
            return new Photo(m_photo.Id.ToString(), file, m_photo.IsFavorite, m_photo.AlbumId.ToString(), album);
        }

        /// <summary>
        /// 逆変換
        /// </summary>
        /// <param name="album"></param>
        /// <returns></returns>
        private M_PHOTO AlbumToTable(Photo photo)
        {
            var m_photo = new M_PHOTO();
            m_photo.Id = Guid.Parse(photo.Id);
            m_photo.FilePath = photo.File.FilePath;
            m_photo.IsFavorite = photo.IsFavorite;
            if (photo.AlbumId != null) m_photo.AlbumId = Guid.Parse(photo.AlbumId);

            return m_photo;
        }

        public void StoreIfNotExists(IEnumerable<Photo> photos)
        {
            // TODO: DBプログラミング講座で実装
            throw new NotImplementedException();
        }
    }
}
