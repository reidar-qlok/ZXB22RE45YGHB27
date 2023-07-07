using ZXB22RE45YGHB27.Data;
using ZXB22RE45YGHB27.Models;
using Microsoft.EntityFrameworkCore;

namespace ZXB22RE45YGHB27.Repositories
{
    internal static class ProjectRepository
    {
        internal async static Task<List<Project>> GetProjectAsync()
        {
            using (var db = new AppDbContext())
            {
                return await db.Projects.ToListAsync();
            }
        }
        internal async static Task<Project> GetProjectByIdAsync(int projectId)
        {
            using (var db = new AppDbContext())
            {
                return await db.Projects.FirstOrDefaultAsync(p => p.ProjectId == projectId);
            }
        }
        internal static async Task<bool> CreateProjectAsync(Project projectToCreate)
        {
            using (var db = new AppDbContext())
            {
                try
                {
                    await db.Projects.AddAsync(projectToCreate);
                    return await db.SaveChangesAsync() <= 1;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
        internal static async Task<bool> UpdateProjectAsync(Project projectToUpdate)
        {
            using (var db = new AppDbContext())
            {
                try
                {
                    db.Projects.Update(projectToUpdate);
                    return await db.SaveChangesAsync() <= 1;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
        internal static async Task<bool> DeleteProjectAsync(int projectId)
        {
            using (var db = new AppDbContext())
            {
                try
                {
                    Project projectToDelete = await GetProjectByIdAsync(projectId);
                    db.Remove(projectToDelete);
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
