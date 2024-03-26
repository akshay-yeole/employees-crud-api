using EMS.Core.Models;

namespace EMS.Core.Services
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetAllEmployees();
        Task AddEmployee(Employee employee);
        Task<Employee> GetEmployeeById(Guid id);
        Task UpdateEmployeeById(Guid id, Employee employeeUpdateRequestModel);
        Task DeleteEmployee(Guid id);
    }
}
