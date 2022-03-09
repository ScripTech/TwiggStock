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
    public class DepartmentsService : IBaseResource<DepartmentsModel>
    {
        public async Task<List<DepartmentsModel>> GetResources()
        {
            string query = @"SELECT * FROM departments WHERE deleted_on is null";
            var response = await SQLDataAccessContext.QueryData<DepartmentsModel, dynamic>(query, new { });

            return response.ToList();
        }
        public async Task<DepartmentsModel> GetResourcesById<U>(U id)
        {
            string query = @"SELECT * FROM departments WHERE uuid = @uuid and deleted_on is null";
            var response = await SQLDataAccessContext.QueryData<DepartmentsModel, dynamic>(query, new { uuid = id});

            return response.First();
        }
        public async Task<DepartmentsModel> CreateResource(DepartmentsModel department)
        {
            string query = @"INSERT INTO departments (uuid, name, slug_name, group_email, remarks, is_active, created_on, updated_on)
                VALUES (@uuid, @name, @slug_name, @group_email, @remarks, 1, GETDATE(), GETDATE())";

            await SQLDataAccessContext.StoreData<DepartmentsModel>(query, department);

            string getResource = @"SELECT * FROM departments WHERE uuid = @uuid";
            var response = await SQLDataAccessContext.QueryData<DepartmentsModel, dynamic>(getResource, new { uuid = department.Uuid });
            return response.FirstOrDefault();
        }

        public async Task DeleteResource(DepartmentsModel department)
        {
            string query = @"UPDATE departments SET deleted_on = GETDATE() where uuid = @uuid";
            await SQLDataAccessContext.StoreData<dynamic>(query, new { uuid = department.Uuid});
        }

        public async Task DeleteResourcePermanently(DepartmentsModel department)
        {
            string query = @"DELETE departments where uuid = @uuid";
            await SQLDataAccessContext.StoreData<dynamic>(query, new {uuid = department.Uuid});
        }

        public async Task<List<DepartmentsModel>> ListDeletedResources()
        {
            try
            {
                string query = @"SELECT * from departments where deleted_on is not null";
                var response = await SQLDataAccessContext.QueryData<DepartmentsModel, dynamic>(query, new { });

                return response.ToList();
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public async Task RestoreResource(DepartmentsModel department)
        {
            try
            {
                string query = @"UPDATE departments SET deleted_on = NULL WHERE uuid = @uuid";
                await SQLDataAccessContext.StoreData<dynamic>(query, new { uuid = department.Uuid});
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<DepartmentsModel> UpdateResource(DepartmentsModel department)
        {
            string query = @"UPDATE departments SET name = @name, slug_name = @slug_name, group_email = @group_email, remarks = @remarks, is_active = @is_active,updated_on = GETDATE() WHERE uuid = @uuid";
            await SQLDataAccessContext.StoreData<dynamic>(query, new{
                uuid = department.Uuid,
                name = department.Name,
                slug_name = department.Slug_Name,
                group_email = department.Group_Email,
                remarks = department.Remarks,
                is_active = department.IsActive
            });

            string getUserQuery = @"SELECT * from departments where uuid = @uuid";
            var response = await SQLDataAccessContext.QueryData<DepartmentsModel, dynamic>(getUserQuery, new {uuid = department.Uuid});
            return response.FirstOrDefault();
        }
    }
}
