﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VuelingFinalExam.DomainModel.Entites;

namespace VuelingFinalExam.ApplicationService.Contracts
{
    public interface ISpyReportService
    {
        Task<IEnumerable<SpyReport>> GetAllClientsAsync();
        Task<SpyReport> AddClientAsync(SpyReport spyReport);
    }
}
