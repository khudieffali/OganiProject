using Azure.Core;
using Business.Modules.BlogCategoryModule.Queries.BlogCategoryGetAllQuery;
using Business.Modules.BlogsModule.Commands.BlogAddCommand;
using Business.Modules.BlogsModule.Commands.BlogDeleteCommand;
using Business.Modules.BlogsModule.Commands.BlogEditCommand;
using Business.Modules.BlogsModule.Queries.BlogGetAllQuery;
using Business.Modules.BlogsModule.Queries.BlogGetQuery;
using Business.Modules.TagsModule.Queries.TagGetAllQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Ogani.Areas.OganiAdmin.Controllers
{
    [Area(nameof(OganiAdmin))]
    public class BlogsController(IMediator mediator) : Controller
    {
        private readonly IMediator _mediator = mediator;

        public async Task<IActionResult> Index(BlogGetAllRequest request)
        {
            var response = await _mediator.Send(request);
            return View(response);
        }
        public async Task<IActionResult> Details(BlogGetRequest request)
        {
            var response = await _mediator.Send(request);
            return View(response);
        }

        public async Task<IActionResult> Create()
        {
            var blogCategories = await _mediator.Send(new BlogCategoryGetAllRequest());
            ViewBag.BlogCategories = new SelectList(blogCategories, "Id", "Name");
            var tags = await _mediator.Send(new TagGetAllRequest());
            ViewBag.TagList = new SelectList(tags, "Id", "Name");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BlogAddRequest request)
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

        public async Task<IActionResult> Edit(BlogGetRequest request)
        {
            var response = await _mediator.Send(request);
            var blogCategories = await _mediator.Send(new BlogCategoryGetAllRequest());
            ViewBag.BlogCategories = new SelectList(blogCategories, "Id", "Name");
            var tags = await _mediator.Send(new TagGetAllRequest());
            ViewBag.TagList = new SelectList(tags, "Id", "Name");
            return View(response);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(BlogEditRequest request)
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
        public async Task<IActionResult> Delete(BlogDeleteRequest request)
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
