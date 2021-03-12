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
    public class ClientsController : Controller
    {
        private readonly IApplicationServiceClient applicationServiceClient;
        private readonly IMapperClient mapperClient;

        public ClientsController(IApplicationServiceClient applicationServiceClient, IMapperClient mapperClient)
        {
            this.applicationServiceClient = applicationServiceClient;
            this.mapperClient = mapperClient;
        }

        // GET: Clientes
        public async Task<IActionResult> Index()
        {
            var list = await applicationServiceClient.GetAll();
            return View(mapperClient.MapperListClient(list));
        }

        // GET: Clientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientDto = await applicationServiceClient.GetById((int)id);
            var client = mapperClient.MapperDTOToEntity(clientDto);
            if (client == null)
            {
                return NotFound();
            }

            return View(client);
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
        public async Task<IActionResult> Create([Bind("Name,LastName,Email,RegistrationDate,Active,Id")] Client client)
        {
            if (ModelState.IsValid)
            {
                await applicationServiceClient.Add(mapperClient.MapperEntityToDTO(client));
                return RedirectToAction(nameof(Index));
            }
            return View(client);
        }

        // GET: Clientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientDto = await applicationServiceClient.GetById((int)id);
            var client = mapperClient.MapperDTOToEntity(clientDto);
            if (client == null)
            {
                return NotFound();
            }
            return View(client);
        }

        // POST: Clientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,LastName,Email,RegistrationDate,Active,Id")] Client client)
        {
            if (id != client.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await applicationServiceClient.Update(mapperClient.MapperEntityToDTO(client));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (! await ClienteExists(client.Id))
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
            return View(client);
        }

        // GET: Clientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientDto = await applicationServiceClient.GetById((int)id);
            var client = mapperClient.MapperDTOToEntity(clientDto);
            if (client == null)
            {
                return NotFound();
            }

            return View(client);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var client = await applicationServiceClient.GetById(id);
            await applicationServiceClient.Remove(client);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> ClienteExists(int id)
        {
            var client = await applicationServiceClient.GetById(id);
            return client != null;
        }
    }
}
