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
    /// <see cref="IPhotoRepository">の実装クラス
    /// </summary>
    public class PhotoRepository : IPhotoRepository
    {
        /// <summary>
        /// 永続化ストアとして利用するCSVファイルパス
        /// </summary>
        private string CsvFilePath { get; }
        private IKeywordRepository keywordRepository;

        public PhotoRepository(string databaseName, IKeywordRepository keywordRepository)
        {
            this.CsvFilePath = $"{databaseName}_Photo.csv"; // $"{...}" : 文字列展開
            this.keywordRepository = keywordRepository;
        }

        public bool Exists(Photo entity)
        {
            // TODO: ファイルIO講座以降で実装可能
            throw new NotImplementedException();
        }

        public bool ExistsBy(string id)
        {
            // TODO: ファイルIO講座以降で実装可能
            throw new NotImplementedException();
        }


        public void StoreIfNotExists(IEnumerable<Photo> photos)
        {
            // TODO: ファイルIO講座以降で実装可能
            throw new NotImplementedException();
        }


        public IEnumerable<Photo> Find(Func<IQueryable<Photo>, IQueryable<Photo>> query)
        {
            if (FindAll() != null)
            {
                return query(FindAll().AsQueryable());
            }
            else
            {
                return new List<Photo>();
            }

        }
       

        public Photo Find(Func<IQueryable<Photo>, Photo> query)
        { 
            if(FindAll() != null)
            {
                return query(FindAll().AsQueryable());
            }
            else
            {
                return null;
            }
            
        }

        public Photo FindBy(string id)
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

        public Photo Store(Photo entity)
        {
            var serialized = Serialize(entity);
            var updated = false;
            var tmpFile = Path.GetTempFileName();

            if (System.IO.File.Exists(this.CsvFilePath))
            {
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
                      
            // 新規フォトデータを書き込み
            using (var writer = new StreamWriter(this.CsvFilePath, true))
            {
                writer.WriteLine(serialized);
            }

            return entity;
           
        }


        // CSVの行データをすべて取得する
        private IEnumerable<Photo> FindAll()
        {
            var result = new List<Photo>();

            if (System.IO.File.Exists(CsvFilePath))
            {
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
            else
            {
                // なかったよ
                return null;
            }

        }

        // Keyword型のデータをCSVの1行に変換する（＝シリアライズ）
        private string Serialize(Photo photo)
            => $"{photo.Id},{photo.File.FilePath},{photo.IsFavorite.ToString()},{photo.KeywordId ?? ""}";

        // CSVの1行をKeyword型のデータに変換する（＝デシリアライズ）
        private Photo Deserialize(string csvRow)
        {
            var split = csvRow.Split(',');
            var file = new Domain.Model.File(split[1]);
            var keyword = keywordRepository.FindBy(split[3]);
            var dateTime = new DateTime(1993, 05, 15, 15, 00, 00);
            return new Photo(split[0], file, dateTime, Convert.ToBoolean(split[2]), split[3], keyword);
        }

    }
}
