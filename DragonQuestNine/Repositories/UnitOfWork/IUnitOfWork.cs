﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DragonQuestNine.Repositories.UnitOfWork
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}
