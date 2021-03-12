using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RestAPIModeloDDD.Application.Interfaces;
using RestAPIModeloDDD.Domain.Entities;
using RestAPIModeloDDD.Infraestructure.Data;

namespace WebApplicationModeloDDD.Controllers
{
    public class ClientesController : Controller
    {
        private readonly IApplicationServiceCliente applicationServiceCliente;
        private readonly IMapperCliente mapperCliente;

        public ClientesController(IApplicationServiceCliente applicationServiceCliente, IMapperCliente mapperCliente)
        {
            this.applicationServiceCliente = applicationServiceCliente;
            this.mapperCliente = mapperCliente;
        }

        // GET: Clientes
        public async Task<IActionResult> Index()
        {
            var list = await applicationServiceCliente.GetAll();
            return View(mapperCliente.MapperListCliente(list));
        }

        // GET: Clientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clienteDto = await applicationServiceCliente.GetById((int)id);
            var cliente = mapperCliente.MapperDtoToEntity(clienteDto);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // GET: Clientes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Clientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Sobrenome,Email,DataCadastro,Ativo,Id,Name")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                await applicationServiceCliente.Add(mapperCliente.MapperEntityToDto(cliente));
                return RedirectToAction(nameof(Index));
            }
            return View(cliente);
        }

        // GET: Clientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clienteDto = await applicationServiceCliente.GetById((int)id);
            var cliente = mapperCliente.MapperDtoToEntity(clienteDto);
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }

        // POST: Clientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Sobrenome,Email,DataCadastro,Ativo,Id,Name")] Cliente cliente)
        {
            if (id != cliente.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await applicationServiceCliente.Update(mapperCliente.MapperEntityToDto(cliente));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (! await ClienteExists(cliente.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(cliente);
        }

        // GET: Clientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clienteDto = await applicationServiceCliente.GetById((int)id);
            var cliente = mapperCliente.MapperDtoToEntity(clienteDto);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cliente = await applicationServiceCliente.GetById(id);
            await applicationServiceCliente.Remove(cliente);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> ClienteExists(int id)
        {
            var cliente = await applicationServiceCliente.GetById(id);
            return cliente != null;
        }
    }
}
