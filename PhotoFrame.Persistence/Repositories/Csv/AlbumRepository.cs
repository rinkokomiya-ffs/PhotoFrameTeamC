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
    /// <see cref="IAlbumRepository">の実装クラス
    /// </summary>
    class AlbumRepository : IAlbumRepository
    {
        /// <summary>
        /// 永続化ストアとして利用するCSVファイルパス
        /// </summary>
        private string CsvFilePath { get; }

        public AlbumRepository(string databaseName)
        {
            this.CsvFilePath = $"{databaseName}_Album.csv"; // $"{...}" : 文字列展開

            if (!System.IO.File.Exists(CsvFilePath))
            {
                using (System.IO.File.CreateText(CsvFilePath)) { }
            }
        }

        public IEnumerable<Album> Find(Func<IQueryable<Album>, IQueryable<Album>> query)
            => query(FindAll().AsQueryable()).ToList();

        public Album Find(Func<IQueryable<Album>, Album> query)
            => query(FindAll().AsQueryable());

        public Album FindBy(string id)
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

        public bool Exists(Album entity) => ExistsBy(entity.Id);

        public bool ExistsBy(string id) => FindBy(id) != null;

        public Album Store(Album entity)
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

        // Album型のデータをCSVの1行に変換する
        private string Serialize(Album album)
            => $"{album.Id},{album.Name},{album.Description ?? ""}";

        // CSVの1行をAlbum型のデータに変換する
        private Album Deserialize(string csvRow)
        {
            var split = csvRow.Split(',');
            return new Album(split[0], split[1], split[2]);
        }

        // CSVの行データをすべて取得する
        private IEnumerable<Album> FindAll()
        {
            var result = new List<Album>();

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
