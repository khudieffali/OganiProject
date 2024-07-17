using Business.Modules.TagsModule.Commands.TagAddCommand;
using Business.Modules.TagsModule.Commands.TagDeleteCommand;
using Business.Modules.TagsModule.Commands.TagEditCommand;
using Business.Modules.TagsModule.Queries.TagGetAllQuery;
using Business.Modules.TagsModule.Queries.TagGetQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ogani.Areas.OganiAdmin.Controllers
{
    [Area(nameof(OganiAdmin))]
    public class TagsController(IMediator mediator) : Controller
    {
        private readonly IMediator _mediator = mediator;

        public async Task<IActionResult> Index(TagGetAllRequest request)
        {
            var response=await _mediator.Send(request);
            return View(response);
        }
        public async Task<IActionResult> Details(TagGetRequest request)
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
        public async Task<IActionResult> Create(TagAddRequest request)
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
        public async Task<IActionResult> Edit(TagGetRequest request)
        {
            var response=await _mediator.Send(request);
            return View(response);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(TagEditRequest request)
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

        public async Task<IActionResult> Delete(TagDeleteRequest request)
        {
            try
            {
                var response=await _mediator.Send(request);
                return PartialView("_PartialTag", response);
            }
            catch
            {

                return View();
            }
        }
    }
}
