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

namespace TwiggStock.Controllers
{
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        public readonly IBaseResource<DepartmentsModel> _departmentService;
        public DepartmentsController (IBaseResource<DepartmentsModel> departmentService) {
            _departmentService = departmentService;
        }

        [HttpGet]
        [Route ("/api/v01/departments/")]
        public async Task<IActionResult> GetDepartments()
        {
            try
            {
                var departments = await _departmentService.GetResources();

                var response = ResponseTransformer.TransformResponse<List<DepartmentsModel>>(departments);
                return Ok (response);
            }
            catch (System.Exception ex)
            {
                throw new Exception("Error while getting departments! details: " + ex.Message);
            }
        }

        [HttpGet]
        [Route ("/api/v01/departments/{id}")]
        public async Task<IActionResult> GetUserByIDAsync(Guid id)
        {
            try
            {
                var departments = await _departmentService.GetResourcesById<Guid>(id);
                var response = ResponseTransformer.TransformResponse<DepartmentsModel>(departments);

                return Ok(response);
            }
            catch (System.Exception ex)
            {
                throw new Exception("Error while getting departments! Details: " + ex.Message);
            }
        }

        [HttpPost]
        [Route ("/api/v01/departments/create")]
        public async Task<IActionResult> CreateDepartments([FromBody] Department department)
        {
            try
            {
                DepartmentsModel departmentModel = new DepartmentsModel {
                    Uuid = Guid.NewGuid(),
                    Name = department.Name,
                    Slug_Name = department.Slug_Name,
                    Group_Email = department.Group_Email,
                    Remarks = department.Remarks,
                    IsActive = department.IsActive,
                };

                var request = await _departmentService.CreateResource(departmentModel);
                var resp = ResponseTransformer.TransformResponse<DepartmentsModel>(request);

                return Ok(resp);

            }
            catch (System.Exception ex)
            {
                throw new Exception("Error while adding new department! Details: " + ex.Message);
            }
        }

        [HttpPost]
        [Route ("/api/v01/departments/{id}/update")]
        public async Task<IActionResult> UpdateDepartmentAsync([FromBody] DepartmentsModel reqBody, Guid id)
        {
            DepartmentsModel department = new DepartmentsModel{};
            try
            {
                department = await _departmentService.GetResourcesById<Guid>(id);
            }
            catch (System.Exception)
            {
                throw new Exception("Department with id: " + id + " does not exist!");
            }

            var data = new {
                Name = reqBody.Name,
                Slug_Name = reqBody.Slug_Name,
                Remarks = reqBody.Remarks ?? department.Remarks,
                IsActive = reqBody.IsActive,
                Group_Email = reqBody.Group_Email ?? department.Group_Email
            };

            try
            {
                DepartmentsModel departmentModel = new DepartmentsModel {
                    Uuid = department.Uuid,
                    Name = data.Name,
                    Slug_Name = data.Slug_Name,
                    Group_Email = data.Group_Email,
                    Remarks = data.Remarks,
                    IsActive = data.IsActive,
                };

                var request = await _departmentService.UpdateResource(departmentModel);
                var resp = ResponseTransformer.TransformResponse<DepartmentsModel>(request);

                return Ok(resp);

            }
            catch (System.Exception ex)
            {
                throw new Exception("Error while updating department! Error Details: " + ex.Message);
            }
        }
    }
}
