using AutoMapper;
using MediatR;
using Student.Application.Features.Student.Command;
using Student.Domain.Interface;
using Student.Domain.Models;
using Student.Domain.Service;

namespace Student.Application.Features.Student.Handler
{
    public class UpdateStudentCommandHandler:IRequestHandler<UpdateStudentCommand,string>
    {
        #region Constructor
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;
        private readonly IMessageQueueService _messageQueueService;
        public UpdateStudentCommandHandler(IStudentRepository studentRepository, IMapper mapper, IMessageQueueService messageQueueService)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
            _messageQueueService = messageQueueService;
        }
        #endregion
        #region Update existing student
        public async Task<string> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            var studentEntity = _mapper.Map<Students>(request);
            var student= await _studentRepository.UpdateAsync(studentEntity);
            await _messageQueueService.SendMessageAsync(student);
            return student;
        }
        #endregion
    }
}
