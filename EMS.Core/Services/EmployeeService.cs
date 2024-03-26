using EMS.Core.Data;
using EMS.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace EMS.Core.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly AppDbContext _dbContext;
        public EmployeeService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddEmployee(Employee employee)
        {
            employee.Id = Guid.NewGuid();
            await _dbContext.Employees.AddAsync(employee);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Employee>> GetAllEmployees()
        {
            return await _dbContext.Employees.ToListAsync();   
        }

        public async Task<Employee> GetEmployeeById(Guid id)
        {
            return await _dbContext.Employees.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateEmployeeById(Guid id, Employee employeeUpdateRequestModel)
        {
            var employee = await _dbContext.Employees.FindAsync(id);
            employee.Name = employeeUpdateRequestModel.Name;
            employee.Email = employeeUpdateRequestModel.Email;
            employee.Phone = employeeUpdateRequestModel.Phone;
            employee.Salary = employeeUpdateRequestModel.Salary;
            employee.Department = employeeUpdateRequestModel.Department;
            await _dbContext.SaveChangesAsync();
        }
        public async Task DeleteEmployee(Guid id)
        {
            var employee = await _dbContext.Employees.FindAsync(id);
            _dbContext.Employees.Remove(employee);
            await _dbContext.SaveChangesAsync();
        }
    }
}
