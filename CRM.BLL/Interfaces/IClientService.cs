using CRM.BLL.DTO;
using System;
using System.Collections.Generic;

namespace CRM.BLL.Interfaces
{
    public interface IClientService
    {
        public List<KohonenaDTO> NeuronKohonena(/*DateTime dateFrom, DateTime dateTo*/);
        public IEnumerable<ClientRFMAnalysisDTO> ContactRFMAnalysis(/*DateTime dateFrom, DateTime dateTo*/);
    }
}