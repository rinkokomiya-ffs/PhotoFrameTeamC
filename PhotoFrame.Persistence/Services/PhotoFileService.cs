using PhotoFrame.Domain.Model;
using System.Collections.Generic;
using System.IO;

namespace PhotoFrame.Persistence
{
    /// <summary>
    /// <see cref="IPhotoFileService">の実装クラス
    /// </summary>
    class PhotoFileService : IPhotoFileService
    {
        // 定数
        // キーワード登録上限値
        private readonly int MAX_REGIST_IMAGE = 100;

        public IEnumerable<Domain.Model.File> FindAllPhotoFilesFromDirectory(string directory)
        {
            List<Domain.Model.File> fileList = null;

            // directoryが存在する場合
            if (Directory.Exists(directory))
            {
                fileList = new List<Domain.Model.File>();
                string[] pathList = Directory.GetFiles(directory);

                foreach (string filePath in pathList)
                {
                    Domain.Model.File file = new Domain.Model.File(filePath);

                    if (file.IsPhoto)
                    {
                        fileList.Add(file);
                    }
                    if (fileList.Count >= MAX_REGIST_IMAGE) break;
                }

            }
            return fileList;
        }
    }
}
