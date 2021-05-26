using CRM.BLL.DTO;
using CRM.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CRM.BLL.Interfaces
{
    public interface IQueueService
    {
        Task<IEnumerable<QueueDTO>> GetAllQueue();
        Task<QueueDTO> GetQueueById(Guid id);
        Task<int> CreateQueue(QueueDTO queueDTO);
        Task<int> UpdateQueue(QueueDTO queueDTO);
        Task<int> UpdateFullQueue(QueueDTO queueDTO);
        Task<int> DeleteQueue(Guid Id);
    }
}
