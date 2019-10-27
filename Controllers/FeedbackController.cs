using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BethaniPieShop.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BethaniPieShop.Controllers
{
    [Authorize]
    public class FeedbackController : Controller
    {

        public readonly IFeedbackRepository _feedbackRepository;
        // GET: /<controller>/
        public FeedbackController(IFeedbackRepository feedbackRepository)
        {
            _feedbackRepository = feedbackRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Feedback feedback)
        {
            if (ModelState.IsValid)
            {
                _feedbackRepository.AddFeeback(feedback);
                return RedirectToAction("FeedbackComplete");
            }
            else
            {
                return View(feedback);
            }
            
        }

        public IActionResult FeedbackComplete()
        {
            return View();
        }
    }
}
