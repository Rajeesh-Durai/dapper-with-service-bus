using Student.Domain.Models;
namespace Student.Domain.Interface
{
    public interface IStudentRepository
    {
        Task<List<Students>> GetAllAsync();
        Task<string> AddAsync(Students student);
        Task<string> UpdateAsync(Students student);
        Task<string> DeleteAsync(int id);
    }
}
