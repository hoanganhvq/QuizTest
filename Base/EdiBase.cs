using QuizTest.Models;
using QuizTest.Repositories;
using Microsoft.AspNetCore.Components;

namespace QuizTest.Base
{
    public class EditBase : ComponentBase
    {
        public Employee staff { get; set; } = new Employee();

        [Inject]
        public IStaffRepository staffRepository { get; set; }

        [Parameter]
        public string Id { get; set; }

        protected override async Task OnInitializedAsync()
        {
            staff = await staffRepository.GetStaff(int.Parse(Id)); // Fetch the employee
        }

        public async Task UpdateStaff()
        {
            await staffRepository.UpdateStaff(staff.EmployeeId, staff.Name, staff.Address, staff.StartingDate, staff.EducationId, staff.DepartmentId);
        }
    }

}