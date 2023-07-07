using ZXB22RE45YGHB27.Data;
using ZXB22RE45YGHB27.Models;
using Microsoft.EntityFrameworkCore;

namespace ZXB22RE45YGHB27.Repositories
{
    internal static class ProjectListRepository
    {

        internal async static Task<List<ProjectList>> GetProjectListAsync()
        {
            using (var db = new AppDbContext())
            {
                return await db.ProjectLists.ToListAsync();
            }
        }
        internal async static Task<ProjectList> GetProjectListByIdAsync(int projectListId)
        {
            using (var db = new AppDbContext())
            {
                return await db.ProjectLists.FirstOrDefaultAsync(p => p.ProjectListId == projectListId);
            }
        }
        internal static async Task<bool> CreateProjectListAsync(ProjectList projectListToCreate)
        {
            using (var db = new AppDbContext())
            {
                try
                {
                    await db.ProjectLists.AddAsync(projectListToCreate);
                    return await db.SaveChangesAsync() <= 1;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
        internal static async Task<bool> UpdateProjectListAsync(ProjectList projectListToUpdate)
        {
            using (var db = new AppDbContext())
            {
                try
                {
                    db.ProjectLists.Update(projectListToUpdate);
                    return await db.SaveChangesAsync() <= 1;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
        internal static async Task<bool> DeleteProjectListAsync(int projectListId)
        {
            using (var db = new AppDbContext())
            {
                try
                {
                    ProjectList projectListToDelete = await GetProjectListByIdAsync(projectListId);
                    db.Remove(projectListToDelete);
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
