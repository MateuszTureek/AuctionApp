using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuctionApp.Core.BLL.Service.Contract;
using AuctionApp.Core.DAL.Enum;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AuctionApp.Areas.customer.Controllers {
    [Area ("customer")]
    [Authorize (Roles = Role.customer)]
    public class SubcategoryController : Controller {
        readonly ICategoryService _categoryService;

        public SubcategoryController (ICategoryService categoryService) {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> SubcategoryByCatId (int? id) {
            if (id == null) return BadRequest ();
            var category = await _categoryService.GetCategoryAsync ((int) id);
            var subcategory = category.Subcategories.Select (s => new SelectListItem () { Value = s.Id + "", Text = s.Name }).ToList ();
            return Json (subcategory);
        }
    }
}