﻿using PhotoFrame.Domain.Model;
using PhotoFrame.Persistence.EF;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.SqlServer;

namespace PhotoFrame.Persistence
{
    public enum Type { Csv, EF }

    /// <summary>
    /// 永続化ストアに応じたリポジトリセットを提供するファクトリ
    /// </summary>
    public class RepositoryFactory : IRepositoryFactory
    {
        // ストア名称
        //   App.config（アプリケーション構成ファイル）に定義した文字列を引く
        private static readonly string DatabaseName = ConfigurationManager.AppSettings["DatabaseName"];

        private readonly Type type;

        public IKeywordRepository KeywordRepository { get; }
        public IPhotoRepository PhotoRepository { get; }

        public RepositoryFactory(Type t)
        {
            this.type = t;
            switch (type)
            {
                case Type.Csv:
                    KeywordRepository = new Csv.KeywordRepository(DatabaseName);
                    PhotoRepository = new Csv.PhotoRepository(DatabaseName, KeywordRepository);
                    break;
                case Type.EF:
                    // TODO: EFに適した生成に変更してください
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
