using Microsoft.AspNetCore.Mvc;
using RestAPIModeloDDD.Application.Dtos;
using RestAPIModeloDDD.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestAPIModeloDDD.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IApplicationServiceProduct applicationServiceProduct;

        public ProductController(IApplicationServiceProduct applicationServiceProduct)
        {
            this.applicationServiceProduct = applicationServiceProduct;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> Get()
        {
            return Ok(await applicationServiceProduct.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<string>> Get(int id)
        {
            return Ok(await applicationServiceProduct.GetById(id));
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ProductDto productDto)
        {
            try
            {
                if (productDto == null)
                    return NotFound();

                await applicationServiceProduct.Add(productDto);
                return Ok("Produto Cadastrado com sucesso");
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] ProductDto productDto)
        {
            try
            {
                if (productDto == null)
                    return NotFound();

                await applicationServiceProduct.Update(productDto);
                return Ok("Produto atualizado com sucesso!");
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpDelete]
        public async Task<ActionResult> Delete([FromBody] ProductDto productDto)
        {
            try
            {
                if (productDto == null)
                    return NotFound();

                await applicationServiceProduct.Remove(productDto);
                return Ok("Produto removido com sucesso!");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
