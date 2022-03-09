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
    public class StockInService : IBaseResource<StockInModel>
    {
        public async Task<List<StockInModel>> GetResources()
        {
            string query = @"SELECT * FROM stocks WHERE deleted_on is null";
            var response = await SQLDataAccessContext.QueryData<StockInModel, dynamic>(query, new { });

            return response.ToList();
        }

        public async Task<StockInModel> GetResourcesById<U>(U id)
        {
            string query = @"SELECT * FROM stocks WHERE uuid = @uuid and deleted_on is null";
            var response = await SQLDataAccessContext.QueryData<StockInModel, dynamic>(query, new { uuid = id});

            return response.First();
        }

        public async Task<StockInModel> CreateResource(StockInModel stockItem)
        {
            string query = @"INSERT INTO stocks (uuid, description, quantity, value, item_model, spent_category, spent_date, supplier_id, author_id, created_on, updated_on)
                VALUES (@uuid, @description, @quantity, @value, @item_model, @spent_category, @spent_date, @supplier_id, @author_id, GETDATE(), GETDATE())";

            await SQLDataAccessContext.StoreData<StockInModel>(query, stockItem);

            string getResource = @"SELECT * FROM stocks WHERE uuid = @login";
            var response = await SQLDataAccessContext.QueryData<StockInModel, dynamic>(getResource, new { stockItem.Uuid });
            return response.FirstOrDefault();
        }

        public async Task DeleteResource(StockInModel stockItem)
        {
            string query = @"UPDATE users SET deleted_on = GETDATE() where uuid = @uuid";
            await SQLDataAccessContext.StoreData<dynamic>(query, new {uuid = stockItem.Uuid});
        }

        public async Task DeleteResourcePermanently(StockInModel stockItem)
        {
            string query = @"DELETE stocks where uuid = @uuid";
            await SQLDataAccessContext.StoreData<dynamic>(query, new { uuid = stockItem.Uuid});
        }

        public async Task<List<StockInModel>> ListDeletedResources()
        {
            string query = @"SELECT * from stocks where deleted_on is not null";
            var response = await SQLDataAccessContext.QueryData<StockInModel, dynamic>(query, new { });
            return response.ToList();
        }

        public async Task RestoreResource(StockInModel stockItem)
        {
            string query = @"UPDATE stocks SET deleted_on = NULL WHERE uuid = @uuid";
            await SQLDataAccessContext.StoreData<dynamic>(query, new { uuid = stockItem.Uuid });
        }

        public async Task<StockInModel> UpdateResource(StockInModel resource)
        {
            throw new NotImplementedException("You can not update a stock information, delete and created new entrie.");
        }
    }
}
