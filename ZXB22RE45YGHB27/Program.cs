using Microsoft.OpenApi.Models;
using ZXB22RE45YGHB27.Models;
using ZXB22RE45YGHB27.Repositories;

namespace ZXB22RE45YGHB27
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(swaggerGenOptions =>
            {
                swaggerGenOptions.SwaggerDoc(name: "v1", info: new OpenApiInfo { Title = "Asp.Net Core Swagger API", Version = "v2" });
            });

            builder.Services.AddCors();
            var app = builder.Build();
            app.UseCors(builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
            );
            app.UseSwagger();
            app.UseSwaggerUI(swaggerUiOptions =>
            {
                swaggerUiOptions.DocumentTitle = "Administrate Employee timesystem API";
                swaggerUiOptions.SwaggerEndpoint("/swagger/v1/swagger.json", name: "Api that gives you a possibility to administrate worked time for employees.");
                swaggerUiOptions.RoutePrefix = string.Empty;

            });

            app.UseHttpsRedirection();
            //******************************************************************************************
            app.MapGet("/get-all-employees", async () => await EmployeeRepository.GetEmployeeAsync())
                .WithTags("Employees Endpoint");
            //*****************************************************************************************
            app.MapGet(pattern: "/get-employee-by-id/{employeeId}", handler: async (int employeeId) =>
            {
                Employee employeeToReturn = await EmployeeRepository.GetEmployeeByIdAsync(employeeId);
                if (employeeToReturn != null)
                {
                    return Results.Ok(value: employeeToReturn);
                }
                else
                {
                    return Results.BadRequest();
                }
            }).WithTags("Employees Endpoint");
            //*********************************************************************************************
            app.MapPost(pattern: "/create-employee", handler: async (Employee employeeToCreate) =>
            {
                bool createSuccessful = await EmployeeRepository.CreateEmployeeAsync(employeeToCreate);
                if (createSuccessful)
                {
                    return Results.Ok(value: "Employee Createed successfully");
                }
                else
                {
                    return Results.BadRequest();
                }
            }).WithTags("Employees Endpoint");
            //*********************************************************************************************
            app.MapPut(pattern: "/update-employee", handler: async (Employee employeeToUpdate) =>
            {
                bool updateSuccessful = await EmployeeRepository.UpdateEmployeeAsync(employeeToUpdate);
                if (updateSuccessful)
                {
                    return Results.Ok(value: "Updating an employee was successful");
                }
                else
                {
                    return Results.BadRequest();
                }
            }).WithTags("Employees Endpoint");
            //*********************************************************************************************
            app.MapDelete(pattern: "/delete-employee-by-id/{employeeId}", handler: async (int employeeId) =>
            {
                bool deleteSuccessful = await EmployeeRepository.DeleteEmployeeAsync(employeeId);
                if (deleteSuccessful)
                {
                    return Results.Ok(value: "Deleting an employee was successful");
                }
                else
                {
                    return Results.BadRequest();
                }
            }).WithTags("Employees Endpoint");
            //*********************************************************************************************


            //******************************************************************************************
            app.MapGet("/get-all-projects", async () => await ProjectRepository.GetProjectAsync())
                .WithTags("Projects Endpoint");
            //*****************************************************************************************
            app.MapGet(pattern: "/get-project-by-id/{projectId}", handler: async (int projectId) =>
            {
                Project projectToReturn = await ProjectRepository.GetProjectByIdAsync(projectId);
                if (projectToReturn != null)
                {
                    return Results.Ok(value: projectToReturn);
                }
                else
                {
                    return Results.BadRequest();
                }
            }).WithTags("Projects Endpoint");
            //*********************************************************************************************
            app.MapPost(pattern: "/create-project", handler: async (Project projectToCreate) =>
            {
                bool createSuccessful = await ProjectRepository.CreateProjectAsync(projectToCreate);
                if (createSuccessful)
                {
                    return Results.Ok(value: "Project Created successfully");
                }
                else
                {
                    return Results.BadRequest();
                }
            }).WithTags("Projects Endpoint");
            //*********************************************************************************************
            app.MapPut(pattern: "/update-project", handler: async (Project projectToUpdate) =>
            {
                bool updateSuccessful = await ProjectRepository.UpdateProjectAsync(projectToUpdate);
                if (updateSuccessful)
                {
                    return Results.Ok(value: "Updated project successfully");
                }
                else
                {
                    return Results.BadRequest();
                }
            }).WithTags("Projects Endpoint");
            //*********************************************************************************************
            app.MapDelete(pattern: "/delete-project-by-id/{projectId}", handler: async (int projectId) =>
            {
                bool deleteSuccessful = await ProjectRepository.DeleteProjectAsync(projectId);
                if (deleteSuccessful)
                {
                    return Results.Ok(value: "Delete of project was successful");
                }
                else
                {
                    return Results.BadRequest();
                }
            }).WithTags("Projects Endpoint");
            //*********************************************************************************************
            //*********************************************************************************************


            //******************************************************************************************
            app.MapGet("/get-all-projectlists", async () => await ProjectListRepository.GetProjectListAsync())
                .WithTags("ProjectLists Endpoint");
            //*****************************************************************************************
            app.MapGet(pattern: "/get-projectlist-by-id/{projectListId}", handler: async (int projectListId) =>
            {
                ProjectList projectListToReturn = await ProjectListRepository.GetProjectListByIdAsync(projectListId);
                if (projectListToReturn != null)
                {
                    return Results.Ok(value: projectListToReturn);
                }
                else
                {
                    return Results.BadRequest();
                }
            }).WithTags("ProjectLists Endpoint");
            //*********************************************************************************************
            app.MapPost(pattern: "/create-projectList", handler: async (ProjectList projectListToCreate) =>
            {
                bool createSuccessful = await ProjectListRepository.CreateProjectListAsync(projectListToCreate);
                if (createSuccessful)
                {
                    return Results.Ok(value: "ProjectList Created successfully");
                }
                else
                {
                    return Results.BadRequest();
                }
            }).WithTags("ProjectLists Endpoint");
            //*********************************************************************************************
            app.MapPut(pattern: "/update-projectList", handler: async (ProjectList projectListToUpdate) =>
            {
                bool updateSuccessful = await ProjectListRepository.UpdateProjectListAsync(projectListToUpdate);
                if (updateSuccessful)
                {
                    return Results.Ok(value: "Updated projectList successfully");
                }
                else
                {
                    return Results.BadRequest();
                }
            }).WithTags("ProjectLists Endpoint");
            //*********************************************************************************************
            app.MapDelete(pattern: "/delete-projectList-by-id/{projectListId}", handler: async (int projectListId) =>
            {
                bool deleteSuccessful = await ProjectListRepository.DeleteProjectListAsync(projectListId);
                if (deleteSuccessful)
                {
                    return Results.Ok(value: "Delete of projectList was successful");
                }
                else
                {
                    return Results.BadRequest();
                }
            }).WithTags("ProjectLists Endpoint");
            //*********************************************************************************************
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.Run();
        }
    }
}