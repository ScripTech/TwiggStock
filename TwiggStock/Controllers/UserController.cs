using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TwiggStock.DataAcess.Models;
using TwiggStock.Models;
using TwiggStock.Transformers;
using TwiggStock.utils;

namespace TwiggStock.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        public readonly IBaseResource<UserModel> _userService;
        public UserController (IBaseResource<UserModel> userService) {
            _userService = userService;
        }

        [HttpGet]
        [Route ("/api/v01/users/")]
        public async Task<IActionResult> GetUsers () {
            try
            {
                var userModel = await _userService.GetResources();
                var response = ResponseTransformer.TransformResponse<List<UserModel>>(userModel);
                return Ok (response);
            }
            catch (System.Exception ex)
            {
                throw new Exception("Error while getting users", ex);
            }
        }

        /// List User By ID
        [HttpGet]
        [Route ("/api/v01/users/{userId}")]
        public async Task<IActionResult> GetUserByIDAsync (Guid userId) {
            try
            {
                var userModel = await _userService.GetResourcesById<Guid>(userId);
                var response = ResponseTransformer.TransformResponse<UserModel>(userModel);
                return Ok (response);
            }
            catch (System.Exception)
            {
                throw new Exception("User not found");
            }
        }

        [HttpPost]
        [Route ("/api/v01/users/register")]
        public async Task<IActionResult> UserRegisterAsync ([FromBody] User requestBody) {

           byte[] salt = ApplicationUtils.GenerateHashSalt();
           string saltaString = Convert.ToBase64String(salt);

           string hashedPassword = ApplicationUtils.HashPassword(requestBody.Password, salt);

            UserModel user = new UserModel {
                Uuid = Guid.NewGuid(),
                Firstname = requestBody.Firstname,
                Lastname = requestBody.Lastname,
                Login = requestBody.Login,
                Password = hashedPassword,
                Salt = saltaString,
                Mail_notification = requestBody.Mail_notification,
                Created_on = requestBody.Created_on,
                Updated_on = requestBody.Updated_on,
                Deleted_on = requestBody.Deleted_on
            };

            var request = await _userService.CreateResource(user);

            var response = ResponseTransformer.TransformResponse<UserModel>(user);
            return Ok (response);
        }

        [HttpPost]
        [Route ("/api/v01/users/{userId}/update")]
        public async Task<IActionResult> UserUpdateAsync ([FromBody] UserModel requestBody, Guid userId) {

            UserModel usersModel = new UserModel{};
            try
            {
                usersModel = await _userService.GetResourcesById<Guid>(userId);
            }
            catch (System.Exception)
            {
                throw new Exception("User not found");
            }

            try
            {
                 UserModel user = new UserModel {
                    Uuid = usersModel.Uuid,
                    Firstname = requestBody.Firstname,
                    Lastname = requestBody.Lastname,
                    Mail_notification = requestBody.Mail_notification,
                };

                var serverResponse = await _userService.UpdateResource(user);

                var response = ResponseTransformer.TransformResponse<UserModel>(serverResponse);
                return Ok (response);
            }
            catch (System.Exception ex)
            {
                throw new Exception("Error while registering user! \n" + ex.Message);
            }
        }

    }
}
