﻿using LanchesMac.Areas.Admin.Services;
using Microsoft.AspNetCore.Mvc;

namespace LanchesMac.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminRelatorioVendasController : Controller
    {
        private readonly RelatorioVendasService _relatorioVendasService;

        public AdminRelatorioVendasController(RelatorioVendasService relatorioVendasService)
        {
            _relatorioVendasService = relatorioVendasService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> RelatorioVendaSimples(DateTime? minDate, DateTime? maxDate)
        {
            if(!minDate.HasValue)
            {
                minDate = new DateTime(DateTime.Now.Year,1,1);
            }
            if (!minDate.HasValue)
            {
                minDate = DateTime.Now;
            }

            ViewData["minDate"] = minDate.Value.ToString("yyyy-MM-dd");
            ViewData["maxDate"] = maxDate.Value.ToString("yyyy-MM-dd");

            var result = await _relatorioVendasService.FindByDateAsync(minDate, maxDate);

            return View(result);
        }
    }
}
