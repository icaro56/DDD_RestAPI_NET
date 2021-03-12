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
    public class ProdutosController : Controller
    {
        private readonly IApplicationServiceProduto applicationServiceProduto;
        private readonly IMapperProduto mapperProduto;

        public ProdutosController(IApplicationServiceProduto applicationServiceProduto, IMapperProduto mapperProduto)
        {
            this.applicationServiceProduto = applicationServiceProduto;
            this.mapperProduto = mapperProduto;
        }

        // GET: Produtos
        public async Task<IActionResult> Index()
        {
            var list = await applicationServiceProduto.GetAll();

            return View(mapperProduto.MapperListProdutos(list));
        }

        // GET: Produtos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produtoDto = await applicationServiceProduto.GetById((int)id);
            var produto = mapperProduto.MapperDtoToEntity(produtoDto);

            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        // GET: Produtos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Produtos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Price,Active,Id,Name")] Produto produto)
        {
            if (ModelState.IsValid)
            {
                await applicationServiceProduto.Add(mapperProduto.MapperEntityToDto(produto));
                
                return RedirectToAction(nameof(Index));
            }
            return View(produto);
        }

        // GET: Produtos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produtoDto = await applicationServiceProduto.GetById((int)id);
            var produto = mapperProduto.MapperDtoToEntity(produtoDto);
            if (produto == null)
            {
                return NotFound();
            }
            return View(produto);
        }

        // POST: Produtos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Price,Active,Id,Name")] Produto produto)
        {
            if (id != produto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await applicationServiceProduto.Update(mapperProduto.MapperEntityToDto(produto));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (! await ProdutoExists(produto.Id))
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
            return View(produto);
        }

        // GET: Produtos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produtoDto = await applicationServiceProduto.GetById((int)id);
            var produto = mapperProduto.MapperDtoToEntity(produtoDto);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        // POST: Produtos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var produtoDto = await applicationServiceProduto.GetById(id);
            await applicationServiceProduto.Remove(produtoDto);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> ProdutoExists(int id)
        {
            var produto = await applicationServiceProduto.GetById(id);

            return produto != null;
        }
    }
}
