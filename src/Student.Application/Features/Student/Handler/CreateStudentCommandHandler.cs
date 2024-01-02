using AutoMapper;
using MediatR;
using Student.Application.Features.Student.Command;
using Student.Application.Features.Student.Query;
using Student.Application.View_Model;
using Student.Domain.Interface;
using Student.Domain.Models;
using Student.Domain.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Application.Features.Student.Handler
{
    public class CreateStudentCommandHandler:IRequestHandler<CreateStudentCommand, string>
    {
        #region Constructor
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;
        private readonly IMessageQueueService _messageQueueService;
        public CreateStudentCommandHandler(IStudentRepository studentRepository, IMapper mapper,IMessageQueueService messageQueueService)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
            _messageQueueService = messageQueueService;
        }
        #endregion
        #region Create new student
        public async Task<string> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            var studentEntity = _mapper.Map<Students>(request);
            var student= await _studentRepository.AddAsync(studentEntity);
            await _messageQueueService.SendMessageAsync(student);
            return student;
        }
        #endregion
    }
}
