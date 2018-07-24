using PhotoFrame.Domain.Model;

namespace PhotoFrame.Persistence
{
    public interface IRepositoryFactory
    {
        IKeywordRepository KeywordRepository { get; }
        IPhotoRepository PhotoRepository { get; }
    }
}
