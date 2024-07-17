using Business.Modules.OrganicsModule.Commands.OrgaincAddCommand;
using Business.Modules.OrganicsModule.Commands.OrganicDeleteCommand;
using Business.Modules.OrganicsModule.Commands.OrganicEditCommand;
using Business.Modules.OrganicsModule.Queries.OrganicGetAllQuery;
using Business.Modules.OrganicsModule.Queries.OrganicGetQuery;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ogani.Areas.OganiAdmin.Controllers
{
    [Area(nameof(OganiAdmin))]
    public class OrganicController(IMediator mediator) : Controller
    {
        private readonly IMediator _mediator = mediator;

        // GET: OrganicController
        public async Task<IActionResult> Index(OrganicGetAllRequest request)
        {
            var response=await _mediator.Send(request);
            return View(response);
        }

        public async Task<IActionResult> Details(OrganicGetRequest request)
        {
            var response= await _mediator.Send(request);
            return View(response);
        }

        // GET: OrganicController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: IOrganicController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(OrganicAddRequest request)
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

        // GET: OrganicController/Edit/5
        public async Task<IActionResult> Edit(OrganicGetRequest request)
        {
            var response=await _mediator.Send(request);
            return View(response);
        }

        // POST: OrganicController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(OrganicEditRequest request)
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

        // POST: OrganicController/Delete/5
        [HttpPost]
        public async Task<IActionResult> Delete(OrganicDeleteRequest request)
        {
            try
            {
                var response=await _mediator.Send(request);
                return PartialView("_PartialOrganic",response);
            }
            catch
            {
                return View();
            }
        }
    }
}
