using MediatR;
using Student.Application.Exception;
using Student.Application.Features.Student.Command;
using Student.Domain.Interface;
using Student.Domain.Models;
using Student.Domain.Service;

namespace Student.Application.Features.Student.Handler
{
    public class DeleteStudentCommandHandler  : IRequestHandler<DeleteStudentCommand,string>
    {
        #region Constructor
        private readonly IStudentRepository _studentRepository;
        private readonly IMessageQueueService _messageQueueService;
        public DeleteStudentCommandHandler(IStudentRepository studentRepository, IMessageQueueService messageQueueService)
        {
            _studentRepository = studentRepository;
            _messageQueueService = messageQueueService;
        }
        #endregion
        #region Delete student by id
        public async Task<string> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            var student= await _studentRepository.DeleteAsync(request.StudentId);
            if(student==null)
            {
                throw new StudentNotFoundException(nameof(Students), request.StudentId);
            }
            await _messageQueueService.SendMessageAsync(student);
            return student;
        }
        #endregion
    }
}
