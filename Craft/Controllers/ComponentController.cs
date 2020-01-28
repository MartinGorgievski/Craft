using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Craft.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Craft.Services;
using Craft.ViewModels;
using Craft.Models;
namespace Craft.Controllers
{
    public class ComponentController : Controller
    {
        private IHardwareUnit _hardwareUnit;
        private IHardwareComponent _hardwareComponent;
        private ICategoryFilter _categoryFilter;
        private ComponenViewModel viewComponent;
        private readonly CraftMyPcContext _context;

        public ComponentController(CraftMyPcContext context, IHardwareUnit hardwareUnit, 
                                   IHardwareComponent hardwareComponent,
                                   ICategoryFilter categoryFilter)
        {
            _context = context;
            _hardwareUnit = hardwareUnit;
            _hardwareComponent = hardwareComponent;
            _categoryFilter = categoryFilter;
        }

        public async Task<IActionResult> Component(string id /*int? pageid*/)
        {

            int idComponent = await _hardwareComponent.GetHardwareComponentId(id);
            viewComponent = new ComponenViewModel();
            viewComponent.HardwareUnits = await _hardwareUnit.GetHardwareUnitsByTypeAsync(idComponent);
            viewComponent.FilterCategories = await _categoryFilter.getFilterCategoriesForHardwareComponent(idComponent);

            ViewData["ComponentId"] = idComponent;
            ViewData["ComponentTitle"] = id;
            //viewComponent.HardwareUnits = await PaginatedList<viewComponent.HardwareUnits>
            //.CreateAsync(_context.AsNoTracking(), pageid ?? 1, pageSizeid ?? 25)
            return View(viewComponent);
        }

        [HttpGet]
        public async Task<IActionResult> FilterComponents(List<int> FilterAttrChecked)
        {
            List<HardwareUnit> HardwareUnits = new List<HardwareUnit>();
            
            var filteredList = await _context.HardwareUnitSpecification
                                             .Include(s => s.HardwareUnit)
                                             .Include(s => s.ComponentSpecification)
                                             .ToListAsync();
            if (FilterAttrChecked.Count == 0)
            {
                return PartialView(filteredList.Distinct());
            }
            foreach (var item in FilterAttrChecked)
            {
               HardwareUnits.AddRange(filteredList.Where(s => s.FilterComponentId == item).Select(s => s.HardwareUnit).ToList());
            }
            
            return PartialView(HardwareUnits.Distinct());
        }

        public async Task<IActionResult> DetailInformation(string id)
        {
            DetailProduct product = new DetailProduct();

            product.HardwareUnit = await _context.HardwareUnits.Where(s => s.UrlName.ToLower().Trim() == id.ToLower().Trim())
                                .Include(s => s.HardwareUnitSpecifications)
                                .ThenInclude(s => s.ComponentSpecification)
                                .ThenInclude(s => s.ComponentSpecificationCategory).FirstOrDefaultAsync();

            product.ComponentSpecificationCategory = _context.ComponentSpecificationCategories
                                .Include(s => s.ComponentSpecification)
                                .ThenInclude(s => s.HardwareUnitSpecifications)
                                .ThenInclude(s => s.HardwareUnit).ToList();

            return View(product);
        }
    }
}