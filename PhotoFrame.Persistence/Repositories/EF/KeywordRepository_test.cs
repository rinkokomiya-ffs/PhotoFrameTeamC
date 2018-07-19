using PhotoFrame.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.SqlServer;
using PhotoFrame.Persistence.Repositories;


namespace PhotoFrame.Persistence.EF
{
    class KeywordRepository_test: IKeywordRepository
    {
      
        private List<Keyword> keywordList;
        private SqlProviderServices _sqlProviderServices;
        public KeywordRepository_test(SqlProviderServices sqlProviderServices)
        {           
            keywordList = new List<Keyword>();
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
            => query(keywordList.AsQueryable());

        /// <summary>
        /// 引数のFunc<>の条件でデータ検索
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public Keyword Find(Func<IQueryable<Keyword>, Keyword> query)
            => query(keywordList.AsQueryable());

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
            var keyword = entity;

            var searchedKeyword = keywordList.SingleOrDefault(p => p.Id == keyword.Id);

            if (searchedKeyword == null)
            {
                keywordList.Add(keyword);
            }
            else
            {
                keywordList.Remove(searchedKeyword);
                keywordList.Add(entity);
            }
           
            return entity;
          
        }

    }
}
