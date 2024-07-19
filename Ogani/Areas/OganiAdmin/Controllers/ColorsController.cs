using Business.Modules.ColorsModule.Commands.ColorAddCommand;
using Business.Modules.ColorsModule.Commands.ColorDeleteCommand;
using Business.Modules.ColorsModule.Commands.ColorEditCommand;
using Business.Modules.ColorsModule.Queries.ColorGetAllQuery;
using Business.Modules.ColorsModule.Queries.ColorGetQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ogani.Areas.OganiAdmin.Controllers
{
    [Area(nameof(OganiAdmin))]
    public class ColorsController(IMediator mediator) : Controller
    {
        private readonly IMediator _mediator = mediator;

        public async Task<IActionResult> Index(ColorGetAllRequest request)
        {
            var response =await _mediator.Send(request);
            return View(response);
        }

        public async Task<IActionResult> Details(ColorGetRequest request)
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
		public async Task<IActionResult> Create(ColorAddRequest request)
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
		public async Task<IActionResult> Edit(ColorGetRequest request)
		{
            var response = await _mediator.Send(request);
			return View(response);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(ColorEditRequest request)
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
		public async Task<IActionResult> Delete(ColorDeleteRequest request)
		{
			try
			{
				var response=await _mediator.Send(request);
				return PartialView("_PartialColor",response);
			}
			catch
			{
				return View();
			}

		}

	}
}
