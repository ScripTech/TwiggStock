using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Base;
using DataAccess;
using TwiggStock.DataAcess.Models;


namespace TwiggStock.DataAcess.Services
{
    public class DepartmentBugdetService : IBaseResource<DepartmentBugdetModel>
    {
        public async Task<List<DepartmentBugdetModel>> GetResources()
        {
            string query = @"SELECT * FROM budget inner join departments on budget.department_id = departments.uuid WHERE budget.deleted_on is null";
            var response = await SQLDataAccessContext.QueryData<DepartmentBugdetModel, dynamic>(query, new { });

            foreach (DepartmentBugdetModel budget in response.ToList())
            {
                string queryDep = @"SELECT * FROM departments WHERE uuid = @department_id";
                var departments = await SQLDataAccessContext.QueryData<DepartmentsModel, dynamic>(queryDep, new { department_id = budget.Department_id});
                budget.department = departments.FirstOrDefault();
            }
            return response.ToList();
        }

        public async Task<DepartmentBugdetModel> GetResourcesById<U>(U id)
        {
            string query = @"SELECT * FROM budget inner join departments on budget.department_id = departments.uuid WHERE budget.id = @id and budget.deleted_on is null";
            var response = await SQLDataAccessContext.QueryData<DepartmentBugdetModel, dynamic>(query, new { id = id});

            foreach (DepartmentBugdetModel budget in response.ToList())
            {
                string queryDep = @"SELECT * FROM departments WHERE uuid = @department_id";
                var departments = await SQLDataAccessContext.QueryData<DepartmentsModel, dynamic>(queryDep, new { department_id = budget.Department_id});
                budget.department = departments.FirstOrDefault();
            }

            return response.First();
        }

        public async Task<DepartmentBugdetModel> CreateResource(DepartmentBugdetModel resource)
        {
            string query = @"INSERT INTO budget (department_id, budget_value, budget_used, budget_year, author_id, created_on, updated_on)
                VALUES (@department_id, @budget_value, @budget_used, @budget_year, @author_id, GETDATE(), GETDATE())";

            await SQLDataAccessContext.StoreData<DepartmentBugdetModel>(query, resource);

            string getResource = @"SELECT * FROM budget inner join departments on budget.department_id = departments.uuid WHERE budget.id = @id and budget.deleted_on is null";
            var response = await SQLDataAccessContext.QueryData<DepartmentBugdetModel, dynamic>(getResource, new { id = resource.Id });
            return response.FirstOrDefault();
        }

        public async Task DeleteResource(DepartmentBugdetModel resource)
        {
             string query = @"UPDATE budget SET deleted_on = GETDATE() where id = @id";
            await SQLDataAccessContext.StoreData<DepartmentBugdetModel>(query, resource);
        }

        public async Task DeleteResourcePermanently(DepartmentBugdetModel resource)
        {
            string query = @"DELETE budget where id = @id";
            await SQLDataAccessContext.StoreData<DepartmentBugdetModel>(query, resource);
        }

        public async Task<List<DepartmentBugdetModel>> ListDeletedResources()
        {
            string query = @"SELECT * from budget where deleted_on is not null";
            var response = await SQLDataAccessContext.QueryData<DepartmentBugdetModel, dynamic>(query, new { });
            return response.ToList();
        }

        public async Task RestoreResource(DepartmentBugdetModel resource)
        {
            string query = @"UPDATE budget SET deleted_on = NULL WHERE id = @id";
            await SQLDataAccessContext.StoreData<int>(query, resource.Id);
        }

        public Task<DepartmentBugdetModel> UpdateResource(DepartmentBugdetModel resource)
        {
            throw new NotImplementedException("Updadte budget not yet implemented. Thiis actions is not allowed. @Edilson Mucanze");
        }
    }
}
