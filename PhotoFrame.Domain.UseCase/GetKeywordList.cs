using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoFrame.Domain.Model;

namespace PhotoFrame.Domain.UseCase
{
    public class GetKeywordList
    {

        private readonly IKeywordRepository _keywordRepository;

        public GetKeywordList(IKeywordRepository photoRepository)
        {
            _keywordRepository = photoRepository;
        }
        public IEnumerable<Keyword> Execute()
        {
            // 全アルバム名を取得
            return _keywordRepository.Find(albums => albums); 
        }
    }
}
