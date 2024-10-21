using Microsoft.AspNetCore.Components;
using QuizTest.Models;
using QuizTest.Repositories;


namespace QuizTest.Base
{
    public class StaffListBase : ComponentBase
    {
        public IEnumerable<Employee> staffs { get; set; }

        [Inject]

        public IStaffRepository staffRepositoy { get; set; }

        protected override async Task OnInitializedAsync()
        {
            staffs = await staffRepositoy.GetAllStaff();
        }

        public async Task DeleteStaff(int id)
        {
            await staffRepositoy.DeleteStaff(id);
        }
    }
}