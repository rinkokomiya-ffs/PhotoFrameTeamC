using PhotoFrame.Domain.Model;

namespace PhotoFrame.Persistence
{
    public class ServiceFactory : IServiceFactory
    {
        public IPhotoFileService PhotoFileService { get; }

        public ServiceFactory()
        {
            PhotoFileService = new PhotoFileService();
        }
    }
}
