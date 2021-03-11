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
    public class ProdutoController : ControllerBase
    {
        private readonly IApplicationServiceProduto applicationServiceProduto;

        public ProdutoController(IApplicationServiceProduto applicationServiceProduto)
        {
            this.applicationServiceProduto = applicationServiceProduto;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> Get()
        {
            return Ok(await applicationServiceProduto.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<string>> Get(int id)
        {
            return Ok(await applicationServiceProduto.GetById(id));
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ProductDto produtoDto)
        {
            try
            {
                if (produtoDto == null)
                    return NotFound();

                await applicationServiceProduto.Add(produtoDto);
                return Ok("Produto Cadastrado com sucesso");
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] ProductDto produtoDto)
        {
            try
            {
                if (produtoDto == null)
                    return NotFound();

                await applicationServiceProduto.Update(produtoDto);
                return Ok("Produto atualizado com sucesso!");
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpDelete]
        public async Task<ActionResult> Delete([FromBody] ProductDto produtoDto)
        {
            try
            {
                if (produtoDto == null)
                    return NotFound();

                await applicationServiceProduto.Remove(produtoDto);
                return Ok("Produto removido com sucesso!");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
