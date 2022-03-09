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
    public class SuppliersService : IBaseResource<SuppliersModel>
    {
        public async Task<List<SuppliersModel>> GetResources()
        {
            try
            {
                string query = @"SELECT * FROM suppliers WHERE deleted_on is null";
                var response = await SQLDataAccessContext.QueryData<SuppliersModel, dynamic>(query, new { });

                return response.ToList();
            }
            catch (System.Exception ex)
            {
               throw new Exception("SQL error: " + ex.Message);
            }
        }

        public async Task<SuppliersModel> GetResourcesById<U>(U id)
        {
            try
            {
                string query = @"SELECT * FROM suppliers WHERE uuid = @uuid and deleted_on is null";
                var response = await SQLDataAccessContext.QueryData<SuppliersModel, dynamic>(query, new { uuid = id});

                return response.First();
            }
            catch (System.Exception ex)
            {
                throw new Exception("SQL error: " + ex.Message);
            }
        }

        public async Task<SuppliersModel> CreateResource(SuppliersModel supplier)
        {
            try
            {
                string query = @"INSERT INTO suppliers (uuid, name, nuit, country, city, address, cell_number, email_address, remarks, is_active,  created_on, updated_on)
                VALUES (@uuid, @name, @nuit, @country, @city, @address, @cell_number, @email_address, @remarks, 1, GETDATE(), GETDATE())";

                await SQLDataAccessContext.StoreData<SuppliersModel>(query, supplier);

                string getResource = @"SELECT * FROM suppliers WHERE uuid = @uuid";
                var response = await SQLDataAccessContext.QueryData<SuppliersModel, dynamic>(getResource, new { uuid = supplier.Uuid });

                return response.FirstOrDefault();
            }
            catch (System.Exception ex)
            {
                throw new Exception("SQL error: " + ex.Message);
            }
        }

        public async Task DeleteResource(SuppliersModel supplier)
        {
            string query = @"UPDATE suppliers SET deleted_on = GETDATE() where uuid = @uuid";
            await SQLDataAccessContext.StoreData<dynamic>(query, new { uuid = supplier.Uuid});
        }

        public async Task DeleteResourcePermanently(SuppliersModel supplier)
        {
            string query = @"DELETE suppliers where uuid = @uuid";
            await SQLDataAccessContext.StoreData<dynamic>(query, new {uuid = supplier.Uuid});
        }

        public async Task<List<SuppliersModel>> ListDeletedResources()
        {
            try
            {
                string query = @"SELECT * from suppliers where deleted_on is not null";
                var response = await SQLDataAccessContext.QueryData<SuppliersModel, dynamic>(query, new { });

                return response.ToList();
            }
            catch (System.Exception ex)
            {
                throw new Exception("SQL error: " + ex.Message);
            }
        }

        public async Task RestoreResource(SuppliersModel supplier)
        {
            try
            {
                string query = @"UPDATE suppliers SET deleted_on = NULL WHERE uuid = @uuid";
                await SQLDataAccessContext.StoreData<dynamic>(query, new { uuid = supplier.Uuid});
            }
            catch (System.Exception ex)
            {
                throw new Exception("SQL error: " + ex.Message);
            }
        }

        public async Task<SuppliersModel> UpdateResource(SuppliersModel supplier)
        {
            try
            {
                string query = @"UPDATE suppliers SET name = @name, nuit = @nuit, country = @country, city = @city, address = @address, cell_number = @cell_number, email_address = @email_address, remarks = @remarks, updated_on = GETDATE() WHERE uuid = @uuid";
                await SQLDataAccessContext.StoreData<dynamic>(query, new {
                    uuid = supplier.Uuid,
                    name = supplier.Name,
                    nuit = supplier.Nuit,
                    country = supplier.Country,
                    city = supplier.City,
                    address = supplier.Address,
                    cell_number = supplier.Cell_Number,
                    email_address = supplier.Email_Address,
                    remarks = supplier.Remarks,
                });

                string getQuery = @"select * from suppliers where uuid = @uuid";
                var response = await SQLDataAccessContext.QueryData<SuppliersModel, dynamic>(
                        getQuery, new {uuid = supplier.Uuid}
                    );
                return response.FirstOrDefault();
            }
            catch (System.Exception ex)
            {
                throw new Exception("SQL error: " + ex.Message);
            }
        }
    }
}
