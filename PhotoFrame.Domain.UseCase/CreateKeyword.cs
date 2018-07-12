using PhotoFrame.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PhotoFrame.Domain.UseCase
{
    /// <summary>
    /// アルバムを作成するユースケースを実現する
    /// </summary>
    // TODO: 仮実装
    public class CreateKeyword
    {
        private readonly IKeywordRepository albumRepository;
        
        public CreateKeyword(IKeywordRepository albumRepository)
        {
            this.albumRepository = albumRepository;
          
        }

        /// <summary>
        /// アルバムの登録
        /// </summary>
        /// <param name="albumName"></param>
        /// <returns>終了状態を数値で返す</returns>
        public int Execute(string albumName)
        {
            IEnumerable<Keyword> result = albumRepository.Find((IQueryable<Keyword> albums) => (from p in albums where p.Name == albumName select p));

            if (albumName != "")
            {
                // 登録済みのアルバム名でない場合
                if (result == null || result.Count() == 0)
                {

                    var album = Keyword.Create(albumName);
                    albumRepository.Store(album);

                    // 正常終了
                    return 0;
                }
                else
                {
                    // 既存のアルバム名
                    return 2;
                }
            }
            else
            {
                // アルバム名未入力
                return 1;
            }

        }

        /// <summary>
        /// 非同期処理用
        /// </summary>
        /// <param name="albumName"></param>
        /// <returns></returns>
        public async Task<int> ExecuteAsync(string albumName)
        {
            var judgement = await Task.Run(() =>
            {
                IEnumerable<Keyword> result = albumRepository.Find((IQueryable<Keyword> albums) => (from p in albums where p.Name == albumName select p));

                if (albumName != "")
                {
                    // 登録済みのアルバム名でない場合
                    if (result == null || result.Count() == 0)
                    {

                        var album = Keyword.Create(albumName);
                        albumRepository.Store(album);

                        // 正常終了
                        return 0;
                    }
                    else
                    {
                        // 既存のアルバム名
                        return 2;
                    }
                }
                else
                {
                    // アルバム名未入力
                    return 1;
                }

            });

            return judgement;
        }

    }
    
}
