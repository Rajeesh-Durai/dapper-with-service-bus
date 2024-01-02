using MediatR;

namespace Student.Application.Features.Student.Command
{
    public class DeleteStudentCommand: IRequest<string>
    {
        public int StudentId { get; set; }
    }
}
