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
    /// <see cref="IAlbumRepository">の実装クラス
    /// </summary>
    class AlbumRepository : IAlbumRepository
    {
        private SqlProviderServices _sqlProviderServices;

        public AlbumRepository(SqlProviderServices sqlProviderServices)
        {
            _sqlProviderServices = sqlProviderServices;
        }

        public bool Exists(Album entity)
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
        /// 引数のFunc<>の条件で複数データ検索
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public IEnumerable<Album> Find(Func<IQueryable<Album>, IQueryable<Album>> query)
            => query(FindAll());

        /// <summary>
        /// 引数のFunc<>の条件でデータ検索
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public Album Find(Func<IQueryable<Album>, Album> query)
            => query(FindAll());

        public Album FindBy(string id)
        {
            // TODO: DBプログラミング講座で実装
            throw new NotImplementedException();
        }

        /// <summary>
        /// アルバム保存
        /// 同じIDがあったら保存しないで更新
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public Album Store(Album entity)
        {
            // TODO: DBプログラミング講座で実装
            var album = AlbumToTable(entity);
          
            using (var photoFrameEntity = new PhotoFrameDBEntities())
            {
                // トランザクション作成
                using (var transaction = photoFrameEntity.Database.BeginTransaction())
                {
                    try
                    {
                        var searchedAlbum = photoFrameEntity.M_ALBUM.SingleOrDefault(p => p.Id == album.Id);

                        if (searchedAlbum == null)
                        {
                            photoFrameEntity.M_ALBUM.Add(album);
                        }
                        else
                        {
                            searchedAlbum.Name = album.Name;
                            searchedAlbum.Descript = album.Descript;
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
        private IQueryable<Album> FindAll()
        {
            using (var photoFrameEntity = new PhotoFrameDBEntities())
            {
                var albums  = from p in photoFrameEntity.M_ALBUM.ToList() select TableToAlbum(p);
                return albums.AsQueryable();
            }
        }

        /// <summary>
        /// DBのテーブルデータからAlbumオブジェクトへ変換
        /// </summary>
        /// <param name="m_album"></param>
        /// <returns></returns>
        private Album TableToAlbum(M_ALBUM m_album)
        {
            return new Album(m_album.Id.ToString(), m_album.Name, m_album.Descript);
        }

        /// <summary>
        /// 逆変換
        /// </summary>
        /// <param name="album"></param>
        /// <returns></returns>
        private M_ALBUM AlbumToTable(Album album)
        {
            var m_album = new M_ALBUM();
            m_album.Id = Guid.Parse(album.Id);
            m_album.Name = album.Name;
            m_album.Descript = album.Description;

            return m_album;
        }

    }
}
