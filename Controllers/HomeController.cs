using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BethaniPieShop.Models;
using BethaniPieShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BethaniPieShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPieRepository _pieRepository;

        public HomeController(IPieRepository pieRepository)
        {
            _pieRepository = pieRepository;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            var pies = _pieRepository.GetAllPies().OrderBy(t => t.Name);

            HomeViewModel viewModel = new HomeViewModel()
            {
                Title = "Welcome to Bethanie Pie's Shop!",
                Pies = pies.ToList()
            };
            return View(viewModel);
        }

        public IActionResult Details(int id)
        {
            var pie = _pieRepository.GetPieById(id);
            if (pie == null)
                return NotFound();
            else
                return View(pie);
        }
    }
}
