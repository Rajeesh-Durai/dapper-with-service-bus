using Student.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Domain.Service
{
    public interface IMessageQueueService
    {
        Task SendMessageAsync(string message);
        Task SendAllMessageAsync(List<Students> message);
    }
}
