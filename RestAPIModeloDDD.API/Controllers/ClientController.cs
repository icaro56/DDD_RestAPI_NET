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
    public class ClientController : ControllerBase
    {
        private readonly IApplicationServiceClient applicationServiceClient;

        public ClientController(IApplicationServiceClient applicationServiceClient)
        {
            this.applicationServiceClient = applicationServiceClient;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> Get()
        {
            return Ok(await applicationServiceClient.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<string>> Get(int id)
        {
            return Ok(await applicationServiceClient.GetById(id));
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ClientDTO clientDto)
        {
            try
            {
                if (clientDto == null)
                    return NotFound();

                await applicationServiceClient.Add(clientDto);
                return Ok("Cliente Cadastrado com sucesso");
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] ClientDTO clientDto)
        {
            try
            {
                if (clientDto == null)
                    return NotFound();

                await applicationServiceClient .Update(clientDto);
                return Ok("Cliente atualizado com sucesso!");
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpDelete]
        public async Task<ActionResult> Delete([FromBody] ClientDTO clientDto)
        {
            try
            {
                if (clientDto == null)
                    return NotFound();

                await applicationServiceClient.Remove(clientDto);
                return Ok("Cliente removido com sucesso!");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
