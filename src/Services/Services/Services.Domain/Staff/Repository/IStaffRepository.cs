﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Domain.Staff.Repository
{
    public interface IStaffRepository
    {
        Task<Staff> GetStaffAsync(Guid id);
        void AddStaff(Staff staff);
        void UpdateStaff(Staff staff);
    }
}