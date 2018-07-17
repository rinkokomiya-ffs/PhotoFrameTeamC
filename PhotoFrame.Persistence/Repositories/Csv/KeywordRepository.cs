using PhotoFrame.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PhotoFrame.Persistence.Csv
{
    /// <summary>
    /// <see cref="IKeywordRepository">の実装クラス
    /// </summary>
    class KeywordRepository : IKeywordRepository
    {
        /// <summary>
        /// 永続化ストアとして利用するCSVファイルパス
        /// </summary>
        private string CsvFilePath { get; }

        public KeywordRepository(string databaseName)
        {
            this.CsvFilePath = $"{databaseName}_Keyword.csv"; // $"{...}" : 文字列展開

            if (!System.IO.File.Exists(CsvFilePath))
            {
                using (System.IO.File.CreateText(CsvFilePath)) { }
            }
        }

        public IEnumerable<Keyword> Find(Func<IQueryable<Keyword>, IQueryable<Keyword>> query)
            => query(FindAll().AsQueryable()).ToList();

        public Keyword Find(Func<IQueryable<Keyword>, Keyword> query)
            => query(FindAll().AsQueryable());

        public Keyword FindBy(string id)
        {
            using (var reader = new StreamReader(CsvFilePath, Encoding.UTF8))
            {
                while (reader.Peek() >= 0)
                {
                    var row = reader.ReadLine();
                    var entity = Deserialize(row);
                    if (entity.Id == id)
                    {
                        return entity;
                    }
                }
            }
            return null;
        }

        public bool Exists(Keyword entity) => ExistsBy(entity.Id);

        public bool ExistsBy(string id) => FindBy(id) != null;

        public Keyword Store(Keyword entity)
        {
            var serialized = Serialize(entity);
            var updated = false;
            var tmpFile = Path.GetTempFileName();

            using (var reader = new StreamReader(CsvFilePath, Encoding.UTF8))
            using (var writer = new StreamWriter(tmpFile, false, Encoding.UTF8))
            {
                while (reader.Peek() >= 0)
                {
                    var row = reader.ReadLine();
                    var deserialized = Deserialize(row);
                    if (deserialized.Id == entity.Id)
                    {
                        // 更新
                        updated = true;
                        writer.WriteLine(serialized);
                        continue;
                    }
                    else
                    {
                        writer.WriteLine(row);
                    }
                }

                if (!updated)
                {
                    // 追加
                    writer.WriteLine(serialized);
                }
            }

            System.IO.File.Copy(tmpFile, CsvFilePath, true);
            System.IO.File.Delete(tmpFile);

            return entity;
        }

        // Keyword型のデータをCSVの1行に変換する
        private string Serialize(Keyword keyword)
            => $"{keyword.Id},{keyword.Name}";

        // CSVの1行をKeyword型のデータに変換する
        private Keyword Deserialize(string csvRow)
        {
            var split = csvRow.Split(',');
            return new Keyword(split[0], split[1]);
        }

        // CSVの行データをすべて取得する
        private IEnumerable<Keyword> FindAll()
        {
            var result = new List<Keyword>();

            using (var reader = new StreamReader(CsvFilePath, Encoding.UTF8))
            {
                while (reader.Peek() >= 0)
                {
                    var row = reader.ReadLine();
                    var entity = Deserialize(row);
                    result.Add(entity);
                }
            }

            return result;
        }
      

    }
}
