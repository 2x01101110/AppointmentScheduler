﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BuildingBlocks.Infrastructure.Idempotency
{
    public class IdempotentCommandRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime Time { get; set; }
    }
}
