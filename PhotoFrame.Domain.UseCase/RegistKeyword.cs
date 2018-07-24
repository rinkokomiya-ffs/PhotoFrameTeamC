using PhotoFrame.Domain.Model;
using System.Linq;

namespace PhotoFrame.Domain.UseCase
{
    /// <summary>
    /// アルバムを作成するユースケースを実現する
    /// </summary>
    public class RegistKeyword
    {
        private readonly IKeywordRepository _keywordRepository;

        public RegistKeyword(IKeywordRepository keywordRepository)
        {
            _keywordRepository = keywordRepository;
        }

        /// <summary>
        /// アルバムの登録
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns>終了状態を数値で返す</returns>
        public int Execute(string keywordName)
        {
            var result = _keywordRepository.Find(keywords => keywords.SingleOrDefault(keyword => keyword.Name == keywordName));

            // 登録済みのアルバム名でない場合
            if (result == null)
            {
                var keyword = Keyword.Create(keywordName);
                _keywordRepository.Store(keyword);

                // 正常終了
                return 0;
            }
            else
            {
                // 既存のアルバム名
                return 1;
            }
        }
    }
}
