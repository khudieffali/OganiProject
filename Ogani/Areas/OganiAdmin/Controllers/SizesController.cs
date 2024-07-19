using Azure.Core;
using Azure;
using Business.Modules.SizesModule.Queries.SizeGetAllQuery;
using Business.Modules.SizesModule.Queries.SizeGetQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Business.Modules.SizesModule.Commands.SizeAddCommand;
using Business.Modules.SizesModule.Commands.SizeEditCommand;
using Business.Modules.SizesModule.Commands.SizeDeleteCommand;

namespace Ogani.Areas.OganiAdmin.Controllers
{
    [Area(nameof(OganiAdmin))]
    public class SizesController(IMediator mediator) : Controller
    {
        private readonly IMediator _mediator = mediator;

        public async Task<IActionResult> Index(SizeGetAllRequest request)
        {
            var response= await _mediator.Send(request);
            return View(response);
        }

        public async Task<IActionResult> Details(SizeGetRequest request)
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
        public async Task<IActionResult> Create(SizeAddRequest request)
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

        public async Task<IActionResult> Edit(SizeGetRequest request)
        {
            var response = await _mediator.Send(request);
            return View(response);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(SizeEditRequest request)
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
        public async Task<IActionResult> Delete(SizeDeleteRequest request)
        {
            try
            {
                var response=await _mediator.Send(request);
                return PartialView("_PartialSize",response);    
            }
            catch
            {
                return View();
            }

        }

    }
}
