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
    public class StockInController : ControllerBase
    {
        public readonly IBaseResource<StockInModel> _stockinService;
        public StockInController (IBaseResource<StockInModel> stockinService) {
            _stockinService = stockinService;
        }

        [HttpGet]
        [Route ("/api/v01/stock")]
        public async Task<IActionResult> GetStocksIn()
        {
            try
            {
                var categories = await _stockinService.GetResources();

                var response = ResponseTransformer.TransformResponse<List<StockInModel>>(categories);
                return Ok (response);
            }
            catch (System.Exception ex)
            {
                throw new Exception("Error while getting stock information! details: " + ex.Message);
            }
        }

        [HttpGet]
        [Route ("/api/v01/stocks/{id}")]
        public async Task<IActionResult> GetStockInByIdAsync(Guid id)
        {
            try
            {
                var stock = await _stockinService.GetResourcesById<Guid>(id);
                var response = ResponseTransformer.TransformResponse<StockInModel>(stock);

                return Ok(response);
            }
            catch (System.Exception ex)
            {
                throw new Exception("Error while getting stock-in with id: "+id+"\n Details: " + ex.Message);
            }
        }

        [HttpPost]
        [Route ("/api/v01/stocks/item/add")]
        public async Task<IActionResult> AddStockIn([FromBody] ItemStocks stockitem)
        {
            try
            {
                StockInModel stockModel = new StockInModel {
                    Uuid = Guid.NewGuid(),
                    Description = stockitem.Description,
                    Item_Model = stockitem.Item_Model,
                    Quantity = stockitem.Quantity,
                    Supplier_Id = stockitem.Supplier_Id,
                    Value = stockitem.Value,
                    Spent_category = stockitem.spent_category,
                    Spent_date = stockitem.spent_date,
                    Author_id = stockitem.Author_id,
                    Categorie_Id = stockitem.Categorie_Id
                };

                var request = await _stockinService.CreateResource(stockModel);
                var resp = ResponseTransformer.TransformResponse<StockInModel>(request);

                return Ok(resp);

            }
            catch (System.Exception ex)
            {
                throw new Exception("Error while adding stock! Error Details: " + ex.Message);
            }
        }

    }
}
