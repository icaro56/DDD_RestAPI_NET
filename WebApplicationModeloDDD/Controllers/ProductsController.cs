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
    public class ProductsController : Controller
    {
        private readonly IApplicationServiceProduct applicationServiceProduct;
        private readonly IMapperProduct mapperProduct;

        public ProductsController(IApplicationServiceProduct applicationServiceProduct, IMapperProduct mapperProduct)
        {
            this.applicationServiceProduct = applicationServiceProduct;
            this.mapperProduct = mapperProduct;
        }

        // GET: Produtos
        public async Task<IActionResult> Index()
        {
            var list = await applicationServiceProduct.GetAll();

            return View(mapperProduct.MapperListProducts(list));
        }

        // GET: Produtos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produtoDto = await applicationServiceProduct.GetById((int)id);
            var produto = mapperProduct.MapperDTOToEntity(produtoDto);

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
        public async Task<IActionResult> Create([Bind("Name,Price,Active,Id")] Product product)
        {
            if (ModelState.IsValid)
            {
                //await applicationServiceProduto.Add(mapperProduto.MapperEntityToDto(produto));

                await applicationServiceProduct.AddProduct(product);

                if (product.Notifications.Any())
                {
                    foreach (var item in product.Notifications)
                    {
                        ModelState.AddModelError(item.PropertyName, item.Message);
                    }

                    return View(product);
                }

                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Produtos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produtoDto = await applicationServiceProduct.GetById((int)id);
            var produto = mapperProduct.MapperDTOToEntity(produtoDto);
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
        public async Task<IActionResult> Edit(int id, [Bind("Name,Price,Active,Id")] Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //await applicationServiceProduto.Update(mapperProduto.MapperEntityToDto(produto));

                    await applicationServiceProduct.UpdateProduct(product);

                    if (product.Notifications.Any())
                    {
                        foreach (var item in product.Notifications)
                        {
                            ModelState.AddModelError(item.PropertyName, item.Message);
                        }

                        return View(product);
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (! await ProdutoExists(product.Id))
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
            return View(product);
        }

        // GET: Produtos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productDto = await applicationServiceProduct.GetById((int)id);
            var product = mapperProduct.MapperDTOToEntity(productDto);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Produtos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productDto = await applicationServiceProduct.GetById(id);
            await applicationServiceProduct.Remove(productDto);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> ProdutoExists(int id)
        {
            var product = await applicationServiceProduct.GetById(id);

            return product != null;
        }
    }
}
