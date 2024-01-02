using AutoMapper;
using MediatR;
using Student.Application.Features.Student.Query;
using Student.Application.View_Model;
using Student.Domain.Interface;
using Student.Domain.Models;
using Student.Domain.Service;

namespace Student.Application.Features.Student.Handler
{
    public class GetStudentQueryHandler:IRequestHandler<GetStudentsQuery,List<StudentResponse>>
    {
        #region Constructor
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;
        private readonly IMessageQueueService _messageQueueService;
        public GetStudentQueryHandler(IStudentRepository studentRepository, IMapper mapper, IMessageQueueService messageQueueService)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
            _messageQueueService = messageQueueService;
        }
        #endregion
        #region Get all Students
        public async Task<List<StudentResponse>> Handle(GetStudentsQuery request,CancellationToken cancellationToken )
        {
            List < Students> students= await _studentRepository.GetAllAsync();
            await _messageQueueService.SendAllMessageAsync(students);
            return _mapper.Map<List<StudentResponse>>(students);
        }
        #endregion
    }
}
