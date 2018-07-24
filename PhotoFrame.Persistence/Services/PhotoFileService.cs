﻿using PhotoFrame.Domain.Model;
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
            // TODO: コレクション講座で実装予定
            List<Domain.Model.File> file_list = null;

            // directoryが存在する場合
            if (Directory.Exists(directory))
            {
                file_list = new List<Domain.Model.File>();
                string[] path_list = Directory.GetFiles(directory);

                foreach (string filePath in path_list)
                {
                    Domain.Model.File file = new Domain.Model.File(filePath);

                    if (file.IsPhoto)
                    {
                        file_list.Add(file);
                    }
                    if (file_list.Count >= MAX_REGIST_IMAGE) break;
                }

            }
            return file_list;
        }
    }
}
