using ZXB22RE45YGHB27.Data;
using ZXB22RE45YGHB27.Models;
using Microsoft.EntityFrameworkCore;

namespace ZXB22RE45YGHB27.Repositories
{
    internal static class EmployeeRepository
    {

        internal async static Task<List<Employee>> GetEmployeeAsync()
        {
            using (var db = new AppDbContext())
            {
                return await db.Employees.ToListAsync();
            }
        }
        internal async static Task<Employee> GetEmployeeByIdAsync(int employeeId)
        {
            using (var db = new AppDbContext())
            {
                return await db.Employees.FirstOrDefaultAsync(p => p.EmployeeId == employeeId);
            }
        }
        internal static async Task<bool> CreateEmployeeAsync(Employee employeeToCreate)
        {
            using (var db = new AppDbContext())
            {
                try
                {
                    await db.Employees.AddAsync(employeeToCreate);
                    return await db.SaveChangesAsync() <= 1;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
        internal static async Task<bool> UpdateEmployeeAsync(Employee employeeToUpdate)
        {
            using (var db = new AppDbContext())
            {
                try
                {
                    db.Employees.Update(employeeToUpdate);
                    return await db.SaveChangesAsync() <= 1;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
        internal static async Task<bool> DeleteEmployeeAsync(int employeeId)
        {
            using (var db = new AppDbContext())
            {
                try
                {
                    Employee employeeToDelete = await GetEmployeeByIdAsync(employeeId);
                    db.Remove(employeeToDelete);
                    return await db.SaveChangesAsync() <= 1;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
    }
}
