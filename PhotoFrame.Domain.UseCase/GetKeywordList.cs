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

        private readonly IKeywordRepository keywordRepository;

        public GetKeywordList(IKeywordRepository repository)
        {
            this.keywordRepository = repository;
        }
        public IEnumerable<Keyword> Execute()
        {
            // 全アルバム名を取得
            return keywordRepository.Find((IQueryable<Keyword> albums) => albums); 
        }
    }
}
