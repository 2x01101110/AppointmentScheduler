﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.Infrastructure.Idempotency
{
    public interface IRequestManager
    {
        Task<bool> ExistsAsync(Guid id);
        Task CreateRequestForCommandAsync<T>(Guid id);
    }
}
