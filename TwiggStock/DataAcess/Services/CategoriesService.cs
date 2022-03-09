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
    public class CategoriesService : IBaseResource<CategoriesModel>
    {
        public async Task<List<CategoriesModel>> GetResources()
        {
            string query = @"SELECT * FROM categories WHERE deleted_on is null";
            var response = await SQLDataAccessContext.QueryData<CategoriesModel, dynamic>(query, new { });

            return response.ToList();
        }

        public async Task<CategoriesModel> GetResourcesById<U>(U id)
        {
            string query = @"SELECT * FROM categories inner join suppliers on suppliers.uuid = categories.uuid WHERE uuid = @uuid and deleted_on is null limit 1";
            var response = await SQLDataAccessContext.QueryData<CategoriesModel, dynamic>(query, new { uuid = id});

            return response.First();
        }

        public async Task<CategoriesModel> CreateResource(CategoriesModel categorie)
        {
            string query = @"INSERT INTO categories (uuid, description, supplier_id, author_id, created_on, updated_on)
                VALUES (@uuid, @description, @supplier_id, @author_id, GETDATE(), GETDATE())";

            await SQLDataAccessContext.StoreData<CategoriesModel>(query, categorie);

            string getResource = @"SELECT * FROM categories inner join suppliers on suppliers.uuid = categories.uuid WHERE categories.uuid = @uuid and categories.deleted_on is null";
            var response = await SQLDataAccessContext.QueryData<CategoriesModel, dynamic>(getResource, new { uuid = categorie.Uuid });
            return response.FirstOrDefault();
        }

        public async Task DeleteResource(CategoriesModel categorie)
        {
            string query = @"UPDATE users SET deleted_on = GETDATE() where uuid = @uuid";
            await SQLDataAccessContext.StoreData<CategoriesModel>(query, categorie);
        }

        public async Task DeleteResourcePermanently(CategoriesModel categorie)
        {
            string query = @"DELETE categories where uuid = @uuid";
            await SQLDataAccessContext.StoreData<CategoriesModel>(query, categorie);
        }

        public async Task<List<CategoriesModel>> ListDeletedResources()
        {
            string query = @"SELECT * from categories where deleted_on is not null";
            var response = await SQLDataAccessContext.QueryData<CategoriesModel, dynamic>(query, new { });
            return response.ToList();
        }

        public async Task RestoreResource(CategoriesModel categorie)
        {
            string query = @"UPDATE categories SET deleted_on = NULL WHERE uuid = @uuid";
            await SQLDataAccessContext.StoreData<Guid>(query, categorie.Uuid);
        }

        public Task<CategoriesModel> UpdateResource(CategoriesModel resource)
        {
            throw new NotImplementedException();
        }
    }
}
