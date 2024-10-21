using QuizTest.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace QuizTest.Repositories
{
    public class StaffRepository : IStaffRepository
    {
        public EmployeesContext employeesContext { get; set; }

        public StaffRepository(EmployeesContext employeesContext)
        {
            this.employeesContext = employeesContext;
        }

        public async Task<IEnumerable<Employee>> GetAllStaff()
        {
            return await employeesContext.Employees.ToListAsync();
        }

        public async Task<Employee> GetStaff(int id)
        {
            var employee = await employeesContext.Employees
                .Include(e => e.Department)
                .Include(e => e.Education).FirstOrDefaultAsync(e => e.EmployeeId == id);

            return employee;
        }

        public async Task UpdateStaff(int id, string name, string address, DateTime? startingDate, int? departmentId, int? educationId)
        {
            try
            {
                var updatedStaff = await employeesContext.Employees.FirstOrDefaultAsync(e => e.EmployeeId == id);
                if (updatedStaff == null)
                {
                    Console.WriteLine("No data found");
                    return;
                }

                updatedStaff.Name = name;
                updatedStaff.Address = address;
                updatedStaff.StartingDate = startingDate;
                updatedStaff.DepartmentId = departmentId;
                updatedStaff.EducationId = educationId;

                // Optional: Force the entity state to modified
                employeesContext.Entry(updatedStaff).State = EntityState.Modified;

                await employeesContext.SaveChangesAsync(); // Ensure changes are saved
                Console.WriteLine("Everything is updated");
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine($"Error updating database: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
            }

           
        }

        public async Task DeleteStaff(int id)
        {
            var staff = await GetStaff(id);
            employeesContext.Employees.Remove(staff);
            employeesContext.SaveChangesAsync();
            Console.WriteLine("Delete successfully");
        }

    }
}