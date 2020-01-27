using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Craft.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Craft.Services;
namespace Craft.Controllers
{
    public class ComponentController : Controller
    {
        //private readonly CraftMyPcContext _context;
        private IHardwareUnit _hardwareUnit;
        private IHardwareComponent _hardwareComponent;
        public ComponentController(/*CraftMyPcContext context,*/ IHardwareUnit hardwareUnit, IHardwareComponent hardwareComponent)
        {
            //_context = context;
            _hardwareUnit = hardwareUnit;
            _hardwareComponent = hardwareComponent;
        }

        public async Task<IActionResult> Component(string id)
        {
            var idComponent = await _hardwareComponent.GetHardwareComponentId(id);
            var model = await _hardwareUnit.GetHardwareUnitsByTypeAsync(idComponent);

            return View(model);
        }
        public async Task<IActionResult> DetailInformation(string id)
        {

            return View();
        }
    }
}