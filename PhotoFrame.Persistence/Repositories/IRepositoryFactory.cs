﻿using PhotoFrame.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoFrame.Persistence
{
    public interface IRepositoryFactory
    {
        IKeywordRepository KeywordRepository { get; }
        IPhotoRepository PhotoRepository { get; }
    }
}
