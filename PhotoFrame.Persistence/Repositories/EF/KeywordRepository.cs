
using PhotoFrame.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.SqlServer;
using PhotoFrame.Persistence.Repositories.EF;

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
            var keyword = KeywordToTable(entity);
          
            using (var photoFrameEntity = new PhotoFrameTeamCEntities2())
            {
                // トランザクション作成
                using (var transaction = photoFrameEntity.Database.BeginTransaction())
                {
                    try
                    {
                        var searchedKeyword = photoFrameEntity.m_Keyword.SingleOrDefault(p => p.Id == keyword.Id);

                        if (searchedKeyword == null)
                        {
                            photoFrameEntity.m_Keyword.Add(keyword);
                        }
                        else
                        {
                            searchedKeyword.Name = keyword.Name;
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
            using (var photoFrameEntity = new PhotoFrameTeamCEntities2())
            {
                var keywords = from p in photoFrameEntity.m_Keyword.ToList() select TableToKeyword(p);
                return keywords.AsQueryable();
            }
        }

        /// <summary>
        /// DBのテーブルデータからKeywordオブジェクトへ変換
        /// </summary>
        /// <param name="m_keyword"></param>
        /// <returns></returns>
        private Keyword TableToKeyword(m_Keyword m_keyword)
        {
            return new Keyword(m_keyword.Id.ToString(), m_keyword.Name);
        }

        /// <summary>
        /// 逆変換
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        private m_Keyword KeywordToTable(Keyword keyword)
        {
            var m_keyword = new m_Keyword();
            m_keyword.Id = Guid.Parse(keyword.Id);
            m_keyword.Name = keyword.Name;

            return m_keyword;
        }

    }
}
