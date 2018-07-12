using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoFrame.Domain.Model;

namespace PhotoFrame.Domain.UseCase
{
    public class SearchDirectory
    {
        private readonly IPhotoRepository photoRepository;
        private readonly IPhotoFileService photoFileService;

        public SearchDirectory(IPhotoRepository photoRepository, IPhotoFileService photoFileService)
        {
            this.photoRepository = photoRepository;
            this.photoFileService = photoFileService;
        }

        /// <summary>
        /// 指定したディレクトリ直下のフォトのリストを返す
        /// </summary>
        /// <param name="directoryName"></param>
        /// <returns></returns>
        public IEnumerable<Photo> Execute(string directoryName)
        {
            var files = photoFileService.FindAllPhotoFilesFromDirectory(directoryName);
            var photosInDirectory = new List<Photo>();

            foreach (var file in files)
            {
                Func<IQueryable<Photo>, Photo> query = allPhotos => allPhotos.FirstOrDefault(a => a.File.FilePath == file.FilePath);
               
                var hitPhoto = photoRepository.Find(query);

                if (hitPhoto != null)
                {
                    photosInDirectory.Add(hitPhoto);
                }
                else
                {
                    photosInDirectory.Add(Photo.CreateFromFile(file));
                }
            }

            return photosInDirectory;
        }

        /// <summary>
        /// 非同期処理
        /// </summary>
        /// <param name="directoryName"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Photo>> ExecuteAsync(string directoryName)
        {
            var files = photoFileService.FindAllPhotoFilesFromDirectory(directoryName);
            var photosInDirectory = await Task.Run(() =>
            {
                var photosList = new List<Photo>();
                foreach (var file in files)
                {
                    Func<IQueryable<Photo>, Photo> query = allPhotos => allPhotos.FirstOrDefault(a => a.File.FilePath == file.FilePath);

                    var hitPhoto = photoRepository.Find(query);

                    if (hitPhoto != null)
                    {
                        photosList.Add(hitPhoto);
                    }
                    else
                    {
                        photosList.Add(Photo.CreateFromFile(file));
                    }
                }

                return photosList;
            });
            
            return photosInDirectory;
        }
    }
}
