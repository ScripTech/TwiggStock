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
    public class DepartmentBugdetController : ControllerBase
    {
        public readonly IBaseResource<DepartmentBugdetModel> _budgetService;
        public DepartmentBugdetController (IBaseResource<DepartmentBugdetModel> budgetService) {
            _budgetService = budgetService;
        }

        [HttpGet]
        [Route ("/api/v01/budgets/")]
        public async Task<IActionResult> GetUsers () {
            try
            {
                var budgetModel = await _budgetService.GetResources();
                var response = ResponseTransformer.TransformResponse<List<DepartmentBugdetModel>>(budgetModel);
                return Ok (response);
            }
            catch (System.Exception ex)
            {
                throw new Exception("Error while getting users", ex);
            }
        }

        /// List User By ID
        [HttpGet]
        [Route ("/api/v01/budgets/{id}")]
        public async Task<IActionResult> GetUserByIDAsync (int id) {
            try
            {
                var budgetModel = await _budgetService.GetResourcesById<int>(id);
                var response = ResponseTransformer.TransformResponse<DepartmentBugdetModel>(budgetModel);
                return Ok (response);
            }
            catch (System.Exception ex)
            {
                throw new Exception("budgets not found Error: " + ex);
            }
        }

        [HttpPost]
        [Route ("/api/v01/budgets/add")]
        public async Task<IActionResult> CreateItemCategorie([FromBody] DepartmentBugdet requestBody)
        {
            try
            {
                DepartmentBugdetModel budgetModel = new DepartmentBugdetModel {
                    Department_id = requestBody.Department_id,
                    Budget_used = 0,
                    Budget_value = requestBody.Budget_value,
                    Budget_year = requestBody.Budget_year,
                    Author_id = requestBody.Author_id
                };

                var request = await _budgetService.CreateResource(budgetModel);
                var resp = ResponseTransformer.TransformResponse<DepartmentBugdetModel>(request);

                return Ok(resp);

            }
            catch (System.Exception ex)
            {
                throw new Exception("Error while adding new categorie! Details: " + ex.Message);
            }
        }
    }
}
