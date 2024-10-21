using QuizTest.Models;

namespace QuizTest.Repositories
{
    public interface IStaffRepository
    {
        Task<IEnumerable<Employee>> GetAllStaff();

        Task<Employee> GetStaff(int id);

        Task UpdateStaff(int id, string name, string address, DateTime? startingDate, int? departmentId, int? educationId);

        Task DeleteStaff(int id);

    }
}