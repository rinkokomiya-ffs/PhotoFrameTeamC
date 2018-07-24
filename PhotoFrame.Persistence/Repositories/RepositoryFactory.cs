using PhotoFrame.Domain.Model;
using System;
using System.Configuration;
using System.Data.Entity.SqlServer;

namespace PhotoFrame.Persistence
{
    public enum Type { EF }

    /// <summary>
    /// 永続化ストアに応じたリポジトリセットを提供するファクトリ
    /// </summary>
    public class RepositoryFactory : IRepositoryFactory
    {
        // ストア名称
        //  App.config（アプリケーション構成ファイル）に定義した文字列を引く
        private static readonly string DatabaseName = ConfigurationManager.AppSettings["DatabaseName"];

        private readonly Type type;

        public IKeywordRepository KeywordRepository { get; }
        public IPhotoRepository PhotoRepository { get; }

        public RepositoryFactory(Type t)
        {
            this.type = t;
            switch (type)
            {
                case Type.EF:
                    SqlProviderServices sqlProviderServices = SqlProviderServices.Instance;
                    KeywordRepository = new EF.KeywordRepository(sqlProviderServices);
                    PhotoRepository = new EF.PhotoRepository(KeywordRepository, sqlProviderServices);
                    break;
                default:
                    throw new ArgumentException("The specified type is not supported.");
            }
        }
    }
}
