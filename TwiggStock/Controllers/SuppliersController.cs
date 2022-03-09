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
    public class SuppliersController : ControllerBase
    {
        public readonly IBaseResource<SuppliersModel> _suppliersService;
        public SuppliersController (IBaseResource<SuppliersModel> suppliersService) {
            _suppliersService = suppliersService;
        }

        [HttpGet]
        [Route ("/api/v01/suppliers/")]
        public async Task<IActionResult> GetSuppliers()
        {
            try
            {
                var suppliers = await _suppliersService.GetResources();

                var response = ResponseTransformer.TransformResponse<List<SuppliersModel>>(suppliers);
                return Ok (response);
            }
            catch (System.Exception ex)
            {
                throw new Exception("Error while getting Suppliers! Error details: " + ex.Message);
            }
        }

        [HttpGet]
        [Route ("/api/v01/suppliers/{id}")]
        public async Task<IActionResult> GetSuppliersByIDAsync(Guid id)
        {
            try
            {
                var departments = await _suppliersService.GetResourcesById<Guid>(id);
                var response = ResponseTransformer.TransformResponse<SuppliersModel>(departments);

                return Ok(response);
            }
            catch (System.Exception ex)
            {
                throw new Exception("Error while getting suppliers! Error details: " + ex.Message);
            }
        }

        [HttpPost]
        [Route ("/api/v01/suppliers/create")]
        public async Task<IActionResult> CreateSuppliers([FromBody] Suppliers supplier)
        {
            try
            {
                SuppliersModel suppliersModel = new SuppliersModel {
                    Uuid = Guid.NewGuid(),
                    Name = supplier.Name,
                    Nuit = supplier.Nuit,
                    Country = supplier.Country,
                    City = supplier.City,
                    Address = supplier.Address,
                    Cell_Number = supplier.Cell_Number,
                    Email_Address = supplier.Email_Address,
                    Remarks = supplier.Remarks,
                };

                var request = await _suppliersService.CreateResource(suppliersModel);
                var resp = ResponseTransformer.TransformResponse<SuppliersModel>(request);

                return Ok(resp);

            }
            catch (System.Exception ex)
            {
                throw new Exception("Error while adding new suppliers! Error details: " + ex.Message);
            }
        }

        [HttpPost]
        [Route ("/api/v01/suppliers/{id}/update")]
        public async Task<IActionResult> UpdateDepartmentAsync([FromBody] SuppliersModel reqBody, Guid id)
        {
            SuppliersModel supplier = new SuppliersModel{};
            try
            {
                supplier = await _suppliersService.GetResourcesById<Guid>(id);
            }
            catch (System.Exception)
            {
                throw new Exception("Department with id: " + id + " does not exist!");
            }

            try
            {
                SuppliersModel supplierModel = new SuppliersModel {
                    Uuid = supplier.Uuid,
                    Name = reqBody.Name,
                    Nuit = reqBody.Nuit,
                    Country = reqBody.Country,
                    City = reqBody.City,
                    Address = reqBody.Address,
                    Cell_Number = reqBody.Cell_Number,
                    Email_Address = reqBody.Email_Address,
                    Remarks = reqBody.Remarks,
                };

                var request = await _suppliersService.UpdateResource(supplierModel);
                var resp = ResponseTransformer.TransformResponse<SuppliersModel>(request);

                return Ok(resp);
            }
            catch (System.Exception ex)
            {
                throw new Exception("Error while updating supplier with id: " + id + ".\nError Details: " + ex.Message);
            }
        }
    }
}
