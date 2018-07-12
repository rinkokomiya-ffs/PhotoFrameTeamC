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
    /// <see cref="IKeywordRepository">の実装クラス
    /// </summary>
    class KeywordRepository : IKeywordRepository
    {
        private SqlProviderServices _sqlProviderServices;

        public KeywordRepository(SqlProviderServices sqlProviderServices)
        {
            _sqlProviderServices = sqlProviderServices;
        }

        public bool Exists(Keyword entity)
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
        public IEnumerable<Keyword> Find(Func<IQueryable<Keyword>, IQueryable<Keyword>> query)
            => query(FindAll());

        /// <summary>
        /// 引数のFunc<>の条件でデータ検索
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public Keyword Find(Func<IQueryable<Keyword>, Keyword> query)
            => query(FindAll());

        public Keyword FindBy(string id)
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
        public Keyword Store(Keyword entity)
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
        private IQueryable<Keyword> FindAll()
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
        private Keyword TableToAlbum(M_ALBUM m_album)
        {
            return new Keyword(m_album.Id.ToString(), m_album.Name, m_album.Descript);
        }

        /// <summary>
        /// 逆変換
        /// </summary>
        /// <param name="album"></param>
        /// <returns></returns>
        private M_ALBUM AlbumToTable(Keyword album)
        {
            var m_album = new M_ALBUM();
            m_album.Id = Guid.Parse(album.Id);
            m_album.Name = album.Name;
            m_album.Descript = album.Description;

            return m_album;
        }

    }
}
