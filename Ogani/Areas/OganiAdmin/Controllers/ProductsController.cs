using Business.Modules.ColorsModule.Queries.ColorGetAllQuery;
using Business.Modules.ProductsModule.Commands.ProductAddCommand;
using Business.Modules.ProductsModule.Commands.ProductDeleteCommand;
using Business.Modules.ProductsModule.Commands.ProductEditCommand;
using Business.Modules.ProductsModule.Queries.ProductGetAllQuery;
using Business.Modules.ProductsModule.Queries.ProductGetQuery;
using Business.Modules.SizesModule.Queries.SizeGetAllQuery;
using Business.Modules.TagsModule.Queries.TagGetAllQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Ogani.Areas.OganiAdmin.Controllers
{
    [Area(nameof(OganiAdmin))]
    public class ProductsController(IMediator mediator) : Controller
    {
        private readonly IMediator _mediator = mediator;

        public async Task<IActionResult> Index(ProductGetAllRequest request)
        {
            var response = await _mediator.Send(request);
            return View(response);
        }
        public async Task<IActionResult> Details(ProductGetRequest request)
        {
            var response = await _mediator.Send(request);
            return View(response);
        }

        public async Task<IActionResult> Create()
        {
            var productColors = await _mediator.Send(new ColorGetAllRequest());
            ViewBag.BlogCategories = new SelectList(productColors, "Id", "Name");
            var productSizes = await _mediator.Send(new SizeGetAllRequest());
            ViewBag.TagList = new SelectList(productSizes, "Id", "Name");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductAddRequest request)
        {
            try
            {
                await _mediator.Send(request);
                return RedirectToAction(nameof(Index));
            }
            catch
            {

                return View();
            }

        }

        public async Task<IActionResult> Edit(ProductGetRequest request)
        {
            var response = await _mediator.Send(request);
            var productColors = await _mediator.Send(new ColorGetAllRequest());
            ViewBag.BlogCategories = new SelectList(productColors, "Id", "Name");
            var productSizes = await _mediator.Send(new SizeGetAllRequest());
            ViewBag.TagList = new SelectList(productSizes, "Id", "Name");
            return View(response);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProductEditRequest request)
        {
            try
            {
                await _mediator.Send(request);
                return RedirectToAction(nameof(Index));
            }
            catch
            {

                return View();
            }

        }

        [HttpPost]
        public async Task<IActionResult> Delete(ProductDeleteRequest request)
        {
            try
            {
                var response = await _mediator.Send(request);
                return PartialView("_PartialBlog", response);
            }
            catch
            {

                return View();
            }

        }
    }
}
