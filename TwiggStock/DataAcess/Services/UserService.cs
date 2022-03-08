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
    #pragma warning disable 0436
    public class UserService : IBaseResource<UserModel>
    {
        public async Task<List<UserModel>> GetResources()
        {
            string query = @"SELECT * FROM users WHERE deleted_on is null";
            var response = await SQLDataAccessContext.QueryData<UserModel, dynamic>(query, new { });

            return response.ToList();
        }

        /// Get Resource by ID
        public async Task<UserModel> GetResourcesById<U>(U userId)
        {
            string query = @"SELECT * FROM users WHERE uuid = @uuid and deleted_on is null";
            var response = await SQLDataAccessContext.QueryData<UserModel, dynamic>(query, new { uuid = userId});

            return response.First();
        }

        public async Task<UserModel> CreateResource(UserModel user)
        {
            string query = @"INSERT INTO users (uuid, firstname, lastname, login, password, mail_notification, salt, created_on, updated_on)
                VALUES (@uuid, @firstname, @lastname, @login, @password, @mail_notification, @salt, GETDATE(), GETDATE())";

            await SQLDataAccessContext.StoreData<UserModel>(query, user);

            string getResource = @"SELECT * FROM users WHERE login = @login";
            var response = await SQLDataAccessContext.QueryData<UserModel, dynamic>(getResource, new { user.Login });
            return response.FirstOrDefault();
        }

        public async Task DeleteResource(UserModel user)
        {
            string query = @"UPDATE users SET deleted_on = GETDATE() where id = @id";
            await SQLDataAccessContext.StoreData<int>(query, user.Id);
        }

        public async Task DeleteResourcePermanently(UserModel user)
        {
            string query = @"DELETE users where id = @id";
            await SQLDataAccessContext.StoreData<int>(query, user.Id);
        }

        public async Task<List<UserModel>> ListDeletedResources()
        {
            string query = @"SELECT * from users where deleted_on is not null";
            var response = await SQLDataAccessContext.QueryData<UserModel, dynamic>(query, new { });
            return response.ToList();
        }

        public async Task RestoreResource(UserModel user)
        {
            string query = @"UPDATE users SET deleted_on = NULL WHERE id = @id";
            await SQLDataAccessContext.StoreData<int>(query, user.Id);
        }

        public async Task<UserModel> UpdateResource(UserModel user)
        {
            string query = @"UPDATE users SET firstname = @firstname, lastname = @lastname, mail_notification = @mail_notification, updated_on = GETDATE() WHERE uuid = @uuid";
            await SQLDataAccessContext.StoreData<dynamic>(query, new{
                uuid = user.Uuid,
                firstname = user.Firstname,
                lastname = user.Lastname,
                mail_notification = user.Mail_notification
            });

            string getUserQuery = @"select * from users where uuid = @uuid";
            var response = await SQLDataAccessContext.QueryData<UserModel, dynamic>(getUserQuery, new {uuid = user.Uuid});
            return response.FirstOrDefault();
        }

    }
}
