using Business.Modules.CategoriesModule.Commands.CategoryAddCommand;
using Business.Modules.CategoriesModule.Commands.CategoryDeleteCommand;
using Business.Modules.CategoriesModule.Commands.CategoryEditCommand;
using Business.Modules.CategoriesModule.Queries.CategoryGetAllQuery;
using Business.Modules.CategoriesModule.Queries.CategoryGetQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Ogani.Areas.OganiAdmin.Controllers
{
	[Area(nameof(OganiAdmin))]
	public class CategoriesController(IMediator mediator) : Controller
	{
		private readonly IMediator _mediator = mediator;

		public async Task<IActionResult> Index(CategoryGetAllRequest request)
		{
			var response = await _mediator.Send(request);
			return View(response);
		}
        public async Task<IActionResult> Details(CategoryGetRequest request)
        {
          
            var response=await _mediator.Send(request);
            return View(response);
        }

        public async Task<IActionResult> Create()
		{
            var categories = await _mediator.Send(new CategoryGetAllRequest());
            ViewBag.Categories = new SelectList(categories, "Id", "Name");
            return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CategoryAddRequest request)
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

        public async Task<IActionResult> Edit(CategoryGetRequest request)
        {
            var categories = await _mediator.Send(new CategoryGetAllRequest());
            ViewBag.Categories = new SelectList(categories, "Id", "Name");
            var response = await _mediator.Send(request);
            return View(response);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CategoryEditRequest request)
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
        public async Task<IActionResult> Delete(CategoryDeleteRequest request)
        {
            try
            {
                var response=await _mediator.Send(request);
                return PartialView("_PartialCategory",response);
            }
            catch
            {

                return View();
            }
        }
    }
}
