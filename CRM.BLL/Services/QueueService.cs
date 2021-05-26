 using AutoMapper;
using CRM.BLL.DTO;
using CRM.BLL.Interfaces;
using CRM.DAL;
using CRM.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRM.BLL.Services
{
    public class QueueService: IQueueService
    {
        private readonly CrmDbContext db;
        private readonly IMapper _mapper;
        public QueueService(CrmDbContext _crmDbContext, IMapper mapper)
        {
            db = _crmDbContext;
            _mapper = mapper;
        }
        public async Task<IEnumerable<QueueDTO>> GetAllQueue()
        {
            var queues = await db.Queues.ToListAsync();
            return _mapper.Map<IEnumerable<QueueDTO>>(queues);
        }
        public async Task<QueueDTO> GetQueueById(Guid id)
        {
            var queue = await db.Queues.FirstOrDefaultAsync(c => c.Id == id);
            return _mapper.Map<QueueDTO>(queue);
        }
        public async Task<int> CreateQueue(QueueDTO queueDTO)
        {
            var queue = _mapper.Map<Queue>(queueDTO);
            await db.Queues.AddAsync(queue);

            return await db.SaveChangesAsync();
        }
        public async Task<int> UpdateQueue(QueueDTO queueDTO)
        {
            var queueMapper = _mapper.Map<Queue>(queueDTO);

            var queue = await db.Queues.FirstOrDefaultAsync(c => c.Id == queueMapper.Id);
            if (queue == null) throw new Exception("Queue not found");

            queue.TelephoneNumber = queueDTO.TelephoneNumber != null ? queueDTO.TelephoneNumber : queue.TelephoneNumber;
            queue.DateTimeStartCall = queueDTO.DateTimeStartCall != null ? queueDTO.DateTimeStartCall : queue.DateTimeStartCall;
            queue.TimeWait = queueDTO.TimeWait != null ? queueDTO.TimeWait : queue.TimeWait;
            queue.DateStartAnswer = queueDTO.DateStartAnswer != null ? queueDTO.DateStartAnswer : queue.DateStartAnswer;
            queue.DateEndAnswer = queueDTO.DateEndAnswer != null ? queueDTO.DateEndAnswer : queue.DateEndAnswer;
            queue.ResponsibleId = queueDTO.ResponsibleId != null ? queueDTO.ResponsibleId : queue.ResponsibleId;
            queue.Description = queueDTO.Description != null ? queueDTO.Description : queue.Description;

            return await db.SaveChangesAsync();
        }
        public async Task<int> UpdateFullQueue(QueueDTO queueDTO)
        {
            var queueMapper = _mapper.Map<Queue>(queueDTO);

            var queue = await db.Queues.FirstOrDefaultAsync(c => c.Id == queueMapper.Id);
            if (queue == null) throw new Exception("Queue not found");

            queue.TelephoneNumber = queueDTO.TelephoneNumber;
            queue.DateTimeStartCall = queueDTO.DateTimeStartCall;
            queue.TimeWait = queueDTO.TimeWait;
            queue.DateStartAnswer = queueDTO.DateStartAnswer;
            queue.DateEndAnswer = queueDTO.DateEndAnswer;
            queue.ResponsibleId = queueDTO.ResponsibleId;
            queue.Description = queueDTO.Description;

            return await db.SaveChangesAsync();
        }
        public async Task<int> DeleteQueue(Guid Id)
        {
            var queue = await db.Queues.FirstOrDefaultAsync(c => c.Id == Id);
            if (queue == null) throw new Exception("Queue not found");

            db.Queues.Remove(queue);

            return await db.SaveChangesAsync();
        }

    }
}
