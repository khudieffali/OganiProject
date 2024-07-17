using Azure.Core;
using Azure;
using Business.Modules.BlogCategoryModule.Commands.BlogCategoryAddCommand;
using Business.Modules.BlogCategoryModule.Queries.BlogCategoryGetAllQuery;
using Business.Modules.BlogCategoryModule.Queries.BlogCategoryGetQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Business.Modules.BlogCategoryModule.Commands.BlogCategoryEditCommand;
using Business.Modules.BlogCategoryModule.Commands.BlogCategoryDeleteCommand;

namespace Ogani.Areas.OganiAdmin.Controllers
{
    [Area(nameof(OganiAdmin))]
	public class BlogCategoriesController(IMediator mediator) : Controller
	{
		private readonly IMediator _mediator = mediator;

		public async Task<IActionResult> Index(BlogCategoryGetAllRequest request)
		{
			var response=await _mediator.Send(request);
			return View(response);
		}

        public async Task<IActionResult> Details(BlogCategoryGetRequest request)
        {
            var response = await _mediator.Send(request);
            return View(response);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
		[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BlogCategoryAddRequest request)
        {
			try
			{
                var response = await _mediator.Send(request);
                return RedirectToAction(nameof(Index));
            }
			catch 
			{

				return View();
			}
           
        }
        public async Task<IActionResult> Edit(BlogCategoryGetRequest request)
        {
            var response= await _mediator.Send(request);
            return View(response);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(BlogCategoryEditRequest request)
        {
            try
            {
                var response = await _mediator.Send(request);
                return RedirectToAction(nameof(Index));
            }
            catch
            {

                return View();
            }

        }

        [HttpPost]
        public async Task<IActionResult> Delete(BlogCategoryDeleteRequest request)
        {
            try
            {
                var response = await _mediator.Send(request);
                return PartialView("_PartialBlogCategory", response);
            }
            catch
            {

                return View();
            }

        }
    }
}
