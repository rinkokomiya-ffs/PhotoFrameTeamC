using System.Collections.Generic;

namespace PhotoFrame.Domain.Model
{
    /// <summary>
    /// ファイルディレクトリ中の写真ファイルを扱うサービスインターフェース
    /// </summary>
    public interface IPhotoFileService
    {
        IEnumerable<File> FindAllPhotoFilesFromDirectory(string directory);
    }
}
