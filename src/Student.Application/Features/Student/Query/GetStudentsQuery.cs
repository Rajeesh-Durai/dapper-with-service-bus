using MediatR;
using Student.Application.View_Model;
namespace Student.Application.Features.Student.Query
{
    public class GetStudentsQuery : IRequest<List<StudentResponse>>
    {
    }
}
