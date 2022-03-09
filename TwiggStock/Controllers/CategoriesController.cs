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
    public class CategoriesController : ControllerBase
    {
        public readonly IBaseResource<CategoriesModel> _categoriesService;
        public CategoriesController (IBaseResource<CategoriesModel> categoriesService) {
            _categoriesService = categoriesService;
        }

        [HttpGet]
        [Route ("/api/v01/categories/")]
        public async Task<IActionResult> GetCategories()
        {
            try
            {
                var categories = await _categoriesService.GetResources();

                var response = ResponseTransformer.TransformResponse<List<CategoriesModel>>(categories);
                return Ok (response);
            }
            catch (System.Exception ex)
            {
                throw new Exception("Error while getting categories! details: " + ex.Message);
            }
        }

        [HttpGet]
        [Route ("/api/v01/categories/{id}")]
        public async Task<IActionResult> GetCategoriesByIdAsync(Guid id)
        {
            try
            {
                var categories = await _categoriesService.GetResourcesById<Guid>(id);
                var response = ResponseTransformer.TransformResponse<CategoriesModel>(categories);

                return Ok(response);
            }
            catch (System.Exception ex)
            {
                throw new Exception("Error while getting categories with id: "+id+"\n Details: " + ex.Message);
            }
        }

        [HttpPost]
        [Route ("/api/v01/categories/create")]
        public async Task<IActionResult> CreateItemCategorie([FromBody] CategoriesModel categorie)
        {
            try
            {
                CategoriesModel categorieModel = new CategoriesModel {
                    Uuid = Guid.NewGuid(),
                    Description = categorie.Description,
                    Supplier_Id = categorie.Supplier_Id,
                    Author_id = categorie.Author_id
                };

                var request = await _categoriesService.CreateResource(categorieModel);
                var resp = ResponseTransformer.TransformResponse<CategoriesModel>(request);

                return Ok(resp);

            }
            catch (System.Exception ex)
            {
                throw new Exception("Error while adding new categorie! Details: " + ex.Message);
            }
        }

    }
}
