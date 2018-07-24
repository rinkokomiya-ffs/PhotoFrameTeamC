using PhotoFrame.Domain.Model;

namespace PhotoFrame.Persistence
{
    public interface IServiceFactory
    {
        IPhotoFileService PhotoFileService { get; }
    }
}
