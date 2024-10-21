using QuizTest.Models;
using QuizTest.Repositories;
using Microsoft.AspNetCore.Components;
namespace QuizTest.Base
{
    public class StaffDetailBase : ComponentBase
    {
        public Employee staff { get; set; } = new Employee();
        [Inject]
        public IStaffRepository staffRepository {  get; set; }

        [Parameter]
        public string Id {  get; set; }

        protected override async Task OnInitializedAsync()
        {
            Id = Id ?? "1";
            staff = await staffRepository.GetStaff(int.Parse(Id));
        }

        public async Task DeleteStaff()
        {
            await staffRepository.DeleteStaff(int.Parse(Id));
        }
    }
}